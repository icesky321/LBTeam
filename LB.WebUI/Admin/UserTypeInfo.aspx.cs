using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB;

public partial class Admin_UserTypeInfo : System.Web.UI.Page
{
    LB.BLL.UserTypeInfo bll_usertypeinfo = new LB.BLL.UserTypeInfo();
    LB.SQLServerDAL.UserTypeInfo MUserTypeInfo = new LB.SQLServerDAL.UserTypeInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvUserTypeDataBind();
        }
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        MUserTypeInfo.UserTypeName = tbUserType.Text;
        bll_usertypeinfo.NewUserTypeInfo(MUserTypeInfo);
        gvUserTypeDataBind();
    }

    void gvUserTypeDataBind()
    {
        gvUserType.DataSource = bll_usertypeinfo.GetUserTypeInfo();
        gvUserType.DataBind();
    }

    protected void gvUserType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvUserType.EditIndex = -1;
        gvUserTypeDataBind();
    }
    protected void gvUserType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvUserType.EditIndex = e.NewEditIndex;
        gvUserTypeDataBind();
    }
    protected void gvUserType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Id = gvUserType.DataKeys[e.RowIndex].Values["UserTypeId"].ToString();
        LB.SQLServerDAL.UserTypeInfo IMUserTypeInfo = bll_usertypeinfo.GetUserTypeById(Convert.ToInt32(Id));
        IMUserTypeInfo.UserTypeId = Convert.ToInt32(Id);
        IMUserTypeInfo.UserTypeName = ((TextBox)(gvUserType.Rows[e.RowIndex].Cells[1].FindControl("tbEditUserTypeName"))).Text.ToString().Trim();
        bll_usertypeinfo.UpdateUserTypeInfo(IMUserTypeInfo);
        gvUserType.EditIndex = -1;
        gvUserTypeDataBind();
    }
    protected void gvUserType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = gvUserType.DataKeys[e.RowIndex].Values["UserTypeId"].ToString();
        bll_usertypeinfo.DeleteUserTypeInfo(Convert.ToInt32(Id));
        gvUserType.EditIndex = -1;
        gvUserTypeDataBind();
    }
}