using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

public partial class Login_Test : System.Web.UI.Page
{
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    AddressService addrsvc = new AddressService();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    //List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        //    var provinces = bll_region.GetRegions("0");
        //    foreach (Cobe.CnRegion.SQLServerDAL.Region region in provinces)
        //    {
        //        string id = region.Id.ToString();
        //        string name = region.AreaName;
        //        ddlProvince.Items.Add(new ListItem(name, id));
        //    }
        //}
    }
}