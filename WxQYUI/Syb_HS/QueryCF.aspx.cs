using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_HS_QueryCF : System.Web.UI.Page
{
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();

    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

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

            hfCityRegionCode.Value = user.RegionCode.Substring(0, 4) + "00000000";
            ltlCityWholeName.Text = bll_region.GetRegion(hfCityRegionCode.Value).WholeName;
            hfHS_UserId.Value = user.UserId.ToString();


            LoadCounty(hfCityRegionCode.Value);
        }

    }

    private void LoadCounty(string cityRegionCode)
    {
        var counties = bll_region.GetRegions(cityRegionCode);
        rptCounty.DataSource = counties;
        rptCounty.DataBind();
    }

    protected void rptCounty_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Cobe.CnRegion.SQLServerDAL.Region region = e.Item.DataItem as Cobe.CnRegion.SQLServerDAL.Region;

            Literal ltlUserNum = e.Item.FindControl("ltlUserNum") as Literal;
            ltlUserNum.Text = bll_userManage.GetCount_CF_InCounty(region.Id).ToString();
        }
    }
}