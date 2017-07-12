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
            hfTown.Value = user.Town;
            hfStreet.Value = user.Street;

            ltlProvince.Text = user.Province;
            ltlCity.Text = user.City;
            ltlTown.Text = user.Town;
            ltlStreet.Text = user.Street;

            LoadCFInStreet(hfCity.Value, hfTown.Value, hfStreet.Value);       // 加载本街道内所有产废单位
        }


    }

    /// <summary>
    /// 加载本街道内所有产废单位
    /// </summary>
    public void LoadCFInStreet(string city, string town, string street)
    {
        var query = bll_userManage1.GetUserInfo_InStreet(city, town, street);

        lvUserInfo.DataSource = query.AsQueryable();
        lvUserInfo.DataBind();

        ltlCount.Text = bll_userManage1.GetCount_CF_InStreet(city, town, street).ToString();
    }


    #endregion


}