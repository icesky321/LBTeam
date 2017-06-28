using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_Monitor_SearchPuteAccounts : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_users();
        }
    }

    private void Load_users()
    {
        MembershipUserCollection users = Membership.GetAllUsers();
        lboxUsers.Items.Clear();
        foreach (MembershipUser user in users)
        {
            if (!bll_user.ExistTelNum(user.UserName))
                lboxUsers.Items.Add(user.UserName);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string userName = lboxUsers.SelectedItem.Text;
        Membership.DeleteUser(userName);
        Load_users();
    }
}