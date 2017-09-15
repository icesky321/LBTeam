using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

public partial class Quotation_Quote : System.Web.UI.Page
{
    LB.BLL.TSManage bll_ts = new LB.BLL.TSManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    JavaScriptSerializer js = new JavaScriptSerializer();
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.BLL.QuotationManage bll_quotation = new LB.BLL.QuotationManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        Load_UserInfo();
        Load_TS();
        Load_Region();
    }

    private void Load_UserInfo()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string mobile = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(mobile);
        hfUserId.Value = user.UserId.ToString();

        Cobe.CnRegion.SQLServerDAL.Region region = bll_region.GetRegion(user.RegionCode);
        if (region == null)
            return;
        hfRegionCode.Value = region.CityId;
        Cobe.CnRegion.SQLServerDAL.Region cityRegion = bll_region.GetRegion(hfRegionCode.Value);
        ltlCityName.Text = cityRegion.WholeName;
    }

    private void Load_Region()
    {
        var regions = bll_region.GetRegions(hfRegionCode.Value);
        GridView1.DataSource = regions;
        GridView1.DataBind();
    }

    private void Load_TS()
    {
        var tses = bll_ts.GetTSInfo();
        ddlDC.Items.Clear();
        foreach (LB.SQLServerDAL.TSInfo ts in tses)
        {
            ListItem item = new ListItem(ts.TSName + "（" + ts.ChargeUnit + "）", ts.TsCode);
            ddlDC.Items.Add(item);
        }
        ddlDC.Items.Insert(0, new ListItem("选择电瓶品种"));
    }

    protected void ddlDC_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDC.SelectedIndex == 0)
            return;

        ListItem item = ddlDC.SelectedItem;
        string code = item.Value;
        LB.SQLServerDAL.TSInfo ts = bll_ts.GetTS_ByCode(code);
        ltlDescription.Text = ts.Description;
        ltlChargeUnit.Text = "元/" + ts.ChargeUnit;


        hfTs.Value = js.Serialize(ts);
        Load_Region();
    }

    protected void btnQuote_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
            return;

        if (!Page.IsValid)
            return;

        string mobile = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(mobile);


        foreach (GridViewRow row in GridView1.Rows)
        {
            string regionCode = (row.FindControl("hfRegionCode") as HiddenField).Value;
            string priceStr = (row.FindControl("tbPrice") as TextBox).Text;
            decimal price = 0m;
            decimal.TryParse(priceStr, out price);

            LB.SQLServerDAL.TSInfo ts = js.Deserialize<LB.SQLServerDAL.TSInfo>(hfTs.Value);

            LB.SQLServerDAL.Quotation quotation = new LB.SQLServerDAL.Quotation();
            quotation.RegionCode = regionCode;

            quotation.UserId = user.UserId;
            quotation.UserName = user.UserName;

            quotation.TSId = ts.TSId;
            quotation.TSName = ts.TSName;
            quotation.TSCode = ts.TsCode;
            quotation.StandardUnit = ts.ChargeUnit;

            quotation.QuotedPrice = price;

            if (price > 0)
                bll_quotation.NewQuotation_NotSubmit(quotation);
        }
        bll_quotation.SubmitChanges();
        messageBox.Show("报价数据保存成功。");
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = true;
        if (ddlDC.SelectedIndex == 0)
            args.IsValid = false;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            TextBox tbprice = row.FindControl("tbPrice") as TextBox;
            tbprice.Text = "";
        }
    }



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ddlDC.SelectedIndex < 1)
            return;

        string tsCode = ddlDC.SelectedItem.Value;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbLastPrice = e.Row.FindControl("lbLastPrice") as Label;
            HiddenField hfCityRegionCode = e.Row.FindControl("hfRegionCode") as HiddenField;

            int userId = 0;
            int.TryParse(hfUserId.Value, out userId);

            if (userId == 0)
                return;

            LB.SQLServerDAL.Quotation quotation = bll_quotation.GetLastQuotedPrice(userId, tsCode, hfCityRegionCode.Value);
            if (quotation == null)
                return;

            lbLastPrice.Text = quotation.QuotedPrice.ToString();
        }
    }

    protected void btnFillup_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            TextBox tbPrice = row.FindControl("tbPrice") as TextBox;
            tbPrice.Text = tbPriceSample.Text;
        }
    }
}