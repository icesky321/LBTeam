using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


public partial class MP_CreateLeads : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sellInfo = new LB.BLL.SellInfoManage();
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
        LoadSellerInfo();
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
        detailInfo = "待售电瓶品种：" + tsNames + " | " + tbAdditionText.Value;
        sellInfo.Description = detailInfo;

        sellInfo.Quantity = tbVolume.Value;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);
        sellInfo.TradePlace = user.Address;
        sellInfo.CF_UserId = user.UserId;
        sellInfo.CF_UserMobile = userName;
        sellInfo.JD_AcceptedTag = false;
        sellInfo.StatusMsg = "等待绿宝客服审核";
        sellInfo.IsClosed = false;
        LB.SQLServerDAL.SellInfo newSellInfo = bll_sellInfo.CreateSellInfo(sellInfo);

        // 以下设计思路，如果在工作时间，审核信息发送给“信息客服”，如果在非工作时间，信息发送给“信息客服后备”。
        // 4信息客服后备，3信息客服
        TimeSpan tsBegin = new TimeSpan(8, 0, 0);
        TimeSpan tsEnd = new TimeSpan(17, 30, 0);
        if ((int)DateTime.Now.DayOfWeek >= 1 && (int)DateTime.Now.DayOfWeek <= 5 && DateTime.Now.TimeOfDay >= tsBegin && DateTime.Now.TimeOfDay < tsEnd)
            SendWxArticle_ToKefu("3", newSellInfo);
        else
            SendWxArticle_ToKefu("4", newSellInfo);
        Response.Redirect("CreateLeads.aspx#pageRegCompleted", true);
    }


    private void SendWxArticle_ToKefu(string toTags, LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "有出售信息需要审核";
        article.Description = "产废单位发布了一条出售信息，请点击该条信息直接审核，或到客服管理平台→业务信息审核栏目进行审核。";
        article.Url = "http://weixin.lvbao111.com/WeixinQY/Kefu_Info/SellInfo_Handle.aspx?infoId=" + sellInfo.InfoId.ToString();
        sendmsg.SendArticleToTags(toTags, article, "5");
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MP/TodayQuotation.aspx");
    }
}