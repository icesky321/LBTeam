using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.QY.AdvancedAPIs;
using System.Configuration;

public partial class WeixinQY_TestGetCode_OAuth2 : System.Web.UI.Page
{
    //LB.Weixin.AccessTokenManage atManage = new LB.Weixin.AccessTokenManage();

    string corpId = string.Empty;
    string redirect_uri = string.Empty;
    string code = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        init_Load();
    }

    private void init_Load()
    {
        corpId = ConfigurationManager.AppSettings["CorpID"] ?? "wxabb13491cd384449";
        redirect_uri = Server.UrlEncode("weixin.lvbao111.com/WeixinQY/Test/TestShowUserInfo.aspx");
        string responseType = "code";
        string scope = "snsapi_privateinfo";
        string agentid = ((int)LB.Weixin.企业号应用.默认).ToString();
        string state = "state";
        var url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type={2}&scope={3}&agentid={4}&state={5}#wechat_redirect", corpId, redirect_uri, responseType, scope, agentid, state);

        // scope: snsapi_base、snsapi_userinfo、snsapi_privateinfo
        //code = OAuth2Api.GetCode(corpId, redirect_uri, string.Empty, "code", "snsapi_userinfo");       // 获取Code
        code = url;
        Literal1.Text = code;

        ////string accessToken = atManage.AccessToken;
        //string accessToken = "mSl8mMWnS5diVxTFjyFW2TSi6d-SEaN8p8ysV2CHrzo04dQgUiCrZx2JNAahRUtB";
        //// 根据上面获取到的 Code， 以及系统AccessToken参数，获取用户信息。
        //Senparc.Weixin.QY.AdvancedAPIs.OAuth2.GetUserInfoResult result =
        //OAuth2Api.GetUserId(accessToken, code);
        //ListBox1.Items.Add("DeviceId:" + result.DeviceId);
        //ListBox1.Items.Add("errmsg:" + result.errmsg);
        //ListBox1.Items.Add("OpenId:" + result.OpenId);
        //ListBox1.Items.Add("UserId:" + result.UserId);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(code);
    }

    protected void btnGetCode_Click(object sender, EventArgs e)
    {
        corpId = ConfigurationManager.AppSettings["CorpID"] ?? "wxabb13491cd384449";
        redirect_uri = Server.UrlEncode("TestGetCode_OAuth2.aspx");
        string code = Senparc.Weixin.QY.AdvancedAPIs.OAuth2Api.GetCode(corpId, redirect_uri, "state");
        ltlCode.Text = code;
        ltlCode.Text = Request.QueryString["code"];
    }
}