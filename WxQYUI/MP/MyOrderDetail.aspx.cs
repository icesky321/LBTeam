using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MP_MyOrderDetail : System.Web.UI.Page
{
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sellinfo = new LB.BLL.SellInfoManage();
    LB.BLL.CF_JD_OrderDetail bll_cf_jd_orderdetail = new LB.BLL.CF_JD_OrderDetail();
    Cobe.CnRegion.RegionManage region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["infoId"] != null)
            {
                string infoId = Request.QueryString["infoId"];
                LB.SQLServerDAL.SellInfo MSellInfo = new LB.SQLServerDAL.SellInfo();
                MSellInfo = bll_sellinfo.GetSellInfo_ById(Guid.Parse(infoId));
                if (bll_cf_jd_order.ExistInfoId(Guid.Parse(infoId)))
                {
                    hfinfoId.Value = infoId;
                    MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderByinfoId(Guid.Parse(hfinfoId.Value));
                    hfCFId.Value = MCF_JD_Order.CFId.ToString();
                    lbAmount.Text = MCF_JD_Order.Amount.ToString();
                    lbRemark.Text = MCF_JD_Order.Remark;
                    LB.SQLServerDAL.UserInfo InUserInfo = new LB.SQLServerDAL.UserInfo();
                    LB.SQLServerDAL.UserInfo OutUserInfo = new LB.SQLServerDAL.UserInfo();
                    InUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(MCF_JD_Order.InUserId));
                    OutUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(MCF_JD_Order.OutUserId));
                    lbCFDW.Text = InUserInfo.RealName + "(手机号：" + InUserInfo.MobilePhoneNum + ")\n地址：" + region.GetRegion(InUserInfo.RegionCode).WholeName + InUserInfo.Address;
                    lbJDYWY.Text = OutUserInfo.RealName + "(手机号：" + OutUserInfo.MobilePhoneNum + ")\n地址：" + region.GetRegion(OutUserInfo.RegionCode).WholeName + InUserInfo.Address;
                    btn.Visible = true;
                }
                else
                {
                    //hfCFId.Value = "00000000-0000-0000-0000-000000000000";
                    Response.Redirect("~/ErrorPage/Rehandle.aspx");
                }
                if (MSellInfo.IsClosed)
                {
                    btn.Visible = false;
                }
                //if (User.Identity.IsAuthenticated)
                //{
                //    string userMobile = User.Identity.Name;
                //    LB.SQLServerDAL.UserInfo user = bll_usermanage.GetUserInfoByTelNum(userMobile);
                //    if (user.UserTypeId == 1)
                //    {
                //        btn.Visible = true;
                //    }
                //    else
                //    {
                //        btn.Visible = false;
                //    }
                //}

            }
        }
    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
        LB.SQLServerDAL.SellInfo MSellInfo = new LB.SQLServerDAL.SellInfo();
        MSellInfo = bll_sellinfo.GetSellInfo_ById(Guid.Parse(hfinfoId.Value));
        MSellInfo.StatusMsg = "产废单位已确认";
        MSellInfo.IsClosed = true;
        bll_sellinfo.UpdateSellInfo(MSellInfo);
        MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderByinfoId(Guid.Parse(hfinfoId.Value));
        SendWxArticle_ToCF(MCF_JD_Order.CFId, "1");
        Response.Redirect("MySellInfos.aspx");

    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        LB.SQLServerDAL.SellInfo MSellInfo = new LB.SQLServerDAL.SellInfo();
        MSellInfo = bll_sellinfo.GetSellInfo_ById(Guid.Parse(hfinfoId.Value));
        MSellInfo.JD_TohandleTag = true;
        MSellInfo.JD_AcceptedTag = true;
        MSellInfo.StatusMsg = "回收业务员重新填单";
        bll_sellinfo.UpdateSellInfo(MSellInfo);
        MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderByinfoId(Guid.Parse(hfinfoId.Value));
        SendWxArticle_ToCF(MCF_JD_Order.CFId);
        bll_cf_jd_orderdetail.DeleteCF_JD_OrderDetailByCFId(MCF_JD_Order.CFId);
        bll_cf_jd_order.DeleteCF_JD_OrderByCFId(MCF_JD_Order.CFId);
        Response.Redirect("MySellInfos.aspx");
    }

    private void SendWxArticle_ToCF(Guid CFId)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(CFId);
        LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
        MUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(MCF_JD_Order.OutUserId));
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "产废单位回收单明细";
        article.Description = "收货金额：" + MCF_JD_Order.Amount + "元" + "\n" + "产废单位核实此单有误，请与客户核对后重新填写";
        article.Url = "~/Syb_JD/GoodsReceipt.aspx?infoId=" + MCF_JD_Order.InfoId.ToString();
        sendmsg.SendArticleToUsers(MUserInfo.QYUserId, article, "5");
    }

    private void SendWxArticle_ToCF(Guid CFId, string QYId)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(CFId);
        LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
        MUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(MCF_JD_Order.OutUserId));
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "街道回收员收货单明细";
        article.Description = "街道业务员：" + MUserInfo.RealName + "(" + MUserInfo.MobilePhoneNum + ")" + "收货金额：" + MCF_JD_Order.Amount + "元" + "\n" + "查看明细请继续戳我";
        article.Url = "http://weixin.lvbao111.com/WeixinQY/Syb_hsgs/PayOrder.aspx?CFId=" + CFId;
        sendmsg.SendArticleToUsers(QYId, article, "5");
    }
}