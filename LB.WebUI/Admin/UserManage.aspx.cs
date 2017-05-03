﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserManage : System.Web.UI.Page
{
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
    LB.BLL.UserTypeInfo bll_usertypeinfo = new LB.BLL.UserTypeInfo();
    LB.SQLServerDAL.UserTypeInfo MUserTypeInfo = new LB.SQLServerDAL.UserTypeInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillUserTypeInfo();
        }
    }

    void FillUserTypeInfo()
    {
        IQueryable<LB.SQLServerDAL.UserTypeInfo> usertypes = bll_usertypeinfo.GetUserTypeInfo();
        foreach (LB.SQLServerDAL.UserTypeInfo UserTypeInfo in usertypes)
        {
            ddlUserType.Items.Add(new ListItem(UserTypeInfo.UserTypeName, UserTypeInfo.UserTypeId.ToString()));
        }
        ddlUserType.Items.Insert(0, "");
    }

    void gvUserInfoDataBind()
    {
        gvUserInfo.DataSource = bll_userinfo.GetUserInfoByUserTypeId(Convert.ToInt32(ddlUserType.SelectedItem.Value));
        //gvUserInfo.DataSource = bll_userinfo.GetUserInfo();
        gvUserInfo.DataBind();
        foreach (GridViewRow gvRow in gvUserInfo.Rows)
        {
            string UserId = gvRow.Cells[0].Text;
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).IDAuthentication == false)
            {
                ((MultiView)(gvRow.Cells[6].FindControl("MultiView3"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[6].FindControl("MultiView3"))).ActiveViewIndex = 1;
            }
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).ChopAuthentication == false)
            {
                ((MultiView)(gvRow.Cells[7].FindControl("MultiView4"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[7].FindControl("MultiView4"))).ActiveViewIndex = 1;
            }
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).Audit == false)
            {
                ((MultiView)(gvRow.Cells[7].FindControl("MultiView5"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[7].FindControl("MultiView5"))).ActiveViewIndex = 1;
            }
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).InCharge == false)
            {
                ((MultiView)(gvRow.Cells[7].FindControl("MultiView6"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[7].FindControl("MultiView6"))).ActiveViewIndex = 1;
            }
        }
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        gvUserInfoDataBind();
    }

    protected void gvUserInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string UserId = e.CommandArgument.ToString();
        MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
        if (e.CommandName == "IDCard")
        {
            string url = MUserInfo.IDCard;
            Response.Redirect(url);
        }
        if (e.CommandName == "IPass")
        {
            MUserInfo.IDAuthentication = true;
        }
        if (e.CommandName == "IUPass")
        {
            MUserInfo.IDAuthentication = false;
        }
        if (e.CommandName == "Chop")
        {
            string url = MUserInfo.Chop;
            Response.Redirect(url);
        }
        if (e.CommandName == "CPass")
        {
            MUserInfo.ChopAuthentication = true;
        }
        if (e.CommandName == "CUPass")
        {
            MUserInfo.ChopAuthentication = false;
        }
        if (e.CommandName == "Pass")
        {
            MUserInfo.Audit = true;
            MUserInfo.AuditDate = System.DateTime.Now;
        }
        if (e.CommandName == "UPass")
        {
            MUserInfo.Audit = false;
            MUserInfo.AuditDate = System.DateTime.Now;
        }
        if (e.CommandName == "ICPass")
        {
            MUserInfo.InCharge = true;
            MUserInfo.InChargeDate = System.DateTime.Now;
        }
        if (e.CommandName == "ICUPass")
        {
            MUserInfo.InCharge = false;
            MUserInfo.InChargeDate = System.DateTime.Now;
        }
        bll_userinfo.UpdateUserInfo(MUserInfo);
        gvUserInfoDataBind();
    }
}