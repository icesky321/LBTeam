using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_JD_QueryMyHS : System.Web.UI.Page
{
    LB.BLL.UserManage bll_userManage1 = new LB.BLL.UserManage();
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.CopInfo bll_cop = new LB.BLL.CopInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();

        }
    }

    #region 初始化加载
    private void Init_Load()
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            hfUserMobile.Value = HttpContext.Current.User.Identity.Name;
            LB.SQLServerDAL.UserInfo user = bll_userManage.GetUserInfoByTelNum(hfUserMobile.Value);
            if (user == null)
                return;


            hfJD_UserId.Value = user.UserId.ToString();

            string regionCode = user.RegionCode;
            Cobe.CnRegion.SQLServerDAL.Region region = bll_region.GetRegion(regionCode);
            if (region == null)
                return;

            int level = 0;
            level = region.Level ?? 0;

            if (level < 3)
                Response.Redirect("UserInfoIncomplete.aspx");
            else
            {
                hfCityRegionCode.Value = region.CityId;

                Cobe.CnRegion.SQLServerDAL.Region cityRegion = bll_region.GetRegion(region.CountyId);
                if (cityRegion != null)
                    ltlCityWholeName.Text = cityRegion.WholeName;
            }

            LoadHSInCity(hfCityRegionCode.Value);       // 加载本街道内所有产废单位
        }


    }

    /// <summary>
    /// 加载本街道内所有产废单位
    /// </summary>
    public void LoadHSInCity(string cityRegionCode)
    {
        var query = bll_userManage1.GetUserInfo_HS_InCity(cityRegionCode);

        lvUserInfo.DataSource = query;
        lvUserInfo.DataBind();

        ltlCount.Text = bll_userManage1.GetCount_HS_InCity(cityRegionCode).ToString();
    }


    #endregion

    public string GetCopName(string strUserId)
    {
        int userId = 0;
        int.TryParse(strUserId, out userId);

        if (userId == 0)
            return "";

        LB.SQLServerDAL.CopInfo cop = bll_cop.GetCopInfoeByUserId(userId);
        if (cop == null)
            return "";

        string returnString = string.Empty;

        if (string.IsNullOrEmpty(cop.ShortName))
            returnString = "未设置";
        else
            returnString = cop.ShortName;

        return returnString;
    }


    protected void lvUserInfo_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        LB.SQLServerDAL.UserInfo user = e.Item.DataItem as LB.SQLServerDAL.UserInfo;
        Literal ltlHS_CopName = e.Item.FindControl("ltlHS_CopName") as Literal;

        LB.SQLServerDAL.CopInfo cop = bll_cop.GetCopInfoeByUserId(user.UserId);
        if (cop == null)
        {
            ltlHS_CopName.Text = "未完成企业实名认证";
            return;
        }

        if (string.IsNullOrEmpty(cop.ShortName))
            ltlHS_CopName.Text = "未设置";
        else
        {

            ltlHS_CopName.Text = cop.ShortName + "&nbsp;&nbsp;" + (cop.BAuthentication == true ? "(实名认证)" : "未实名认证");
        }


    }
}