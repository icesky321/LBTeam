using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserNoticeManage : System.Web.UI.Page
{
    LB.SQLServerDAL.UserNoticeInfo MUserNoticeInfo = new LB.SQLServerDAL.UserNoticeInfo();
    LB.BLL.UserNoticeInfo bll_usernoticeinfo = new LB.BLL.UserNoticeInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvUerNoticDataBind();
        }
    }

    void gvUerNoticDataBind()
    {
        if (bll_usernoticeinfo.GetUserNoticeInfoByAudit(false) != null)
        {
            gvUnDealUserNoticeInfo.DataSource = bll_usernoticeinfo.GetUserNoticeInfoByAudit(false);
            gvUnDealUserNoticeInfo.DataBind();
            foreach (GridViewRow gvRow in gvUnDealUserNoticeInfo.Rows)
            {
                string Id = gvRow.Cells[0].Text;
                if (bll_usernoticeinfo.GetUserNoticeInfoByNoticeId(Convert.ToInt32(Id)).Audit == false)
                {
                    ((MultiView)(gvRow.Cells[3].FindControl("MultiView1"))).ActiveViewIndex = 0;
                }
                else
                {
                    ((MultiView)(gvRow.Cells[3].FindControl("MultiView1"))).ActiveViewIndex = 1;
                }
            }
        }
        if (bll_usernoticeinfo.GetUserNoticeInfoByAudit(true) != null)
        {
            gvDealUserNoticeInfo.DataSource = bll_usernoticeinfo.GetUserNoticeInfoByAudit(true);
            gvDealUserNoticeInfo.DataBind();
            foreach (GridViewRow gvRow in gvDealUserNoticeInfo.Rows)
            {
                string Id = gvRow.Cells[0].Text;
                if (bll_usernoticeinfo.GetUserNoticeInfoByNoticeId(Convert.ToInt32(Id)).Audit == false)
                {
                    ((MultiView)(gvRow.Cells[3].FindControl("MultiView2"))).ActiveViewIndex = 0;
                }
                else
                {
                    ((MultiView)(gvRow.Cells[3].FindControl("MultiView2"))).ActiveViewIndex = 1;
                }
            }
        }
    }


    protected void gvUnDealUserNoticeInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")
        {
            string Id = e.CommandArgument.ToString();
            MUserNoticeInfo = bll_usernoticeinfo.GetUserNoticeInfoByNoticeId(Convert.ToInt32(Id));
            MUserNoticeInfo.Audit = true;
            MUserNoticeInfo.AuditDate = System.DateTime.Now;
            MUserNoticeInfo.Operator = HttpContext.Current.User.Identity.Name;
            bll_usernoticeinfo.UpdateUserNoticeInfo(MUserNoticeInfo);
            gvUerNoticDataBind();
        }
        if (e.CommandName == "UnShow")
        {
            string Id = e.CommandArgument.ToString();
            MUserNoticeInfo = bll_usernoticeinfo.GetUserNoticeInfoByNoticeId(Convert.ToInt32(Id));
            MUserNoticeInfo.Audit = false;
            MUserNoticeInfo.AuditDate = System.DateTime.Now;
            MUserNoticeInfo.Operator = HttpContext.Current.User.Identity.Name;
            bll_usernoticeinfo.UpdateUserNoticeInfo(MUserNoticeInfo);
            gvUerNoticDataBind();
        }
    }

    protected void gvUnDealUserNoticeInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = gvUnDealUserNoticeInfo.DataKeys[e.RowIndex].Values["NoticeId"].ToString();
        bll_usernoticeinfo.DeleteUserNoticeInfo(Convert.ToInt32(Id));
        gvUnDealUserNoticeInfo.EditIndex = -1;
        gvUerNoticDataBind();
    }

    protected void gvDealUserNoticeInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")
        {
            string Id = e.CommandArgument.ToString();
            MUserNoticeInfo = bll_usernoticeinfo.GetUserNoticeInfoByNoticeId(Convert.ToInt32(Id));
            MUserNoticeInfo.Audit = true;
            MUserNoticeInfo.AuditDate = System.DateTime.Now;
            MUserNoticeInfo.Operator = HttpContext.Current.User.Identity.Name;
            bll_usernoticeinfo.UpdateUserNoticeInfo(MUserNoticeInfo);
            gvUerNoticDataBind();
        }
        if (e.CommandName == "UnShow")
        {
            string Id = e.CommandArgument.ToString();
            MUserNoticeInfo = bll_usernoticeinfo.GetUserNoticeInfoByNoticeId(Convert.ToInt32(Id));
            MUserNoticeInfo.Audit = false;
            MUserNoticeInfo.AuditDate = System.DateTime.Now;
            MUserNoticeInfo.Operator = HttpContext.Current.User.Identity.Name;
            bll_usernoticeinfo.UpdateUserNoticeInfo(MUserNoticeInfo);
            gvUerNoticDataBind();
        }
    }

    protected void gvDealUserNoticeInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = gvDealUserNoticeInfo.DataKeys[e.RowIndex].Values["NoticeId"].ToString();
        bll_usernoticeinfo.DeleteUserNoticeInfo(Convert.ToInt32(Id));
        gvDealUserNoticeInfo.EditIndex = -1;
        gvUerNoticDataBind();
    }
}