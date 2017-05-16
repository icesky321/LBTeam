using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CopDetail : System.Web.UI.Page
{
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["CopId"] != null)
            {
                int CopId = Convert.ToInt32(Request.QueryString["CopId"]);
                MCopInfo = bll_copinfo.GetCopInfoeById(CopId);
                MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(MCopInfo.UserId));
                CopNameLabel.Text = MCopInfo.CopName;
                ContactLabel.Text = MUserInfo.UserName;
                TelNumLabel.Text = MUserInfo.MobilePhoneNum;
                ProvinceLabel.Text = MUserInfo.Province;
                CityLabel.Text = MUserInfo.City;
                TownLabel.Text = MUserInfo.Town;
                StreetLabel.Text = MUserInfo.Street;

            }
        }
    }
}