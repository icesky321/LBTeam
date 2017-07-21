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
    CNRegionService cnregion = new CNRegionService();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        string id = ddlStreet.SelectedItem.Value;
        string name = ddlStreet.SelectedItem.Text;
        //values.Add(new CascadingDropDownNameValue(name, id));
        if (id=="")
        {
            lbMsg.Visible = true;
            lbMsg.Text = "请完善地址信息";
        }
        else
        {
            lbMsg.Visible = true;
            lbMsg.Text = "OK";
        }
    }
}