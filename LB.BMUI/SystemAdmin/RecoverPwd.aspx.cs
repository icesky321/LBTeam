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

public partial class Admin_RecoverPwd : System.Web.UI.Page
{
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbUserName.Text = HttpContext.Current.User.Identity.Name;
        }
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        if (Membership.ValidateUser(lbUserName.Text, tbPwd.Text) == true)
        {
            Membership.GetUser(lbUserName.Text).ChangePassword(tbPwd.Text, tbConfirmPassword.Text);
            lbMsg.Visible = true;
        }
    }
}
