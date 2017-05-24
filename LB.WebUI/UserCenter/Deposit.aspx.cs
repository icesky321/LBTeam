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
            MUserdepositinfo = bll_userepositinfo.GetUserDepositInfoByUserId(MUserInfo.UserId);
            lbDeposit.Text = MUserdepositinfo.Amount.ToString() + "元";
            lbInDate.Text = MUserdepositinfo.InDate.ToString();
        }
    }
}