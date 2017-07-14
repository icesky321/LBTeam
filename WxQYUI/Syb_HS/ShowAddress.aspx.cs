using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_ShowAddress : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Address();
        }
    }

    private void Load_Address()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;

        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);

        if (user == null)
            return;

        ltlProvince.Text = user.Province;
        ltlCity.Text = user.City;
        ltlXian.Text = user.Town;
        ltlStreet.Text = user.Street;
        ltlAddress.Text = string.IsNullOrEmpty(user.Address) ? "未登记" : user.Address;
        tbAddress.Text = string.IsNullOrEmpty(user.Address) ? "" : user.Address;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;

        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);

        if (user == null)
            return;


        user.Province = Request.Params["sheng"].ToString();
        user.City = Request.Params["shi"].ToString();
        user.Town = Request.Params["xian"].ToString();
        user.Street = Request.Params["xiang"].ToString();
        user.Address = tbAddress.Text;

        bll_user.UpdateUserInfo(user);

        Response.Redirect("ShowAddress.aspx");
    }
}