using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Senparc.Weixin.QY.AdvancedAPIs;
using LB.Weixin;

public partial class WeixinQY_TestShowUserInfo : System.Web.UI.Page
{
    BaseAccessTokenManage atManage = new BaseAccessTokenManage();
    protected void Page_Load(object sender, EventArgs e)
    {


        string code = Request.QueryString["code"];
        ltlCode.Text = code;
        string accessTokenServiceUri = ConfigurationManager.AppSettings["AccessTokenServiceUri"] ?? "";
        string accessToken = Senparc.Weixin.HttpUtility.RequestUtility.HttpGet(accessTokenServiceUri, null);
        //string accessToken = "bsiBf1bJD9NK7Jo3UgBnLs8Zu1zvmfKXoPFXFPVIB_huZVaMgXaU1hIFTCf3IOC5";
        // 根据上面获取到的 Code， 以及系统AccessToken参数，获取用户信息。
        Senparc.Weixin.QY.AdvancedAPIs.OAuth2.GetUserInfoResult result = OAuth2Api.GetUserId(accessToken, code);
        ListBox1.Items.Add("DeviceId:" + result.DeviceId);
        ListBox1.Items.Add("errmsg:" + result.errmsg);
        ListBox1.Items.Add("OpenId:" + result.OpenId);
        ListBox1.Items.Add("UserId:" + result.UserId);
    }


}