using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Deposit : System.Web.UI.Page
{
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserDepositInfo MUserDepositInfo = new LB.SQLServerDAL.UserDepositInfo();
    LB.BLL.UserDepositInfo bll_userdepositinfo = new LB.BLL.UserDepositInfo();
    LB.BLL.UserAuditMsg bll_UserAuditMsg = new LB.BLL.UserAuditMsg();
    LB.SQLServerDAL.UserAuditMsg MUserAuditMsg = new LB.SQLServerDAL.UserAuditMsg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvUnDealDataBind();
            gvDealDataBind();
        }
    }

    void gvUnDealDataBind()
    {
        //gvUserInfo.DataSource = bll_userinfo.GetUserInfoByUserTypeId(5);
        gvUnDeal.DataSource = bll_UserAuditMsg.GetUserAuditMsgByStatus(false);
        gvUnDeal.DataBind();
        foreach (GridViewRow gvRow in gvUnDeal.Rows)
        {
            string UserId = gvRow.Cells[0].Text;
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).Audit == true)
            {
                ((MultiView)(gvRow.Cells[5].FindControl("MultiView1"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[5].FindControl("MultiView1"))).ActiveViewIndex = 0;
            }
            if (bll_UserAuditMsg.GetUserAuditMsgByUserId(Convert.ToInt32(UserId), false).Status == true)
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView2"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView2"))).ActiveViewIndex = 0;
            }
        }
    }

    void gvDealDataBind()
    {
        gvDeal.DataSource = bll_UserAuditMsg.GetUserAuditMsgByStatus(true);
        gvDeal.DataBind();
        foreach (GridViewRow gvRow in gvDeal.Rows)
        {
            string UserId = gvRow.Cells[0].Text;
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).Audit == true)
            {
                ((MultiView)(gvRow.Cells[5].FindControl("MultiView3"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[5].FindControl("MultiView3"))).ActiveViewIndex = 0;
            }
            if (bll_UserAuditMsg.GetUserAuditMsgByUserId(Convert.ToInt32(UserId), true).Status == true)
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView4"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView4"))).ActiveViewIndex = 0;
            }
        }
    }
}