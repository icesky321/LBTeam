using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Linq;

public partial class Admin_UserAdmin_CreateNewUser : System.Web.UI.Page
{
    LB.BLL.UserTypeInfo bll_usertypeinfo = new LB.BLL.UserTypeInfo();
    LB.SQLServerDAL.UserTypeInfo MUserTypeInfo = new LB.SQLServerDAL.UserTypeInfo();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillUserTypeInfo();
        }
    }

    void FillUserTypeInfo()
    {
        IQueryable<LB.SQLServerDAL.UserTypeInfo> usertypes = bll_usertypeinfo.GetUserTypeInfo();
        foreach (LB.SQLServerDAL.UserTypeInfo UserTypeInfo in usertypes)
        {
            ddlUserType.Items.Add(new ListItem(UserTypeInfo.UserTypeName, UserTypeInfo.UserTypeId.ToString()));
        }
        ddlUserType.Items.Insert(0, "");
    }

    //protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlUserType.SelectedValue == "1")
    //    {
    //        Panel1.Visible = true;
    //    }
    //    else
    //    {
    //        Panel1.Visible = false;
    //    }
    //}


    protected void btnCreateUser_Click(object sender, EventArgs e)
    {
        Membership.CreateUser(tbMobileNum.Text.Trim(), tbPassword.Text);
        MUserInfo.UserTypeId = 0;
        MUserInfo.UserName = tbUserName.Text;
        MUserInfo.MobilePhoneNum = tbMobileNum.Text;
        MUserInfo.Province = DDLAddress1.province.ToString();
        MUserInfo.City = DDLAddress1.city.ToString();
        MUserInfo.Town = DDLAddress1.country.ToString();
        MUserInfo.Street = DDLAddress1.street.ToString();
        MUserInfo.CreateTime = System.DateTime.Now;
        MUserInfo.IDAuthentication = false;
        MUserInfo.ChopAuthentication = false;
        MUserInfo.InCharge = false;
        MUserInfo.Audit = false;
        MUserInfo.AuditDate = Convert.ToDateTime("1900-1-1");
        bll_userinfo.NewUserInfo(MUserInfo);
        //Response.Redirect("UpdateEmployee.aspx?Account=" + tbMobileNum.Text.Trim());
        Response.Redirect("AddUserToRole.aspx");
    }
}
