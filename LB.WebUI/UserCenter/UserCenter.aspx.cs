using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter1 : System.Web.UI.Page
{
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
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
                Response.Redirect("Default.aspx");
            }

        }
    }

    void MultiViewBind()
    {
        UserBind();
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        if (Request.IsAuthenticated)
        {
            if (MUserInfo.UserTypeId == 1)
            {
                MultiView1.ActiveViewIndex = 0;
                if (MUserInfo.IDCard == "" || MUserInfo.Chop == "")
                {
                    btComplete.Visible = true;
                }
                else
                {
                    btComplete.Visible = false;
                }

            }
            else if (MUserInfo.UserTypeId == 2)
            {
                MultiView1.ActiveViewIndex = 1;
                if (MUserInfo.IDCard == "" || MUserInfo.Chop == "")
                {
                    btComplete1.Visible = true;
                }
                else
                {
                    btComplete1.Visible = false;
                }
            }
            else if (MUserInfo.UserTypeId == 3)
            {
                MultiView1.ActiveViewIndex = 2;
            }
            else if (MUserInfo.UserTypeId == 4)
            {
                MultiView1.ActiveViewIndex = 3;
            }
            else if (MUserInfo.UserTypeId == 0)
            {
                Response.Redirect("UpdateRole.aspx?UserId=" + MUserInfo.UserId.ToString());
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
        MCopInfo = bll_copinfo.GetCopInfoeByUserId(MUserInfo.UserId);
        string url = "../CopAuthentication.aspx?CopId=" + MCopInfo.CopId.ToString();
        Response.Redirect(url);
    }
}
