using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class WeixinQY_JDAccession : System.Web.UI.Page
{
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.BLL.UserTypeInfo bll_usertypeinfo = new LB.BLL.UserTypeInfo();
    LB.SQLServerDAL.UserTypeInfo MUserTypeInfo = new LB.SQLServerDAL.UserTypeInfo();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void gvUserInfoDataBind()
    {
        gvUserInfo.DataSource = bll_userinfo.GetUserInfoByUserTypeId_RegionCode_TelNum(5, "", tbTelNum.Text);
        gvUserInfo.DataBind();
        foreach (GridViewRow gvRow in gvUserInfo.Rows)
        {
            string UserId = gvRow.Cells[0].Text;
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            if (string.IsNullOrEmpty(bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).IDCard) == false)
            {
                if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).IDAuthentication == true)
                {
                    ((MultiView)(gvRow.Cells[3].FindControl("MultiView3"))).ActiveViewIndex = 1;
                }
                else
                {
                    ((MultiView)(gvRow.Cells[3].FindControl("MultiView3"))).ActiveViewIndex = 0;
                }
            }
            else
            {
                ((LinkButton)(gvRow.Cells[3].FindControl("lbtnIDCard"))).Visible = false;
                ((MultiView)(gvRow.Cells[3].FindControl("MultiView3"))).ActiveViewIndex = 2;
            }
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).Audit == true)
            {
                ((MultiView)(gvRow.Cells[4].FindControl("MultiView5"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[4].FindControl("MultiView5"))).ActiveViewIndex = 0;
            }
        }
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        gvUserInfoDataBind();
    }

    protected void gvUserInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "choose")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            lbMobileNum.Text = MUserInfo.MobilePhoneNum;
            hfUserId.Value = MUserInfo.UserId.ToString();
        }
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        LB.SQLServerDAL.UserInfo MUser = new LB.SQLServerDAL.UserInfo();
        MUser = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(hfUserId.Value));
        MUser.IsQYUser = true;
        MUser.QYUserId = tbQYId.Text;
        bll_userinfo.UpdateUserInfo(MUser);
        lbMsg.Visible = true;
    }
}