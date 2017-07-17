using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

/// <summary>
/// 本系统的角色有：报销系统具有两种用户角色 Baoxiao.Admin Baoxiao.Accountant
/// </summary>
public partial class BasicConfig_SysUserManage : System.Web.UI.Page
{
    LB.BLL.StaffManage bll_staff = new LB.BLL.StaffManage();
    LB.Weixin.Message.MsgSender bll_wxSender = new LB.Weixin.Message.MsgSender();
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }



    #region 属性

    /// <summary>
    /// 司磅员
    /// </summary>
    public string RoleWeighman
    {
        get { return "Instruct.Weighman"; }
    }

    /// <summary>
    /// 中控确认人
    /// </summary>
    public string RoleConfirmor
    {
        get { return "Instruct.Confirmor"; }
    }

    /// <summary>
    /// 报表查阅者
    /// </summary>
    public string RoleVisitor
    {
        get { return "Instruct.Visitor"; }
    }

    #endregion

    #region 初始加载
    private void Init_Load()
    {
        GetCountOfUser();
        LoadStaff();
    }

    private void GetCountOfUser()
    {
        lbCountOfUser.Text = bll_staff.GetStaffSum().ToString();
    }

    private void LoadStaff()
    {
        gvUser.DataSource = bll_staff.GetStaff();
        gvUser.DataBind();
    }
    #endregion

    /// <summary>
    /// 判断指定工号职工是否是企业微信用户。
    /// </summary>
    /// <param name="jobNumber">工号</param>
    /// <returns></returns>
    //protected bool IsWeixinUser(string jobNumber)
    //{
    //    return bll_wxSender.IsWeixinUser(jobNumber);
    //}

    #region 从角色中 添加 或 删除 用户
    protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddToRole")
        {
            ImageButton imgButton = e.CommandSource as ImageButton;
            string jobNumber = e.CommandArgument.ToString();
            string roleName = imgButton.AlternateText;
            AddToRoleBase(jobNumber, roleName);
            LoadStaff();
        }

        if (e.CommandName == "RemoveFromRole")
        {
            ImageButton imgButton = e.CommandSource as ImageButton;
            string jobNumber = e.CommandArgument.ToString();
            string roleName = imgButton.AlternateText;
            RemoveFromRoleBase(jobNumber, roleName);
            LoadStaff();
        }

        if (e.CommandName == "Config")
        {
            Response.Redirect("EditStaff.aspx?staffId=" + e.CommandArgument.ToString());
        }
    }


    // 将用户添加进指定的角色
    private void AddToRoleBase(string jobNumber, string roleName)
    {
        if (!Roles.RoleExists(roleName))
        {
            Roles.CreateRole(roleName);
        }

        if (!Roles.IsUserInRole(jobNumber, roleName))
        {
            Roles.AddUserToRole(jobNumber, roleName);
        }
    }

    // 将用户从指定的角色中移除
    private void RemoveFromRoleBase(string jobNumber, string roleName)
    {
        if (Roles.RoleExists(roleName) && Roles.IsUserInRole(jobNumber, roleName))
        {
            Roles.RemoveUserFromRole(jobNumber, roleName);
        }
    }

    #endregion

    protected void gvUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // TODO 人在公司时，调试下面语句，jobNumber 是否能正常获取到工号。

        string staffIdstr = e.Keys["StaffId"].ToString();
        Guid staffId = Guid.Empty;
        Guid.TryParse(staffIdstr, out staffId);

        if (staffId == Guid.Empty)
            return;

        LB.SQLServerDAL.Staff staff = bll_staff.GetStaffByStaffId(staffId);
        if (staff == null)
            return;

        MembershipUser accUser = Membership.GetUser(staff.MobileNum);
        if (accUser != null)
        {
            // 从角色中移除，可能无需手动移除角色，也许删除了账户就自动移除角色。
            RemoveFromRoleBase(staffIdstr, this.RoleWeighman);
            RemoveFromRoleBase(staffIdstr, this.RoleConfirmor);
            RemoveFromRoleBase(staffIdstr, this.RoleVisitor);
            // 删除用户账户
            Membership.DeleteUser(staff.MobileNum);
        }

        // 删除用户
        bll_user.DeleteUserInfo(staff.MobileNum);

        // 删除平台员工
        bll_staff.DeleteStaff(staffId);

        LoadStaff();
    }

    protected void btnCreateUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateStaff.aspx");
    }
}