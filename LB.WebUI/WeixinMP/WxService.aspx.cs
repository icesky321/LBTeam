using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using System.Configuration;

public partial class WeixinMP_WxService : System.Web.UI.Page
{
    private readonly string Token = ConfigurationManager.AppSettings["token"]; //与微信公众账号后台的Token设置保持一致，区分大小写。

    string signature = string.Empty;
    string timestamp = string.Empty;
    string nonce = string.Empty;
    string echostr = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        init_Load();
    }

    private void init_Load()
    {
        string token = ConfigurationManager.AppSettings["token"] ?? "lvbao";
        signature = Request.QueryString["signature"];
        timestamp = Request.QueryString["timestamp"];
        nonce = Request.QueryString["nonce"];
        echostr = Request.QueryString["echoStr"];


        if (Request.HttpMethod == "GET")
        {

            // get method -仅在微信后台填写URL验证时触发
            if (CheckSignature.Check(signature, timestamp, nonce, token))
            {
                Response.Clear();       // 在修改服务器配置时，可能会发生 Token验证失败 的错误，要加上此句
                Response.Write(echostr);
                Response.End();
            }
            else
            {
                Response.Clear();       // 在修改服务器配置时，可能会发生 Token验证失败 的错误，要加上此句
                Response.Write("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, token) + "." +
                    "如果你看到此句，说明此地址有效，但回调验证未通过，请注意Token的一致性。");
                Response.End();
            }
        }

    }
}