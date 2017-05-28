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
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                hfId.Value = Id.ToString();
                //MUserTypeInfo = bll_usertype.GetUserTypeById(Id);
                //DLCopInfo.DataSource = bll_copinfo.GetCopInfoByUserType(Id);
                //DLCopInfo.DataBind();
                DLCopInfoDataBind("","","","",Id);
            }
        }
    }
    void DLCopInfoDataBind(string province,string city,string country,string street, int UserTypeId)
    {

        DLCopInfo.DataSource = bll_copinfo.GetCopInfodByAddress(province, city, country, street, UserTypeId);
        DLCopInfo.DataBind();
        foreach (DataListItem item in this.DLCopInfo.Items)
        {
            if (Request.IsAuthenticated)
            {
                if (bll_usermanage.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name).Audit == true)
                {
                    ((MultiView)item.FindControl("MultiView1")).ActiveViewIndex = 2;
                }
                else
                {
                    ((MultiView)item.FindControl("MultiView1")).ActiveViewIndex = 1;
                }
            }
            else
            {
                ((MultiView)item.FindControl("MultiView1")).ActiveViewIndex = 0;
            }

        }


    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        DLCopInfoDataBind(DDLAddress1.province, DDLAddress1.city, DDLAddress1.country, DDLAddress1.street, Convert.ToInt32(hfId.Value));
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