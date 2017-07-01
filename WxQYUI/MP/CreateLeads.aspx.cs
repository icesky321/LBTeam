﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


public partial class MP_CreateLeads : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sellInfo = new LB.BLL.SellInfoManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        LoadSellerInfo();
    }

    private void LoadSellerInfo()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;       // 用户账户即为用户手机号码
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);

        if (user == null)
            return;

        bool imcompletMark = false;

        if (string.IsNullOrEmpty(user.RealName))
            ltlRealName.Text = "未设置";
        else
            ltlRealName.Text = user.RealName;

        if (string.IsNullOrEmpty(user.MobilePhoneNum))
        {
            ltlTelNum.Text = "未设置";
            imcompletMark = true;
        }
        else
            ltlTelNum.Text = user.MobilePhoneNum;

        if (string.IsNullOrEmpty(user.Address))
        {
            ltlAddress.Text = "未设置";
            imcompletMark = true;
        }
        else
            ltlAddress.Text = user.Address;

        if (imcompletMark == true)
        {
            hfImcomplete.Value = "true";
            ltlContactMsg.Text = "&nbsp;&nbsp;(* 信息不完整)";
            coll1.Attributes.Add("data-collapsed", "false");
        }

    }






    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            lbMsg.Text = "您尚未登录，请先登录。";
            return;
        }
        if (hfImcomplete.Value == "true")
        {
            lbMsg.Text = "卖家信息不完整，请先完善信息";
            return;
        }
        LB.SQLServerDAL.SellInfo sellInfo = new LB.SQLServerDAL.SellInfo();

        sellInfo.Title = "废旧蓄铅电池出售";

        string detailInfo = string.Empty;
        List<string> listTSName = new List<string>();
        foreach (ListItem item in cblDP.Items)
        {
            if (item.Selected)
                listTSName.Add(item.Text);
        }
        string tsNames = string.Join("、", listTSName.ToArray());
        detailInfo = "待售电瓶品种：" + tsNames + " | " + tbAdditionText.Value;
        sellInfo.Description = detailInfo;

        sellInfo.Quantity = tbVolume.Value;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);
        sellInfo.TradePlace = user.Address;
        sellInfo.CF_UserId = user.UserId;
        sellInfo.CF_UserMobile = userName;
        bll_sellInfo.CreateSellInfo(sellInfo);

        Response.Redirect("CreateLeads.aspx#pageRegCompleted", true);
    }
}