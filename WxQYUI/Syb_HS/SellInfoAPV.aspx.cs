using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB.Weixin.Message;
using Senparc.Weixin.QY.AdvancedAPIs.Mass;

public partial class Syb_HS_SellInfoAPV : System.Web.UI.Page
{
    LB.BLL.SellInfoManage bll_SellInfo = new LB.BLL.SellInfoManage();
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        if (Request.QueryString["infoId"] != null)
        {
            hfSellInfoId.Value = Request.QueryString["infoId"];
            Load_SellInfo(hfSellInfoId.Value);
            Load_JD();
        }

    }


    private void Load_SellInfo(string id)
    {
        Guid infoId = Guid.Empty;
        Guid.TryParse(id, out infoId);

        if (infoId == Guid.Empty)
            return;

        LB.SQLServerDAL.SellInfo sellInfo = bll_SellInfo.GetSellInfo_ById(infoId);

        if (sellInfo == null)
            return;

        // 检测业务单是否曾被处理。
        if (sellInfo.HS_TohandleTag == false)
        {
            divMsg.Visible = true;
            btnAllocation.Enabled = false;
        }

        ltlTitle.Text = sellInfo.Title;
        ltlDescription.Text = sellInfo.Description;
        ltlQuantity.Text = sellInfo.Quantity;
        ltlLvbaoLeaveMsg.Text = sellInfo.Kefu_LeaveMsg;
        hfhs_userId.Value = sellInfo.HS_UserId.ToString();


        int cf_userId = sellInfo.CF_UserId;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByUserId(cf_userId);

        if (user == null)
            return;

        ltlRealName.Text = user.RealName;
        ltlMobileNum.Text = user.MobilePhoneNum;
        ltlAddress.Text = user.Address;
    }

    private void Load_JD()
    {
        if (string.IsNullOrEmpty(hfhs_userId.Value))
            return;

        int hs_userId = 0;
        int.TryParse(hfhs_userId.Value, out hs_userId);

        LB.SQLServerDAL.UserInfo hs_user = bll_user.GetUserInfoByUserId(hs_userId);
        if (hs_user == null)
            return;

        string cityRegionCode = hs_user.RegionCode;
        var jd_users = bll_user.GetUserInfo_JD_InCity(cityRegionCode);
        ddlJD.Items.Clear();
        foreach (LB.SQLServerDAL.UserInfo user in jd_users)
        {
            ListItem item = new ListItem(user.RealName, user.UserId.ToString());
            ddlJD.Items.Add(item);
        }
        ddlJD.Items.Insert(0, "选择回收业务员");
    }


    protected void btnAllocation_Click(object sender, EventArgs e)
    {
        Guid infoId = Guid.Empty;
        Guid.TryParse(hfSellInfoId.Value, out infoId);

        if (infoId == Guid.Empty)
            return;

        LB.SQLServerDAL.SellInfo sellInfo = bll_SellInfo.GetSellInfo_ById(infoId);

        if (sellInfo == null)
            return;


        sellInfo.HS_LeaveMsg = tbRemark.Text;
        sellInfo.HS_HandleDate = DateTime.Now;
        sellInfo.HS_HandleResult = "工单指派完成";
        sellInfo.HS_TohandleTag = false;

        string result = string.Empty;

        sellInfo.JD_TohandleTag = true;

        if (ddlJD.SelectedIndex < 1)
            return;

        int jd_userId = 0;
        int.TryParse(ddlJD.SelectedValue, out jd_userId);
        sellInfo.JD_UserId = jd_userId;
        sellInfo.StatusMsg = "回收公司工单指派完成，等待回收业务员处理";

        bll_SellInfo.UpdateSellInfo(sellInfo);

        result = SendWxArticle_ToJD(sellInfo);


        Response.Redirect("~/ErrorPage/Success.aspx?remark=" + result);



    }

    #region 发送微信信息
    private string SendWxArticle_ToJD(LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.SQLServerDAL.UserInfo cf_User = bll_user.GetUserInfoByUserId(sellInfo.CF_UserId);
        LB.SQLServerDAL.UserInfo jd_User = bll_user.GetUserInfoByUserId(sellInfo.JD_UserId);
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "新业务提醒";
        article.Description = sellInfo.Title + "\n卖家姓名：" + cf_User.RealName + "\n手机号：" + cf_User.MobilePhoneNum + "\n详细地址：" +
             cf_User.Address + "\n出售信息：" + sellInfo.Description + "\n\n绿宝备注：" + sellInfo.Kefu_LeaveMsg + "\n回收公司备注：" + tbRemark.Text;
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


    #endregion
}