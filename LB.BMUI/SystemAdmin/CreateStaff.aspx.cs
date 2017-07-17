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
using System.Linq;

public partial class SystemAdmin_CreateStaff : System.Web.UI.Page
{
    LB.BLL.StaffManage bll_staff = new LB.BLL.StaffManage();

    LB.BLL.UserManage bll_userInfo = new LB.BLL.UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }




    protected void btnCreateUser_Click(object sender, EventArgs e)
    {
        // 创建登录账户
        MembershipUser account = System.Web.Security.Membership.GetUser(tbMobileNum.Text);
        if (account == null)
            Membership.CreateUser(tbMobileNum.Text.Trim(), "12345678");

        // 创建用户信息
        LB.SQLServerDAL.UserInfo user = new LB.SQLServerDAL.UserInfo();
        if (!bll_userInfo.ExistTelNum(tbMobileNum.Text.Trim()))
        {
            user.UserTypeId = 0;
            user.UserName = tbUserName.Text;
            user.RealName = tbRealName.Text;
            user.MobilePhoneNum = tbMobileNum.Text;
            bll_userInfo.NewUserInfo(user);
        }

        // 创建平台员工信息
        LB.SQLServerDAL.Staff staff = new LB.SQLServerDAL.Staff();
        if (!bll_staff.ExistMobile(tbMobileNum.Text.Trim()))
        {
            staff.MobileNum = tbMobileNum.Text;
            staff.UserName = tbUserName.Text;
            staff.JobNumber = tbJobNumber.Text;
            staff.RealName = tbRealName.Text;
            bll_staff.CreateStaff(staff);
        }

        Response.Redirect("StaffManage.aspx");
    }
}
