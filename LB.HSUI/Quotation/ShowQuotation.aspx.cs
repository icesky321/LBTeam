using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Quotation_ShowQuotation : System.Web.UI.Page
{
    LB.BLL.TSManage bll_ts = new LB.BLL.TSManage();
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.BLL.QuotationManage bll_quote = new LB.BLL.QuotationManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string mobile = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(mobile);
        hfUserId.Value = user.UserId.ToString();

        var regions = bll_region.GetRegions(hfCityCode.Value);
        rptRegion.DataSource = regions;
        rptRegion.DataBind();
    }

    protected void rptRegion_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Repeater rptTS = e.Item.FindControl("rptTS") as Repeater;
            var tses = bll_ts.GetTSInfo();
            rptTS.DataSource = tses;
            rptTS.DataBind();
        }

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptTS2 = e.Item.FindControl("rptTS2") as Repeater;
            var tses = bll_ts.GetTSInfo();
            rptTS2.DataSource = tses;
            rptTS2.DataBind();
        }
    }

    protected void rptTS2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int userId = 0;
        int.TryParse(hfUserId.Value, out userId);

        Repeater rptTS2 = sender as Repeater;
        HiddenField hfCountyCode = rptTS2.Parent.FindControl("hfCountyCode") as HiddenField;

        LB.SQLServerDAL.TSInfo tsInfo = e.Item.DataItem as LB.SQLServerDAL.TSInfo;
        string tsCode = tsInfo.TsCode;

        LB.SQLServerDAL.Quotation quotation = bll_quote.GetLastQuotedPrice(userId, tsCode, hfCountyCode.Value);

        Literal ltlPrice = e.Item.FindControl("ltlPrice") as Literal;
        if (quotation == null)
            ltlPrice.Text = "";
        else
            ltlPrice.Text = quotation.QuotedPrice.ToString();
    }
}