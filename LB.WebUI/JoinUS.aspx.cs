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
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["UserId"] != null)
            {
                string UserId = Request.QueryString["UserId"];
                hfUserId.Value = UserId;
                MUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(UserId));
                if (MUserInfo.UserTypeId == 5)
                {
                    if (MUserInfo.Audit == true)
                    {
                        MultiView1.ActiveViewIndex = 1;
                        lbBody.Text = "对不起，您所在的" + MUserInfo.Province + MUserInfo.City + MUserInfo.Town + MUserInfo.Street + " 名额已占，请更改您的地址试试？";
                    }
                    else
                    {
                        MultiView1.ActiveViewIndex = 0;
                        lbNoBody.Text = "恭喜您，您所在的" + MUserInfo.Province + MUserInfo.City + MUserInfo.Town + MUserInfo.Street + " 名额暂缺，请尽快占领此地区，施展您的潜力吧！";
                    }
                }
                else
                {
                    MultiView1.ActiveViewIndex = 2;
                }
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