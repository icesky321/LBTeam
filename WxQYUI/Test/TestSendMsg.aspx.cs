using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB.Weixin.Message;
using System.Configuration;

public partial class WeixinQY_Test_TestSendMsg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 使用Senparc接口发送消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSendMsg_Click(object sender, EventArgs e)
    {
        string atscUrl = ConfigurationManager.AppSettings["AccessTokenServiceUri"] ?? "http://116.62.124.21/WeixinQY/AccessTokenService.aspx";
        string accessToken = Senparc.Weixin.HttpUtility.RequestUtility.HttpGet(atscUrl, null);
        string toUser = tbUsers.Text;
        string toParty = "";
        string toTag = "";
        string agentId = "9";
        //string content = "此段信息是由后台代码发送的消息，若见此消息代表代码有效01";
        List<Senparc.Weixin.QY.Entities.Article> articles = new List<Senparc.Weixin.QY.Entities.Article>();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "信用卡还款提醒";
        article.Description = "信用卡：9999\n银行：中信银行\n还款金额：88\n到期时间：明天\n";
        article.Url = "www.baidu.com";
        articles.Add(article);
        Senparc.Weixin.QY.AdvancedAPIs.MassApi.SendNews(accessToken, toUser, toParty, toTag, agentId, articles);
    }

    /// <summary>
    /// 使用绿宝微信接口发送文本消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSendMsgByLB_Click(object sender, EventArgs e)
    {
        MsgSender msgSender = new MsgSender();
        msgSender.SendTextToUsers(tbUsers.Text, "恭喜发财");
    }

    protected void btnSendArticleByLB_Click(object sender, EventArgs e)
    {
        MsgSender msgSender = new MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();

        article.Title = "废电瓶出售意向";
        article.Description = "供应商：正气汽车维修店\n数量：10组\n联系人：李峰\n地址：正大路88号\n联系电话：13877777777\n\n提醒消息测试！！！888";
        article.Url = "www.0574zy.com";

        msgSender.SendArticleToUsers(tbUsers.Text, article);
    }

    protected void btnSendFileByLB_Click(object sender, EventArgs e)
    {

        MsgSender msgSender = new MsgSender();

        msgSender.SendFileToUsers("01", "2vmZufcT7RZagfCMD1PaIU_PyxCxuF4VVGShCeq16Ke4w3bbjH3iZboGoC3u6tAz9");
    }
}