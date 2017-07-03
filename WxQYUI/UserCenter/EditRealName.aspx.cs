using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_EditRealName : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);
        if (user == null)
            return;

        if (string.IsNullOrEmpty(user.RealName))
            ltlRealName.Text = "未实名";
        else
        {
            ltlRealName.Text = user.RealName;
            tbRealName.Text = user.RealName;
        }

        if (string.IsNullOrEmpty(user.UserName))
            ltlNiChen.Text = "未设置";
        else
        {
            ltlNiChen.Text = user.UserName;
            tbNiChen.Text = user.UserName;
        }

        tbRealName.Text = user.RealName;
    }

    protected void btnEditRealName_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(viewEditRealName);
    }

    protected void btnSaveRealName_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);
        if (user == null)
            return;


        string realName = tbRealName.Text;
        if (!string.IsNullOrEmpty(realName))
        {
            user.RealName = realName;
            bll_user.UpdateUserInfo(user);
        }

        Init_Load();

        MultiView1.SetActiveView(viewRealName);
    }

    protected void btnEditNiChen_Click(object sender, EventArgs e)
    {
        MultiView2.SetActiveView(viewEditNiChen);
    }

    protected void btnSaveNiChen_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);
        if (user == null)
            return;


        string nichen = tbNiChen.Text;
        if (!string.IsNullOrEmpty(nichen))
        {
            user.UserName = nichen;
            bll_user.UpdateUserInfo(user);
        }

        Init_Load();

        MultiView2.SetActiveView(viewShowNiChen);
    }
}