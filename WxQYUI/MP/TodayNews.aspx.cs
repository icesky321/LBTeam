using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MP_TodayNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfBeginDate.Value = System.DateTime.Now.AddDays(-1).ToString();
            hfEndDate.Value = System.DateTime.Now.AddDays(1).ToString();
        }
    }
}