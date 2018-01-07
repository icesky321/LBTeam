using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class WeixinQY_CityManagerAccession : System.Web.UI.Page
{
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.BLL.UserTypeInfo bll_usertypeinfo = new LB.BLL.UserTypeInfo();
    LB.SQLServerDAL.UserTypeInfo MUserTypeInfo = new LB.SQLServerDAL.UserTypeInfo();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.CityManager_Config bll_citimanager_config = new LB.BLL.CityManager_Config();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Province();
        }
    }

    #region  加载省市县
    private void Load_Province()
    {
        var provinces = bll_region.GetRegions("0");
        ddlProvince.Items.Clear();
        foreach (Cobe.CnRegion.SQLServerDAL.Region region in provinces)
        {
            ddlProvince.Items.Add(new ListItem(region.AreaName, region.Id));
        }
        ddlProvince.Items.Insert(0, "--选择省份--");
    }

    private void Load_City()
    {
        var cities = bll_region.GetRegions(ddlProvince.SelectedValue);
        ddlCity.Items.Clear();
        foreach (Cobe.CnRegion.SQLServerDAL.Region region in cities)
        {
            ddlCity.Items.Add(new ListItem(region.AreaName, region.Id));
        }
        ddlCity.Items.Insert(0, "--选择城市--");
    }

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProvince.SelectedIndex > 0)
        {
            hfRegionCode.Value = ddlProvince.SelectedValue;
            Load_City();
        }
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex > 0)
        {
            hfRegionCode.Value = ddlCity.SelectedValue;
        }
    }
    #endregion

    void gvUserInfoDataBind()
    {
        gvUserInfo.DataSource = bll_userinfo.GetUserInfoByUserTypeId_RegionCode_TelNum(5, "", tbTelNum.Text);
        gvUserInfo.DataBind();
        foreach (GridViewRow gvRow in gvUserInfo.Rows)
        {
            string UserId = gvRow.Cells[0].Text;
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            if (string.IsNullOrEmpty(bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).IDCard) == false)
            {
                if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).IDAuthentication == true)
                {
                    ((MultiView)(gvRow.Cells[3].FindControl("MultiView3"))).ActiveViewIndex = 1;
                }
                else
                {
                    ((MultiView)(gvRow.Cells[3].FindControl("MultiView3"))).ActiveViewIndex = 0;
                }
            }
            else
            {
                ((LinkButton)(gvRow.Cells[3].FindControl("lbtnIDCard"))).Visible = false;
                ((MultiView)(gvRow.Cells[3].FindControl("MultiView3"))).ActiveViewIndex = 2;
            }
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).Audit == true)
            {
                ((MultiView)(gvRow.Cells[4].FindControl("MultiView5"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[4].FindControl("MultiView5"))).ActiveViewIndex = 0;
            }
        }
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        gvUserInfoDataBind();
    }

    protected void gvUserInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "choose")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            lbMobileNum.Text = MUserInfo.MobilePhoneNum;
            hfUserId.Value = MUserInfo.UserId.ToString();
        }
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        LB.SQLServerDAL.CityManager_Config MCitiManager_Config = new LB.SQLServerDAL.CityManager_Config();
        MCitiManager_Config.IsLocked = false;
        MCitiManager_Config.MobilePhoneNum = lbMobileNum.Text;
        MCitiManager_Config.RegionCode = hfRegionCode.Value;
        MCitiManager_Config.UserId = Convert.ToInt32(hfUserId.Value);
        bll_citimanager_config.SetConfig(MCitiManager_Config);
        LB.SQLServerDAL.UserInfo MUser = new LB.SQLServerDAL.UserInfo();
        MUser = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(hfUserId.Value));
        MUser.IsQYUser = true;
        MUser.QYUserId = tbQYId.Text;
        bll_userinfo.UpdateUserInfo(MUser);
        lbMsg.Visible = true;
    }
}