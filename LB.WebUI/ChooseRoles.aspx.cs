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
            if (Request.IsAuthenticated)
            {
                Response.Redirect("~/UserCenter/UserCenter.aspx");
            }
            else
            { FillUserTypeInfo(); }

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
            if (RadioButton1.Checked)
            {
                string url = "UserRegister.aspx?UserTypeId=" + ddlUserType.SelectedItem.Value.ToString();
                Response.Redirect(url);
            }
            else if (RadioButton2.Checked)
            {
                string url = "CopRegister.aspx?UserTypeId=" + ddlUserType.SelectedItem.Value.ToString();
                Response.Redirect(url);
            }

        }
        else if (ddlUserType.SelectedItem.Value == "5")
        {
            string url = "UserRegister.aspx?UserTypeId=" + ddlUserType.SelectedItem.Value.ToString();
            Response.Redirect(url);
        }
        else
        {
            string url = "CopRegister.aspx?UserTypeId=" + ddlUserType.SelectedItem.Value.ToString();
            Response.Redirect(url);
        }
    }

    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUserType.SelectedValue == "1")
        {
            Panel1.Visible = true;
        }
        else
        {
            Panel1.Visible = false;
        }
    }
}