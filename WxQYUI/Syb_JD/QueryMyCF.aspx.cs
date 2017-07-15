using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_JD_QueryMyCF : System.Web.UI.Page
{
    LB.BLL.UserManage bll_userManage1 = new LB.BLL.UserManage();
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
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

            if (String.IsNullOrEmpty(user.RegionCode))
                Response.Redirect("~/ErrorPage/NoAddress.aspx", true);

            hfStreetRegionCode.Value = user.RegionCode.Substring(0, 9) + "000";
            hfJD_UserId.Value = user.UserId.ToString();
            ltlStreetWholeName.Text = bll_region.GetRegion(hfStreetRegionCode.Value).WholeName;
            LoadCFInStreet(hfStreetRegionCode.Value);       // 加载本街道内所有产废单位
        }


    }

    /// <summary>
    /// 加载本街道内所有产废单位
    /// </summary>
    public void LoadCFInStreet(string streetRegionCode)
    {
        var query = bll_userManage1.GetUserInfo_InStreet(streetRegionCode);

        lvUserInfo.DataSource = query.AsQueryable();
        lvUserInfo.DataBind();

        ltlCount.Text = bll_userManage1.GetCount_CF_InStreet(streetRegionCode).ToString();
    }


    #endregion


}