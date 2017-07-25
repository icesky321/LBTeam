using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB.Weixin.Message;
using Senparc.Weixin.QY.AdvancedAPIs.Mass;

public partial class BusiReview_SellInfo_Handle : System.Web.UI.Page
{
    LB.BLL.SellInfoManage bll_sellInfo = new LB.BLL.SellInfoManage();
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
    LB.BLL.StaffManage bll_staff = new LB.BLL.StaffManage();
    LB.BLL.CopInfo bll_cop = new LB.BLL.CopInfo();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        Load_PingtaiYWY();      // 加载平台业务员

        if (Request.QueryString["infoId"] != null)
        {
            hfInfoId.Value = Request.QueryString["infoId"];

            Guid infoId = Guid.Empty;
            Guid.TryParse(hfInfoId.Value, out infoId);

            if (infoId == Guid.Empty)
                return;

            // 获取出售信息
            LB.SQLServerDAL.SellInfo sellInfo = bll_sellInfo.GetSellInfo_ById(infoId);

            if (sellInfo == null)
                return;

            lbTitle.Text = sellInfo.Title;
            lbCreateDate.Text = string.Format("{0:yyyy-MM-dd hh:mm}", sellInfo.CreateDate);
            ltlDescription.Text = sellInfo.Description;
            ltlQuantity.Text = sellInfo.Quantity;

            // 获取产废单位信息
            int cf_userId = sellInfo.CF_UserId;
            LB.SQLServerDAL.UserInfo user = bll_userManage.GetUserInfoByUserId(cf_userId);

            if (user == null)
                return;

            ltlRealName.Text = user.RealName;
            ltlPhone.Text = user.MobilePhoneNum;
            ltlAddress.Text = user.Address;
            Cobe.CnRegion.SQLServerDAL.Region region = bll_region.GetRegion(user.RegionCode);
            if (region != null)
                lbRegionWholeName.Text = region.WholeName;
            hfRegionCode.Value = user.RegionCode;
            hfCF_UserId.Value = user.UserId.ToString();
            hfCF_QYUserId.Value = user.QYUserId;

            // 指派回收业务员
            AutoAllocationHSYWY(region);

            // 自动指派回收公司
            AutoAllocaionHS(region);
        }
    }



    private void Load_PingtaiYWY()
    {
        var staffs = bll_staff.GetStaff();
        ddlPingtaiYWY.Items.Clear();
        foreach (LB.SQLServerDAL.Staff staff in staffs)
        {
            ddlPingtaiYWY.Items.Add(new ListItem(staff.RealName, staff.MobileNum));
        }
        ddlPingtaiYWY.Items.Insert(0, "请选择平台回收业务员");
    }

    protected void CommandButton_Click(object sender, CommandEventArgs e)
    {
        Guid infoId = Guid.Empty;
        Guid.TryParse(hfInfoId.Value, out infoId);

        if (infoId == Guid.Empty)
            return;

        LB.SQLServerDAL.SellInfo sellInfo = bll_sellInfo.GetSellInfo_ById(infoId);

        if (sellInfo == null)
            return;

        if (e.CommandName == "Accept")
        {
            sellInfo.Kefu_LeaveMsg = tbRemark.Text;
            sellInfo.Kefu_HandleDate = DateTime.Now;
            sellInfo.Kefu_HandleResult = "审核通过";
            sellInfo.Kefu_TohandleTag = false;

            string result = string.Empty;
            if (rbtnAuto.Checked)
            {
                sellInfo.JD_TohandleTag = true;
                int userId = 0;
                int.TryParse(hfJD_UserId.Value, out userId);
                sellInfo.JD_UserId = userId;
                sellInfo.StatusMsg = "绿宝平台已审核，等待回收业务员处理";

                bll_sellInfo.UpdateSellInfo(sellInfo);

                result = SendWxArticle_ToJD(sellInfo);
            }

            if (rbtnHS.Checked)
            {
                sellInfo.HS_TohandleTag = true;
                int hs_userId = 0;
                int.TryParse(ddlHS.SelectedValue, out hs_userId);
                sellInfo.HS_UserId = hs_userId;
                sellInfo.StatusMsg = "绿宝平台已审核，等待回收公司处理";

                bll_sellInfo.UpdateSellInfo(sellInfo);

                result = SendWxArticle_ToHS(sellInfo);
            }

            if (rbtnJD.Checked)
            {
                sellInfo.JD_TohandleTag = true;

                if (ddlPingtaiYWY.SelectedIndex < 1)
                    return;


                string jd_Mobile = ddlPingtaiYWY.SelectedValue;
                LB.SQLServerDAL.UserInfo user = bll_userManage.GetUserInfoByTelNum(jd_Mobile);

                if (user == null)
                    return;
                sellInfo.JD_UserId = user.UserId;
                sellInfo.StatusMsg = "绿宝平台已审核，等待回收业务员处理";
                sellInfo.HS_UserId = Convert.ToInt32(ddlHS.SelectedValue);
                bll_sellInfo.UpdateSellInfo(sellInfo);

                result = SendWxArticle_ToJD(sellInfo);
            }

            ltlResult.Text = "审核完毕。" + result;

        }

        if (e.CommandName == "Reject")
        {
            sellInfo.Kefu_LeaveMsg = tbRemark.Text;
            sellInfo.Kefu_HandleDate = DateTime.Now;
            sellInfo.Kefu_HandleResult = "拒绝转发";
            sellInfo.Kefu_TohandleTag = false;
            sellInfo.StatusMsg = "审核未通过，信息已被关闭";
            sellInfo.IsClosed = true;
            bll_sellInfo.UpdateSellInfo(sellInfo);
        }


    }


    #region 发送微信信息
    private string SendWxArticle_ToJD(LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.SQLServerDAL.UserInfo cf_User = bll_userManage.GetUserInfoByUserId(sellInfo.CF_UserId);
        LB.SQLServerDAL.UserInfo jd_User = bll_userManage.GetUserInfoByUserId(sellInfo.JD_UserId);
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "新业务提醒";
        article.Description = sellInfo.Title + "\n\n卖家姓名：" + cf_User.RealName + "\n手机号：" + cf_User.MobilePhoneNum + "\n详细地址：" +
             cf_User.Address + "\n出售信息：" + sellInfo.Description;
        article.Url = "http://weixin.lvbao111.com/WeixinQY/Syb_JD/GoodsReceipt.aspx?InfoId=" + sellInfo.InfoId.ToString();

        string errmsg = string.Empty;

        if (string.IsNullOrEmpty(jd_User.QYUserId))
            errmsg = "您选定的回收业务员未绑定企业号账户，无法接收到微信提醒信息。";
        else
        {
            MassResult result = sendmsg.SendArticleToUsers(jd_User.QYUserId, article, "5");
            errmsg = result.errmsg;
        }
        return errmsg;
    }

    private string SendWxArticle_ToHS(LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.SQLServerDAL.UserInfo cf_User = bll_userManage.GetUserInfoByUserId(sellInfo.CF_UserId);
        LB.SQLServerDAL.UserInfo hs_User = bll_userManage.GetUserInfoByUserId(sellInfo.HS_UserId);
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "新业务提醒";
        article.Description = sellInfo.Title + "\n\n卖家姓名：" + cf_User.RealName + "\n手机号：" + cf_User.MobilePhoneNum + "\n详细地址：" +
             cf_User.Address + "\n出售信息：" + sellInfo.Description + "\n\n绿宝备注：" + tbRemark.Text;
        article.Url = "http://weixin.lvbao111.com/WeixinQY/Syb_HS/SellInfoAPV.aspx?infoId=" + sellInfo.InfoId.ToString();

        string errmsg = string.Empty;

        if (string.IsNullOrEmpty(hs_User.QYUserId))
            errmsg = "您选定的回收公司后台管理人员未绑定企业号账户，无法接收到微信提醒信息。";
        else
        {
            MassResult result = sendmsg.SendArticleToUsers(hs_User.QYUserId, article, "5");
            errmsg = result.errmsg;
        }
        return errmsg;
    }

    #endregion


    protected void AutoAllocationHSYWY(Cobe.CnRegion.SQLServerDAL.Region region)
    {
        if (region.Level != 4)
        {
            ltlJD_UserName.Text = "[产废单位区划未完善，无法获取街道业务员]";
            return;
        }
        else
        {
            LB.SQLServerDAL.UserInfo jd_user = bll_userManage.GetUserInfo_JD_InStreet(hfRegionCode.Value);
            if (jd_user == null)
            {
                ltlJD_UserName.Text = "[该地区尚未发展业务员，请平台另行分配]";

                return;
            }
            else
            {
                ltlJD_UserName.Text = jd_user.UserName + "(" + jd_user.RealName + ")";
                hfJD_UserId.Value = jd_user.UserId.ToString();
            }
        }
    }

    private void AutoAllocaionHS(Cobe.CnRegion.SQLServerDAL.Region region)
    {
        if (region == null)
            return;

        if (region.Level >= 2)
        {
            string cityRegionCode = region.CityId;
            var hs_users = bll_userManage.GetUserInfo_HS_InCity(region.CityId);
            ddlHS.Items.Clear();
            foreach (LB.SQLServerDAL.UserInfo user in hs_users)
            {
                LB.SQLServerDAL.CopInfo cop = bll_cop.GetCopInfoeByUserId(user.UserId);
                if (cop != null)
                {
                    ListItem item = new ListItem(cop.ShortName, user.UserId.ToString());
                    ddlHS.Items.Add(item);
                }
            }

        }
    }
}