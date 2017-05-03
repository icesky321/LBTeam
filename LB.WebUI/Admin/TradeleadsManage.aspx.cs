using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TradeleadsManage : System.Web.UI.Page
{
    LB.BLL.Tradeleads bll_tradeleads = new LB.BLL.Tradeleads();
    LB.SQLServerDAL.Tradeleads MTradeleads = new LB.SQLServerDAL.Tradeleads();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvTradeleadsInfoDataBind();
        }
    }

    void gvTradeleadsInfoDataBind()
    {
        gvTradeleadsInfo.DataSource = bll_tradeleads.GetTradeleads();
        gvTradeleadsInfo.DataBind();

        foreach (GridViewRow gvRow in gvTradeleadsInfo.Rows)
        {
            string Id = gvRow.Cells[0].Text;
            if (bll_tradeleads.GetTradeleadsByinfoId(Convert.ToInt32(Id)).Audit == false)
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

    protected void gvTradeleadsInfo_RowCommand(object sender, GridViewCommandEventArgs e)
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
            MTradeleads=bll_tradeleads.GetTradeleadsByinfoId(Convert.ToInt32(Id));
            MTradeleads.Audit = true;
            MTradeleads.AuditDatetime = System.DateTime.Now;
            bll_tradeleads.UpdateTradeleads(MTradeleads);
            gvTradeleadsInfoDataBind();
        }
        if (e.CommandName == "UnShow")
        {
            string Id = e.CommandArgument.ToString();
            MTradeleads = bll_tradeleads.GetTradeleadsByinfoId(Convert.ToInt32(Id));
            MTradeleads.Audit = false;
            MTradeleads.AuditDatetime = System.DateTime.Now;
            bll_tradeleads.UpdateTradeleads(MTradeleads);
            gvTradeleadsInfoDataBind();
        }

    }
    protected void gvTradeleadsInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = gvTradeleadsInfo.DataKeys[e.RowIndex].Values["infoId"].ToString();
        bll_tradeleads.DeleteTradeleads(Convert.ToInt32(Id));
        gvTradeleadsInfo.EditIndex = -1;
        gvTradeleadsInfoDataBind();
    }
}