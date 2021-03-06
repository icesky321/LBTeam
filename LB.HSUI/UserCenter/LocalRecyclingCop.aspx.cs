﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_Supplier_LocalRecyclingCop : System.Web.UI.Page
{
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiViewBind();
        }
    }

    void MultiViewBind()
    {
        if (Request.IsAuthenticated)
        {
            if (HttpContext.Current.User.IsInRole("CESupplier") || HttpContext.Current.User.IsInRole("CERecyclingCop") || HttpContext.Current.User.IsInRole("CEUser"))
            {
                if (DLCopInfo.Items.Count != 0)
                {
                    MultiView1.ActiveViewIndex = 0;
                    DLCopInfoDataBind(HttpContext.Current.User.Identity.Name);
                }
                else
                {
                    MultiView1.ActiveViewIndex = 1;
                }
            }
            else
            {
                
                Response.Redirect("../Default.aspx");
            }
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }

    void DLCopInfoDataBind(string TelNum)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(TelNum);
        
        DLCopInfo.DataSource = bll_copinfo.GetCopInfodByAddress(MUserInfo.Province, MUserInfo.City, "--", "--", 2);
        DLCopInfo.DataBind();
        foreach (DataListItem item in this.DLCopInfo.Items)
        {
            if (HttpContext.Current.User.IsInRole("general"))
            { ((Label)item.FindControl("TelNumLabel")).Visible = false; }

        }

    }
}