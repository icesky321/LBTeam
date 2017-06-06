using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_OneKeySell : System.Web.UI.Page
{
    LB.BLL.UserNoticeInfo bll_usernoticeinfo = new LB.BLL.UserNoticeInfo();
    LB.SQLServerDAL.UserNoticeInfo MUserNoticeInfo = new LB.SQLServerDAL.UserNoticeInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Response.Redirect("~/Admin/Manage.aspx");
                }
                else if (bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name).Audit == true)
                {

                    MultiView1.ActiveViewIndex = 0;

                }
                else
                {
                    Response.Redirect("Deposit.aspx");
                }
            }
            else
            {
                Response.Redirect("~/ChooseRoles.aspx");
            }
        }
    }

    protected void btSell_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        MUserNoticeInfo.UserId = MUserInfo.UserId;
        MUserNoticeInfo.UserNotice = "我有东西要卖，请及时与我联系，联系人：" + MUserInfo.UserName + "联系方式：" + MUserInfo.MobilePhoneNum + "地址：" + MUserInfo.Province + MUserInfo.City + MUserInfo.Town + MUserInfo.Street;
        MUserNoticeInfo.CreateDate = System.DateTime.Now;
        MUserNoticeInfo.Hit = 0;
        MUserNoticeInfo.Audit = false;
        MUserNoticeInfo.AuditDate = Convert.ToDateTime("1900-1-1");
        MUserNoticeInfo.Operator = "";
        bll_usernoticeinfo.NewUserNoticeInfo(MUserNoticeInfo);
        MultiView1.ActiveViewIndex = 1;
    }
}