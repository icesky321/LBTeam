using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Monitor_GlobalMonitor : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        // 系统内用户总数
        ltlUserSum.Text = bll_user.GetUserSum().ToString();
        // 已认证通过，并加入微信企业号的用户数。
        ltlIsQYUserSum.Text = bll_user.GetIsQYUser_Sum().ToString();
    }
}