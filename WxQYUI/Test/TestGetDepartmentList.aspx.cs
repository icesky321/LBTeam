using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.QY.AdvancedAPIs;

public partial class WeixinQY_Test_TestGetDepartmentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string accessToken = tbAccessToken.Text;
        Senparc.Weixin.QY.AdvancedAPIs.MailList.GetDepartmentListResult result = MailListApi.GetDepartmentList(accessToken);
        
    }
}