using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using LB.WeixinMP;

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
    //LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    //LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.PaymentDetail bll_paymentdetail = new LB.BLL.PaymentDetail();
    Cobe.CnRegion.RegionManage region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["InfoId"] != null)
            {
                string InfoId = Request.QueryString["InfoId"];
                hfInfoId.Value = InfoId;
                if (bll_cf_jd_order.ExistInfoId(Guid.Parse(hfInfoId.Value)))
                {
                    LB.SQLServerDAL.CF_JD_Order Mcf = new LB.SQLServerDAL.CF_JD_Order();
                    Mcf = bll_cf_jd_order.GetCF_JD_OrderByinfoId(Guid.Parse(hfInfoId.Value));
                    Response.Redirect("Success.aspx?CFId=" + Mcf.CFId.ToString());
                }
                else
                {
                    MSellInfo = bll_sellinfomanage.GetSellInfo_ById(Guid.Parse(hfInfoId.Value));
                    LB.SQLServerDAL.UserInfo InUserInfo = new LB.SQLServerDAL.UserInfo();
                    LB.SQLServerDAL.UserInfo OutUserInfo = new LB.SQLServerDAL.UserInfo();
                    InUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.CF_UserId);
                    OutUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.JD_UserId);
                    lbCf.Text = InUserInfo.RealName + "\n地址：" + region.GetRegion(InUserInfo.RegionCode).WholeName + InUserInfo.Address;
                    tbcfdw.Text = InUserInfo.MobilePhoneNum;
                    lbjd.Text = OutUserInfo.RealName + "\n地址：" + region.GetRegion(OutUserInfo.RegionCode).WholeName + OutUserInfo.Address;
                    tbjdywy.Text = OutUserInfo.MobilePhoneNum;
                }
            }
            else
            {
                //hfInfoId.Value = "0ea3eec2-6911-44df-8003-c478ccaf6a36";
                //if (bll_cf_jd_order.ExistInfoId(Guid.Parse(hfInfoId.Value)))
                //{
                //    Response.Redirect("Success.aspx?CFId=0ea3eec2-6911-44df-8003-c478ccaf6a36");
                //}
                //else
                //{
                //    MSellInfo = bll_sellinfomanage.GetSellInfo_ById(Guid.Parse(hfInfoId.Value));
                //    LB.SQLServerDAL.UserInfo InUserInfo = new LB.SQLServerDAL.UserInfo();
                //    LB.SQLServerDAL.UserInfo OutUserInfo = new LB.SQLServerDAL.UserInfo();
                //    InUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.CF_UserId);
                //    OutUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.JD_UserId);
                //    lbCf.Text = InUserInfo.RealName + "\n地址：" + region.GetRegion(InUserInfo.RegionCode).WholeName + InUserInfo.Address;
                //    tbcfdw.Text = InUserInfo.MobilePhoneNum;
                //    lbjd.Text = OutUserInfo.RealName + "\n地址：" + region.GetRegion(OutUserInfo.RegionCode).WholeName + InUserInfo.Address;
                //    tbjdywy.Text = OutUserInfo.MobilePhoneNum;

                //}
            }

        }
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        //if (bll_cf_jd_order.ExistInfoId(Guid.Parse(hfInfoId.Value)))
        //{
        //    LB.SQLServerDAL.CF_JD_Order Mcf = new LB.SQLServerDAL.CF_JD_Order();
        //    Mcf = bll_cf_jd_order.GetCF_JD_OrderByinfoId(Guid.Parse(hfInfoId.Value));
        //    Response.Redirect("Success.aspx?CFId=" + Mcf.CFId.ToString());
        //}
        //else
        //{
        MSellInfo = bll_sellinfomanage.GetSellInfo_ById(Guid.Parse(hfInfoId.Value));
        //MUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(MSellInfo.HS_UserId));
        MCF_JD_Order.InUserId = bll_usermanage.GetUserInfoByTelNum(tbcfdw.Text).UserId;
        MCF_JD_Order.OutUserId = bll_usermanage.GetUserInfoByTelNum(tbjdywy.Text).UserId;
        MCF_JD_Order.Amount = Convert.ToDecimal(tbAmount.Text);
        MCF_JD_Order.TransferMethod = "银行转账";
        MCF_JD_Order.Remark = tbRemark.Text;
        MCF_JD_Order.TransferDate = System.DateTime.Now;
        MCF_JD_Order.OperatorConfirm = false;
        MCF_JD_Order.OperateDate = System.DateTime.Now;
        MCF_JD_Order.Audit = false;
        MCF_JD_Order.AuditDatetime = Convert.ToDateTime("1900-01-01");
        MCF_JD_Order.InfoId = Guid.Parse(hfInfoId.Value);
        MCF_JD_Order.CopUserId = MSellInfo.HS_UserId;
        MCF_JD_Order.CopUserAudit = false;
        bll_cf_jd_order.NewCF_JD_Order(MCF_JD_Order);
        foreach (RepeaterItem item in Repeater1.Items)
        {
            Literal ltlTSName = item.FindControl("ltlTSName") as Literal;
            TextBox tbNum = item.FindControl("tbNum") as TextBox;
            Literal Literal1 = item.FindControl("Literal1") as Literal;
            if (tbNum.Text != "")
            {
                LB.SQLServerDAL.CF_JD_OrderDetail MCF_JD_OrderDetail = new LB.SQLServerDAL.CF_JD_OrderDetail();
                MCF_JD_OrderDetail.CFId = MCF_JD_Order.CFId;
                MCF_JD_OrderDetail.GoodsDetail = ltlTSName.Text;
                MCF_JD_OrderDetail.Quantity = Convert.ToDecimal(tbNum.Text);
                MCF_JD_OrderDetail.GoodsUnit = Literal1.Text;
                bll_cf_jd_orderdetail.NewCF_JD_OrderDetail(MCF_JD_OrderDetail);
            }
        }
        if (bll_cf_jd_orderdetail.ExistCFId(MCF_JD_Order.CFId))
        {
            MSellInfo.JD_TohandleTag = false;
            MSellInfo.JD_AcceptedTag = false;
            MSellInfo.StatusMsg = "详单填写完毕,待产废单位确认";
            //MSellInfo.IsClosed = true;
            bll_sellinfomanage.UpdateSellInfo(MSellInfo);
            LB.SQLServerDAL.UserInfo MuserInfo = new LB.SQLServerDAL.UserInfo();
            MuserInfo = bll_usermanage.GetUserInfoByTelNum(tbcfdw.Text);
            string url = "http://weixin.lvbao111.com/WeixinQY/MP/MyOrderDetail.aspx?infoId=" + hfInfoId.Value.ToString();
            SendShortMsg(MuserInfo.OpenId, url);
            Response.Redirect("Success.aspx?CFId=" + MCF_JD_Order.CFId.ToString());
        }
        else
        {
            bll_cf_jd_order.DeleteCF_JD_OrderByCFId(MCF_JD_Order.CFId);
            lbMsg.Text = "请输入货品清单数量";
            lbMsg.Visible = true;
        }

        //}

    }

    private void SendShortMsg(string openId,string url)
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
        //string openId = "oOP4JwivBNerfDcFyetChe5cw2Vw"; // 李峰在绿宝服务号中的OpenId
        //string openId = "oOP4JwmLfZaGeHomkHVvhEHMoeAY"; // 曹俊


        TMData_收到报价通知 data = new TMData_收到报价通知();
        data.first.value = "您好，您收到一条报价信息";
        data.keyword1.value = System.DateTime.Now.ToString("yyyy-MM-dd HH：mm：ss：ffff"); ;
        data.keyword2.value = "回收业务员";
        data.keyword4.value = "点击这里查看详情，如无差错请点击确认，谢谢";
        data.Url = url;
        TMSender tmSender = new TMSender();
        tmSender.SendWx_ToOpenId(commonAccessToken, openId, data);

    }
}