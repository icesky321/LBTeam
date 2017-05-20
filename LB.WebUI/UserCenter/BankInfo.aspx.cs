using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_BankInfo : System.Web.UI.Page
{
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Response.Redirect("../Admin/Manage.aspx");
                }
                else
                {
                    {
                        UserBind();
                    }
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }

        }
    }

    void UserBind()
    {
        if (Request.IsAuthenticated)
        {
            MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
            lbBankName.Text = MUserInfo.BankName;
            lbAccount.Text = MUserInfo.Account;
            tbUpdateBankName.Text= MUserInfo.BankName;
            tbUpdateAccount.Text = MUserInfo.Account;
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }

    protected void btUpdate_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        MUserInfo.BankName = tbUpdateBankName.Text;
        MUserInfo.Account = tbUpdateAccount.Text;
        bll_userinfo.UpdateUserInfo(MUserInfo);
        MultiView1.ActiveViewIndex = 0;
        UserBind();
    }
}