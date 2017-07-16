﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundManage_LoanAudit : System.Web.UI.Page
{
    LB.SQLServerDAL.PaymentDetail MPaymentDetail = new LB.SQLServerDAL.PaymentDetail();
    LB.BLL.PaymentDetail bll_paymentdetail = new LB.BLL.PaymentDetail();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            MPaymentDetail = e.Item.DataItem as LB.SQLServerDAL.PaymentDetail;
            if (MPaymentDetail == null)
                return;
            int UserId = Convert.ToInt32(MPaymentDetail.UserId);
            MUserInfo = bll_usermanage.GetUserInfoByUserId(UserId);
            Label ltlRealName = e.Item.FindControl("ltlRealName") as Label;
            Label ltlPhone = e.Item.FindControl("ltlPhone") as Label;
            Label ltlAddress = e.Item.FindControl("ltlAddress") as Label;
            Label ltlBankName = e.Item.FindControl("ltlBankName") as Label;
            Label ltlAccount = e.Item.FindControl("ltlAccount") as Label;
            HiddenField hfQYUserId = e.Item.FindControl("hfQYUserId") as HiddenField;

            ltlRealName.Text = MUserInfo.RealName;
            ltlPhone.Text = MUserInfo.MobilePhoneNum;
            ltlBankName.Text = MUserInfo.BankName;
            ltlAccount.Text = MUserInfo.Account;
            hfQYUserId.Value = MUserInfo.QYUserId;

        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Guid PDId = Guid.Empty;
        Guid.TryParse(e.CommandArgument.ToString(), out PDId);
        if (PDId == Guid.Empty)
            return;
        if (e.CommandName == "Accept")
        {
            MPaymentDetail = bll_paymentdetail.GetPaymentDetailByPDId(PDId);
            MPaymentDetail.PayStatus = "结清";
            MPaymentDetail.Audit = User.Identity.Name;
            MPaymentDetail.AuditDate = System.DateTime.Now;
            bll_paymentdetail.UpdatePaymentDetail(MPaymentDetail);
        }
        if (e.CommandName == "Reject")
        {
            MPaymentDetail = bll_paymentdetail.GetPaymentDetailByPDId(PDId);
            MPaymentDetail.PayStatus = "作废";
            MPaymentDetail.Audit = User.Identity.Name;
            MPaymentDetail.AuditDate = System.DateTime.Now;
            bll_paymentdetail.UpdatePaymentDetail(MPaymentDetail);
        }
        Repeater1.DataBind();
    }
}