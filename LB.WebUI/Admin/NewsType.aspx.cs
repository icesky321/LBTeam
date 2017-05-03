using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB;

public partial class Admin_NewsType : System.Web.UI.Page
{
    LB.BLL.NewsType bll_newstype = new LB.BLL.NewsType();
    LB.SQLServerDAL.NewsType MNewType = new LB.SQLServerDAL.NewsType();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvNewsTypeDataBind();
        }
    }
    protected void btSure_Click(object sender, EventArgs e)
    {
        MNewType.NewsType1=tbNewType.Text;
        bll_newstype.NewNewsType(MNewType);
        gvNewsTypeDataBind();
    }

    void gvNewsTypeDataBind()
    {
        gvNewType.DataSource = bll_newstype.GetNewsType();
        gvNewType.DataBind();
    }

    protected void gvNewType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvNewType.EditIndex = -1;
        gvNewsTypeDataBind();
    }
    protected void gvNewType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvNewType.EditIndex = e.NewEditIndex;
        gvNewsTypeDataBind();
    }
    protected void gvNewType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Id = gvNewType.DataKeys[e.RowIndex].Values["NewsTypeId"].ToString();
        LB.SQLServerDAL.NewsType IMNewType = bll_newstype.GetNewTypeById(Convert.ToInt32(Id));
        IMNewType.NewsTypeId = Convert.ToInt32(Id);
        IMNewType.NewsType1 = ((TextBox)(gvNewType.Rows[e.RowIndex].Cells[1].FindControl("tbEditNewsType1"))).Text.ToString().Trim();
        bll_newstype.UpdateNewsType(IMNewType);
        gvNewType.EditIndex = -1;
        gvNewsTypeDataBind();
    }
    protected void gvNewType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = gvNewType.DataKeys[e.RowIndex].Values["NewsTypeId"].ToString();
        bll_newstype.DeleteNewsTypeinfo(Convert.ToInt32(Id));
        gvNewType.EditIndex = -1;
        gvNewsTypeDataBind();
    }
}