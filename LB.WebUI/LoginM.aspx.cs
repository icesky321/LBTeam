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

        //((TextBox)Login1.FindControl("UserName")).Attributes.Add("onfocus", "this.className='focustext';");
        //((TextBox)Login1.FindControl("UserName")).Attributes.Add("onblur", "this.className=''blurtext'';");
        //((TextBox)Login1.FindControl("Password")).Attributes.Add("onfocus", "this.className='focustext';");
        //((TextBox)Login1.FindControl("Password")).Attributes.Add("onblur", "this.className=''blurtext'';");
        //((TextBox)Login1.FindControl("tbVerify")).Attributes.Add("onfocus", "this.className='focustext';");
        //((TextBox)Login1.FindControl("tbVerify")).Attributes.Add("onblur", "this.className=''blurtext'';");
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

                if ((User.IsInRole("Admin") == true))
                {
                    //Label1.Text = HttpContext.Current.User.Identity.Name;
                    Response.Redirect("~/Admin/Manage.aspx");
                }
                else
                {
                    //Label1.Text = HttpContext.Current.User.Identity.Name + "1";
                    Response.Redirect("Default.aspx");
                }
            }


            else
            {
                ((RequiredFieldValidator)Login1.FindControl("VerifyRequired")).Text = "验证码输入错误！";
            }
        }

    }

    protected void lbtnForget_Click(object sender, EventArgs e)
    {
        Response.Redirect("RecoverPWD.aspx");
    }
}
