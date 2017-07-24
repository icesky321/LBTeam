using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_hsgs_PayOrder : System.Web.UI.Page
{
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.PaymentDetail bll_paymentdetail = new LB.BLL.PaymentDetail();
    LB.SQLServerDAL.PaymentDetail MPaymentDetail = new LB.SQLServerDAL.PaymentDetail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["CFId"] != null)
            {
                hfCFId.Value = Request.QueryString["CFId"];
                Load(Guid.Parse(hfCFId.Value));
                if (bll_paymentdetail.ExistCFId(Guid.Parse(hfCFId.Value)))
                {
                    pageRegCompleted.Visible = true;
                    page1.Visible = false;
                }
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



    protected void btSure_Click(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(Guid.Parse(hfCFId.Value));
            MUserInfo = bll_usermanage.GetUserInfoByTelNum(User.Identity.Name);
            MCF_JD_Order.CopUserId = MUserInfo.UserId;
            MCF_JD_Order.CopUserAudit = true;
            MCF_JD_Order.CopAuditDate = System.DateTime.Now;
            bll_cf_jd_order.UpdateCF_JD_Order(MCF_JD_Order);
            MPaymentDetail.Amount = MCF_JD_Order.Amount;
            MPaymentDetail.UserId = MCF_JD_Order.InUserId;
            MPaymentDetail.CreateDate = System.DateTime.Now;
            MPaymentDetail.PayStatus = "已打款";
            MPaymentDetail.CFId = MCF_JD_Order.CFId;
            MPaymentDetail.TransferMethod = "";
            bll_paymentdetail.newPaymentDetail(MPaymentDetail);
            SendWxArticle_ToCF("100", "回收公司已付款,付款编号：" + MCF_JD_Order.CFId + "\n" + "付款金额：" + MCF_JD_Order.Amount, "请到管理后台-回收公司订单审核");
            Response.Redirect("Success.aspx");
        }

    }


    private void SendWxArticle_ToCF(string QYId, string title, string description)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = title;
        article.Description = description;
        sendmsg.SendArticleToUsers(QYId, article, "5");
    }
}