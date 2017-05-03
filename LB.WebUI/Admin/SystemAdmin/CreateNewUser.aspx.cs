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

public partial class Admin_UserAdmin_CreateNewUser : System.Web.UI.Page
{
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnCreateUser_Click(object sender, EventArgs e)
    {
        Membership.CreateUser(tbUserName.Text.Trim(), tbPassword.Text);
        MUserInfo.MobilePhoneNum = tbMobileNum.Text;
        MUserInfo.Province= Request.Params["province"].ToString();
        MUserInfo.City= Request.Params["city"].ToString();
        MUserInfo.Town = Request.Params["country"].ToString();
        MUserInfo.Street = Request.Params["street"].ToString();
        MUserInfo.CreateTime = System.DateTime.Now;
        Response.Redirect("UpdateEmployee.aspx?Account=" + tbUserName.Text.Trim());
    }
}
