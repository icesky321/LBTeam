using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;

public partial class AuthEntrance : System.Web.UI.Page
{
    string appId = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        /* 
         * 具体而言，网页授权流程分为四步： 
            1. 引导用户进入授权页面同意授权，获取code 
            2. 通过code换取网页授权access_token（与基础支持中的access_token不同） 
            3. 如果需要，开发者可以刷新网页授权access_token，避免过期 
            4. 通过网页授权access_token和openid获取用户基本信息 
         * 
        */

        appId = ConfigurationManager.AppSettings["AppId"] ?? "wx05eb2305685408a7";

        string redirectUrl = string.Empty;
        redirectUrl = OAuthApi.GetAuthorizeUrl(appId, "http://weixin.lvbao111.com/WeixinMP/AccessTokenBinding.aspx", "Agree", OAuthScope.snsapi_base);
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
}