﻿using System;
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
        { }
        Response.Redirect("~/Kefu_Info/DispatchManage.aspx");
    }
}