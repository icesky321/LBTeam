using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GoodIdea : System.Web.UI.Page
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
                //MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                Response.Redirect("~/LoginM.aspx");
            }
        }
    }

    protected void btGoodIdea_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        MUserNoticeInfo.UserId = MUserInfo.UserId;
        MUserNoticeInfo.UserNotice = tbUserNotice.Text + "联系人：" + MUserInfo.UserName + "联系方式：" + MUserInfo.MobilePhoneNum + "地址：" + MUserInfo.Province + MUserInfo.City + MUserInfo.Town + MUserInfo.Street;
        MUserNoticeInfo.CreateDate = System.DateTime.Now;
        MUserNoticeInfo.Hit = 0;
        MUserNoticeInfo.Audit = false;
        MUserNoticeInfo.AuditDate = Convert.ToDateTime("1900-1-1");
        MUserNoticeInfo.Operator = "";
        bll_usernoticeinfo.NewUserNoticeInfo(MUserNoticeInfo);
        MultiView1.ActiveViewIndex = 1;
    }
}