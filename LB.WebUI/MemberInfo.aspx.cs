using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberInfo : System.Web.UI.Page
{
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
                if (Request.IsAuthenticated)
                {
                    if (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("InfoManage") || HttpContext.Current.User.IsInRole("UserManage"))
                    {
                        DLCopInfoDataBind("", "", "", "", Id);
                    }

                    else if (bll_usermanage.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name).Audit == true)
                    {
                        DLCopInfoDataBind("", "", "", "", Id);
                    }
                    else
                    {
                        Response.Redirect("~/UserCenter/Deposit.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/LoginM.aspx");
                }

            }
        }
    }

    void DLCopInfoDataBind(string province, string city, string country, string street, int UserTypeId)
    {
        if (bll_usermanage.GetUserInfosBySEO(province, city, country, street, UserTypeId.ToString(), "") != null)
        {
            DLCopInfo.DataSource = bll_usermanage.GetUserInfosBySEO(province, city, country, street, UserTypeId.ToString(), "");
            DLCopInfo.DataBind();
            //foreach (DataListItem item in this.DLCopInfo.Items)
            //{
            //    if (Request.IsAuthenticated)
            //    {
            //        if (bll_usermanage.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name).Audit == true)
            //        {
            //            ((MultiView)item.FindControl("MultiView1")).ActiveViewIndex = 2;
            //        }
            //        else
            //        {
            //            ((MultiView)item.FindControl("MultiView1")).ActiveViewIndex = 1;
            //        }
            //    }
            //    else
            //    {
            //        ((MultiView)item.FindControl("MultiView1")).ActiveViewIndex = 0;
            //    }

            //}
        }



    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        DLCopInfoDataBind(DDLAddress1.province, DDLAddress1.city, DDLAddress1.country, DDLAddress1.street, Convert.ToInt32(hfId.Value));
    }
}