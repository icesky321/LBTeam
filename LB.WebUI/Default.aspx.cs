using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


public partial class _Default : System.Web.UI.Page
{
    LB.BLL.NewsInfo bll_newsinfo = new LB.BLL.NewsInfo();
    LB.BLL.Tradeleads bll_tradeleads = new LB.BLL.Tradeleads();
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    LB.SQLServerDAL.NewsInfo Mn = new LB.SQLServerDAL.NewsInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            gvNewsDatabind();
            gvPBNewsDatabind();
            gvPriceNewsDatabind();
            gvLawNewsDatabind();
            gvBuyInfoDatabind();
            gvSellInfoDatabind();
            DLCopInfoDataBind();
            lbNotice.Text = ConfigurationManager.AppSettings["Notice"];
            //lbNotice.Text = bll_newsinfo.GetNewsInfoById(1).Content;

        }
    }

    void gvNewsDatabind()
    {
        gvNews.DataSource = bll_newsinfo.GetNewsInfoByTypeTop13(1);
        gvNews.DataBind();

    }

    void gvPBNewsDatabind()
    {
        gvPBNew.DataSource = bll_newsinfo.GetNewsInfoByTypeTop13(2);
        gvPBNew.DataBind();

    }

    void gvPriceNewsDatabind()
    {
        gvPrice.DataSource = bll_newsinfo.GetNewsInfoByTypeTop13(3);
        gvPrice.DataBind();

    }

    void gvBuyInfoDatabind()
    {
        gvBuyInfo.DataSource = bll_tradeleads.GetTradeleadsByTradeType(1, true);
        gvBuyInfo.DataBind();

    }

    void gvSellInfoDatabind()
    {
        gvSellInfo.DataSource = bll_tradeleads.GetTradeleadsByTradeType(2,true);
        gvSellInfo.DataBind();

    }

    void gvLawNewsDatabind()
    {
        gvLaw.DataSource = bll_newsinfo.GetNewsInfoByTypeTop13(4);
        gvLaw.DataBind();

    }

    protected void gvNews_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string Id = e.CommandArgument.ToString();
            string url = "~/NewsDetail.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
        if (e.CommandName == "AllNews")
        {
            string Id = "1";
            string url = "~/News.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
    }
    protected void gvPBNew_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string Id = e.CommandArgument.ToString();
            string url = "~/NewsDetail.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
        if (e.CommandName == "AllNews")
        {
            string Id = "2";
            string url = "~/News.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
    }
    protected void gvPrice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string Id = e.CommandArgument.ToString();
            string url = "~/NewsDetail.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
        if (e.CommandName == "AllNews")
        {
            string Id = "3";
            string url = "~/News.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
    }

    protected void gvLaw_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string Id = e.CommandArgument.ToString();
            string url = "~/NewsDetail.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
        if (e.CommandName == "AllNews")
        {
            string Id = "4";
            string url = "~/News.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
    }

    protected void gvSellInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string infoId = e.CommandArgument.ToString();
            string url = "~/TradeleadsDetail.aspx?infoId=" + infoId.ToString();
            Response.Redirect(url);
        }
        if (e.CommandName == "AllSell")
        {
            string url = "~/AllSellInfo.aspx";
            Response.Redirect(url);
        }
    }

    protected void gvBuyInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string infoId = e.CommandArgument.ToString();
            string url = "~/TradeleadsDetail.aspx?infoId=" + infoId.ToString();
            Response.Redirect(url);
        }
        if (e.CommandName == "AllBuy")
        {
            string url = "~/AllBuyInfo.aspx";
            Response.Redirect(url);
        }
    }

    void DLCopInfoDataBind()
    {
        //DLCopInfo.DataSource = bll_copinfo.GetCopInfo();
        //DLCopInfo.DataBind();
    }

    protected void DLCopInfo_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName == "Detail")
        {
            string CopId = e.CommandArgument.ToString();
            string url = "~/CopDetail.aspx?CopId=" + CopId;
            Response.Redirect(url);
        }
    }
}