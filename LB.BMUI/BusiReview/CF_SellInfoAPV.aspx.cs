﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB.Weixin.Message;
using Senparc.Weixin.QY.AdvancedAPIs.Mass;

public partial class BusiReview_CF_SellInfoAPV : System.Web.UI.Page
{
    LB.BLL.SellInfoManage bll_sellInfo = new LB.BLL.SellInfoManage();
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        RefreshCount();
    }

    private void RefreshCount()
    {
        lbCount.Text = bll_sellInfo.GetCount_KefuTohandle().ToString();
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LB.SQLServerDAL.SellInfo sellInfo = e.Item.DataItem as LB.SQLServerDAL.SellInfo;

            if (sellInfo == null)
                return;

            int cf_userId = sellInfo.CF_UserId;
            LB.SQLServerDAL.UserInfo user = bll_userManage.GetUserInfoByUserId(cf_userId);

            if (user == null)
                return;

            Label ltlRealName = e.Item.FindControl("ltlRealName") as Label;
            Label ltlPhone = e.Item.FindControl("ltlPhone") as Label;
            Label ltlAddress = e.Item.FindControl("ltlAddress") as Label;
            HiddenField hfQYUserId = e.Item.FindControl("hfQYUserId") as HiddenField;

            ltlRealName.Text = user.RealName;
            ltlPhone.Text = user.MobilePhoneNum;
            ltlAddress.Text = user.Address;
            hfQYUserId.Value = user.QYUserId;
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button btn = e.CommandSource as Button;
        TextBox tbRemark = btn.FindControl("tbRemark") as TextBox;

        Guid infoId = Guid.Empty;
        Guid.TryParse(e.CommandArgument.ToString(), out infoId);

        if (infoId == Guid.Empty)
            return;

        LB.SQLServerDAL.SellInfo sellInfo = bll_sellInfo.GetSellInfo_ById(infoId);

        if (sellInfo == null)
            return;

        if (e.CommandName == "Accept")
        {
            sellInfo.Kefu_LeaveMsg = tbRemark.Text;
            sellInfo.Kefu_HandleDate = DateTime.Now;
            sellInfo.Kefu_HandleResult = "审核通过";
            sellInfo.Kefu_TohandleTag = false;
            sellInfo.JD_TohandleTag = true;
            sellInfo.JD_UserId = 1164;      // TODO: 分配街道业务员的逻辑仍需修改。

            string result = SendWx_ToCF(sellInfo.JD_UserId);

            if (result == "ok")
                bll_sellInfo.UpdateSellInfo(sellInfo);
        }

        if (e.CommandName == "Reject")
        {
            sellInfo.Kefu_LeaveMsg = tbRemark.Text;
            sellInfo.Kefu_HandleDate = DateTime.Now;
            sellInfo.Kefu_HandleResult = "拒绝转发";
            sellInfo.Kefu_TohandleTag = false;
            sellInfo.IsClosed = true;
            bll_sellInfo.UpdateSellInfo(sellInfo);
        }
        Repeater1.DataBind();
    }

    private string SendWx_ToCF(int jd_UserId)
    {
        //TODO: 发布前修改微信发布逻辑

        LB.SQLServerDAL.UserInfo user = bll_userManage.GetUserInfoByUserId(jd_UserId);
        if (user == null)
            return "";
        MsgSender msgSender = new MsgSender();
        MassResult result = msgSender.SendTextToUsers(user.QYUserId, "产废单位有一条信息已被审核通过。jd_UserId：" + jd_UserId.ToString(), "5");
        return result.errmsg;
    }
}