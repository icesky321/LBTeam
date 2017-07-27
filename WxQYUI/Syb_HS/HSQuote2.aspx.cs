using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

public partial class Syb_HS_HSQuote2 : System.Web.UI.Page
{
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.TSManage bll_ts = new LB.BLL.TSManage();
    LB.BLL.QuotationManage bll_quote = new LB.BLL.QuotationManage();
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.BLL.CopInfo bll_cop = new LB.BLL.CopInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }


    }

    #region 初始化加载
    private void Init_Load()
    {
        Load_UserInfo();
        Load_Ts();
        Load_City();
    }

    private void Load_UserInfo()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(User.Identity.Name);
        if (user == null)
            return;

        hfUserId.Value = user.UserId.ToString();
        hfUserName.Value = user.UserName;

        LB.SQLServerDAL.CopInfo cop = bll_cop.GetCopInfoeByUserId(user.UserId);
        if (cop != null)
        {
            hfCopName.Value = cop.CopName;
        }
    }

    /// <summary>
    /// 加载电瓶信息
    /// </summary>
    private void Load_Ts()
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                string tsCode = Request.QueryString["id"];
                LB.SQLServerDAL.TSInfo ts = bll_ts.GetTS_ByCode(tsCode);
                if (ts == null)
                    return;

                ltlTSName.Text = ts.TSName;
                ltlTsCode.Text = ts.TsCode;
                ltlChargeUnit.Text = ts.ChargeUnit;

                JavaScriptSerializer jss = new JavaScriptSerializer();
                hfTsInfo.Value = jss.Serialize(ts);
            }
        }
    }

    /// <summary>
    /// 加载城市信息
    /// </summary>
    private void Load_City()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(User.Identity.Name);
        if (user == null)
            return;

        string regionCode = user.RegionCode;
        Cobe.CnRegion.SQLServerDAL.Region region = bll_region.GetRegion(regionCode);

        if (region == null)
            return;

        var counties = bll_region.GetRegions(region.CityId);

        Repeater1.DataSource = counties;
        Repeater1.DataBind();

    }

    #endregion


    protected void btnQuote1_Command(object sender, CommandEventArgs e)
    {
        Button btn = sender as Button;
        TextBox tbQuotedPrice = btn.FindControl("tbQuotedPrice") as TextBox;
        HiddenField hfRegionCode = btn.FindControl("hfRegionCode") as HiddenField;

        LB.SQLServerDAL.Quotation quotation = new LB.SQLServerDAL.Quotation();
        int userId = 0;
        int.TryParse(hfUserId.Value, out userId);

        quotation.UserId = userId;
        if (string.IsNullOrEmpty(hfCopName.Value))
            quotation.UserName = hfUserName.Value;
        else
            quotation.UserName = hfCopName.Value;

        decimal price = 0m;
        decimal.TryParse(tbQuotedPrice.Text, out price);
        quotation.QuotedPrice = price;

        JavaScriptSerializer jss = new JavaScriptSerializer();
        LB.SQLServerDAL.TSInfo ts = jss.Deserialize<LB.SQLServerDAL.TSInfo>(hfTsInfo.Value);
        quotation.TSName = ts.TSName;
        quotation.TSId = ts.TSId;
        quotation.TSCode = ts.TsCode;
        quotation.StandardUnit = ts.ChargeUnit;

        quotation.RegionCode = hfRegionCode.Value;

        bll_quote.NewQuotation(quotation);
    }

    protected void btnOneClickQuote_Click(object sender, EventArgs e)
    {
        List<LB.SQLServerDAL.Quotation> quotes = new List<LB.SQLServerDAL.Quotation>();

        foreach (RepeaterItem item in Repeater1.Items)
        {
            TextBox tbQuotedPrice = item.FindControl("tbQuotedPrice") as TextBox;
            HiddenField hfRegionCode = item.FindControl("hfRegionCode") as HiddenField;


            LB.SQLServerDAL.Quotation quotation1 = new LB.SQLServerDAL.Quotation();
            int userId = 0;
            int.TryParse(hfUserId.Value, out userId);

            quotation1.UserId = userId;
            if (string.IsNullOrEmpty(hfCopName.Value))
                quotation1.UserName = hfUserName.Value;
            else
                quotation1.UserName = hfCopName.Value;

            decimal price = 0m;
            decimal.TryParse(tbQuotedPrice.Text, out price);
            quotation1.QuotedPrice = price;


            JavaScriptSerializer jss = new JavaScriptSerializer();
            LB.SQLServerDAL.TSInfo ts = jss.Deserialize<LB.SQLServerDAL.TSInfo>(hfTsInfo.Value);
            quotation1.TSName = ts.TSName;
            quotation1.TSId = ts.TSId;
            quotation1.TSCode = ts.TsCode;
            quotation1.StandardUnit = ts.ChargeUnit;

            quotation1.RegionCode = hfRegionCode.Value;

            if (quotation1.QuotedPrice > 0)
                bll_quote.NewQuotation_NotSubmit(quotation1);
        }

        bll_quote.SubmitChanges();
        Response.Redirect("~/ErrorPage/Success.aspx");
    }



    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Cobe.CnRegion.SQLServerDAL.Region region = e.Item.DataItem as Cobe.CnRegion.SQLServerDAL.Region;
        string tsCode = ltlTsCode.Text;
        int userId = 0;
        int.TryParse(hfUserId.Value, out userId);

        LB.SQLServerDAL.Quotation quotation = bll_quote.GetTodayLastQuotedPrice(userId, tsCode, region.Id);
        decimal price = quotation == null ? 0.00m : quotation.QuotedPrice;

        TextBox tbQuotedPrice = e.Item.FindControl("tbQuotedPrice") as TextBox;
        tbQuotedPrice.Text = price.ToString();
    }
}