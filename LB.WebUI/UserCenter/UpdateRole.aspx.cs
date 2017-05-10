using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_UpdateRole : System.Web.UI.Page
{
    LB.BLL.UserTypeInfo bll_usertypeinfo = new LB.BLL.UserTypeInfo();
    LB.SQLServerDAL.UserTypeInfo MUserTypeInfo = new LB.SQLServerDAL.UserTypeInfo();
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["UserId"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["UserId"]);
                hfUserId.Value = Id.ToString();
                FillUserTypeInfo();
            }
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

    protected void btSure_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(hfUserId.Value));
        MUserInfo.UserTypeId = Convert.ToInt32(ddlUserType.SelectedItem.Value);
        MUserInfo.Province = DDLAddress1.province;
        MUserInfo.City = DDLAddress1.city;
        MUserInfo.Town = DDLAddress1.country;
        MUserInfo.Street = DDLAddress1.street;
        bll_userinfo.UpdateUserInfo(MUserInfo);
        Response.Redirect("UserCenter.aspx");
    }
}