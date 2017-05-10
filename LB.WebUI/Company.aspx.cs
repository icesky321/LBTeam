using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Company : System.Web.UI.Page
{
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    LB.BLL.UserTypeInfo bll_usertype = new LB.BLL.UserTypeInfo();
    LB.SQLServerDAL.UserTypeInfo MUserTypeInfo = new LB.SQLServerDAL.UserTypeInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                //MUserTypeInfo = bll_usertype.GetUserTypeById(Id);
                DLCopInfo.DataSource = bll_copinfo.GetCopInfoByUserType(Id);
                DLCopInfo.DataBind();
            }
        }
    }
    void DLCopInfoDataBind()
    {

        DLCopInfo.DataSource = bll_copinfo.GetCopInfodByAddress(DDLAddress1.province, DDLAddress1.city, DDLAddress1.country, DDLAddress1.street, 2);
        DLCopInfo.DataBind();
        foreach (DataListItem item in this.DLCopInfo.Items)
        {
            if (HttpContext.Current.User.IsInRole("general"))
            { ((Label)item.FindControl("TelNumLabel")).Visible = false;}
                
        }


    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        DLCopInfoDataBind();
    }

    protected void DLCopInfo_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName == "Detail")
        {
            string CopId = e.CommandArgument.ToString();
            string url = "~/CopDetail.aspx?CopId=" + CopId;
            Response.Redirect(url);
        }
    }
}