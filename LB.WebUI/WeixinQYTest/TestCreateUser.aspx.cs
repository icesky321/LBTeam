using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.Entities;
using LB.Weixin;
using LB.Weixin.Contact;
using System.Configuration;

/// <summary>
/// 微信企业号中创建用户测试
/// 2017.05.26
/// </summary>
public partial class WeixinQYTest_TestCreateUser : System.Web.UI.Page
{
    LB.WeixinQYWS.MemberService ws_member = new LB.WeixinQYWS.MemberService();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string userId = tbUserId.Text;
        string name = tbUserName.Text;
        int dep = Convert.ToInt32(tbDeps.Text);
        int[] deps = new int[1] { dep };
        string mobile = tbMobile.Text;
        string result = ws_member.CreateMember(userId, name, mobile, LB.WeixinQYWS.部门.地域认证回收员);

        Literal1.Text = result;

    }

}