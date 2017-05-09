using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_Supplier_LocalRecycling : System.Web.UI.Page
{
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiViewBind();
        }
    }

    void MultiViewBind()
    {
        if (Request.IsAuthenticated)
        {
            if (HttpContext.Current.User.IsInRole("CESupplier") || HttpContext.Current.User.IsInRole("CERecyclingCop"))
            {
                MultiView1.ActiveViewIndex = 0;
                UserBind(HttpContext.Current.User.Identity.Name);
            }
            else
            {
                MultiView1.ActiveViewIndex = 1;
            }
        }
        else {
            Response.Redirect("../Default.aspx");
        }
    }

    void UserBind(string TelNum)
    {
        
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(TelNum);
        LB.SQLServerDAL.UserInfo MUserInfoNew = bll_userinfo.GetUserInfoByAddress(5, MUserInfo.Province, MUserInfo.City, MUserInfo.Town, MUserInfo.Street);
        UserNameLabel.Text = MUserInfoNew.UserName;
        MobilePhoneNumLabel.Text = MUserInfoNew.MobilePhoneNum;
        ProvinceLabel.Text = MUserInfoNew.Province;
        CityLabel.Text = MUserInfoNew.City;
        TownLabel.Text = MUserInfoNew.Town;
        StreetLabel.Text = MUserInfoNew.Street;
        IDAuthenticationLabel.Text = MUserInfoNew.IDAuthentication.ToString();
        if (MUserInfoNew.IDAuthentication == true)
        {
            IDAuthenticationLabel.Text = Aunth1.msg;
        }
        else
        {
            IDAuthenticationLabel.Text = UnAunth1.msg;
        }
        //AuditLabel.Text = MUserInfo.Audit.ToString();
        if (MUserInfoNew.Audit == true)
        {
            AuditLabel.Text = Aunth1.msg;
        }
        else
        {
            AuditLabel.Text = UnAunth1.msg;
        }
        BankNameLabel.Text = MUserInfoNew.BankName;
        AccountLabel.Text = MUserInfoNew.Account;
    }
}