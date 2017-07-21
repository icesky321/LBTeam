using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CF_JD_OrderManage : System.Web.UI.Page
{
    LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    LB.BLL.PaymentDetail bll_paymentdetail = new LB.BLL.PaymentDetail();
    LB.SQLServerDAL.PaymentDetail MPaymentDetail = new LB.SQLServerDAL.PaymentDetail();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbInNum = e.Item.FindControl("lbInNum") as Label;
            Label lbInUserId = e.Item.FindControl("lbInUserId") as Label;
            LB.SQLServerDAL.UserInfo InMUserInfo = new LB.SQLServerDAL.UserInfo();
            InMUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(lbInUserId.Text));
            lbInNum.Text = InMUserInfo.MobilePhoneNum;
            Label lbOutNum = e.Item.FindControl("lbOutNum") as Label;
            Label lbOutUserId = e.Item.FindControl("lbOutUserId") as Label;
            LB.SQLServerDAL.UserInfo OutMUserInfo = new LB.SQLServerDAL.UserInfo();
            OutMUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(lbOutUserId.Text));
            lbOutNum.Text = OutMUserInfo.MobilePhoneNum;
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Audit")//判断这个Item里哪个控件响应的这个事件  
        {
            string CFId = (string)e.CommandArgument;//获取Item传过来的参数  
            MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(Guid.Parse(CFId));
            MCF_JD_Order.AuditOperator = User.Identity.Name;
            MCF_JD_Order.AuditDatetime = System.DateTime.Now;
            MCF_JD_Order.Audit = true;
            bll_cf_jd_order.UpdateCF_JD_Order(MCF_JD_Order);
            MPaymentDetail = bll_paymentdetail.GetPaymentDetailByCFId(Guid.Parse(CFId));
            MPaymentDetail.PayStatus = "已到款";
            MPaymentDetail.Audit = User.Identity.Name;
            MPaymentDetail.AuditDate = System.DateTime.Now;
            bll_paymentdetail.UpdatePaymentDetail(MPaymentDetail);
            Repeater1.DataBind();
            string jd_qyid = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(MCF_JD_Order.OutUserId)).QYUserId;

            //string cop_qyid= bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(MCF_JD_Order.CopUserId)).QYUserId;
            SendWxArticle_ToCF(Guid.Parse(CFId), jd_qyid);
            //SendWxArticle_ToCF(Guid.Parse(CFId), cop_qyid);
        }
    }

    private void SendWxArticle_ToCF(Guid CFId,string QYId)
    {
        //TODO: 发布前修改微信发布逻辑
        MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(CFId);
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "平台货款确认";
        article.Description = "平台已收到货款" + MCF_JD_Order.Amount + "元";
        sendmsg.SendArticleToUsers(QYId, article, "5");
    }
}