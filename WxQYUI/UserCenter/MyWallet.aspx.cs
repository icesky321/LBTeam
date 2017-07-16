using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_MyWallet : System.Web.UI.Page
{
    LB.BLL.PaymentDetail bll_paymentdetail = new LB.BLL.PaymentDetail();
    LB.SQLServerDAL.PaymentDetail MPaymentDetail = new LB.SQLServerDAL.PaymentDetail();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
                MUserInfo = bll_usermanage.GetUserInfoByTelNum(User.Identity.Name);
                if (bll_paymentdetail.ExistUserId(MUserInfo.UserId))
                {
                    lbTotalMoney.Text = bll_paymentdetail.GetAmountSumByUserId(MUserInfo.UserId).ToString();
                    lbWaitMoney.Text = System.Math.Abs(bll_paymentdetail.GetWaitAmountSumByUserId(MUserInfo.UserId)).ToString();
                }
                else
                {
                    lbTotalMoney.Text = "0";
                    lbWaitMoney.Text = "0";
                }
            }
        }
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(lbTotalMoney.Text) != 0)
        {
            MUserInfo = bll_usermanage.GetUserInfoByTelNum(User.Identity.Name);
            MPaymentDetail.Amount = Convert.ToDecimal("-" + lbTotalMoney.Text);
            MPaymentDetail.UserId = MUserInfo.UserId;
            MPaymentDetail.CreateDate = System.DateTime.Now;
            MPaymentDetail.PayStatus = "待审核";
            MPaymentDetail.AuditDate = Convert.ToDateTime("1900-01-01");
            bll_paymentdetail.newPaymentDetail(MPaymentDetail);
            Response.Redirect("MyWallet.aspx#pageRegCompleted", true);
        }
        else
        {
            Response.Redirect("MyWallet.aspx#errorPage", true);
        }
    }
}