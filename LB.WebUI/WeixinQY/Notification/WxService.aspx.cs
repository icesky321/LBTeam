using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin;
using Senparc.Weixin.QY;
using Senparc.Weixin.QY.Entities;
using System.Configuration;

public partial class WeixinQY_Notification_WxService : System.Web.UI.Page
{
    string token = string.Empty;
    string encodingAESKey = string.Empty;
    string corpId = string.Empty;
    string echostr = string.Empty;
    string signature = string.Empty;
    string timestamp = string.Empty;
    string nonce = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        init_Load();
    }

    private void init_Load()
    {
        if (Request.HttpMethod == "GET")
        {
            token = ConfigurationManager.AppSettings["Token"] ?? "lvbao";
            encodingAESKey = ConfigurationManager.AppSettings["EncodingAESKey"] ?? "cP9Dvx7aiWyX84sjVEq2Cy45Hmafxrq6IWPjua0yBYM";
            corpId = ConfigurationManager.AppSettings["CorpID"] ?? "wxabb13491cd384449";

            signature = Request.QueryString["msg_signature"];
            timestamp = Request.QueryString["timestamp"];
            nonce = Request.QueryString["nonce"];
            echostr = Request.QueryString["echoStr"];
            string decryptEchoString = string.Empty;



            // get method -仅在微信后台填写URL验证时触发
            decryptEchoString = Signature.VerifyURL(token, encodingAESKey, corpId, signature, timestamp, nonce, echostr);
            if (decryptEchoString != null)
            {
                Response.Clear();
                Response.Write(decryptEchoString);
                Response.End();
            }
        }

        //if (Request.HttpMethod == "POST")
        //{
        //    //post method - 当有用户向公众账号发送消息时触发
        //    if (!CheckSignature.Check(signature, timestamp, nonce, token))
        //    {
        //        Response.Clear();
        //        Response.Write("身份检验未通过，参数错误！");
        //        return;
        //    }

        //    //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
        //    Senparc.Weixin.MP.Entities.Request.PostModel postModel = new Senparc.Weixin.MP.Entities.Request.PostModel();
        //    postModel.SetSecretInfo(token, string.Empty, "wx5987b3efa3881815");
        //    var messageHandler = new LB.Weixin.CommonService.CustomMessageHandler.CustomMessageHandler(Request.InputStream, postModel);
        //    //执行微信处理过程
        //    messageHandler.Execute();
        //    //输出结果
        //    //WriteContent(messageHandler.ResponseDocument.ToString());
        //}

    }
}