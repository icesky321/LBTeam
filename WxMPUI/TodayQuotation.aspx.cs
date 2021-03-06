﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;

public partial class MP_TodayQuotation : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.BLL.TSManage bll_ts = new LB.BLL.TSManage();
    LB.BLL.QuotationManage bll_quote = new LB.BLL.QuotationManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();

    string appId = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        appId = ConfigurationManager.AppSettings["AppId"] ?? "wx05eb2305685408a7";

        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
                /*  代码功能：
                 *      当用户账户处理登录状态，但是用户账户却未与服务号OpenId关联时，以下代码生效，使用户账户与服务号OpenId关联上。
                 *      
                 *      当所有的在用用户，都已与 OpenId 关联上时，以下代码就完成了历史使命，可以删除。
                 *  
                 *  流程：
                 *  /// 1、当请求本页的查询字符串中不包含 code 参数时，调用 Senparc OAuthApi，获取OAuth2.0认证网址，然后微信服务器将重定向
                 *         回本页面，此时，查询字符串中将会带上 code 参数。
                 *      2、仍旧使用 OAuthApi，凭借获取到的 code 参数，获取 OAuthAccessToken，获得用户OpenId。
                 *      3、将OpenId与账户关联。
                 * */
                string mobile = User.Identity.Name;
                LB.SQLServerDAL.UserInfo localUser = bll_user.GetUserInfoByTelNum(mobile);

                #region  关联OpenId 片断代码
                if (string.IsNullOrEmpty(localUser.OpenId))
                {

                    // 获取用户 服务号OpenId，并绑定到用户账户。
                    if (string.IsNullOrEmpty(Request.QueryString["code"]))
                    {
                        string redirectUrl = string.Empty;
                        redirectUrl = OAuthApi.GetAuthorizeUrl(appId, "http://weixin.lvbao111.com/WeixinMP/TodayQuotation.aspx", "Agree", OAuthScope.snsapi_base);
                        Response.Redirect(redirectUrl);
                    }
                    else
                    {
                        string code = Request.QueryString["code"];
                        string appSecret = ConfigurationManager.AppSettings["AppSecret"] ?? "b1100370fae06d358ab0ba6263bfa6ac";
                        OAuthAccessTokenResult AccessTokenEntity = OAuthApi.GetAccessToken(appId, appSecret, code);
                        string openId = AccessTokenEntity.openid;

                        if (localUser != null && string.IsNullOrEmpty(localUser.OpenId))
                        {
                            localUser.OpenId = openId;
                            bll_user.UpdateUserInfo(localUser);
                        }
                    }

                }

                #endregion

                Load_UserInfo();
                Load_TsInfo();
                LoadTodayQuotation();
                if (string.IsNullOrEmpty(localUser.RegionCode))
                {
                    btRegionCode.Visible = true;
                }
                else
                {
                    btRegionCode.Visible = false;
                }
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
        Response.Redirect("../WeixinQY/MP/CreateLeads.aspx");
    }

    protected void btRegionCode_Click(object sender, EventArgs e)
    {
        Response.Redirect("../WeixinQY/UserCenter/ShowAddress.aspx");
    }
}