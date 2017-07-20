using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB.SQLServerDAL;
using LB.Weixin;
using Senparc.Weixin.Entities;

public partial class Admin_WeixinQY_UserAccession : System.Web.UI.Page
{
    LB.SQLServerDAL.LBDataContext dbContext = new LB.SQLServerDAL.LBDataContext(LB.SQLServerDAL.DS.ConnectionString.ConnectionStringLB());
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();
    LB.Weixin.Contact.MemberManage bll_member = new LB.Weixin.Contact.MemberManage();
    LB.BLL.UserTypeInfo bll_userType = new LB.BLL.UserTypeInfo();
    System.Collections.Generic.Dictionary<string, string> userTypeDS = new Dictionary<string, string>();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        Load_UserType();
        if (!IsPostBack)
        {
            Init_Load();
        }

    }

    private void Load_UserType()
    {
        var userTypes = bll_userType.GetUserTypeInfo();
        foreach (LB.SQLServerDAL.UserTypeInfo userType in userTypes)
        {
            userTypeDS.Add(userType.UserTypeId.ToString(), userType.UserTypeName);
        }
    }

    private void Init_Load()
    {
        LoadUsers();
    }

    private void LoadUsers()
    {
        var query = from c in dbContext.UserInfo
                    where c.Audit == true && c.IsQYUser == false && c.UserTypeId > 1
                    select c;
        gvUsers.DataSource = query;
        gvUsers.DataBind();
    }

    protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Create")
        {
            int userId = 0;
            int.TryParse(e.CommandArgument.ToString(), out userId);
            if (userId == 0)
                return;

            LB.SQLServerDAL.UserInfo user = bll_userManage.GetUserInfoByUserId(userId);
            string qyUserId = LB.BLL.CodeRule.GenerateNewQYUserId();

            LB.Weixin.BaseAccessTokenManage batm = new LB.Weixin.BaseAccessTokenManage();
            string accessToken = batm.AccessToken;

            LB.Weixin.部门 dep = 部门.平台员工;

            switch (user.UserTypeId)
            {
                case 2:
                    dep = 部门.地域回收公司;
                    break;
                case 3:
                    dep = 部门.冶炼厂;
                    break;
                case 5:
                    dep = 部门.地域认证回收员;
                    break;
                default:
                    dep = 部门.平台员工;
                    break;
            }

            QyJsonResult result = bll_member.CreateMember(qyUserId, user.UserName, user.MobilePhoneNum, dep, accessToken);
            lbResult.Text = result.errmsg;

            if (result.errmsg == "created")
            {
                user.QYUserId = qyUserId;
                user.IsQYUser = true;
                bll_userManage.UpdateUserInfo(user);
            }
            LoadUsers();
        }
    }

    protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Literal ltlVocationType = e.Row.FindControl("ltlVocationType") as Literal;
            HiddenField hfVocationTypeId = e.Row.FindControl("hfVocationTypeId") as HiddenField;
            ltlVocationType.Text = userTypeDS[hfVocationTypeId.Value];

            HiddenField hfRegionCode = e.Row.FindControl("hfRegionCode") as HiddenField;
            Label lbRegionWholeName = e.Row.FindControl("lbRegionWholeName") as Label;
            if (!string.IsNullOrEmpty(hfRegionCode.Value))
            {
                Cobe.CnRegion.SQLServerDAL.Region region = bll_region.GetRegion(hfRegionCode.Value);
                if (region == null)
                    return;

                lbRegionWholeName.Text = region.WholeName;
            }
        }
    }
}