using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_Aunth : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text= "<span class='verified'>已审核</span>";
        }
    }

    public string msg
    {
        get
        {
            return Label1.Text;
        }
    }


}