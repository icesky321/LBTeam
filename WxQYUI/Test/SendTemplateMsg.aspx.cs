using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities.Menu;
using Senparc.Weixin.MP.AdvancedAPIs;
using System.Configuration;
using LB.WeixinMP;

public partial class SendTemplateMsg : System.Web.UI.Page
{
    string appId = string.Empty;
    string appSecret = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {


    }

    private void SendShortMsg()
    {
        if (ConfigurationManager.AppSettings["AppId"] != null)
        {
            appId = ConfigurationManager.AppSettings["AppId"];
            appSecret = ConfigurationManager.AppSettings["AppSecret"];
        }
        BaseAccessTokenManage bat = new BaseAccessTokenManage();
        var commonAccessToken = bat.AccessToken;
        //string openId = "oOP4JwivBNerfDcFyetChe5cw2Vw"; // 李峰在绿宝服务号中的OpenId
        string openId = "oOP4JwmLfZaGeHomkHVvhEHMoeAY"; // 曹俊

        TMData_下单成功通知 data = new TMData_下单成功通知();
        data.first.value = "下单成功，绿宝三益电瓶回收平台已收到您的预约单！\n";
        data.keyword1.value = "废旧电瓶回收";
        data.keyword2.value = DateTime.Now.Date.ToShortDateString() + "\n";
        data.remark.value = "您的预约单在审核后将指派回收人员在24小时内上门回收，请耐心等待";
        data.Url= "http://weixin.lvbao111.com/WeixinQY/MP/MyOrderDetail.aspx?infoId=17aae7fd-4cae-432d-8c29-d3768175d5cd";
        TMSender tmSender = new TMSender();
        tmSender.SendWx_ToOpenId(commonAccessToken, openId, data);

    }



    protected void btnSend_Click(object sender, EventArgs e)
    {
        SendShortMsg();
    }
}