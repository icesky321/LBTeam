using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserControls_DDLAddress : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string province
    {
        get
        {
            return Request.Params["province"].ToString();
        }
    }
    public string city
    {
        get
        {
            return Request.Params["city"].ToString();
        }
    }
    public string country
    {
        get
        {
            return Request.Params["country"].ToString();
        }
    }
    public string street
    {
        get
        {
            return Request.Params["street"].ToString();
        }
    }

    public void setMsg(string value)
    {
        lbMsg.Text = value;
    }
}