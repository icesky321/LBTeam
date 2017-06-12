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
        int dep = Convert.ToInt32(tbDeps.Text);
        int[] deps = new int[1] { dep };
        string mobile = tbMobile.Text;
        QyJsonResult result = MailListApi.CreateMember(accessToken, userId, name, deps, null, mobile);

        Literal1.Text = result.errmsg;

    }

    protected void btnCreate2_Click(object sender, EventArgs e)
    {
        MemberManage mm = new MemberManage();
        string accessToken = tbAccessToken.Text;
        string userId = tbUserId.Text;
        string name = tbUserName.Text;

        string mobile = tbMobile.Text;
        QyJsonResult result = mm.CreateMember(userId, name, mobile, 部门.地域认证回收员, accessToken);

        Literal1.Text = result.errmsg;
    }

    protected void btnGetAT_Click(object sender, EventArgs e)
    {
        string accessToken = string.Empty;
        string serviceUri = ConfigurationManager.AppSettings["AccessTokenServiceUri"] ?? "";
        if (!string.IsNullOrEmpty(serviceUri))
        {
            accessToken = Senparc.Weixin.HttpUtility.RequestUtility.HttpGet(serviceUri, null);
        }
        tbAccessToken.Text = accessToken;

    }
}