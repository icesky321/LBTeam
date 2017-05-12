using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CopInfoManage : System.Web.UI.Page
{
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvCopInfoDataBind();
        }
    }

    void gvCopInfoDataBind()
    {
        gvCopInfo.DataSource = bll_copinfo.GetCopInfoByUserType(2);
        gvCopInfo.DataBind();

        foreach (GridViewRow gvRow in gvCopInfo.Rows)
        {
            string CopId = gvRow.Cells[0].Text;
            MCopInfo = bll_copinfo.GetCopInfoeById(Convert.ToInt32(CopId));
            if (bll_copinfo.GetCopInfoeById(Convert.ToInt32(CopId)).BAuthentication == false)
            {
                ((MultiView)(gvRow.Cells[7].FindControl("MultiView1"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[7].FindControl("MultiView1"))).ActiveViewIndex = 1;
            }
            if (bll_copinfo.GetCopInfoeById(Convert.ToInt32(CopId)).HWAuthentication == false)
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView2"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView2"))).ActiveViewIndex = 1;
            }
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(MCopInfo.UserId)).IDAuthentication == false)
            {
                ((MultiView)(gvRow.Cells[9].FindControl("MultiView3"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[9].FindControl("MultiView3"))).ActiveViewIndex = 1;
            }
            //if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(MCopInfo.UserId)).ChopAuthentication == false)
            //{
            //    ((MultiView)(gvRow.Cells[10].FindControl("MultiView4"))).ActiveViewIndex = 0;
            //}
            //else
            //{
            //    ((MultiView)(gvRow.Cells[10].FindControl("MultiView4"))).ActiveViewIndex = 1;
            //}
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(MCopInfo.UserId)).Audit == false)
            {
                ((MultiView)(gvRow.Cells[9].FindControl("MultiView5"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[9].FindControl("MultiView5"))).ActiveViewIndex = 1;
            }
        }
    }

    protected void gvCopInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string CopId = e.CommandArgument.ToString();
        MCopInfo = bll_copinfo.GetCopInfoeById(Convert.ToInt32(CopId));
        MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(MCopInfo.UserId));
        if (e.CommandName == "Bizlicense")
        {
            string url = MCopInfo.Bizlicense;
            Response.Redirect(url);
        }
        if (e.CommandName == "BPass")
        {
            MCopInfo.BAuthentication = true;
        }
        if (e.CommandName == "BUPass")
        {
            MCopInfo.BAuthentication = false;
        }
        if (e.CommandName == "HWPermit")
        {
            string url = MCopInfo.HWPermit;
            Response.Redirect(url);
        }
        if (e.CommandName == "HPass")
        {
            MCopInfo.HWAuthentication = true;
        }
        if (e.CommandName == "HUPass")
        {
            MCopInfo.HWAuthentication = false;
        }
        if (e.CommandName == "IDCard")
        {
            string url = MUserInfo.IDCard;
            Response.Redirect(url);
        }
        if (e.CommandName == "IPass")
        {
            MUserInfo.IDAuthentication= true;
        }
        if (e.CommandName == "IUPass")
        {
            MUserInfo.IDAuthentication = false;
        }
        //if (e.CommandName == "Chop")
        //{
        //    string url = MUserInfo.Chop;
        //    Response.Redirect(url);
        //}
        //if (e.CommandName == "CPass")
        //{
        //    MUserInfo.ChopAuthentication = true;
        //}
        //if (e.CommandName == "CUPass")
        //{
        //    MUserInfo.ChopAuthentication = false;
        //}
        if (e.CommandName == "Pass")
        {
            MUserInfo.Audit = true;
            MUserInfo.AuditDate = System.DateTime.Now;
        }
        if (e.CommandName == "UPass")
        {
            MUserInfo.Audit = false;
            MUserInfo.AuditDate = System.DateTime.Now;
        }
        bll_userinfo.UpdateUserInfo(MUserInfo);
        bll_copinfo.UpdateCopInfo(MCopInfo);
        gvCopInfoDataBind();
    }
}