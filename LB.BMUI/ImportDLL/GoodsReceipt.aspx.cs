﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_Dyywy_GoodsReceipt : System.Web.UI.Page
{
    LB.BLL.UnitInfo bll_unitinfo = new LB.BLL.UnitInfo();
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    LB.BLL.CF_JD_OrderDetail bll_cf_jd_orderdetail = new LB.BLL.CF_JD_OrderDetail();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sellinfomanage = new LB.BLL.SellInfoManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["InUserId"] != null && Request.QueryString["OutUserId"] != null)
            {
                string InUserId = Request.QueryString["InUserId"];
                hfInUserId.Value = InUserId;
                string OutUserId = Request.QueryString["OutUserId"];
                hfOutUserId.Value = OutUserId;
                string InfoId = Request.QueryString["InfoId"];
                hfInfoId.Value = InfoId;
                LB.SQLServerDAL.UserInfo InUserInfo = new LB.SQLServerDAL.UserInfo();
                LB.SQLServerDAL.UserInfo OutUserInfo = new LB.SQLServerDAL.UserInfo();
                InUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(hfInUserId.Value));
                OutUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(hfOutUserId.Value));
                tbcfdw.Text = InUserInfo.MobilePhoneNum;
                tbjdywy.Text = OutUserInfo.MobilePhoneNum;
            }
        }
    }


    protected void btSure_Click(object sender, EventArgs e)
    {
        LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
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
        LB.SQLServerDAL.SellInfo MSellInfo = bll_sellinfomanage.GetSellInfo_ById(Guid.Parse(hfInfoId.Value));
        MSellInfo.IsClosed = true;
        bll_sellinfomanage.UpdateSellInfo(MSellInfo);
        //sendmsg.SendTextToUsers("2", "哈哈哈");
        Response.Redirect("Success.aspx?CFId=" + MCF_JD_Order.CFId.ToString());

        //Response.Redirect("Success.aspx?CFId=0c31f580-8be2-4d40-b506-f10f53c0073b");
    }
}