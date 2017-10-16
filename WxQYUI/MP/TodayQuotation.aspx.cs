using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
///                                            
///                                             ★★    非常重要    ★★
///                            本页面已失效，产废单位在服务号中查询报价信息，不再使用该页面，
///                            服务号中查询报价信息，已链接至 WeixinMP/TodayQuotation.aspx
///                            
///                                                    新页面 2017年10月16日启用
///                            
/// </summary>
public partial class MP_TodayQuotation : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.BLL.TSManage bll_ts = new LB.BLL.TSManage();
    LB.BLL.QuotationManage bll_quote = new LB.BLL.QuotationManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login/Login.aspx");
                //Response.Redirect("PublicTodayQuotation.aspx");
            }
            else
            {
                Load_UserInfo();
                Load_TsInfo();
                LoadTodayQuotation();
            }

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
        Cobe.CnRegion.SQLServerDAL.Region region = bll_region.GetRegion(regionCode);
        if (region == null)
            return;

        int level = 0;
        level = region.Level ?? 0;

        if (level < 3)
            Response.Redirect("UserInfoIncomplete.aspx");
        else
        {
            ltlRegionWholeName.Text = bll_region.GetRegion(region.CountyId).WholeName;
            hfCountyId.Value = region.CountyId;
        }

    }

    /// <summary>
    /// 加载电池品种
    /// <para>该报价面向产废单位，剔除所有以吨计价的品种。</para>
    /// </summary>
    private void Load_TsInfo()
    {
        var query = bll_ts.GetTSInfo();
        List<LB.SQLServerDAL.TSInfo> tsInfoes = new List<LB.SQLServerDAL.TSInfo>();
        foreach (LB.SQLServerDAL.TSInfo ts in query)
        {
            if (ts.ChargeUnit != "吨")
                tsInfoes.Add(ts);
        }
        Repeater2.DataSource = tsInfoes;
        Repeater2.DataBind();
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
                MCopInfo = bll_copinfo.GetCopInfoeByUserId(quotation.UserId);
                ltlHS_UserName.Text = MCopInfo.ShortName;
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

    protected void btSell_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MP/CreateLeads.aspx");
    }
}