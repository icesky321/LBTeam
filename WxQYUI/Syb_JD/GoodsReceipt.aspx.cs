using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_Dyywy_GoodsReceipt : System.Web.UI.Page
{
    LB.BLL.UnitInfo bll_unitinfo = new LB.BLL.UnitInfo();
    LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    LB.BLL.CF_JD_OrderDetail bll_cf_jd_orderdetail = new LB.BLL.CF_JD_OrderDetail();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sellinfomanage = new LB.BLL.SellInfoManage();
    LB.SQLServerDAL.SellInfo MSellInfo = new LB.SQLServerDAL.SellInfo();
    SendMsgService sendmsg = new SendMsgService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["InfoId"] != null)
            {
                string InfoId = Request.QueryString["InfoId"];
                hfInfoId.Value = InfoId;
                MSellInfo = bll_sellinfomanage.GetSellInfo_ById(Guid.Parse(hfInfoId.Value));
                LB.SQLServerDAL.UserInfo InUserInfo = new LB.SQLServerDAL.UserInfo();
                LB.SQLServerDAL.UserInfo OutUserInfo = new LB.SQLServerDAL.UserInfo();
                InUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.CF_UserId);
                OutUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.JD_UserId);
                tbcfdw.Text = InUserInfo.MobilePhoneNum;
                tbjdywy.Text = OutUserInfo.MobilePhoneNum;
            }

        }
    }


    protected void btSure_Click(object sender, EventArgs e)
    {
        MCF_JD_Order.InUserId = bll_usermanage.GetUserInfoByTelNum(tbcfdw.Text).UserId;
        MCF_JD_Order.OutUserId = bll_usermanage.GetUserInfoByTelNum(tbjdywy.Text).UserId;
        MCF_JD_Order.Amount = Convert.ToDecimal(tbAmount.Text);
        MCF_JD_Order.TransferMethod = "银行转账";
        MCF_JD_Order.Remark = tbRemark.Text;
        MCF_JD_Order.TransferDate = System.DateTime.Now;
        MCF_JD_Order.OperatorConfirm = false;
        MCF_JD_Order.OperateDate = Convert.ToDateTime("1900-01-01");
        MCF_JD_Order.Audit = false;
        MCF_JD_Order.AuditDatetime = Convert.ToDateTime("1900-01-01");
        MCF_JD_Order.InfoId = Guid.Parse(hfInfoId.Value);
        MCF_JD_Order.CopId = 1007;//数据库中是杭州赐翔
        bll_cf_jd_order.NewCF_JD_Order(MCF_JD_Order);
        foreach (RepeaterItem item in Repeater1.Items)
        {
            Literal ltlTSName = item.FindControl("ltlTSName") as Literal;
            TextBox tbNum = item.FindControl("tbNum") as TextBox;
            DropDownList ddlUnitInfo = item.FindControl("ddlUnitInfo") as DropDownList;
            if (tbNum.Text != "")
            {
                LB.SQLServerDAL.CF_JD_OrderDetail MCF_JD_OrderDetail = new LB.SQLServerDAL.CF_JD_OrderDetail();
                MCF_JD_OrderDetail.CFId = MCF_JD_Order.CFId;
                MCF_JD_OrderDetail.GoodsDetail = ltlTSName.Text;
                MCF_JD_OrderDetail.Quantity = Convert.ToDecimal(tbNum.Text);
                MCF_JD_OrderDetail.GoodsUnit = ddlUnitInfo.SelectedItem.Text;
                bll_cf_jd_orderdetail.NewCF_JD_OrderDetail(MCF_JD_OrderDetail);
            }

        }
        MSellInfo = bll_sellinfomanage.GetSellInfo_ById(Guid.Parse(hfInfoId.Value));
        MSellInfo.IsClosed = true;
        bll_sellinfomanage.UpdateSellInfo(MSellInfo);
        //sendmsg.SendTextToUsers("2", "哈哈哈");
        Response.Redirect("Success.aspx?CFId=" + MCF_JD_Order.CFId.ToString());
        SendWxArticle_ToCF("2", "回收公司已付款", "请到管理后台-回收公司订单审核");
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