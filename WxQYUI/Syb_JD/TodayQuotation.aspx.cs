using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_Dyywy_TodayQuotation : System.Web.UI.Page
{
    LB.BLL.TSInfo bll_ts = new LB.BLL.TSInfo();
    LB.BLL.QuotationManage bll_quote = new LB.BLL.QuotationManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTodayQuotation();
        }
    }


    protected void LoadTodayQuotation()
    {
        var query = bll_quote.GetQuotation("宁波", DateTime.Now.Date);
        Repeater1.DataSource = query;
        Repeater1.DataBind();
    }


    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LB.SQLServerDAL.TSInfo ts = e.Item.DataItem as LB.SQLServerDAL.TSInfo;
            LB.SQLServerDAL.Quotation quotation = bll_quote.GetLastQuotation(1162, ts.TSId);
            //Literal ltlPrice = Repeater2.Items[e.Item.ItemIndex].FindControl("ltlPrice") as Literal;
            Literal ltlPrice = e.Item.FindControl("ltlPrice") as Literal;
            Literal ltlDate = e.Item.FindControl("ltlDate") as Literal;
            if (quotation != null)
            {
                ltlPrice.Text = quotation.QuotedPrice.ToString() + "&nbsp;元/吨";
                ltlDate.Text = quotation.OfferDate.ToShortDateString();
            }
            else
            {
                ltlPrice.Text = "---";
                ltlDate.Text = "";
            }
        }
    }
}