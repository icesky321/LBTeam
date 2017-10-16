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


/// <summary>
/// 绿宝网站自动登录界面
/// 作者：cobe
/// 修改时间：2017-10-16
/// 
/// 原理：
/// 当网站Web.config 配置好用户登录后，用户请求网页，若检测到用户没有登录凭证，将会重定向到本自动登录界面 AutoLogin
/// 
/// 本页面处理逻辑：
/// 1、当请求本页的查询字符串中不包含 code 参数时，调用 Senparc OAuthApi，获取OAuth2.0认证网址，然后微信服务器将重定向
/// 回本页 AutoLogin.aspx，此时，查询字符串中将会带上 code 参数。
/// 2、仍旧使用 OAuthApi，获取 OAuthAccessToken，获得用户OpenId。
/// 3、根据微信用户OpenId，到本地数据库中反查OpenId对应的用户，若可以找到用后，则帮助用户自动登录平台。
///      若找不到对应用户，说明用户尚未绑定账户和微信号，则引导用户跳转到绑定账户界面 AccountBinding.aspx 。
/// 
/// </summary>
public partial class AutoLogin : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();

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
                else
                {
                    // 数据库中找不到 OpenId，则引导用户到 AccountBinding.aspx 页面去绑定账户。
                    string url = string.Format("AccountBinding.aspx?openId={0}", openId);
                    Response.Redirect(url);
                }
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