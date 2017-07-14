using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataM_FillRegionCode : System.Web.UI.Page
{
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Province();
        }
    }

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

    private void Load_County()
    {
        var counties = bll_region.GetRegions(ddlCity.SelectedValue);
        ddlCounty.Items.Clear();
        foreach (Cobe.CnRegion.SQLServerDAL.Region region in counties)
        {
            ddlCounty.Items.Add(new ListItem(region.AreaName, region.Id));
        }
        ddlCounty.Items.Insert(0, "--选择区县--");
    }

    private void Load_Street()
    {
        var streets = bll_region.GetRegions(ddlCounty.SelectedValue);
        ddlStreet.Items.Clear();
        foreach (Cobe.CnRegion.SQLServerDAL.Region region in streets)
        {
            ddlStreet.Items.Add(new ListItem(region.AreaName, region.Id));
        }
        ddlStreet.Items.Insert(0, "--选择区县--");
    }

    protected void btnFetchOneUser_Click(object sender, EventArgs e)
    {
        LB.SQLServerDAL.UserInfo user = bll_user.GetUser_NotRegionCode();
        hfUserId.Value = user.UserId.ToString();
        ltlUserId.Text = user.UserId.ToString();
        ltlUserName.Text = user.UserName;
        ltlDiyu.Text = user.Province + " - " + user.City + " - " + user.Town + " - " + user.Street;
    }

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProvince.SelectedIndex > 0)
        {
            Load_City();
        }
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex > 0)
            Load_County();
    }

    protected void ddlCounty_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCounty.SelectedIndex > 0)
            Load_Street();
    }

    protected void btnSaveProvince_Click(object sender, EventArgs e)
    {
        SaveRegionCode(ddlProvince.SelectedValue);
    }

    protected void btnSavecity_Click(object sender, EventArgs e)
    {
        SaveRegionCode(ddlCity.SelectedValue);
    }

    protected void btnSaveCounty_Click(object sender, EventArgs e)
    {
        SaveRegionCode(ddlCounty.SelectedValue);
    }

    protected void btnSaveStreet_Click(object sender, EventArgs e)
    {
        SaveRegionCode(ddlStreet.SelectedValue);
    }

    protected void SaveRegionCode(string regionCode)
    {
        int userId = 0;
        int.TryParse(hfUserId.Value, out userId);

        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByUserId(userId);
        user.RegionCode = regionCode;
        bll_user.UpdateUserInfo(user);
        ltlMessage.Text = user.UserName + " 信息已保存";
    }
}