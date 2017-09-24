using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_JD_SetBookBillMode : System.Web.UI.Page
{
    LB.BLL.ConfigManage bll_configManage = new LB.BLL.ConfigManage();
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    #region
    private void Init_Load()
    {
        if (User.Identity.IsAuthenticated)
        {
            LB.SQLServerDAL.JD_Config config = bll_configManage.GetJD_Config(User.Identity.Name);
            if (config == null)
            {
                hfMode.Value = "on";
                lbMode.Text = "接单中";
                btnSetMode.Text = "关闭接单模式";
                Image1.ImageUrl = "~/Syb_JD/Images/mode_on.jpg";
                return;
            }

            if (config.BookBillModeToggle)
            {
                hfMode.Value = "on";
                lbMode.Text = "接单中";
                btnSetMode.Text = "关闭接单模式";
                Image1.ImageUrl = "~/Syb_JD/Images/mode_on.jpg";
            }
            else
            {
                hfMode.Value = "off";
                lbMode.Text = "休息中";
                btnSetMode.Text = "开启接单模式";
                Image1.ImageUrl = "~/Syb_JD/Images/mode_off.gif";
            }
        }
    }

    #endregion

    protected void btnSetMode_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
            return;

        LB.SQLServerDAL.JD_Config config = bll_configManage.GetJD_Config(User.Identity.Name);

        if (config == null)
        {
            config = new LB.SQLServerDAL.JD_Config();
            config.MobilePhoneNum = User.Identity.Name;
            config.UserId = bll_userManage.GetUserInfoByTelNum(User.Identity.Name).UserId;
            config.BookBillModeToggle = true;
            config.BookBillStatusRemind = true;
        }

        if (hfMode.Value == "on")
        {
            hfMode.Value = "off";

            config.BookBillModeToggle = false;
            lbMode.Text = "休息中";
            btnSetMode.Text = "开启接单模式";
            Image1.ImageUrl = "~/Syb_JD/Images/mode_off.gif";
        }
        else
        {
            hfMode.Value = "on";
            config.BookBillModeToggle = true;
            lbMode.Text = "接单中";
            btnSetMode.Text = "关闭接单模式";
            Image1.ImageUrl = "~/Syb_JD/Images/mode_on.jpg";
        }
        bll_configManage.SetConfig(config);
    }
}