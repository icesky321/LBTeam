using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login_Register : System.Web.UI.Page
{
    LB.BLL.SMS bll_sms = new LB.BLL.SMS();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.BLL.UserTypeInfo bll_userType = new LB.BLL.UserTypeInfo();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["UserTypeId"] != null)
            {
                Init_Load();
                //Load_Address();
                //Load_Province();
                ddlShenfen.SelectedValue = Request.QueryString["UserTypeId"];
            }
            else
            {
                Init_Load();
                //Load_Address();
                //Load_Province();
            }

        }
    }

    private void Init_Load()
    {
        Load_UserType();
    }

    //private void Load_Address()
    //{
    //    if (!User.Identity.IsAuthenticated)
    //        return;

    //    string userName = User.Identity.Name;

    //    LB.SQLServerDAL.UserInfo user = bll_userinfo.GetUserInfoByTelNum(userName);

    //    if (user == null)
    //        return;

    //    tbAddress.Text = string.IsNullOrEmpty(user.Address) ? "" : user.Address;
    //}

    //#region  加载省市县
    //private void Load_Province()
    //{
    //    var provinces = bll_region.GetRegions("0");
    //    ddlProvince.Items.Clear();
    //    foreach (Cobe.CnRegion.SQLServerDAL.Region region in provinces)
    //    {
    //        ddlProvince.Items.Add(new ListItem(region.AreaName, region.Id));
    //    }
    //    ddlProvince.Items.Insert(0, "--选择省份--");
    //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<Script  type=\"text / javascript\">window.location.hash('#regionBegin');</Script>");
    //}

    //private void Load_City()
    //{
    //    var cities = bll_region.GetRegions(ddlProvince.SelectedValue);
    //    ddlCity.Items.Clear();
    //    foreach (Cobe.CnRegion.SQLServerDAL.Region region in cities)
    //    {
    //        ddlCity.Items.Add(new ListItem(region.AreaName, region.Id));
    //    }
    //    ddlCity.Items.Insert(0, "--选择城市--");
    //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<Script  type=\"text / javascript\">window.scrollTo(0, 500);</Script>");
    //}

    //private void Load_County()
    //{
    //    var counties = bll_region.GetRegions(ddlCity.SelectedValue);
    //    ddlCounty.Items.Clear();
    //    foreach (Cobe.CnRegion.SQLServerDAL.Region region in counties)
    //    {
    //        ddlCounty.Items.Add(new ListItem(region.AreaName, region.Id));
    //    }
    //    ddlCounty.Items.Insert(0, "--选择区县--");
    //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<Script>window.location.hash = '#regionBegin';</Script>");
    //}

    //private void Load_Street()
    //{
    //    var streets = bll_region.GetRegions(ddlCounty.SelectedValue);
    //    ddlStreet.Items.Clear();
    //    foreach (Cobe.CnRegion.SQLServerDAL.Region region in streets)
    //    {
    //        ddlStreet.Items.Add(new ListItem(region.AreaName, region.Id));
    //    }
    //    ddlStreet.Items.Insert(0, "--选择区县--");
    //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<Script>window.location.hash = '#regionBegin';</Script>");
    //}
    //#endregion

    //#region 地址下拉列表
    //protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlProvince.SelectedIndex > 0)
    //    {
    //        hfRegionCode.Value = ddlProvince.SelectedValue;
    //        Load_City();
    //    }
    //}

    //protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlCity.SelectedIndex > 0)
    //    {
    //        hfRegionCode.Value = ddlCity.SelectedValue;
    //        Load_County();
    //    }
    //}

    //protected void ddlCounty_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlCounty.SelectedIndex > 0)
    //    {
    //        hfRegionCode.Value = ddlCounty.SelectedValue;
    //        Load_Street();
    //    }
    //}

    //protected void ddlStreet_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlStreet.SelectedIndex > 0)
    //    {
    //        hfRegionCode.Value = ddlStreet.SelectedValue;
    //    }
    //}
    //#endregion

    private void Load_UserType()
    {
        var query = bll_userType.GetUserTypeInfo();
        ddlShenfen.Items.Clear();
        foreach (LB.SQLServerDAL.UserTypeInfo userType in query)
        {
            ddlShenfen.Items.Add(new ListItem(userType.UserTypeName, userType.UserTypeId.ToString()));
        }
        ddlShenfen.Items.Insert(0, "选择行业身份");
    }

    protected void btnReg_Click(object sender, EventArgs e)
    {
        #region  输入表单检验
        if (ddlShenfen.SelectedIndex == 0)
        {
            ltlErrorMsg.Visible = true;
            ltlErrorMsg.Text = "请选择您要注册的行业身份";
            return;
        }
        else
        {
            ltlErrorMsg.Text = "";
            ltlErrorMsg.Visible = false;
        }

        if (string.IsNullOrEmpty(tbMobile.Text))
        {
            ltlErrorMsg.Visible = true;
            ltlErrorMsg.Text = "手机号不可为空";
            return;
        }
        else
        {
            ltlErrorMsg.Text = "";
            ltlErrorMsg.Visible = false;
        }

        if (Session["mobile_code"] == null || Session["mobile_code"].ToString() != tbVeriCode.Text)
        {
            ltlVeriMessage.Text = "验证码输入有误，请重新输入";
            ltlVeriMessage.Visible = true;
        }
        else
        {
            ltlVeriMessage.Text = "";
            ltlVeriMessage.Visible = false;
        }
        if (ddlStreet.SelectedItem.Value == "")
        {
            ltlErrorMsg.Visible = true;
            ltlErrorMsg.Text = "请完善地址信息";
        }
        #endregion
        else
        {
            Membership.CreateUser(tbMobile.Text, tbPassword.Text);

            LB.SQLServerDAL.UserInfo user = new LB.SQLServerDAL.UserInfo();
            user.UserName = Guid.NewGuid().ToString();
            user.UserTypeId = Convert.ToInt32(Convert.ToInt32(ddlShenfen.SelectedValue));
            user.Audit = false;
            user.RegionCode = ddlStreet.SelectedValue;
            user.MobilePhoneNum = tbMobile.Text;
            user.CreateTime = System.DateTime.Now;
            user.IDAuthentication = false;
            user.ChopAuthentication = false;
            user.InCharge = false;
            user.Address = tbAddress.Text;
            bll_userinfo.NewUserInfo(user);
            Roles.AddUserToRole(user.MobilePhoneNum, "general");
            if (Membership.ValidateUser(tbMobile.Text, tbPassword.Text))
            {
                FormsAuthentication.SetAuthCookie(tbMobile.Text, true, FormsAuthentication.FormsCookiePath);
                SendWxArticle_ToCF("100", "有新用户提交注册申请，行业身份为：" + ddlShenfen.SelectedItem.Text + "\n" + "手机号：" + user.MobilePhoneNum, "请到管理后台-用户信息管理审核（如资料不全，对方有可能在补全资料，请耐心等待5分钟）");
            }
            if (user.UserTypeId == 5)
            {
                Response.Redirect("NextReg.aspx?telNum=" + user.MobilePhoneNum);
            }
            else if (user.UserTypeId == 1)
            {
                Response.Redirect("CFNextReg.aspx?telNum=" + user.MobilePhoneNum);
            }
            else
            {
                Response.Redirect("CopNextReg.aspx?telNum=" + user.MobilePhoneNum);
            }
            lbMsg.Text = ddlStreet.SelectedValue;
        }
    }

    protected void lbtnGetVeriCode_Click(object sender, EventArgs e)
    {
        Random rad = new Random();
        int mobile_code = rad.Next(1000, 10000);
        Session["mobile_code"] = mobile_code.ToString();

        if (tbMobile.Text.Length != 11)
        {
            ltlErrorMsg.Visible = true;
            ltlErrorMsg.Text = "手机号必须为11位";
            return;
        }
        else
        {
            ltlErrorMsg.Text = "";
            ltlErrorMsg.Visible = false;
        }

        if (bll_userinfo.ExistUser(tbMobile.Text))
        {
            ltlVeriMessage.Text = "该手机号已占用，请换手机号";
            ltlVeriMessage.Visible = true;
        }
        else
        {
            bll_sms.SendSMS(tbMobile.Text, "您的验证码是：" + mobile_code.ToString() + "【绿宝】");
            lbtnGetVeriCode.Enabled = false;
            ltlVeriMessage.Text = "在下方输入收到的验证码";
            ltlVeriMessage.Visible = true;
        }


    }

    private void SendWxArticle_ToCF(string QYId, string title, string description)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = title;
        article.Description = description;
        sendmsg.SendArticleToUsers(QYId, article, "5");
    }
}