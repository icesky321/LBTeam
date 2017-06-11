using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LB.Weixin;
using LB.Weixin.Contact;
using Senparc.Weixin.Entities;

/// <summary>
/// MemberManage 的摘要说明
/// </summary>
[WebService(Namespace = "http://www.lvbao111.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class MemberService : System.Web.Services.WebService
{

    public MemberService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    /// <summary>
    /// 在企业号中创建用户
    /// </summary>
    /// <param name="qyUserId">userId</param>
    /// <param name="name">姓名</param>
    /// <param name="mobile">手机号码</param>
    /// <param name="dep">部门</param>
    /// <returns></returns>
    [WebMethod]
    public string CreateMember(string qyUserId, string name, string mobile, 部门 dep)
    {
        MemberManage mm = new MemberManage();
        BaseAccessTokenManage batManage = new BaseAccessTokenManage();
        string accessToken = batManage.AccessToken;

        QyJsonResult result = mm.CreateMember(qyUserId, name, mobile, 部门.地域认证回收员, accessToken);

        return result.errmsg;
    }
}
