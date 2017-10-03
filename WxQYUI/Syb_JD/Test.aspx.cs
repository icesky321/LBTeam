using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Syb_Dyywy_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CommandButton_Click(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Accept")
        {
            //LB.BLL.SMS sms = new LB.BLL.SMS();
            //sms.SendSMS("13738487153", "回收员（******）已接单，会尽快与您联系，请耐心等待。【绿宝】");
            SendWxArticle_ToCF("6");
        }
        Response.Redirect("~/Kefu_Info/DispatchManage.aspx");
    }

    private void SendWxArticle_ToCF(string QYId)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "街道回收员收货单明细";
        article.Description = "查看明细请继续戳我";
        article.Url = "http://weixin.lvbao111.com/WeixinQY/Syb_hsgs/PayOrder.aspx=";
        sendmsg.SendArticleToUsers(QYId, article, "5");
    }
}