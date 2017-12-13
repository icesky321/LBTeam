using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login_RetrievalPwd : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRetrievalPwd_Click(object sender, EventArgs e)
    {
        System.Web.Security.MembershipUser user = Membership.GetUser(tbMobileNum.Text);
        string pwd = user.GetPassword();
        LB.BLL.SMS sms = new LB.BLL.SMS();
        //sms.SendSMS("13958202267", "[绿宝科技]验证码：123456，此验证码即为您的当前登录密码，请登录后立即更改您的登录密码。");
        sms.SendSMS(tbMobileNum.Text, "验证码：" + pwd + "。此验证码即为您的账户登录密码，请牢记或者重设密码。【绿宝】");
        Response.Redirect("~/ErrorPage/Success.aspx");
    }
}