using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class UserRegister : System.Web.UI.Page
{
    LB.BLL.UserTypeInfo bll_usertypeinfo = new LB.BLL.UserTypeInfo();
    LB.SQLServerDAL.UserTypeInfo MUserTypeInfo = new LB.SQLServerDAL.UserTypeInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.SMS bll_sms = new LB.BLL.SMS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillUserTypeInfo();
            if (Request.QueryString["UserTypeId"] != null)
            {
                string UserTypeId = Request.QueryString["UserTypeId"];
                hfUserTypeId.Value = UserTypeId;
            }
        }
    }

    void FillUserTypeInfo()
    {
        IQueryable<LB.SQLServerDAL.UserTypeInfo> usertypes = bll_usertypeinfo.GetUserTypeInfo();
        foreach (LB.SQLServerDAL.UserTypeInfo UserTypeInfo in usertypes)
        {
            ddlUser.Items.Add(new ListItem(UserTypeInfo.UserTypeName, UserTypeInfo.UserTypeId.ToString()));
        }
        ddlUser.Items.Insert(0, "");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Random rad = new Random();
        int mobile_code = rad.Next(1000, 10000);
        Session["mobile_code"] = mobile_code.ToString();
        if (tbMobileNum.Text != "" && bll_userinfo.ExistUser(tbMobileNum.Text) == false)
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
            MUserInfo.UserTypeId = Convert.ToInt32(hfUserTypeId.Value);
            MUserInfo.Audit = false;
            MUserInfo.AuditDate = Convert.ToDateTime("1900-1-1");
            MUserInfo.Province = DDLAddress1.province.ToString();
            MUserInfo.City = DDLAddress1.city.ToString();
            MUserInfo.Town = DDLAddress1.country.ToString();
            MUserInfo.Street = DDLAddress1.street.ToString();
            MUserInfo.UserName = tbContacts.Text;
            MUserInfo.MobilePhoneNum = tbMobileNum.Text;
            MUserInfo.CreateTime = System.DateTime.Now;
            MUserInfo.IDAuthentication = false;
            MUserInfo.ChopAuthentication = false;
            MUserInfo.InCharge = false;
            bll_userinfo.NewUserInfo(MUserInfo);
            Roles.AddUserToRole(MUserInfo.MobilePhoneNum, "general");
            string url = "UserAuthentication.aspx?UserId=" + MUserInfo.UserId.ToString();
            Response.Redirect(url);
        }
        else
        {
            lbMsg.Text = "请确认验证码是否输入正确";
            //Label2.Text = "NO";
        }
    }
}