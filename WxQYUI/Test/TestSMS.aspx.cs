using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_TestSMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LB.BLL.SMS sms = new LB.BLL.SMS();
        //sms.SendSMS("13958202267", "[绿宝科技]验证码：123456，此验证码即为您的当前登录密码，请登录后立即更改您的登录密码。");
        sms.SendSMS("15267863162", "验证码：你已成功发布出售信息，绿宝承诺在两日内对您的出售请求做出处理。【绿宝】");
    }
}