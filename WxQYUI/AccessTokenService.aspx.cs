using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB.Weixin;

/// <summary>
/// 微信企业号中央
/// </summary>
public partial class WeixinQY_AccessTokenService : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        BaseAccessTokenManage atManage = new BaseAccessTokenManage();
        string accessToken = atManage.AccessToken;
        atManage.Dispose();
        Response.Clear();
        Response.Write(accessToken);
        Response.End();
    }
}