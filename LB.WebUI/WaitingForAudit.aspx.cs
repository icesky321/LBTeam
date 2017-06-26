using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WaitingForAudit : System.Web.UI.Page
{
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name).Audit == false)
        {
            btDeposit.Visible = true;
        }
        else
        {
            btDeposit.Visible = true;
        }
    }

    protected void btDeposit_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        string url = "JoinUS.aspx?UserId=" + MUserInfo.UserId.ToString();
        Response.Redirect(url);
    }
}