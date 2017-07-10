using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LB.Weixin;
using LB.Weixin.Message;

/// <summary>
/// SendMsgService 的摘要说明
/// </summary>
[WebService(Namespace = "http://weixin.lvbao111.com/WeixinQY/WS")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class SendMsgService : System.Web.Services.WebService
{

    public SendMsgService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    /// <summary>
    /// 发送文本消息给指定用户
    /// </summary>
    /// <param name="users">用户ID，多个用户用|隔开。</param>
    /// <param name="text">发送消息内容，换行使用\n</param>
    /// <param name="agentId">微信企业号应用ID，默认是“消息通知”5</param>
    /// <returns></returns>
    [WebMethod]
    public string SendTextToUsers(string users, string text, string agentId = "5")
    {
        MsgSender msgSender = new MsgSender();
        Senparc.Weixin.QY.AdvancedAPIs.Mass.MassResult result = msgSender.SendTextToUsers(users, text, agentId);
        return result.errmsg;
    }

    /// <summary>
    /// 发送文本消息给标签组
    /// </summary>
    /// <param name="tags">标签组ID，多个标签用|隔开。</param>
    /// <param name="text">发送消息内容，换行使用\n</param>
    /// <param name="agentId">微信企业号应用ID，默认是“消息通知”5</param>
    /// <returns></returns>
    [WebMethod]
    public string SendTextToTags(string tags, string text, string agentId = "5")
    {
        MsgSender msgSender = new MsgSender();
        Senparc.Weixin.QY.AdvancedAPIs.Mass.MassResult result = msgSender.SendTextToTags(tags, text, agentId);
        return result.errmsg;
    }

}
