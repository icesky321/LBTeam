using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemAdmin_EditStaff : System.Web.UI.Page
{
    LB.BLL.StaffManage bll_staff = new LB.BLL.StaffManage();
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.UserTypeInfo bll_userType = new LB.BLL.UserTypeInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();

        }
    }

    private void Init_Load()
    {
        Load_StaffInfo();
        Load_Province();
        Load_HangyeIdentity();
    }


    private void Load_StaffInfo()
    {
        hfStaffId.Value = Request.QueryString["staffId"];

        Guid staffId = Guid.Empty;
        Guid.TryParse(hfStaffId.Value, out staffId);

        if (staffId == Guid.Empty)
            return;

        // 加载平台员工信息
        LB.SQLServerDAL.Staff staff = bll_staff.GetStaffByStaffId(staffId);
        if (staff == null)
            return;
        lbUserName.Text = staff.UserName;
        lbRealName.Text = staff.RealName;
        lbMobileNum.Text = staff.MobileNum;


        // 加载用户信息
        LoadUserInfo(staff.MobileNum);

    }

    private void Load_HangyeIdentity()
    {
        var userTypes = bll_userType.GetUserTypeInfo();
        ddlHangyeIdentity.Items.Clear();
        foreach (LB.SQLServerDAL.UserTypeInfo userType in userTypes)
        {
            ddlHangyeIdentity.Items.Add(new ListItem(userType.UserTypeName, userType.UserTypeId.ToString()));
        }
        ddlHangyeIdentity.Items.Insert(0, new ListItem("选择行业身份"));
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

    protected void btnSaveRegionCode_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hfMobileNum.Value))
        {
            LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(hfMobileNum.Value);
            if (user == null)
                return;
            user.RegionCode = hfRegionCode.Value;
            bll_user.UpdateUserInfo(user);
            LoadUserInfo(user.MobilePhoneNum);
        }
    }

    /// <summary>
    /// 加载用户信息
    /// </summary>
    /// <param name="mobileNum"></param>
    protected void LoadUserInfo(string mobileNum)
    {
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(mobileNum);
        if (user == null)
            return;

        hfUserId.Value = user.UserId.ToString();
        hfMobileNum.Value = user.MobilePhoneNum;
        if (!string.IsNullOrEmpty(user.RegionCode))
        {
            Cobe.CnRegion.SQLServerDAL.Region region = bll_region.GetRegion(user.RegionCode);
            if (region != null)
                lbRegionWholeName.Text = region.WholeName;
        }
        else
        {
            lbRegionWholeName.Text = "[未配置]";
        }

        // 加载行业身份信息
        LB.SQLServerDAL.UserTypeInfo userType = bll_userType.GetUserTypeById((int)user.UserTypeId);
        if (userType == null)
            lbHangyeIdentity.Text = "[未设置]";
        else
            lbHangyeIdentity.Text = userType.UserTypeName.ToString();
    }

    protected void btnSaveHangyeIdentity_Click(object sender, EventArgs e)
    {
        if (ddlHangyeIdentity.SelectedIndex > 0)
        {
            LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(hfMobileNum.Value);
            if (user == null)
                return;
            int userTypeId = 0;
            int.TryParse(ddlHangyeIdentity.SelectedValue, out userTypeId);
            user.UserTypeId = userTypeId;
            bll_user.UpdateUserInfo(user);
            LoadUserInfo(user.MobilePhoneNum);
        }
    }
}