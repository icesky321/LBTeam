using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewsManage : System.Web.UI.Page
{
    LB.BLL.NewsInfo bll_newsinfo = new LB.BLL.NewsInfo();
    LB.SQLServerDAL.NewsInfo MNewsInfo = new LB.SQLServerDAL.NewsInfo();
    LB.SQLServerDAL.NewsType MNewTYpe = new LB.SQLServerDAL.NewsType();
    LB.BLL.NewsType bll_newtype = new LB.BLL.NewsType();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillNewsType();
            gvNewsDataBind();
        }
    }

    void FillNewsType()
    {
        IQueryable<LB.SQLServerDAL.NewsType> newstypes = bll_newtype.GetNewsType();
        foreach (LB.SQLServerDAL.NewsType NewType in newstypes)
        {
            ddlNewsType.Items.Add(new ListItem(NewType.NewsType1, NewType.NewsTypeId.ToString()));
        }
        ddlNewsType.Items.Insert(0, "");
    }


    void gvNewsDataBind()
    {
        gvNewsInfo.DataSource = bll_newsinfo.GetNewsInfo();
        gvNewsInfo.DataBind();

        foreach (GridViewRow gvRow in gvNewsInfo.Rows)
        {
            string Id = gvRow.Cells[0].Text;
            if (bll_newsinfo.GetNewsInfoById(Convert.ToInt32(Id)).IsShow == false)
            {
                //((LinkButton)(gvRow.Cells[11].FindControl("lbCancel"))).Visible = false;
                ((MultiView)(gvRow.Cells[3].FindControl("MultiView1"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[3].FindControl("MultiView1"))).ActiveViewIndex = 1;
            }
        }

    }
    protected void gvNewsInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ////如果是绑定数据行 //清清月儿http://blog.csdn.net/21aspnet 
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        //}
        //if (e.Row.RowIndex != -1)
        //{
        //    int id = e.Row.RowIndex + 1;
        //    e.Row.Cells[0].Text = id.ToString();
        //}
    }
    protected void gvNewsInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string Id = e.CommandArgument.ToString();
            string url = "~/NewsDetail.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
        if (e.CommandName == "Show")
        {
            string Id = e.CommandArgument.ToString();
            MNewsInfo = bll_newsinfo.GetNewsInfoById(Convert.ToInt32(Id));
            MNewsInfo.IsShow = true;
            MNewsInfo.ShowTime = System.DateTime.Now;
            bll_newsinfo.UpdateNewsInfo(MNewsInfo);
            gvNewsDataBind();
        }
        if (e.CommandName == "UnShow")
        {
            string Id = e.CommandArgument.ToString();
            MNewsInfo = bll_newsinfo.GetNewsInfoById(Convert.ToInt32(Id));
            MNewsInfo.IsShow = false;
            MNewsInfo.ShowTime = System.DateTime.Now;
            bll_newsinfo.UpdateNewsInfo(MNewsInfo);
            gvNewsDataBind();
        }

    }
    protected void gvNewsInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = gvNewsInfo.DataKeys[e.RowIndex].Values["id"].ToString();
        bll_newsinfo.DeleteNewsInfo(Convert.ToInt32(Id));
        gvNewsInfo.EditIndex = -1;
        gvNewsDataBind();
    }
    protected void btSearch_Click(object sender, EventArgs e)
    {
        if (ddlNewsType.SelectedItem.Text != "")
        {
            gvNewsInfo.DataSource = bll_newsinfo.GetNewsInfoByType(Convert.ToInt32(ddlNewsType.SelectedItem.Value));
            gvNewsInfo.DataBind();
        }
        else
        {
            gvNewsDataBind();
        }
        
    }
}