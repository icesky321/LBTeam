using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Senparc.Weixin.QY.CommonAPIs;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.QY.AdvancedAPIs.Media;
using Senparc.Weixin.QY;
using Senparc.Weixin;

public partial class WeixinQY_Test_TestGetMaterial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGetMaterial_Click(object sender, EventArgs e)
    {
        string accessToken = string.Empty;
        string serviceUri = ConfigurationManager.AppSettings["AccessTokenServiceUri"] ?? "";
        accessToken = Senparc.Weixin.HttpUtility.RequestUtility.HttpGet(serviceUri, null);


        Senparc.Weixin.Entities.WxJsonResult result =
        BatchGetMaterial(accessToken, "mpnews", 0, 10);
    }

    public static Senparc.Weixin.Entities.WxJsonResult BatchGetMaterial(string accessToken, string type, int offset, int count)
    {

        var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/material/batchget?access_token={0}",
            accessToken);

        var data = new
        {
            type = type,
            offset = offset,
            count = count,
        };

        return Senparc.Weixin.CommonAPIs.CommonJsonSend.Send(accessToken, url, data, CommonJsonSendType.POST, 10000);
    }
}