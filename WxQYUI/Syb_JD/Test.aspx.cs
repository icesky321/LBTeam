using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Syb_Dyywy_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CommandButton_Click(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Accept")
        {
            LB.BLL.SMS sms = new LB.BLL.SMS();
            sms.SendSMS("13738487153", "回收员（******）已接单，会尽快与您联系，请耐心等待。【绿宝】");
        }
        Response.Redirect("~/Kefu_Info/DispatchManage.aspx");
    }
}