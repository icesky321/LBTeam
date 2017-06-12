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
    LB.BLL.UserTypeInfo bll_usertypeinfo = new LB.BLL.UserTypeInfo();
    LB.SQLServerDAL.UserTypeInfo MUsertype = new LB.SQLServerDAL.UserTypeInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("Admin")|| HttpContext.Current.User.IsInRole("InfoManage") || HttpContext.Current.User.IsInRole("UserManage") || HttpContext.Current.User.IsInRole("CustomService"))
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
        MUsertype = bll_usertypeinfo.GetUserTypeById(Convert.ToInt32(MUserInfo.UserTypeId));
        lbRole.Text = MUsertype.UserTypeName;
        if (MUserInfo.Audit == true)
        {
            btComplete1.Visible = false;
            btComplete.Visible = false;

        }
        else
        {
            if (bll_copinfo.ExistUseId(MUserInfo.UserId))//说明是公司性质
            {
                MCopInfo = bll_copinfo.GetCopInfoeByUserId(MUserInfo.UserId);
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
            else//说明是非公司性质
            {
                if (MUserInfo.UserTypeId == 0)//如果类型为老平台账户
                {
                    Response.Redirect("UpdateRole.aspx?UserId=" + MUserInfo.UserId.ToString());
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                    if (string.IsNullOrEmpty(MUserInfo.IDCard))
                    {
                        btComplete.Visible = true;
                    }
                    else
                    {
                        btComplete.Visible = false;
                    }
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

}
