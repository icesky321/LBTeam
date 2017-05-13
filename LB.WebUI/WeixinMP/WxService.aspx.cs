using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities;
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

        if (Request.HttpMethod == "POST")
        {
            //post method - 当有用户向公众账号发送消息时触发
            if (!CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                Response.Clear();
                Response.Write("身份检验未通过，参数错误！");
                return;
            }

            //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            Senparc.Weixin.MP.Entities.Request.PostModel postModel = new Senparc.Weixin.MP.Entities.Request.PostModel();
            postModel.SetSecretInfo(token, string.Empty, "wx5987b3efa3881815");
            var messageHandler = new LB.Weixin.CommonService.CustomMessageHandler.CustomMessageHandler(Request.InputStream, postModel);
            //执行微信处理过程
            messageHandler.Execute();
            //输出结果
            //WriteContent(messageHandler.ResponseDocument.ToString());
        }

    }
}