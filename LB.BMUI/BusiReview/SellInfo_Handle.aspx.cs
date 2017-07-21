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
            sellInfo.JD_TohandleTag = true;
            int userId = 0;
            int.TryParse(hfJD_UserId.Value, out userId);
            sellInfo.JD_UserId = userId;
            sellInfo.StatusMsg = "信息已审核，等待回收业务员接单。";

            bll_sellInfo.UpdateSellInfo(sellInfo);

            string result = SendWxArticle_ToJD(sellInfo);
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

    private string SendWxArticle_ToJD(LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.SQLServerDAL.UserInfo cf_User = bll_userManage.GetUserInfoByUserId(sellInfo.CF_UserId);
        LB.SQLServerDAL.UserInfo jd_User = bll_userManage.GetUserInfoByUserId(sellInfo.JD_UserId);
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "新业务提醒";
        article.Description = sellInfo.Title + "\n卖家姓名：" + cf_User.RealName + "\n手机号：" + cf_User.MobilePhoneNum + "\n详细地址：" +
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

    protected void lbtnManuAllocation_Click(object sender, EventArgs e)
    {
        if (ddlPingtaiYWY.SelectedIndex > 0)
        {
            string mobile = ddlPingtaiYWY.SelectedValue;
            LB.SQLServerDAL.UserInfo jd_user = bll_userManage.GetUserInfoByTelNum(mobile);
            if (jd_user == null)
                return;
            ltlJD_UserName.Text = jd_user.UserName;
            ltlJD_RealName.Text = jd_user.RealName;
            hfJD_UserId.Value = jd_user.UserId.ToString();
        }
    }

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
                ltlJD_UserName.Text = jd_user.UserName;
                hfJD_UserId.Value = jd_user.UserId.ToString();
            }
        }
    }
}