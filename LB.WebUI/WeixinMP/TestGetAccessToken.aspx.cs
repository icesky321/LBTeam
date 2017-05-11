using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using LB.Weixin;

public partial class WeixinMP_TestGetAccessToken : System.Web.UI.Page
{
    AccessTokenManage accessTokenManage = new AccessTokenManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        string appId = ConfigurationManager.AppSettings["AppID"] ?? "wx5987b3efa3881815";
        string appSecret = ConfigurationManager.AppSettings["AppSecret"] ?? "1c70e036847a6bd653bcd24fe3d0c8cb";
        Label1.Text = LB.Weixin.AccessTokenManage.GetAccessToken(appId, appSecret);
    }
}