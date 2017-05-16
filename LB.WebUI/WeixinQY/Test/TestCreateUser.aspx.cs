using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.Entities;

public partial class WeixinQY_Test_TestCreateUser : System.Web.UI.Page
{
    //LB.Weixin.AccessTokenManage atManage = new LB.Weixin.AccessTokenManage();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {

        string accessToken = tbAccessToken.Text;
        string userId = tbUserId.Text;
        string name = tbUserName.Text;
        int[] deps = new int[1] { 4 };
        string mobile = tbMobile.Text;
        QyJsonResult result = MailListApi.CreateMember(accessToken, userId, name, deps, null, mobile);

        Literal1.Text = result.errmsg;

    }

    protected void btnCreate2_Click(object sender, EventArgs e)
    {
        LB.Weixin.Contact.MemberManage mm = new LB.Weixin.Contact.MemberManage();
        string accessToken = tbAccessToken.Text;
        string userId = tbUserId.Text;
        string name = tbUserName.Text;
        int[] deps = new int[1] { 4 };
        string mobile = tbMobile.Text;
        QyJsonResult result = mm.CreateMember(userId, name, mobile, LB.Weixin.绿宝部门.地域认证回收员, accessToken);

        Literal1.Text = result.errmsg;
    }
}