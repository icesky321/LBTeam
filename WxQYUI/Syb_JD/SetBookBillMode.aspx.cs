using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_JD_SetBookBillMode : System.Web.UI.Page
{
    LB.BLL.ConfigManage bll_configManage = new LB.BLL.ConfigManage();
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
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

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProvince.SelectedIndex > 0)
        {
            hfRegionCode.Value = "";
            hfRegionCode.Value = ddlProvince.SelectedValue;
            Load_City();
        }
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex > 0)
        {
            hfRegionCode.Value = ddlCity.SelectedValue;
            Load_County();
        }
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
        }
    }
    #endregion


    #region
    private void Init_Load()
    {
        if (User.Identity.IsAuthenticated)
        {
            LB.SQLServerDAL.JD_Config config = bll_configManage.GetJD_Config(User.Identity.Name);
            if (config == null)
            {
                divregioncode.Visible = true;
                hfMode.Value = "off";
                lbMode.Text = "待激活";
                btnSetMode.Text = "点击激活接单模式";
                Image1.ImageUrl = "~/Syb_JD/Images/mode_off.gif";
                divregioncode.Visible = true;
                return;
            }

            if (config.BookBillModeToggle)
            {
                if (config.RegionCode == "000000000000")
                {
                    divregioncode.Visible = true;
                }
                else
                {
                    divregioncode.Visible = false;
                }
                hfMode.Value = "on";
                lbMode.Text = "接单中";
                btnSetMode.Text = "关闭接单模式";
                Image1.ImageUrl = "~/Syb_JD/Images/mode_on.jpg";
            }
            else
            {
                if (config.RegionCode == "000000000000")
                {
                    divregioncode.Visible = true;
                }
                else
                {
                    divregioncode.Visible = false;
                }
                hfMode.Value = "off";
                lbMode.Text = "休息中";
                btnSetMode.Text = "开启接单模式";
                Image1.ImageUrl = "~/Syb_JD/Images/mode_off.gif";
            }
        }
    }

    #endregion

    protected void btnSetMode_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
            return;

        LB.SQLServerDAL.JD_Config config = bll_configManage.GetJD_Config(User.Identity.Name);

        if (config == null)
        {
            config = new LB.SQLServerDAL.JD_Config();
            config.MobilePhoneNum = User.Identity.Name;
            config.UserId = bll_userManage.GetUserInfoByTelNum(User.Identity.Name).UserId;
            config.BookBillModeToggle = true;
            config.BookBillStatusRemind = true;
            if (ddlStreet.SelectedIndex > 0)
            {
                hfRegionCode.Value = ddlStreet.SelectedValue;
            }
            else if (ddlCounty.SelectedIndex > 0)
            {
                string str1 = ddlCounty.SelectedValue;
                hfRegionCode.Value = str1.Substring(0, 6);
            }
            else if (ddlCity.SelectedIndex > 0)
            {
                string str1 = ddlCity.SelectedValue;
                hfRegionCode.Value = str1.Substring(0, 4);
            }
            else if (ddlProvince.SelectedIndex > 0)
            {
                string str1 = ddlProvince.SelectedValue;
                hfRegionCode.Value = str1.Substring(0, 2);
            }
            config.RegionCode = hfRegionCode.Value;
        }

        if (hfMode.Value == "on")
        {
            if (config.RegionCode == "000000000000")
            {
                config.RegionCode = hfRegionCode.Value;
            }
            else
            {
                divregioncode.Visible = false;
            }
            hfMode.Value = "off";
            config.BookBillModeToggle = false;
            lbMode.Text = "休息中";
            btnSetMode.Text = "开启接单模式";
            Image1.ImageUrl = "~/Syb_JD/Images/mode_off.gif";
        }
        else
        {
            if (config.RegionCode == "000000000000")
            {
                config.RegionCode = hfRegionCode.Value;
            }
            else
            {
                divregioncode.Visible = false;
            }
            hfMode.Value = "on";
            config.BookBillModeToggle = true;
            lbMode.Text = "接单中";
            btnSetMode.Text = "关闭接单模式";
            Image1.ImageUrl = "~/Syb_JD/Images/mode_on.jpg";
        }
        bll_configManage.SetConfig(config);
        divregioncode.Visible = false;
    }
}