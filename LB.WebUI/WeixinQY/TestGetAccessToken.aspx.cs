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

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGetAT_ByLB_Click(object sender, EventArgs e)
    {
        AccessTokenManage accessTokenManage = new AccessTokenManage();
        string corpId = ConfigurationManager.AppSettings["CorpID"] ?? "wxabb13491cd384449";
        string corpSecret = ConfigurationManager.AppSettings["CorpSecret"] ?? "reX64E3nivXBU7J393U5u_QaTOe6L89He_DIhpuxVzVxsh3LpNEadlmJGDMlhJ0P";
        Label1.Text = LB.Weixin.AccessTokenManage.GetAccessToken(corpId, corpSecret);
    }

    protected void btnGetAT_ATC_Click(object sender, EventArgs e)
    {
        string accessToken = string.Empty;
        string serviceUri = ConfigurationManager.AppSettings["AccessTokenServiceUri"] ?? "";
        if (string.IsNullOrEmpty(serviceUri))
        {
            using (AccessTokenManage at = new AccessTokenManage())
            {
                accessToken = at.AccessToken;
            }
        }
        else
        {
            accessToken = Senparc.Weixin.HttpUtility.RequestUtility.HttpGet(serviceUri, null);
        }
        Label2.Text = accessToken;
    }
}