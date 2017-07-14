using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_ShowAddress : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
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

        ltlAddress.Text = string.IsNullOrEmpty(user.Address) ? "未登记" : user.Address;
        if (string.IsNullOrEmpty(user.RegionCode))
        {
            ltlWholeAreaName.Text = "未登记";
        }
        else
        {
            Cobe.CnRegion.SQLServerDAL.Region region = bll_region.GetRegion(user.RegionCode);
            if (region == null)
                return;

            ltlWholeAreaName.Text = region.WholeName;
        }

    }

    


}