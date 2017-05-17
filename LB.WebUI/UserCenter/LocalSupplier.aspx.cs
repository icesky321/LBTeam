using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_LocalSupplier : System.Web.UI.Page
{
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
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
            if (HttpContext.Current.User.IsInRole("CERecyclingCop") || HttpContext.Current.User.IsInRole("CEUser"))
            {
                MultiView1.ActiveViewIndex = 0;
                DLCopInfoDataBind(HttpContext.Current.User.Identity.Name);
            }
            else
            {
                MultiView1.ActiveViewIndex = 1;
            }
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }

    void DLCopInfoDataBind(string TelNum)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(TelNum);
        LB.SQLServerDAL.UserInfo MUserInfoNew = bll_userinfo.GetUserInfoByAddress(1, MUserInfo.Province, MUserInfo.City, MUserInfo.Town, MUserInfo.Street);
        DLCopInfo.DataSource = bll_userinfo.GetUserInfosBySEO(MUserInfoNew.Province, MUserInfoNew.City, MUserInfoNew.Town, MUserInfoNew.Street, "1", "");
        DLCopInfo.DataBind();


    }
}