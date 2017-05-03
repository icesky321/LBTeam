using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using System.Web.Security;

public partial class CopRegister : System.Web.UI.Page
{
    LB.BLL.SMS bll_sms = new LB.BLL.SMS();
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["UserTypeId"] != null)
            {
                string UserTypeId = Request.QueryString["UserTypeId"];
                hfUserTypeId.Value = UserTypeId;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Random rad = new Random();
        int mobile_code = rad.Next(1000, 10000);
        Session["mobile_code"] = mobile_code.ToString();
        if (tbMobileNum.Text != "" && bll_userinfo.ExistTelNum(tbMobileNum.Text) == false)
        {
            bll_sms.SendSMS(tbMobileNum.Text, "您的验证码是：" + mobile_code.ToString() + "【绿宝】");
            Button1.Enabled = false;
            lbMsg.Text = "短信已发送，请紧盯手机哦~";
        }
        else
        {
            lbMsg.Text = "该手机号已注册，请换手机号提交";
        }
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        string mobile_code = Session["mobile_code"].ToString();

        if (tbCode.Text == mobile_code)
        {

            Membership.CreateUser(tbMobileNum.Text, tbPassword.Text);
            MCopInfo.CopName = tbCopName.Text;
            MUserInfo.Province = DDLAddress1.province.ToString();
            MUserInfo.City = DDLAddress1.city.ToString();
            //if (DDLAddress1.country.ToString() != "")
            //{
                MUserInfo.Town = DDLAddress1.country.ToString();
                MUserInfo.Street = DDLAddress1.street.ToString();
                //MCopInfo.CopDetail = FreeTextBox1.Text;
                MUserInfo.UserName = tbContacts.Text;
                MUserInfo.MobilePhoneNum = tbMobileNum.Text;
                MUserInfo.UserTypeId = Convert.ToInt32(hfUserTypeId.Value);
                MCopInfo.BAuthentication = false;
                MCopInfo.HWAuthentication = false;
                MUserInfo.IDAuthentication = false;
                MUserInfo.Audit = false;
                MUserInfo.CreateTime = System.DateTime.Now;
                bll_userinfo.NewUserInfo(MUserInfo);
                MCopInfo.UserId = MUserInfo.UserId;
                bll_copinfo.NewCopInfo(MCopInfo);
                string url = "CopAuthentication.aspx?CopId=" + MCopInfo.CopId.ToString();
                Response.Redirect(url);
            //}
            //else
            //{
            //    DDLAddress1.setMsg("该项不能为空");
            //}

        }
        else
        {
            lbMsg.Text = "请确认验证码是否输入正确";
            //Label2.Text = "NO";
        }
    }
}