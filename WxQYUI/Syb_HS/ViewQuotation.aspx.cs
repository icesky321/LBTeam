using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HS_ViewQuotation : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.BLL.TSManage bll_ts = new LB.BLL.TSManage();
    LB.BLL.QuotationManage bll_quote = new LB.BLL.QuotationManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_UserInfo();
            Load_County();
            LoadTodayQuotation();
        }
    }



    #region 初始化加载

    private void Load_UserInfo()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(User.Identity.Name);
        if (user == null)
            return;

        string regionCode = user.RegionCode;
        Cobe.CnRegion.SQLServerDAL.Region userRegion = bll_region.GetRegion(regionCode);
        if (userRegion == null)
            return;

        int level = 0;
        level = userRegion.Level ?? 0;

        if (level < 2)
            Response.Redirect("UserInfoIncomplete.aspx");
        else
        {
            hfCityRegionCode.Value = userRegion.CityId;
            Cobe.CnRegion.SQLServerDAL.Region cityRegion = bll_region.GetRegion(hfCityRegionCode.Value);

            if (cityRegion != null)
                ltlCityName.Text = cityRegion.AreaName;

            Load_Counties(hfCityRegionCode.Value);

            Cobe.CnRegion.SQLServerDAL.Region countyRegion = bll_region.GetRegion(userRegion.CountyId);
            if (countyRegion != null)
            {
                ltlRegionWholeName.Text = countyRegion.WholeName;
                hfCountyId.Value = userRegion.CountyId;
            }
        }

    }

    private void Load_Counties(string cityRegionCode)
    {
        var counties = bll_region.GetRegions(cityRegionCode);
        rptRegion.DataSource = counties;
        rptRegion.DataBind();
    }

    private void Load_County()
    {
        if (Request.QueryString["CountyRegionCode"] != null)
        {
            Cobe.CnRegion.SQLServerDAL.Region countyRegion = bll_region.GetRegion(Request.QueryString["CountyRegionCode"]);
            if (countyRegion != null)
            {
                ltlRegionWholeName.Text = countyRegion.WholeName;
                hfCountyId.Value = countyRegion.Id;
            }
        }
    }

    /// <summary>
    /// 加载电池品种
    /// <para>该报价面向回收业务员，剔除所有非吨计价的品种。</para>
    /// </summary>
    //private void Load_TsInfo()
    //{
    //    var query = bll_ts.GetTSInfo();
    //    List<LB.SQLServerDAL.TSInfo> tsInfoes = new List<LB.SQLServerDAL.TSInfo>();
    //    foreach (LB.SQLServerDAL.TSInfo ts in query)
    //    {
    //        if (ts.ChargeUnit == "吨")
    //            tsInfoes.Add(ts);
    //    }
    //    Repeater2.DataSource = tsInfoes;
    //    Repeater2.DataBind();
    //}


    protected void LoadTodayQuotation()
    {
        //var query = bll_quote.GetQuotation("宁波", DateTime.Now.Date);
        //Repeater1.DataSource = query;
        //Repeater1.DataBind();
    }
    #endregion

    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LB.SQLServerDAL.TSInfo ts = e.Item.DataItem as LB.SQLServerDAL.TSInfo;
            LB.SQLServerDAL.Quotation quotation = bll_quote.GetLastQuotedPrice(ts.TsCode, hfCountyId.Value);

            Literal ltlHS_UserName = e.Item.FindControl("ltlHS_UserName") as Literal;
            Literal ltlPrice = e.Item.FindControl("ltlPrice") as Literal;
            Literal ltlChargeUnit = e.Item.FindControl("ltlChargeUnit") as Literal;
            Literal ltlDate = e.Item.FindControl("ltlDate") as Literal;

            if (quotation == null)
            {
                ltlPrice.Text = quotation == null ? "-" : quotation.QuotedPrice.ToString() + "&nbsp;元/" + quotation.StandardUnit;
                ltlChargeUnit.Text = "";
                ltlDate.Text = quotation == null ? "-" : quotation.OfferDate.ToShortDateString();
                return;
            }

            LB.SQLServerDAL.CopInfo cop = bll_copinfo.GetCopInfoeByUserId(quotation.UserId);

            ltlHS_UserName.Text = cop == null ? "" : cop.ShortName;
            ltlPrice.Text = quotation == null ? "-" : quotation.QuotedPrice.ToString();
            ltlChargeUnit.Text = "元/" + quotation.StandardUnit;
            ltlDate.Text = quotation == null ? "-" : quotation.OfferDate.ToShortDateString();

        }
    }
}