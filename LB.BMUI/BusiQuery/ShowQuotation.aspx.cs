using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BusiQuery_ShowQuotation : System.Web.UI.Page
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
        Load_HS();
        if (!User.Identity.IsAuthenticated)
            return;

        string mobile = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(mobile);
        hfUserId.Value = user.UserId.ToString();

        var tses = bll_ts.GetTSInfo();
        rptTS.DataSource = tses;
        rptTS.DataBind();


    }

    private void Load_HS()
    {
        var HSes = bll_user.GetUserInfoByUserTypeId(2);
        ddlHS.Items.Clear();
        foreach (LB.SQLServerDAL.UserInfo user in HSes)
        {
            ListItem item = new ListItem(user.RealName, user.UserId.ToString());
            ddlHS.Items.Add(item);
        }

    }

    protected void rptTS_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Repeater rptRegion = e.Item.FindControl("rptRegion") as Repeater;
            var regions = bll_region.GetRegions(hfCityCode.Value);
            rptRegion.DataSource = regions;
            rptRegion.DataBind();
        }

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptRegion2 = e.Item.FindControl("rptRegion2") as Repeater;
            var regions = bll_region.GetRegions(hfCityCode.Value);
            rptRegion2.DataSource = regions;
            rptRegion2.DataBind();
        }
    }

    protected void rptRegion2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int userId = 0;
        int.TryParse(hfUserId.Value, out userId);

        Cobe.CnRegion.SQLServerDAL.Region countyRegion = e.Item.DataItem as Cobe.CnRegion.SQLServerDAL.Region;

        Repeater rptRegion2 = sender as Repeater;
        HiddenField hfTsCode = rptRegion2.Parent.FindControl("hfTsCode") as HiddenField;

        LB.SQLServerDAL.Quotation quotation = bll_quote.GetLastQuotedPrice(userId, hfTsCode.Value, countyRegion.Id);

        Literal ltlPrice = e.Item.FindControl("ltlPrice") as Literal;
        if (quotation == null)
            ltlPrice.Text = "";
        else
            ltlPrice.Text = quotation.QuotedPrice.ToString();
    }
}