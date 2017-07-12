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
            hfCity.Value = user.City;

            ltlProvince.Text = user.Province;
            ltlCity.Text = user.City;

            LoadHSInCity(hfCity.Value);       // 加载本街道内所有产废单位
        }


    }

    /// <summary>
    /// 加载本街道内所有产废单位
    /// </summary>
    public void LoadHSInCity(string city)
    {
        var query = bll_userManage1.GetUserInfo_HS_InCity(city);

        lvUserInfo.DataSource = query.AsQueryable();
        lvUserInfo.DataBind();

        ltlCount.Text = bll_userManage1.GetCount_HS_InCity(city).ToString();
    }


    #endregion


}