﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MP_MySellInfos : System.Web.UI.Page
{
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sellInfo = new LB.BLL.SellInfoManage();
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login/Login.aspx");
            }
            else
            {
                //if (bll_userManage.GetUserInfoByTelNum(User.Identity.Name).Audit == true)
                //{
                Init_Load();
                //}
                //else
                //{
                //    Response.Redirect("~/Login/ImproveData.aspx");
                //}
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

            hfUserId.Value = user.UserId.ToString();


            LoadSellInfos(user.MobilePhoneNum);
        }

    }

    private void LoadSellInfos(string mobile)
    {
        var sellInfos = bll_sellInfo.GetMySellInfo_NotClosed(mobile);
        rptSellInfos.DataSource = sellInfos;
        rptSellInfos.DataBind();
        ltlCount.Text = sellInfos.Count().ToString();
        ltlCount2.Text = sellInfos.Count().ToString();


        var sellInfos2 = bll_sellInfo.GetMySellInfo_IsClosed(mobile);
        rptSellInfos2.DataSource = sellInfos2;
        rptSellInfos2.DataBind();
    }

    protected void lbtnDetail_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateLeads.aspx");
    }

    protected void rptSellInfos2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Guid infoId = Guid.Empty;
        Guid.TryParse(e.CommandArgument.ToString(), out infoId);

        if (infoId == Guid.Empty)
            return;


        if (e.CommandName == "Detail")
        {
            string url = "MyOrderDetail.aspx?infoId=" + e.CommandArgument.ToString();
            Response.Redirect(url);
        }
    }

    protected void rptSellInfos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbInfoId = e.Item.FindControl("lbInfoId") as Label;
            LinkButton lbtnDetail= e.Item.FindControl("lbtnDetail") as LinkButton;
            if (bll_cf_jd_order.ExistInfoId(Guid.Parse(lbInfoId.Text)))
            {
                lbtnDetail.Visible = true;
            }
            else
            {
                lbtnDetail.Visible = false;
            }
            
        }
    }
}