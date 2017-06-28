using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_uc_cfdw : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.BLL.UserTypeInfo bll_userType = new LB.BLL.UserTypeInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        if (User.Identity.IsAuthenticated)
        {
            ltlUserName.Text = User.Identity.Name;
            ltlUserName1.Text = User.Identity.Name;

            if (ltlUserName.Text.Length != 11)
                return;

            LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(ltlUserName.Text);
            ltlUserId.Text = user.UserId.ToString();
            ltlMobile.Text = user.MobilePhoneNum;

            string userType = bll_userType.GetUserTypeById((int)user.UserTypeId).UserTypeName;
            ltlBusiIdentity.Text = userType;
            ltlBusiIdentity1.Text = userType;

            if (string.IsNullOrEmpty(user.RealName))
                ltlRealNameVerify.Text = "未实名";
            else
                ltlRealNameVerify.Text = user.RealName;

            if (string.IsNullOrEmpty(user.Address))
                ltlAddress.Text = "(空)";
            else
                ltlAddress.Text = user.Address;


        }
    }
}