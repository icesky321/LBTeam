﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;


/// <summary>
/// 该页面在网站中已失去实际作用，仅与AuthEntrance.aspx 合作使用，共同展示如何获取 OpenId
/// </summary>
public partial class AccessTokenBinding : System.Web.UI.Page
{
    LB.BLL.SMS bll_sms = new LB.BLL.SMS();
    LB.BLL.UserManage localUserManage = new LB.BLL.UserManage();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Load_Initial_Data();

            if (string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                /* 
                 * 具体而言，网页授权流程分为四步： 
                    1. 引导用户进入授权页面同意授权，获取code 
                    2. 通过code换取网页授权access_token（与基础支持中的access_token不同） 
                    3. 如果需要，开发者可以刷新网页授权access_token，避免过期 
                    4. 通过网页授权access_token和openid获取用户基本信息 
                 * 
                */

                hfAppId.Value = ConfigurationManager.AppSettings["AppId"] ?? "wx05eb2305685408a7";

                string redirectUrl = string.Empty;
                redirectUrl = OAuthApi.GetAuthorizeUrl(hfAppId.Value, "http://weixin.lvbao111.com/WeixinMP/AccessTokenBinding.aspx", "Agree", OAuthScope.snsapi_base);
                Response.Redirect(redirectUrl);

                // 执行以上代码之后，微信服务器会将你重定向到一个类似下面带两个查询字符串的链接地址：
                // http://www.tiyigroup.com/weixin/AccessTokenBinding.aspx/?code=laiifwefk&state=Agree
                // code 用于网页授权 access_token      state表示状态
                // 用户同意授权后 
                // 如果用户同意授权，页面将跳转至 redirect_uri/?code=CODE&state=STATE。
                // 若用户禁止授权，则重定向后不会带上code参数，仅会带上state参数redirect_uri?state=STATE 

                // code说明 ：
                // code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。
            }
            else
            {
                hfcode.Value = Request.QueryString["code"];
                AccessTokenEntity = OAuthApi.GetAccessToken(AppId, AppSecret, code);
                hfOpenId.Value = AccessTokenEntity.openid;
            }
        }



        //ObtainAccessToken();

        //if (!IsPostBack)
        //{
        //    CheckIsLocalUser();
        //}
    }

    #region  属性
    /// <summary>
    /// code作为换取access_token的票据，每次用户授权带上的code将不一样，
    /// code只能使用一次，5分钟未被使用自动过期。
    /// </summary>
    public string code
    {
        get { return hfcode.Value; }
    }

    public string AppId
    {
        get { return hfAppId.Value; }
    }

    public string AppSecret
    {
        get { return hfAppSecret.Value; }
    }

    /// <summary>
    /// 访问令牌实体对象。
    /// </summary>
    public OAuthAccessTokenResult AccessTokenEntity
    {
        get;
        set;
    }

    #endregion


    public void Load_Initial_Data()
    {
        hfAppId.Value = ConfigurationManager.AppSettings["AppId"] ?? "wx05eb2305685408a7";
        hfAppSecret.Value = ConfigurationManager.AppSettings["AppSecret"] ?? "b1100370fae06d358ab0ba6263bfa6ac";
    }

    ///// <summary>
    ///// 获取并缓存访问令牌。
    ///// </summary>
    //private void ObtainAccessToken()
    //{
    //    if (Request.Cookies["access_token"] != null && !string.IsNullOrEmpty(Request.Cookies["access_token"].Values["access_token"]))
    //    {
    //        AccessTokenEntity = new OAuthAccessTokenResult();
    //        AccessTokenEntity.access_token = Request.Cookies["access_token"].Values["access_token"];
    //        AccessTokenEntity.expires_in = Convert.ToInt32(Request.Cookies["access_token"].Values["expires_in"]);
    //        AccessTokenEntity.openid = Request.Cookies["access_token"].Values["openid"];
    //        AccessTokenEntity.refresh_token = Request.Cookies["access_token"].Values["refresh_token"];
    //        AccessTokenEntity.scope = Request.Cookies["access_token"].Values["scope"];
    //        AccessTokenEntity.errcode = ReturnCode.请求成功;
    //    }
    //    else
    //    {
    //        if (Request.Cookies["refresh_token"] != null && !string.IsNullOrEmpty(Request.Cookies["refresh_token"].Values["refresh_token"]))
    //        {
    //            try
    //            {
    //                AccessTokenEntity = OAuthApi.RefreshToken(AppId, Request.Cookies["refresh_token"].Values["refresh_token"]);
    //            }
    //            catch (Exception ee)
    //            {
    //                AccessTokenEntity = OAuthApi.GetAccessToken(AppId, AppSecret, code);
    //            }
    //        }
    //        else
    //        {
    //            AccessTokenEntity = OAuthApi.GetAccessToken(AppId, AppSecret, code);
    //        }
    //        CacheToCookie();
    //    }

    //    // 正确时返回的JSON数据包如下： 
    //    // {
    //    //    "access_token":"ACCESS_TOKEN",
    //    //    "expires_in":7200,               --------> 从这里可以看出 ACCESS_TOKEN 有效期 2 小时
    //    //    "refresh_token":"REFRESH_TOKEN",
    //    //    "openid":"OPENID",
    //    //    "scope":"SCOPE"
    //    // }
    //    // 错误时微信会返回JSON数据包如下（示例为Code无效错误）: 
    //    // {"errcode":40029,"errmsg":"invalid code"}
    //    if (AccessTokenEntity.errcode != ReturnCode.请求成功)
    //    {
    //        lbErrorMsg.Text = "错误：" + AccessTokenEntity.errmsg;
    //        MultiView1.SetActiveView(viewErrorMsg);
    //    }



    //}

    ///// <summary>
    ///// 获取微信用户信息。
    ///// </summary>
    //private OAuthUserInfo ObtainOAuthUserInfo()
    //{
    //    OAuthUserInfo userInfo = new OAuthUserInfo();
    //    //因为第一步选择的是OAuthScope.snsapi_userinfo，这里可以进一步获取用户详细信息

    //    string accessToken = this.AccessTokenEntity.access_token;
    //    string openId = this.AccessTokenEntity.openid;

    //    try
    //    {
    //        userInfo = OAuth.GetUserInfo(accessToken, openId);
    //        Trace.Write("accessToken:" + accessToken);
    //        Trace.Write("openId:" + openId);
    //        Trace.Write("code:" + hfcode.Value);
    //        Session["OAuthUserInfo"] = userInfo;
    //    }
    //    catch (ErrorJsonResultException ex)
    //    {
    //        lbErrorMsg.Text = "未获取到用户信息" + ex.Message;
    //        MultiView1.SetActiveView(viewErrorMsg);
    //    }
    //    return userInfo;
    //}

    //private void CacheToCookie()
    //{
    //    //下面2个数据也可以自己封装成一个类，储存在数据库中（建议结合缓存）
    //    //如果可以确保安全，可以将access_token存入用户的cookie中，每一个人的access_token是不一样的
    //    Session["OAuthAccessTokenStartTime"] = DateTime.Now;
    //    Session["OAuthAccessToken"] = AccessTokenEntity;


    //    // 微信官方称 access_token 有效期为2小时，但实际似乎不到时间就过期了。
    //    // 故此处将有效期设为1小时。
    //    HttpCookie cookieToken = new HttpCookie("access_token");
    //    cookieToken.Values.Add("access_token", AccessTokenEntity.access_token);
    //    cookieToken.Values.Add("expires_in", AccessTokenEntity.expires_in.ToString());
    //    cookieToken.Values.Add("refresh_token", AccessTokenEntity.refresh_token);
    //    cookieToken.Values.Add("openid", AccessTokenEntity.openid);
    //    cookieToken.Values.Add("scope", AccessTokenEntity.scope);
    //    cookieToken.Expires = System.DateTime.Now.AddHours(2);
    //    Response.AppendCookie(cookieToken);


    //    HttpCookie cookieRefreshToken = new HttpCookie("refresh_token");
    //    cookieRefreshToken.Values.Add("refresh_token", AccessTokenEntity.refresh_token);
    //    cookieRefreshToken.Values.Add("openid", AccessTokenEntity.openid);
    //    cookieRefreshToken.Expires = System.DateTime.Now.AddDays(7);
    //    Response.AppendCookie(cookieRefreshToken);
    //}

    //private void CheckIsLocalUser()
    //{
    //    /* 检测微信用户，是否曾经已注册为本地用户，若已经是本地用户，
    //     * 则直接显示用户信息。
    //     * 若不是本地用户，则引导用户输入公司网站帐户绑定。
    //     * */
    //    OAuthUserInfo oauthUser = new OAuthUserInfo();

    //    try
    //    {
    //        oauthUser = OAuth.GetUserInfo(AccessTokenEntity.access_token, AccessTokenEntity.openid);
    //    }
    //    catch (Exception ee)
    //    {
    //        lbLocalUser.Text = "检测是否是本地用户出错，" + ee.Message;
    //    }

    //    if (localUserManage.IsLocalUser(AccessTokenEntity.openid))
    //    {
    //        lbLocalUser.Text = "您已经绑定了帐户，无需重复绑定";
    //        imgUserHead.ImageUrl = oauthUser.headimgurl;
    //        lbNickName.Text = oauthUser.nickname;
    //        MultiView1.SetActiveView(viewLocalUserInfo);
    //    }


    //}


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //    lbErrorMsg.Text = "您未授权微信帐户和公司网站帐户绑定，您将无法访问公司网站";
        //    MultiView1.SetActiveView(viewErrorMsg);
    }
    protected void btnBinding_Click(object sender, EventArgs e)
    {
        #region  输入表单检验

        if (string.IsNullOrEmpty(tbMobile.Text))
        {
            lbLoginError.Visible = true;
            lbLoginError.Text = "手机号不可为空";
            return;
        }
        else
        {
            lbLoginError.Text = "";
            lbLoginError.Visible = false;
        }

        if (Session["mobile_code"] == null || Session["mobile_code"].ToString() != tbVeriCode.Text)
        {
            ltlVeriMessage.Text = "验证码输入有误，请重新输入";
            ltlVeriMessage.Visible = true;
        }
        else
        {
            ltlVeriMessage.Text = "";
            ltlVeriMessage.Visible = false;
        }
        #endregion
        if (tbMobile.Text.Length == 11 && Session["mobile_code"].ToString() == tbVeriCode.Text)
        {
            if (localUserManage.ExistTelNum(tbMobile.Text))
            {
                LB.SQLServerDAL.UserInfo localUser = localUserManage.GetUserInfoByTelNum(tbMobile.Text);
                localUser.OpenId = hfOpenId.Value;
                localUserManage.UpdateUserInfo(localUser);
                lbLocalUser.Text = localUser.MobilePhoneNum;

                MultiView1.SetActiveView(viewLocalUserInfo);
            }
            else
            {
                LB.SQLServerDAL.UserInfo newUser = new LB.SQLServerDAL.UserInfo();
                newUser.UserName = tbMobile.Text;
                newUser.MobilePhoneNum = tbMobile.Text;
                newUser.UserTypeId = 1;
                newUser.OpenId = hfOpenId.Value;
                localUserManage.NewUserInfo(newUser);
                Membership.CreateUser(tbMobile.Text, "123456");

                MultiView1.SetActiveView(viewLocalUserInfo);
            }
            FormsAuthentication.SetAuthCookie(tbMobile.Text, true, FormsAuthentication.FormsCookiePath);
        }
        //    OAuthUserInfo oauthUser = ObtainOAuthUserInfo();

        //    if (!string.IsNullOrEmpty(oauthUser.openid))
        //    {
        //        MembershipUser user = Membership.GetUser(tbJobNumber.Text);

        //        if (Membership.ValidateUser(tbJobNumber.Text, tbPassword.Text))
        //        {
        //            Tiyi.Weixin.SQLServerDAL.WeixinUser wxUser = new Tiyi.Weixin.SQLServerDAL.WeixinUser();
        //            wxUser.City = oauthUser.city;
        //            wxUser.Country = oauthUser.country;
        //            wxUser.Nickname = oauthUser.nickname;
        //            wxUser.OpenId = oauthUser.openid;
        //            wxUser.Province = oauthUser.province;
        //            wxUser.Sex = oauthUser.sex;
        //            wxUser.JobNumber = tbJobNumber.Text;

        //            Tiyi.PMS.Personnel bll_person = new Tiyi.PMS.Personnel();
        //            Tiyi.PMS.PersonInfo personInfo = bll_person.GetPersonInfoByJobNumber(tbJobNumber.Text);
        //            wxUser.RealName = personInfo.Name;

        //            Tiyi.Weixin.BLL.WeixinUserManage wuManage = new WeixinUserManage();
        //            if (!wuManage.ExistWeixinUserByOpenId(wxUser.OpenId))
        //                wuManage.RegisterNewWeixinUser(wxUser);


        //            SendTemplateMessage(wxUser);

        //            Response.Redirect("AuthTest.aspx");
        //        }
        //        else
        //        {
        //            lbLoginError.Text = "<br />您的公司网站帐户检验有误，请重新输入。";
        //            lbLoginError.Visible = true;
        //        }

        //    }
    }

    //private void SendTemplateMessage(Tiyi.Weixin.SQLServerDAL.WeixinUser weixinUser)
    //{
    //    Tiyi.Weixin.BLL.WeixinMessageQueue wx_queque = new WeixinMessageQueue();

    //    TemplateMessageSender wxSender = new TemplateMessageSender();
    //    Tiyi.Weixin.TemplateMessageData_任务处理通知 data = new Tiyi.Weixin.TemplateMessageData_任务处理通知
    //    {
    //        first = new Tiyi.Weixin.TemplateMessageDataItem("尊敬的" + weixinUser.RealName + "，恭喜您的微信帐户已成功绑定至公司网站帐户"),
    //        keyword1 = new Tiyi.Weixin.TemplateMessageDataItem(weixinUser.Nickname + " " + weixinUser.JobNumber),
    //        keyword2 = new Tiyi.Weixin.TemplateMessageDataItem("免密自动登录，事务到达提醒。"),
    //        remark = new Tiyi.Weixin.TemplateMessageDataItem("点击查看个人信息中心")
    //    };
    //    wx_queque.PushInWeixinMessage(weixinUser.JobNumber, data, "http://www.tiyigroup.com");
    //    wx_queque.StartSend();
    //}


    protected void lbtnGetVeriCode_Click(object sender, EventArgs e)
    {
        Random rad = new Random();
        int mobile_code = rad.Next(1000, 10000);
        Session["mobile_code"] = mobile_code.ToString();

        if (tbMobile.Text.Length != 11)
        {
            lbLoginError.Visible = true;
            lbLoginError.Text = "手机号必须为11位";
            return;
        }
        else
        {
            lbLoginError.Text = "";
            lbLoginError.Visible = false;
        }


        bll_sms.SendSMS(tbMobile.Text, "您的验证码是：" + mobile_code.ToString() + "【绿宝】");
        lbtnGetVeriCode.Enabled = false;
        ltlVeriMessage.Text = "在下方输入收到的验证码";
        ltlVeriMessage.Visible = true;



    }

    protected void btnQueryQuotation_Click(object sender, EventArgs e)
    {
        Response.Redirect("TodayQuotation.aspx");
    }
}