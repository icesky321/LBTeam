using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Response.Cookies.Add(new HttpCookie("CheckCode", ""));

        }
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {

    }
    protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (Membership.ValidateUser(Login1.UserName, Login1.Password))
        {
            FormsAuthentication.SetAuthCookie(Login1.UserName, true, FormsAuthentication.FormsCookiePath);

            if (Request.Cookies["CheckCode"].Value.Equals(((TextBox)Login1.FindControl("tbVerify")).Text.ToString()))
            {

                Response.Redirect("Manage.aspx");

            }


            else
            {
                //((RequiredFieldValidator)Login1.FindControl("VerifyRequired")).Text = "验证码输入错误！";
                Login1.FailureText = "验证码输入错误！";
            }
        }

    }

    protected void lbtnForget_Click(object sender, EventArgs e)
    {
        Response.Redirect("RecoverPWD.aspx");
    }

    protected void lbtnNewUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChooseRoles.aspx");
    }
}
