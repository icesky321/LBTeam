using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AllBuyInfo : System.Web.UI.Page
{
    LB.BLL.Tradeleads bll_tradeleads = new LB.BLL.Tradeleads();
    LB.SQLServerDAL.Tradeleads MTradeleads = new LB.SQLServerDAL.Tradeleads();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvBuyInfo.DataSource = bll_tradeleads.GetTradeleadsByTradeType(1);
            gvBuyInfo.DataBind();
        }
    }

    void gvBuyInfoDataBind()
    {
        gvBuyInfo.DataSource = bll_tradeleads.GetTradeleadsByAddressAndType(DDLAddress1.province, DDLAddress1.city, DDLAddress1.country, DDLAddress1.street, 1);


        gvBuyInfo.DataBind();
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        GridViewRow gridViewRow = gvBuyInfo.BottomPagerRow;
        TextBox numBox = (TextBox)gvBuyInfo.BottomPagerRow.FindControl("txtNewPageIndex");
        int inputNum = Convert.ToInt32(numBox.Text);
        gvBuyInfo.PageIndex = inputNum - 1;
        gvBuyInfoDataBind();
    }
    protected void gvBuyInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBuyInfo.PageIndex = e.NewPageIndex;
        gvBuyInfoDataBind();
    }
    protected void gvBuyInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string infoId = e.CommandArgument.ToString();
            string url = "~/TradeleadsDetail.aspx?infoId=" + infoId.ToString();
            Response.Redirect(url);
        }
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        gvBuyInfoDataBind();
    }
}