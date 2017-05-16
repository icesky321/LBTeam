using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeixinQY_Test_TestSendMsg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSendMsg_Click(object sender, EventArgs e)
    {
        LB.Weixin.AccessTokenManage at = new LB.Weixin.AccessTokenManage();
        string accessToken = at.AccessToken;
        string toUser = "01";
        string toParty = "";
        string toTag = "";
        string agentId = "5";
        //string content = "此段信息是由后台代码发送的消息，若见此消息代表代码有效01";
        List<Senparc.Weixin.QY.Entities.Article> articles = new List<Senparc.Weixin.QY.Entities.Article>();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "废电瓶出售意向";
        article.Description = "供应商：正气汽车维修店\n数量：10组\n联系人：李峰\n地址：正大路88号\n联系电话：13877777777\n\n提醒消息测试！！！";
        article.Url = "www.0574zy.com";
        articles.Add(article);
        Senparc.Weixin.QY.AdvancedAPIs.MassApi.SendNews(accessToken, toUser, toParty, toTag, agentId, articles);
    }
}