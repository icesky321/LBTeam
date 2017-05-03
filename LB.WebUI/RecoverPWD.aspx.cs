using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecoverPWD : System.Web.UI.Page
{
    LB.BLL.SMS bll_sms = new LB.BLL.SMS();
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        if (bll_userinfo.ExistTelNum(tbUserName.Text))
        {
            string pwd = bll_userinfo.GetPWD(tbUserName.Text);
            bll_sms.SendSMS(tbUserName.Text, "您的密码是：" + pwd + "  请妥善保管！【绿宝】");
            lbsubject.Text = "密码已发送到您手机，请关注！";
        }
        else
        {
            lbsubject.Text = "对不起，该手机号不存在，是否输入错误？";
        }

    }
}