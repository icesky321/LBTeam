using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News : System.Web.UI.Page
{
    LB.BLL.NewsInfo bll_newsinfo = new LB.BLL.NewsInfo();
    LB.SQLServerDAL.NewsInfo MNewsInfo = new LB.SQLServerDAL.NewsInfo();
    LB.BLL.NewsType bll_newstype = new LB.BLL.NewsType();
    LB.SQLServerDAL.NewsType MNewsType = new LB.SQLServerDAL.NewsType();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                MNewsType = bll_newstype.GetNewTypeById(Id);
                //lbNewsType.Text = MNewsType.NewsType1.ToString();
                gvNewsDataBind(Convert.ToInt32(MNewsType.NewsTypeId));
            }
        }
    }

    void gvNewsDataBind(int TypeId)
    {
        gvNew.DataSource = bll_newsinfo.GetNewsInfoByType(TypeId);
        gvNew.DataBind();
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        GridViewRow gridViewRow = gvNew.BottomPagerRow;
        TextBox numBox = (TextBox)gvNew.BottomPagerRow.FindControl("txtNewPageIndex");
        int inputNum = Convert.ToInt32(numBox.Text);
        gvNew.PageIndex = inputNum - 1;
        gvNewsDataBind(Convert.ToInt32(Request.QueryString["Id"]));
    }
    protected void gvNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNew.PageIndex = e.NewPageIndex;
        gvNewsDataBind(Convert.ToInt32(Request.QueryString["Id"]));
    }
    protected void gvNew_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string Id = e.CommandArgument.ToString();
            string url = "~/NewsDetail.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
    }
}