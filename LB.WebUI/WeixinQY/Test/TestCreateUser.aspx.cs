using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.QY.AdvancedAPIs;

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
        int[] deps = new int[1] { 1 };
        string mobile = tbMobile.Text;
        MailListApi.CreateMember(accessToken, userId, name, deps, null, mobile);
    }
}