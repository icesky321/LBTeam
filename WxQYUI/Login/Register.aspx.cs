using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login_Register : System.Web.UI.Page
{
    LB.BLL.SMS bll_sms = new LB.BLL.SMS();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.BLL.UserTypeInfo bll_userType = new LB.BLL.UserTypeInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        Load_UserType();
    }

    private void Load_UserType()
    {
        var query = bll_userType.GetUserTypeInfo();
        ddlShenfen.Items.Clear();
        foreach (LB.SQLServerDAL.UserTypeInfo userType in query)
        {
            ddlShenfen.Items.Add(new ListItem(userType.UserTypeName, userType.UserTypeId.ToString()));
        }
        ddlShenfen.Items.Insert(0, "选择行业身份");
    }

    protected void btnReg_Click(object sender, EventArgs e)
    {
        #region  输入表单检验
        if (ddlShenfen.SelectedIndex == 0)
        {
            ltlErrorMsg.Visible = true;
            ltlErrorMsg.Text = "请选择您要注册的行业身份";
            return;
        }
        else
        {
            ltlErrorMsg.Text = "";
            ltlErrorMsg.Visible = false;
        }

        if (string.IsNullOrEmpty(tbMobile.Text))
        {
            ltlErrorMsg.Visible = true;
            ltlErrorMsg.Text = "手机号不可为空";
            return;
        }
        else
        {
            ltlErrorMsg.Text = "";
            ltlErrorMsg.Visible = false;
        }

        if (Session["mobile_code"] == null || Session["mobile_code"].ToString() != tbVeriCode.Text)
        {
            ltlVeriMessage.Text = "验证码输入有误，请重新输入";
            ltlVeriMessage.Visible = true;
        }
        else
        {
            ltlVeriMessage.Text = "";
            ltlVeriMessage.Visible = false;
        }
        #endregion


        Membership.CreateUser(tbMobile.Text, tbPassword.Text);

        LB.SQLServerDAL.UserInfo user = new LB.SQLServerDAL.UserInfo();
        user.UserTypeId = Convert.ToInt32(Convert.ToInt32(ddlShenfen.SelectedValue));
        user.Audit = false;
        //user.AuditDate = Convert.ToDateTime("1900-1-1");
        //user.UserName = tbContacts.Text;
        user.MobilePhoneNum = tbMobile.Text;
        user.CreateTime = System.DateTime.Now;
        user.IDAuthentication = false;
        user.ChopAuthentication = false;
        user.InCharge = false;
        bll_userinfo.NewUserInfo(user);
        Roles.AddUserToRole(user.MobilePhoneNum, "general");

        Response.Redirect("Register.aspx#pageRegCompleted");
    }

    protected void lbtnGetVeriCode_Click(object sender, EventArgs e)
    {

        Random rad = new Random();
        int mobile_code = rad.Next(1000, 10000);
        Session["mobile_code"] = mobile_code.ToString();

        if (tbMobile.Text.Length != 11)
        {
            ltlErrorMsg.Visible = true;
            ltlErrorMsg.Text = "手机号必须为11位";
            return;
        }
        else
        {
            ltlErrorMsg.Text = "";
            ltlErrorMsg.Visible = false;
        }

        if (bll_userinfo.ExistUser(tbMobile.Text))
        {
            ltlVeriMessage.Text = "该手机号已占用，请换手机号";
            ltlVeriMessage.Visible = true;
        }
        else
        {
            bll_sms.SendSMS(tbMobile.Text, "您的验证码是：" + mobile_code.ToString() + "【绿宝】");
            lbtnGetVeriCode.Enabled = false;
            ltlVeriMessage.Text = "在下方输入收到的验证码";
            ltlVeriMessage.Visible = true;
        }


    }

}