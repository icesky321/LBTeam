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
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
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
            if (bll_user.ExistTelNum(User.Identity.Name))
            {
                ltlUserName.Text = User.Identity.Name;
                ltlUserName1.Text = User.Identity.Name;

                if (ltlUserName.Text.Length != 11)
                    return;

                LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(ltlUserName.Text);
                //ltlUserId.Text = user.UserId.ToString();
                ltlMobile.Text = user.MobilePhoneNum;

                string userType = bll_userType.GetUserTypeById((int)user.UserTypeId).UserTypeName;
                ltlBusiIdentity.Text = userType;
                //ltlBusiIdentity1.Text = userType;

                if (string.IsNullOrEmpty(user.RealName) || string.IsNullOrEmpty(user.BankName) || user.IDAuthentication == false)
                    ltlRealNameVerify.Text = "需补全信息";
                else
                    ltlRealNameVerify.Text = user.RealName;

                if (string.IsNullOrEmpty(user.Address))
                    ltlAddress.Text = "需补全信息";
                else
                    ltlAddress.Text = user.Address;

                if (!bll_copinfo.ExistUseId(user.UserId))
                {
                    Literal2.Text = "需补全信息(如个人请忽略)";
                }
                else
                {
                    Literal2.Text = bll_copinfo.GetCopInfoeByUserId(user.UserId).CopName;
                    //Literal2.Text = "需补全信息(如个人请忽略)";
                }
            }
            else
            {
                Response.Redirect("~/Login/Login.aspx");
            }

        }
    }
}