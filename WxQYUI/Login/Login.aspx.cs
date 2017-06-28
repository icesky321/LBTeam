using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Membership.ValidateUser(tbUserName.Text, tbPassword.Text))
        {
            FormsAuthentication.SetAuthCookie(tbUserName.Text, true, FormsAuthentication.FormsCookiePath);

            Response.Redirect(FormsAuthentication.GetRedirectUrl(tbUserName.Text, false));


            //else
            //{
            //    //((RequiredFieldValidator)Login1.FindControl("VerifyRequired")).Text = "验证码输入错误！";
            //    //Login1.FailureText = "验证码输入错误！";
            //}
        }
        else
        {
            ltlErrorMsg.Visible = true;
            ltlErrorMsg.Text = "用户名或密码输入有误！";
        }
    }
}