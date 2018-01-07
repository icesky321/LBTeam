using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using LB.WeixinMP;



public partial class MP_CreateLeads : System.Web.UI.Page
{
    LB.BLL.TSManage bll_ts = new LB.BLL.TSManage();
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sellInfo = new LB.BLL.SellInfoManage();
    LB.BLL.SMS sms = new LB.BLL.SMS();
    Cobe.CnRegion.RegionManage region = new Cobe.CnRegion.RegionManage();
    LB.BLL.CityManager_Config bll_citymanage_config = new LB.BLL.CityManager_Config();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login/Login.aspx");
            }
            else
            {
                Init_Load();
            }

        }
    }

    private void Init_Load()
    {
        Load_TS();
        LoadSellerInfo();
    }

    private void Load_TS()
    {
        var query = bll_ts.GetTSInfo();
        List<LB.SQLServerDAL.TSInfo> tses = query.Where(o => o.ChargeUnit == "吨").ToList<LB.SQLServerDAL.TSInfo>();
        cblDP.Items.Clear();
        foreach (LB.SQLServerDAL.TSInfo ts in tses)
        {
            cblDP.Items.Add(new ListItem(ts.TSName, ts.TsCode));
        }
    }

    private void LoadSellerInfo()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;       // 用户账户即为用户手机号码
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);

        if (user == null)
            return;

        bool imcompletMark = false;

        if (string.IsNullOrEmpty(user.RealName))
            ltlRealName.Text = "未设置";
        else
            ltlRealName.Text = user.RealName;

        if (string.IsNullOrEmpty(user.MobilePhoneNum))
        {
            ltlTelNum.Text = "未设置";
            imcompletMark = true;
        }
        else
            ltlTelNum.Text = user.MobilePhoneNum;

        if (string.IsNullOrEmpty(user.Address))
        {
            ltlAddress.Text = "未设置";
            imcompletMark = true;
        }
        else
            ltlAddress.Text = user.Address;

        if (imcompletMark == true)
        {
            hfImcomplete.Value = "true";
            ltlContactMsg.Text = "&nbsp;&nbsp;(* 信息不完整)";
            coll1.Attributes.Add("data-collapsed", "false");
        }

    }






    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            lbMsg.Text = "您尚未登录，请先登录。";
            return;
        }
        if (hfImcomplete.Value == "true")
        {
            lbMsg.Text = "卖家信息不完整，请先完善信息";
            return;
        }
        LB.SQLServerDAL.SellInfo sellInfo = new LB.SQLServerDAL.SellInfo();

        sellInfo.Title = "废旧铅酸蓄电池出售";

        string detailInfo = string.Empty;
        List<string> listTSName = new List<string>();
        foreach (ListItem item in cblDP.Items)
        {
            if (item.Selected)
                listTSName.Add(item.Text);
        }
        string tsNames = string.Join("、", listTSName.ToArray());
        detailInfo = "待售电瓶品种：" + tsNames + " | " + tbVolume.Value + " | " + tbAdditionText.Value;
        sellInfo.Description = detailInfo;

        sellInfo.Quantity = tbVolume.Value;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);
        sellInfo.TradePlace = user.Address;
        sellInfo.CF_UserId = user.UserId;
        sellInfo.CF_UserMobile = userName;
        sellInfo.CF_RegionCode = user.RegionCode;
        sellInfo.JD_AcceptedTag = false;
        sellInfo.StatusMsg = "等待绿宝客服审核";
        sellInfo.IsClosed = false;
        LB.SQLServerDAL.SellInfo newSellInfo = bll_sellInfo.CreateSellInfo(sellInfo);
        sms.SendSMS(userName, "你已成功发布出售信息，绿宝将在两日内对您的出售请求做出处理。（目前仅限杭州、绍兴、温州地区）【绿宝】");
        if (!string.IsNullOrEmpty(user.OpenId))
        {
            SendShortMsg(user.OpenId);
        }




        /*--------------------------------老思路---------------------------------------------*/

        // 以下设计思路，如果在工作时间，审核信息发送给“信息客服”，如果在非工作时间，信息发送给“信息客服后备”。
        // 4信息客服后备，3信息客服
        //TimeSpan tsBegin = new TimeSpan(8, 0, 0);
        //TimeSpan tsEnd = new TimeSpan(17, 30, 0);
        //if ((int)DateTime.Now.DayOfWeek >= 1 && (int)DateTime.Now.DayOfWeek <= 5 && DateTime.Now.TimeOfDay >= tsBegin && DateTime.Now.TimeOfDay < tsEnd)
        //    SendWxArticle_ToKefu("5", newSellInfo);
        //else
        //    SendWxArticle_ToKefu("6", newSellInfo);

        /*------------------------------------------------------------------------------------------------*/




        //新思路：产废单位发布卖货信息，产废单位地址匹配城市管理员地址，如果匹配，发给对应的城市管理员，如果不匹配，发给信息客服处理
        LB.SQLServerDAL.CityManager_Config MCityManager_config = new LB.SQLServerDAL.CityManager_Config();
        MCityManager_config = bll_citymanage_config.GetCityManager_ConfigByRegionCode(user.RegionCode.Substring(0,4));
        if (MCityManager_config != null)
        {
            LB.SQLServerDAL.UserInfo MUser = new LB.SQLServerDAL.UserInfo();
            MUser = bll_user.GetUserInfoByUserId(MCityManager_config.UserId);
            SendWxArticle_ToCityManager(MUser.QYUserId, newSellInfo);
        }
        else
        {
            // 以下设计思路，如果在工作时间，审核信息发送给“信息客服”，如果在非工作时间，信息发送给“信息客服后备”。
            // 4信息客服后备，3信息客服
            TimeSpan tsBegin = new TimeSpan(8, 0, 0);
            TimeSpan tsEnd = new TimeSpan(17, 30, 0);
            if ((int)DateTime.Now.DayOfWeek >= 1 && (int)DateTime.Now.DayOfWeek <= 5 && DateTime.Now.TimeOfDay >= tsBegin && DateTime.Now.TimeOfDay < tsEnd)
                SendWxArticle_ToKefu("5", newSellInfo);
            else
                SendWxArticle_ToKefu("6", newSellInfo);
        }

        Response.Redirect("CreateLeads.aspx#pageRegCompleted", true);
    }


    private void SendWxArticle_ToKefu(string toTags, LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
        MUserInfo = bll_user.GetUserInfoByUserId(sellInfo.CF_UserId);
        article.Title = "有出售信息需要审核";
        article.Description = "产废单位（"+ region.GetRegion(MUserInfo.RegionCode).WholeName+MUserInfo.Address+"）发布了一条出售信息，请点击该条信息直接审核，或到客服管理平台→业务信息审核栏目进行审核。";
        //article.Url = "http://weixin.lvbao111.com/WeixinQY/Kefu_Info/SellInfo_Handle.aspx?infoId=" + sellInfo.InfoId.ToString();
        article.Url = "http://weixin.lvbao111.com/WeixinQY/Kefu_Info/DispatchManage.aspx";
        sendmsg.SendArticleToTags(toTags, article, "5");
    }


    private void SendWxArticle_ToCityManager(string QYId, LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
        MUserInfo = bll_user.GetUserInfoByUserId(sellInfo.CF_UserId);
        article.Title = "有出售信息需要审核";
        article.Description = "产废单位（" + region.GetRegion(MUserInfo.RegionCode).WholeName + MUserInfo.Address + "）发布了一条出售信息，请点击该条信息直接审核，或到客服管理平台→业务信息审核栏目进行审核。";
        //article.Url = "http://weixin.lvbao111.com/WeixinQY/Kefu_Info/SellInfo_Handle.aspx?infoId=" + sellInfo.InfoId.ToString();
        article.Url = "http://weixin.lvbao111.com/WeixinQY/CityManage/DispatchManage.aspx";
        sendmsg.SendArticleToUsers(QYId, article, "5");
    }

    private void SendShortMsg(string openId)
    {
        string appId = string.Empty;
        string appSecret = string.Empty;
        if (ConfigurationManager.AppSettings["AppId"] != null)
        {
            appId = ConfigurationManager.AppSettings["AppId"];
            appSecret = ConfigurationManager.AppSettings["AppSecret"];
        }
        BaseAccessTokenManage bat = new BaseAccessTokenManage();
        var commonAccessToken = bat.AccessToken;

        TMData_下单成功通知 data = new TMData_下单成功通知();
        data.first.value = "下单成功！绿宝三益电瓶回收平台已收到您的卖货请求";
        data.keyword1.value = "废旧电瓶回收业务";
        data.keyword2.value = DateTime.Now.Date.ToShortDateString();
        data.remark.value = "您的卖货单在审核后将指派回收人员在24小时内上门回收，请耐心等待";
        //data.Url
        TMSender tmSender = new TMSender();
        tmSender.SendWx_ToOpenId(commonAccessToken, openId, data);

    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MP/TodayQuotation.aspx");
    }
}