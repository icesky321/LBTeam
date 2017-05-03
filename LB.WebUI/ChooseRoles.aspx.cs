using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChooseRoles : System.Web.UI.Page
{
    LB.BLL.UserTypeInfo bll_usertypeinfo = new LB.BLL.UserTypeInfo();
    LB.SQLServerDAL.UserTypeInfo MUserTypeInfo = new LB.SQLServerDAL.UserTypeInfo();
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

    protected void btSearch_Click(object sender, EventArgs e)
    {
        if (ddlUserType.SelectedItem.Value == "1")
        {
            string url = "UserRegister.aspx?UserTypeId=" + ddlUserType.SelectedItem.Value.ToString();
            Response.Redirect(url);
        }
        if (ddlUserType.SelectedItem.Value == "2")
        {
            string url = "CopRegister.aspx?UserTypeId=" + ddlUserType.SelectedItem.Value.ToString();
            Response.Redirect(url);
        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
        {
            btSearch.Enabled = true;
        }
        else
        {
            btSearch.Enabled = false;
        }
    }
}