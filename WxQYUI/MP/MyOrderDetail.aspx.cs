using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using LB.WeixinMP;

public partial class MP_MyOrderDetail : System.Web.UI.Page
{
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sellinfo = new LB.BLL.SellInfoManage();
    LB.BLL.CF_JD_OrderDetail bll_cf_jd_orderdetail = new LB.BLL.CF_JD_OrderDetail();
    Cobe.CnRegion.RegionManage region = new Cobe.CnRegion.RegionManage();
    LB.BLL.CityManager_Config bll_citymanage_config = new LB.BLL.CityManager_Config();
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
                    //lbCFDW.Text = InUserInfo.RealName + "(手机号：" + InUserInfo.MobilePhoneNum + ")\n地址：" + region.GetRegion(MSellInfo.CF_RegionCode).WholeName + InUserInfo.Address;

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
        //SendWxArticle_ToCF(MCF_JD_Order.CFId, "1");
        LB.SQLServerDAL.CityManager_Config MCityManager_config = new LB.SQLServerDAL.CityManager_Config();
        MCityManager_config = bll_citymanage_config.GetCityManager_ConfigByRegionCode(MSellInfo.CF_RegionCode.Substring(0, 4));
        if (MCityManager_config != null)
        {
            LB.SQLServerDAL.UserInfo MUser = new LB.SQLServerDAL.UserInfo();
            MUser = bll_usermanage.GetUserInfoByUserId(MCityManager_config.UserId);
            SendWxArticle_ToCityManager(MUser.QYUserId, MSellInfo);
        }
        else
        {
            // 以下设计思路，如果在工作时间，审核信息发送给“信息客服”，如果在非工作时间，信息发送给“信息客服后备”。
            // 4信息客服后备，3信息客服
            TimeSpan tsBegin = new TimeSpan(8, 0, 0);
            TimeSpan tsEnd = new TimeSpan(17, 30, 0);
            if ((int)DateTime.Now.DayOfWeek >= 1 && (int)DateTime.Now.DayOfWeek <= 5 && DateTime.Now.TimeOfDay >= tsBegin && DateTime.Now.TimeOfDay < tsEnd)
                SendWxArticle_ToKefu("5", MSellInfo);
            else
                SendWxArticle_ToKefu("6", MSellInfo);
        }
        LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
        MUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.CF_UserId);
        if (!string.IsNullOrEmpty(MUserInfo.OpenId))
        {
            SendShortMsg(MUserInfo.OpenId, MCF_JD_Order);
        }
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

    private void SendWxArticle_ToKefu(string toTags, LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
        MUserInfo = bll_usermanage.GetUserInfoByUserId(sellInfo.CF_UserId);
        article.Title = "有出售信息需要审核";
        article.Description = "产废单位（" + region.GetRegion(MUserInfo.RegionCode).WholeName + MUserInfo.Address + "）发布了一条出售信息，请点击该条信息直接审核，或到客服管理平台→业务信息审核栏目进行审核。";
        //article.Url = "http://weixin.lvbao111.com/WeixinQY/Kefu_Info/SellInfo_Handle.aspx?infoId=" + sellInfo.InfoId.ToString();
        article.Url = "http://weixin.lvbao111.com/WeixinQY/Kefu_Info/DispatchManage.aspx";
        sendmsg.SendArticleToTags(toTags, article, "5");
    }

    private void SendShortMsg(string openId,LB.SQLServerDAL.CF_JD_Order MCF_JD_Order)
    {
        string appId = string.Empty;
        string appSecret = string.Empty;
        if (ConfigurationManager.AppSettings["AppId"] != null)
        {
            appId = ConfigurationManager.AppSettings["AppId"];
            appSecret = ConfigurationManager.AppSettings["AppSecret"];
        }
        BaseAccessTokenManage bat = new BaseAccessTokenManage();
        var commonAccessToken = bat.AccessToken;
        DateTime myDateTime;
        myDateTime = Convert.ToDateTime(MCF_JD_Order.OperateDate);
        

        TMData_回收成功通知 data = new TMData_回收成功通知();
        data.first.value = "您好，回收业务员已回收您货品。";

        data.keyword1.value = myDateTime.Year.ToString() + myDateTime.Month.ToString() + myDateTime.Day.ToString() + myDateTime.Hour.ToString() + myDateTime.Minute.ToString() + myDateTime.Second.ToString() + myDateTime.Millisecond.ToString();
        data.keyword2.value = "详见明细（回收业务-->我的出售）";
        data.keyword3.value = MCF_JD_Order.Amount.ToString() + "元";
        data.keyword4.value = MCF_JD_Order.TransferDate.ToString();
        data.remark.value = "感谢您使用绿宝三益电瓶回收平台，欢迎持续关注并下单！";
        //data.Url
        TMSender tmSender = new TMSender();
        tmSender.SendWx_ToOpenId(commonAccessToken, openId, data);

    }

    private void SendWxArticle_ToCityManager(string QYId, LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
        MUserInfo = bll_usermanage.GetUserInfoByUserId(sellInfo.CF_UserId);
        article.Title = "回收业务成功";
        article.Description = "产废单位（" + region.GetRegion(MUserInfo.RegionCode).WholeName + MUserInfo.Address + "）已确认货物明细及金额";
        article.Url = "http://weixin.lvbao111.com/WeixinQY/MP/MyOrderDetail.aspx?infoId=" + sellInfo.InfoId.ToString(); ;
        sendmsg.SendArticleToUsers(QYId, article, "5");
    }
}