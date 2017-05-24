using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter1 : System.Web.UI.Page
{
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Response.Redirect("../Admin/Manage.aspx");
                }
                else
                {
                    { MultiViewBind(); }
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }

        }
    }

    void MultiViewBind()
    {
        UserBind();
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        if (Request.IsAuthenticated)
        {
            if (MUserInfo.Audit == true)
            {
                btUpdate.Visible = false;
            }
            else
            {
                btUpdate.Visible = true;
            }
            if (MUserInfo.UserTypeId == 1)//如果类型为供应商
            {
                MultiView1.ActiveViewIndex = 0;
                if (string.IsNullOrEmpty(MUserInfo.IDCard))//当身份证和协议为空时
                {
                    btComplete.Visible = true;
                }
                else
                {
                    btComplete.Visible = false;
                }

            }
            else if (MUserInfo.UserTypeId == 2)//如果类型为回收公司
            {
                MultiView1.ActiveViewIndex = 1;
                if (string.IsNullOrEmpty(MUserInfo.IDCard))
                {
                    btComplete1.Visible = true;
                }
                else
                {
                    btComplete1.Visible = false;
                }
            }
            else if (MUserInfo.UserTypeId == 3)//如果类型为冶炼厂
            {
                MultiView1.ActiveViewIndex = 2;
            }
            else if (MUserInfo.UserTypeId == 4)//如果类型为物流公司
            {
                MultiView1.ActiveViewIndex = 3;
            }
            else if (MUserInfo.UserTypeId == 0)//如果类型为老平台账户
            {
                Response.Redirect("UpdateRole.aspx?UserId=" + MUserInfo.UserId.ToString());
            }
            else if (MUserInfo.UserTypeId == 5)//如果类型为地域性业务员
            {

                if (string.IsNullOrEmpty(MUserInfo.IDCard))
                {
                    MultiView1.ActiveViewIndex = 1;
                }
                else if (MUserInfo.Audit == false)
                {
                    MultiView1.ActiveViewIndex = 4;
                }
                else if (MUserInfo.Audit == true)
                {
                   
                }
            }
        }
    }

    void UserBind()
    {
        if (Request.IsAuthenticated)
        {
            MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
            UserNameLabel.Text = MUserInfo.UserName;
            MobilePhoneNumLabel.Text = MUserInfo.MobilePhoneNum;
            ProvinceLabel.Text = MUserInfo.Province;
            CityLabel.Text = MUserInfo.City;
            TownLabel.Text = MUserInfo.Town;
            StreetLabel.Text = MUserInfo.Street;
            IDAuthenticationLabel.Text = MUserInfo.IDAuthentication.ToString();
            lbUpdateMobilePhoneNum.Text = MUserInfo.MobilePhoneNum;
            lbUpdateUserName.Text = MUserInfo.UserName;
            if (MUserInfo.IDAuthentication == true)
            {
                IDAuthenticationLabel.Text = Aunth1.msg;
            }
            else
            {
                IDAuthenticationLabel.Text = UnAunth1.msg;
            }
            //AuditLabel.Text = MUserInfo.Audit.ToString();
            if (MUserInfo.Audit == true)
            {
                AuditLabel.Text = Aunth1.msg;
            }
            else
            {
                AuditLabel.Text = UnAunth1.msg;
            }
            BankNameLabel.Text = MUserInfo.BankName;
            AccountLabel.Text = MUserInfo.Account;
        }
    }

    protected void btComplete_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        string url = "../UserAuthentication.aspx?UserId=" + MUserInfo.UserId.ToString();
        Response.Redirect(url);
    }

    protected void btComplete1_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        string url = "../CopAuthentication.aspx?UserId=" + MUserInfo.UserId.ToString();
        Response.Redirect(url);
    }

    protected void btLocal_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        string url = "../JoinUS.aspx?UserId=" + MUserInfo.UserId.ToString();
        Response.Redirect(url);
    }

    protected void btUpdate_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 5;
        Panel1.Visible = false;
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        UserBind();
        MUserInfo.Province = DDLAddress.province;
        MUserInfo.City = DDLAddress.city;
        MUserInfo.Town = DDLAddress.country;
        MUserInfo.Street = DDLAddress.street;
        bll_userinfo.UpdateUserInfo(MUserInfo);
        Panel1.Visible = true;
        MultiViewBind();

    }
}
