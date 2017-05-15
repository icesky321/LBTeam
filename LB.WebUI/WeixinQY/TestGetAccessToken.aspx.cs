using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using LB.Weixin;

public partial class WeixinQY_TestGetAccessToken : System.Web.UI.Page
{
    AccessTokenManage accessTokenManage = new AccessTokenManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        string corpId = ConfigurationManager.AppSettings["CorpID"] ?? "wxabb13491cd384449";
        string corpSecret = ConfigurationManager.AppSettings["CorpSecret"] ?? "reX64E3nivXBU7J393U5u_QaTOe6L89He_DIhpuxVzVxsh3LpNEadlmJGDMlhJ0P";
        Label1.Text = LB.Weixin.AccessTokenManage.GetAccessToken(corpId, corpSecret);
    }
}