using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JoinUS : System.Web.UI.Page
{
    LB.SQLServerDAL.UserAuditMsg MUserAuditMsg = new LB.SQLServerDAL.UserAuditMsg();
    LB.BLL.UserAuditMsg bll_userauditmsg = new LB.BLL.UserAuditMsg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["UserId"] != null)
            {
                string UserId = Request.QueryString["UserId"];
                hfUserId.Value = UserId;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        MUserAuditMsg.Account = tbAccount.Text;
        MUserAuditMsg.AccountName = tbName.Text;
        MUserAuditMsg.Ammount = tbAmount.Text;
        MUserAuditMsg.Message = tbMessage.Text;
        MUserAuditMsg.Status = false;
        MUserAuditMsg.CreateDate = System.DateTime.Now;
        MUserAuditMsg.UserId = Convert.ToInt32(hfUserId.Value);
        bll_userauditmsg.NewUserAuditMsg(MUserAuditMsg);
        Response.Redirect("~/WaitingForAudit.aspx");
    }
}