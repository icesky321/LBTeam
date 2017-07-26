using System;
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
            Label ltlPayeeName = e.Item.FindControl("ltlPayeeName") as Label;
            Label ltlBankName = e.Item.FindControl("ltlBankName") as Label;
            Label ltlAccount = e.Item.FindControl("ltlAccount") as Label;
            Label lbTotalAmount = e.Item.FindControl("lbTotalAmount") as Label;

            Label lbZFBName = e.Item.FindControl("lbZFBName") as Label;
            Label lbZFBAccount = e.Item.FindControl("lbZFBAccount") as Label;
            Label lbWXAccount = e.Item.FindControl("lbWXAccount") as Label;
            Label lbWXName = e.Item.FindControl("lbWXName") as Label;
            HiddenField hfQYUserId = e.Item.FindControl("hfQYUserId") as HiddenField;
            MultiView MultiView4 = e.Item.FindControl("MultiView4") as MultiView;
            decimal Total = bll_paymentdetail.GetAmountSumByUserId(MUserInfo.UserId);
            //decimal Wait = System.Math.Abs(bll_paymentdetail.GetWaitAmountSumByUserId(MUserInfo.UserId));
            decimal Over = System.Math.Abs(bll_paymentdetail.GetOverAmountSumByUserId(MUserInfo.UserId));
            decimal rest = Total - Over;

            ltlRealName.Text = MUserInfo.RealName;
            ltlPhone.Text = MUserInfo.MobilePhoneNum;
            ltlPayeeName.Text = MUserInfo.PayeeName;
            ltlBankName.Text = MUserInfo.BankName;
            ltlAccount.Text = MUserInfo.Account;
            lbZFBName.Text = MUserInfo.ZfbName;
            lbZFBAccount.Text = MUserInfo.ZfbAccount;
            lbWXName.Text = MUserInfo.WxName;
            lbWXAccount.Text = MUserInfo.WxAccount;
            lbTotalAmount.Text = rest.ToString() + "元";
            hfQYUserId.Value = MUserInfo.QYUserId;
            if (MPaymentDetail.TransferMethod == "网银转账")
            {
                MultiView4.ActiveViewIndex = 0;
            }
            else if (MPaymentDetail.TransferMethod == "支付宝")
            {
                MultiView4.ActiveViewIndex = 1;
            }
            else if (MPaymentDetail.TransferMethod == "微信")
            {
                MultiView4.ActiveViewIndex = 2;
            }
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