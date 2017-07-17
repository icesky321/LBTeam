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
            sellInfo.JD_UserId = 141;      // TODO: 分配街道业务员的逻辑仍需修改。  // 本地1164 服务器上 1186
            sellInfo.StatusMsg = "信息已审核，正在推送到回收业务员。";

            //string result = SendWx_ToCF(sellInfo.JD_UserId);

            //if (result == "ok")
            SendWxArticle_ToCF(sellInfo);
            bll_sellInfo.UpdateSellInfo(sellInfo);


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

    private string SendWx_ToCF(int jd_UserId)
    {
        //TODO: 发布前修改微信发布逻辑

        LB.SQLServerDAL.UserInfo user = bll_userManage.GetUserInfoByUserId(jd_UserId);
        if (user == null)
            return "";
        MsgSender msgSender = new MsgSender();
        MassResult result = msgSender.SendTextToUsers(user.QYUserId, "产废单位有一条信息已被审核通过。jd_UserId：" + jd_UserId.ToString(), "5");
        return result.errmsg;
    }

    private void SendWxArticle_ToCF(LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.SQLServerDAL.UserInfo cf_User = bll_userManage.GetUserInfoByUserId(sellInfo.CF_UserId);
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = sellInfo.Title;
        article.Description = "卖主姓名：" + cf_User.RealName + "\n" + "手机号：" + cf_User.MobilePhoneNum + "\n" + "详细地址：" +
             cf_User.Address + "\n" + sellInfo.Description;
        article.Url = "http://weixin.lvbao111.com/WeixinQY/Syb_hsgs/Choosejdywy.aspx?InfoId=" + sellInfo.InfoId.ToString();
        //article.Url = "http://weixin.lvbao111.com/WeixinQY/Syb_hsgs/Choosejdywy.aspx";
        sendmsg.SendArticleToUsers("2", article, "5");  // TODO: 发布前修改接收对象
    }
}