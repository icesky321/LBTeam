using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MP_Deposit : System.Web.UI.Page
{
    LB.SQLServerDAL.UserAuditMsg MUserAuditMsg = new LB.SQLServerDAL.UserAuditMsg();
    LB.BLL.UserAuditMsg bll_userauditmsg = new LB.BLL.UserAuditMsg();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
                login.Visible = false;
            }
            else
            {
                login.Visible = true;
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            MUserAuditMsg.Account = tbAccount.Value;
            MUserAuditMsg.AccountName = tbName.Value;
            MUserAuditMsg.Ammount = tbAmount.Value;
            MUserAuditMsg.Message = tbAdditionText.Value;
            MUserAuditMsg.Status = false;
            MUserAuditMsg.CreateDate = System.DateTime.Now;

            string username = User.Identity.Name;
            MUserAuditMsg.UserId = Convert.ToInt32(bll_usermanage.GetUserInfoByTelNum(username).UserId);
            bll_userauditmsg.NewUserAuditMsg(MUserAuditMsg);
            Response.Redirect("WaitAudit.aspx");
        }
        else
        {
            lbMsg.Text = "请先注册或登录!";
        }

    }
}