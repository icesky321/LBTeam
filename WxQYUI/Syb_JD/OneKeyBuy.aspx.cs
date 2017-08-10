using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_JD_OneKeyBuy : System.Web.UI.Page
{
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();
    CNRegionService CNRegion = new CNRegionService();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    LB.BLL.CF_JD_OrderDetail bll_cf_jd_orderdetail = new LB.BLL.CF_JD_OrderDetail();
    LB.BLL.PaymentDetail bll_paymentdetail = new LB.BLL.PaymentDetail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Init_Load();
                Load_County();
                Load_Street();
                LB.SQLServerDAL.UserInfo jd_user = new LB.SQLServerDAL.UserInfo();
                jd_user = bll_userManage.GetUserInfoByTelNum(User.Identity.Name);
                hfJD_UserId.Value = jd_user.UserId.ToString();
                lbjd.Text = jd_user.RealName + "\n地址：" + bll_region.GetRegion(jd_user.RegionCode).WholeName + jd_user.Address;
                tbjdywy.Text = jd_user.MobilePhoneNum;
            }

        }
    }

    private void Init_Load()
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            hfUserMobile.Value = HttpContext.Current.User.Identity.Name;
            LB.SQLServerDAL.UserInfo user = bll_userManage.GetUserInfoByTelNum(hfUserMobile.Value);
            if (user == null)
                return;

            if (String.IsNullOrEmpty(user.RegionCode))
                Response.Redirect("~/ErrorPage/NoAddress.aspx", true);

            hfCityRegionCode.Value = user.RegionCode.Substring(0, 4) + "00000000";
            ltlCityWholeName.Text = bll_region.GetRegion(hfCityRegionCode.Value).WholeName;
            hfHS_UserId.Value = user.UserId.ToString();

        }

    }

    private void Load_County()
    {
        var counties = bll_region.GetRegions(hfCityRegionCode.Value);
        ddlCounty.Items.Clear();
        foreach (Cobe.CnRegion.SQLServerDAL.Region region in counties)
        {
            ddlCounty.Items.Add(new ListItem(region.AreaName, region.Id));
        }
        ddlCounty.Items.Insert(0, "--选择区县--");
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<Script>window.location.hash = '#regionBegin';</Script>");
    }

    private void Load_Street()
    {
        var streets = bll_region.GetRegions(ddlCounty.SelectedValue);
        ddlStreet.Items.Clear();
        foreach (Cobe.CnRegion.SQLServerDAL.Region region in streets)
        {
            ddlStreet.Items.Add(new ListItem(region.AreaName, region.Id));
        }
        ddlStreet.Items.Insert(0, "--选择街道--");
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<Script>window.location.hash = '#regionBegin';</Script>");
    }

    protected void ddlCounty_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCounty.SelectedIndex > 0)
        {
            hfRegionCode.Value = ddlCounty.SelectedValue;
            Load_Street();
        }
    }

    protected void ddlStreet_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStreet.SelectedIndex > 0)
        {
            hfRegionCode.Value = ddlStreet.SelectedValue;
            LoadCFInStreet(hfRegionCode.Value);
        }
    }

    public void LoadCFInStreet(string streetRegionCode)
    {
        var query = bll_userManage.GetUserInfo_InStreet(streetRegionCode);
        rptStreet.DataSource = query.AsQueryable();
        rptStreet.DataBind();
    }


    protected void btChooseCF_Click(object sender, EventArgs e)
    {
        ChooseCF.Visible = true;
    }

    protected void rptStreet_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Confirm")//判断这个Item里哪个控件响应的这个事件  
        {
            LB.SQLServerDAL.UserInfo MUser = new LB.SQLServerDAL.UserInfo();
            string UserId = (string)e.CommandArgument;
            MUser = bll_userManage.GetUserInfoByUserId(Convert.ToInt32(UserId));
            lbCf.Text = MUser.RealName + "\n地址：" + bll_region.GetRegion(MUser.RegionCode).WholeName + MUser.Address;
            tbcfdw.Text = MUser.MobilePhoneNum;
            hfCF_UserId.Value = UserId;
            ChooseCF.Visible = false;
        }
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        if (lbCf.Text == "")
        {
            lbMsg.Text = "请选择产废单位";
            lbMsg.Visible = true;
        }
        else
        {
            LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
            MCF_JD_Order.InUserId = Convert.ToInt32(hfCF_UserId.Value);
            MCF_JD_Order.OutUserId = Convert.ToInt32(hfJD_UserId.Value);
            MCF_JD_Order.Amount = Convert.ToDecimal(tbAmount.Text);
            MCF_JD_Order.TransferMethod = "银行转账";
            MCF_JD_Order.Remark = tbRemark.Text;
            MCF_JD_Order.TransferDate = System.DateTime.Now;
            MCF_JD_Order.OperatorConfirm = false;
            MCF_JD_Order.OperateDate = Convert.ToDateTime("1900-01-01");
            MCF_JD_Order.Audit = false;
            MCF_JD_Order.AuditDatetime = Convert.ToDateTime("1900-01-01");
            MCF_JD_Order.CopUserId = 1155;//目前默认李军的赐翔，后期要改
            MCF_JD_Order.CopUserAudit = true;
            MCF_JD_Order.CopAuditDate = System.DateTime.Now;
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
                LB.SQLServerDAL.PaymentDetail MPaymentDetail = new LB.SQLServerDAL.PaymentDetail();
                MPaymentDetail.Amount = MCF_JD_Order.Amount;
                MPaymentDetail.UserId = MCF_JD_Order.InUserId;
                MPaymentDetail.CreateDate = System.DateTime.Now;
                MPaymentDetail.PayStatus = "已到款";
                MPaymentDetail.Audit = User.Identity.Name;
                MPaymentDetail.AuditDate = System.DateTime.Now;
                MPaymentDetail.CFId = MCF_JD_Order.CFId;
                MPaymentDetail.TransferMethod = "";
                bll_paymentdetail.newPaymentDetail(MPaymentDetail);
                SendWxArticle_ToCF(MCF_JD_Order.CFId, "2");
                SendWxArticle_ToCF(MCF_JD_Order.CFId, "1");
                Response.Redirect("Success.aspx?CFId=" + MCF_JD_Order.CFId.ToString());
            }
            else
            {
                bll_cf_jd_order.DeleteCF_JD_OrderByCFId(MCF_JD_Order.CFId);
                lbMsg.Text = "请输入货品清单数量";
                lbMsg.Visible = true;
            }
        }
       

    }

    private void SendWxArticle_ToCF(Guid CFId, string QYId)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
        MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(CFId);
        LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
        MUserInfo = bll_userManage.GetUserInfoByUserId(Convert.ToInt32(MCF_JD_Order.InUserId));
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "街道回收员收货单明细";
        article.Description = "产废单位：" + MUserInfo.RealName + "(" + MUserInfo.MobilePhoneNum + ")" + "\n" + "详细地址：" + bll_region.GetRegion(MUserInfo.RegionCode).WholeName + MUserInfo.Address + "\n" + "收货金额：" + MCF_JD_Order.Amount + "元" + "\n" + "查看明细请继续戳我";
        article.Url = "http://weixin.lvbao111.com/WeixinQY/ManagerInfo/OneKeyBuyInfo.aspx?CFId=" + CFId;
        sendmsg.SendArticleToUsers(QYId, article, "5");
    }
}