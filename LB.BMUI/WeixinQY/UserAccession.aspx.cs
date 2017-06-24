using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB.SQLServerDAL;

public partial class Admin_WeixinQY_UserAccession : System.Web.UI.Page
{
    LB.SQLServerDAL.LBDataContext dbContext = new LB.SQLServerDAL.LBDataContext(LB.SQLServerDAL.DS.ConnectionString.ConnectionStringLB());
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();
    LB.WeixinQYWS.MemberService ws_member = new LB.WeixinQYWS.MemberService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        LoadUsers();
    }

    private void LoadUsers()
    {
        var query = from c in dbContext.UserInfo
                    where c.Audit == true && c.IsQYUser == false && c.UserTypeId == 5
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

            lbResult.Text = ws_member.CreateMember(qyUserId, user.UserName, user.MobilePhoneNum, LB.WeixinQYWS.部门.地域认证回收员);

            if (lbResult.Text == "created")
            {
                user.QYUserId = qyUserId;
                user.IsQYUser = true;
                bll_userManage.UpdateUserInfo(user);
            }
            LoadUsers();
        }
    }
}