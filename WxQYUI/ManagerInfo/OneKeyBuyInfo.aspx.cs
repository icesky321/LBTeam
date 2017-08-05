using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerInfo_OneKeyBuyInfo : System.Web.UI.Page
{
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.PaymentDetail bll_paymentdetail = new LB.BLL.PaymentDetail();
    LB.SQLServerDAL.PaymentDetail MPaymentDetail = new LB.SQLServerDAL.PaymentDetail();
    LB.BLL.SellInfoManage bll_sellinfo = new LB.BLL.SellInfoManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["CFId"] != null)
            {
                hfCFId.Value = Request.QueryString["CFId"];
                Load(Guid.Parse(hfCFId.Value));
            }
            else
            {
                hfCFId.Value = "09b4d20a-72aa-4bc2-a398-34eabeac85d0";
                Load(Guid.Parse(hfCFId.Value));
            }
        }
    }

    void Load(Guid CFId)
    {
        MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(CFId);
        lbAmount.Text = MCF_JD_Order.Amount.ToString();
        lbReamrk.Text = MCF_JD_Order.Remark;
    }
}