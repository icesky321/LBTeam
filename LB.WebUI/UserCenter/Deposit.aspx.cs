using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_Deposit : System.Web.UI.Page
{
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.SQLServerDAL.UserDepositInfo MUserdepositinfo = new LB.SQLServerDAL.UserDepositInfo();
    LB.BLL.UserDepositInfo bll_userepositinfo = new LB.BLL.UserDepositInfo();
    LB.SQLServerDAL.UserAuditMsg MUserauditmsg = new LB.SQLServerDAL.UserAuditMsg();
    LB.BLL.UserAuditMsg bll_userauditmsg = new LB.BLL.UserAuditMsg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserBind();
        }

    }

    void MultiViewBind()
    {
        UserBind();

    }

    void UserBind()
    {
        if (Request.IsAuthenticated)
        {
            MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
            if (bll_userepositinfo.ExistUserId(MUserInfo.UserId))
            {
                MultiView1.ActiveViewIndex = 1;

                MUserdepositinfo = bll_userepositinfo.GetUserDepositInfoByUserId(MUserInfo.UserId);
                lbDeposit.Text = MUserdepositinfo.Amount.ToString() + "元";
                lbInDate.Text = MUserdepositinfo.InDate.ToString();
            }
            else
            {
                MultiView1.ActiveViewIndex = 0;
            }

        }
    }

    protected void btOutDeposit_Click(object sender, EventArgs e)
    {
        MUserInfo=bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        MUserauditmsg.UserId = MUserInfo.UserId;
        MUserauditmsg.AccountName = MUserInfo.BankName;
        MUserauditmsg.Account = MUserInfo.Account;
        MUserauditmsg.CreateDate = System.DateTime.Now;
        MUserauditmsg.Message = "用户：" + MUserInfo.UserName + "手机号：" + MUserInfo.MobilePhoneNum + "要退押金";
        MUserauditmsg.Status = false;
        bll_userauditmsg.NewUserAuditMsg(MUserauditmsg);
    }

    protected void btLocal_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        string url = "../JoinUS.aspx?UserId=" + MUserInfo.UserId.ToString();
        Response.Redirect(url);
    }
}