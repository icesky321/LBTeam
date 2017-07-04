using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;

public partial class Test : System.Web.UI.Page
{
    LB.BLL.SMS bll_senderdx = new LB.BLL.SMS();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("InfoManage") || HttpContext.Current.User.IsInRole("UserManage"))
                {
                    Response.Redirect("../Admin/Manage.aspx");
                }
                else
                {
                    Response.Redirect("../../LB.HSUI/Default.aspx");
                }
            }


        }

    }
}