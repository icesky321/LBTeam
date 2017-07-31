using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_JD_ViewQuotation : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.TSManage bll_ts = new LB.BLL.TSManage();
    LB.BLL.QuotationManage bll_quote = new LB.BLL.QuotationManage();
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_UserInfo();
            Load_TsInfo();
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

        hfUserName.Value = user.RealName;
        string regionCode = user.RegionCode;
        Cobe.CnRegion.SQLServerDAL.Region region = bll_region.GetRegion(regionCode);
        if (region == null)
            return;

        int level = 0;
        level = region.Level ?? 0;

        if (level < 4)
            Response.Redirect("UserInfoIncomplete.aspx");
        else
        {
            hfCountyId.Value = region.CountyId;

            string countyWholeName = bll_region.GetRegion(region.CountyId).WholeName;
            ltlRegionWholeName.Text = countyWholeName;
            ltlRegionWholeName2.Text = countyWholeName;
        }

    }

    /// <summary>
    /// 加载电池品种
    /// <para>该报价面向产废单位，剔除所有以吨计价的品种。</para>
    /// </summary>
    private void Load_TsInfo()
    {
        var query = bll_ts.GetTSInfo();
        List<LB.SQLServerDAL.TSInfo> tsHuishou = new List<LB.SQLServerDAL.TSInfo>();
        List<LB.SQLServerDAL.TSInfo> tsChushou = new List<LB.SQLServerDAL.TSInfo>();
        foreach (LB.SQLServerDAL.TSInfo ts in query)
        {
            if (ts.ChargeUnit != "吨")
                tsHuishou.Add(ts);
            else
                tsChushou.Add(ts);
        }
        Repeater2.DataSource = tsHuishou;
        Repeater2.DataBind();

        rptChuShou.DataSource = tsChushou;
        rptChuShou.DataBind();
    }


    protected void LoadTodayQuotation()
    {
        // TODO： 发布前要修改
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
            if (quotation != null)
            {
                LB.SQLServerDAL.CopInfo cop = bll_copinfo.GetCopInfoeByUserId(quotation.UserId);
                if (cop != null)
                    ltlHS_UserName.Text = cop.ShortName;
                else
                    ltlHS_UserName.Text = hfUserName.Value;
                ltlPrice.Text = quotation.QuotedPrice.ToString();
                ltlChargeUnit.Text = "元/" + quotation.StandardUnit;

                ltlDate.Text = quotation.OfferDate.ToShortDateString();
            }
            else
            {
                ltlPrice.Text = "-";
                ltlChargeUnit.Text = "";
                ltlDate.Text = "";
            }
        }
    }
}