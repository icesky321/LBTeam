using System;
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

public partial class AutoLogin : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }

        if (string.IsNullOrEmpty(Request.QueryString["code"]))
        {
            string redirectUrl = string.Empty;
            redirectUrl = OAuthApi.GetAuthorizeUrl(hfAppId.Value, "http://weixin.lvbao111.com/WeixinMP/AutoLogin.aspx", "Agree", OAuthScope.snsapi_base);
            Response.Redirect(redirectUrl);
        }
        else
        {
            string code = Request.QueryString["code"];

            OAuthAccessTokenResult AccessTokenEntity = OAuthApi.GetAccessToken(hfAppId.Value, hfAppSecret.Value, code);
            string openId = AccessTokenEntity.openid;

            LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfo_ByOpenId(openId);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.MobilePhoneNum, true, FormsAuthentication.FormsCookiePath);
                Response.Redirect(FormsAuthentication.GetRedirectUrl(user.MobilePhoneNum, false));
            }
        }

    }


    #region 初始化加载
    private void Init_Load()
    {
        hfAppId.Value = ConfigurationManager.AppSettings["AppId"] ?? "wx05eb2305685408a7";
        hfAppSecret.Value = ConfigurationManager.AppSettings["AppSecret"] ?? "b1100370fae06d358ab0ba6263bfa6ac";
    }

    #endregion
}