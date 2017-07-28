using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DepositManage : System.Web.UI.Page
{
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserDepositInfo MUserDepositInfo = new LB.SQLServerDAL.UserDepositInfo();
    LB.BLL.UserDepositInfo bll_userdepositinfo = new LB.BLL.UserDepositInfo();
    LB.BLL.UserAuditMsg bll_UserAuditMsg = new LB.BLL.UserAuditMsg();
    LB.SQLServerDAL.UserAuditMsg MUserAuditMsg = new LB.SQLServerDAL.UserAuditMsg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvUnDealDataBind();
            gvDealDataBind();
        }
    }

    void UserBind(string TelNum)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(TelNum);
        UserNameLabel.Text = MUserInfo.UserName;
        MobilePhoneNumLabel.Text = MUserInfo.MobilePhoneNum;
        ProvinceLabel.Text = MUserInfo.Province;
        CityLabel.Text = MUserInfo.City;
        TownLabel.Text = MUserInfo.Town;
        StreetLabel.Text = MUserInfo.Street;
        IDAuthenticationLabel.Text = MUserInfo.IDAuthentication.ToString();
        if (MUserInfo.IDAuthentication == true)
        {
            IDAuthenticationLabel.Text = Aunth1.msg;
        }
        else
        {
            IDAuthenticationLabel.Text = UnAunth1.msg;
        }
        //AuditLabel.Text = MUserInfo.Audit.ToString();
        if (MUserInfo.Audit == true)
        {
            AuditLabel.Text = Aunth1.msg;
        }
        else
        {
            AuditLabel.Text = UnAunth1.msg;
        }
        BankNameLabel.Text = MUserInfo.BankName;
        AccountLabel.Text = MUserInfo.Account;
    }

    void gvUnDealDataBind()
    {
        //gvUserInfo.DataSource = bll_userinfo.GetUserInfoByUserTypeId(5);
        gvUnDeal.DataSource = bll_UserAuditMsg.GetUserAuditMsgByStatus(false);
        gvUnDeal.DataBind();
        foreach (GridViewRow gvRow in gvUnDeal.Rows)
        {
            string UserId = gvRow.Cells[0].Text;
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).Audit == true)
            {
                ((MultiView)(gvRow.Cells[5].FindControl("MultiView1"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[5].FindControl("MultiView1"))).ActiveViewIndex = 0;
            }
            if (bll_UserAuditMsg.GetUserAuditMsgByUserId(Convert.ToInt32(UserId), false).Status == true)
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView2"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView2"))).ActiveViewIndex = 0;
            }
        }
    }

    void gvDealDataBind()
    {
        gvDeal.DataSource = bll_UserAuditMsg.GetUserAuditMsgByStatus(true);
        gvDeal.DataBind();
        foreach (GridViewRow gvRow in gvDeal.Rows)
        {
            string UserId = gvRow.Cells[0].Text;
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).Audit == true)
            {
                ((MultiView)(gvRow.Cells[5].FindControl("MultiView3"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[5].FindControl("MultiView3"))).ActiveViewIndex = 0;
            }
            if (bll_UserAuditMsg.GetUserAuditMsgByUserId(Convert.ToInt32(UserId), true).Status == true)
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView4"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView4"))).ActiveViewIndex = 0;
            }
        }
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        UserBind(tbTelNum.Text);
    }

    protected void btInSure_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(hfTelNum.Value);
        MUserDepositInfo.UserId = MUserInfo.UserId;
        MUserDepositInfo.Amount = Convert.ToDecimal(tbInDeposit.Text);
        MUserDepositInfo.InDate = Convert.ToDateTime(tbIndate.Text);
        MUserDepositInfo.OutDate = Convert.ToDateTime("1900-1-1");
        MUserDepositInfo.Operator = HttpContext.Current.User.Identity.Name;
        MUserDepositInfo.OperateDate = System.DateTime.Now;
        bll_userdepositinfo.NewUserDepositInfo(MUserDepositInfo);
        lbmsg.Text = "操作成功,保证金和任务处理别忘了打勾哦!";
        gvUnDealDataBind();
        gvDealDataBind();
    }

    protected void btOutSure_Click(object sender, EventArgs e)
    {

        MUserInfo = bll_userinfo.GetUserInfoByTelNum(hfTelNum.Value);
        MUserDepositInfo = bll_userdepositinfo.GetUserDepositInfoByUserId(MUserInfo.UserId);
        MUserDepositInfo.UserId = MUserInfo.UserId;
        MUserDepositInfo.Amount = Convert.ToDecimal(MUserDepositInfo.Amount);
        MUserDepositInfo.OutDate = Convert.ToDateTime(tbOutDate.Text);
        MUserDepositInfo.Operator = HttpContext.Current.User.Identity.Name;
        MUserDepositInfo.OperateDate = System.DateTime.Now;
        if (MUserDepositInfo.Amount != Convert.ToDecimal(tbOutDeposit.Text))
        {
            lbmsg.Text = "金额好像不对哦";
        }
        else
        {
            bll_userdepositinfo.DeleteUserDepositInfo(Convert.ToInt32(MUserDepositInfo.UserId));
            lbmsg.Text = "操作成功,保证金和任务处理别忘了打叉哦!";
        }
        gvUnDealDataBind();
        gvDealDataBind();
    }

    protected void gvUnDeal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Pass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MUserInfo.Audit = true;
            MUserInfo.AuditDate = System.DateTime.Now;
            bll_userinfo.UpdateUserInfo(MUserInfo);
        }
        if (e.CommandName == "UPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MUserInfo.Audit = false;
            MUserInfo.AuditDate = System.DateTime.Now;
            bll_userinfo.UpdateUserInfo(MUserInfo);
        }
        if (e.CommandName == "SPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserAuditMsg = bll_UserAuditMsg.GetUserAuditMsgByUserId(Convert.ToInt32(UserId), false);
            MUserAuditMsg.Status = true;
            bll_UserAuditMsg.UpdateUserAuditMsg(MUserAuditMsg);
        }
        if (e.CommandName == "USPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserAuditMsg = bll_UserAuditMsg.GetUserAuditMsgByUserId(Convert.ToInt32(UserId), false);
            MUserAuditMsg.Status = false;
            bll_UserAuditMsg.UpdateUserAuditMsg(MUserAuditMsg);
        }
        if (e.CommandName == "Operate")
        {

            string MobilePhoneNum = e.CommandArgument.ToString();
            UserBind(MobilePhoneNum);
            hfTelNum.Value = MobilePhoneNum;
        }
        gvDealDataBind();
        gvUnDealDataBind();
    }

    protected void gvDeal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DealPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MUserInfo.Audit = true;
            MUserInfo.AuditDate = System.DateTime.Now;
            bll_userinfo.UpdateUserInfo(MUserInfo);
        }
        if (e.CommandName == "DealUPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MUserInfo.Audit = false;
            MUserInfo.AuditDate = System.DateTime.Now;
            bll_userinfo.UpdateUserInfo(MUserInfo);
        }
        if (e.CommandName == "DealSPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserAuditMsg = bll_UserAuditMsg.GetUserAuditMsgByUserId(Convert.ToInt32(UserId), true);
            MUserAuditMsg.Status = true;
            bll_UserAuditMsg.UpdateUserAuditMsg(MUserAuditMsg);
        }
        if (e.CommandName == "DealUSPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserAuditMsg = bll_UserAuditMsg.GetUserAuditMsgByUserId(Convert.ToInt32(UserId), true);
            MUserAuditMsg.Status = false;
            bll_UserAuditMsg.UpdateUserAuditMsg(MUserAuditMsg);
        }
        if (e.CommandName == "DealOperate")
        {

            string MobilePhoneNum = e.CommandArgument.ToString();
            UserBind(MobilePhoneNum);
            hfTelNum.Value = MobilePhoneNum;
        }
        gvUnDealDataBind();
        gvDealDataBind();
    }
}