using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_JD_OrderManage : System.Web.UI.Page
{
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sell = new LB.BLL.SellInfoManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.SMS sms = new LB.BLL.SMS();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userMobile = User.Identity.Name;
                hfJD_UserMobile.Value = User.Identity.Name;
                LB.SQLServerDAL.UserInfo user = bll_usermanage.GetUserInfoByTelNum(userMobile);
                if (user == null)
                    return;

                hfJD_UserId.Value = user.UserId.ToString();

                Load_SellInfoes(user.UserId);
                Load_SellInfoesClosed(userMobile);
            }
        }

    }



    protected void BindData()
    {
        ltlCountTodo1.DataBind();
        ltlCountProcessing1.DataBind();

        ltlCountTodo2.DataBind();
        ltlCountProcessing2.DataBind();

        ltlCountTodo3.DataBind();
        ltlCountProcessing3.DataBind();
    }

    private void Load_SellInfoes(int JD_UserId)
    {
        var query = bll_sell.GetSellInfoBy_JD_NotClosed(JD_UserId);
        List<LB.SQLServerDAL.SellInfo> sellInfoes_Todo = new List<LB.SQLServerDAL.SellInfo>();
        List<LB.SQLServerDAL.SellInfo> sellInfoes_Doing = new List<LB.SQLServerDAL.SellInfo>();

        foreach (LB.SQLServerDAL.SellInfo sellInfo in query)
        {
            if (sellInfo.JD_TohandleTag == true && sellInfo.JD_AcceptedTag == false)
                sellInfoes_Todo.Add(sellInfo);

            if (sellInfo.JD_TohandleTag == true && sellInfo.JD_AcceptedTag == true)
                sellInfoes_Doing.Add(sellInfo);
        }

        if (sellInfoes_Todo.Count() == 0)
            divDataEmptyPrompt1.Visible = true;

        if (sellInfoes_Doing.Count() == 0)
            divDataEmptyPrompt2.Visible = true;

        hfCountTodo.Value = sellInfoes_Todo.Count().ToString();
        hfCountDoing.Value = sellInfoes_Doing.Count().ToString();

        rptSellInfoes_Todo.DataSource = sellInfoes_Todo;
        rptSellInfoes_Doing.DataSource = sellInfoes_Doing;

        rptSellInfoes_Todo.DataBind();
        rptSellInfoes_Doing.DataBind();

        BindData();
    }

    private void Load_SellInfoesClosed(string userMobile)
    {
        var query = bll_sell.GetMySellInfo_IsClosed(userMobile);

        rptSellInfoesClosed.DataSource = query;
        rptSellInfoesClosed.DataBind();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Guid infoId = Guid.Empty;
        Guid.TryParse(e.CommandArgument.ToString(), out infoId);

        if (infoId == Guid.Empty)
            return;


        if (e.CommandName == "Accept")
        {
            LB.SQLServerDAL.SellInfo sellInfo = bll_sell.GetSellInfo_ById(infoId);
            sellInfo.JD_AcceptedTag = true;
            sellInfo.StatusMsg = "回收业务员已接单";
            bll_sell.UpdateSellInfo(sellInfo);
            Load_SellInfoes(Convert.ToInt32(hfJD_UserId.Value));
            LB.SQLServerDAL.UserInfo Muserinfo = new LB.SQLServerDAL.UserInfo();
            Muserinfo = bll_usermanage.GetUserInfoByUserId(sellInfo.CF_UserId);
            sms.SendSMS(Muserinfo.MobilePhoneNum, "验证码：回收员已接单，会尽快与您联系，请耐心等待。【绿宝】");
        }

        if (e.CommandName == "Reject")
        {
            LB.SQLServerDAL.SellInfo sellInfo = bll_sell.GetSellInfo_ById(infoId);
            sellInfo.JD_AcceptedTag = false;
            sellInfo.JD_TohandleTag = false;
            sellInfo.Kefu_TohandleTag = true;
            sellInfo.StatusMsg = "回收业务员拒绝该单";
            bll_sell.UpdateSellInfo(sellInfo);
            Load_SellInfoes(Convert.ToInt32(hfJD_UserId.Value));
            SendWxArticle_ToKefu("6", sellInfo);
        }


        if (e.CommandName == "Confirm")//判断这个Item里哪个控件响应的这个事件  
        {
            string url = "GoodsReceipt.aspx?infoId=" + e.CommandArgument.ToString();
            Response.Redirect(url);
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbCFDW = e.Item.FindControl("lbCFDW") as Label;
            LB.SQLServerDAL.SellInfo MSellInfo = new LB.SQLServerDAL.SellInfo();
            Label lbCFRealname = e.Item.FindControl("lbCFRealname") as Label;
            Label lbAddress = e.Item.FindControl("lbAddress") as Label;
            Label lbInfoId = e.Item.FindControl("lbInfoId") as Label;
            LB.SQLServerDAL.UserInfo InUser = new LB.SQLServerDAL.UserInfo();
            MSellInfo = bll_sell.GetSellInfo_ById(Guid.Parse(lbInfoId.Text));
            LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
            MUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.CF_UserId);
            lbCFRealname.Text = MUserInfo.RealName;
            lbCFDW.Text = MUserInfo.MobilePhoneNum;
            lbAddress.Text = bll_region.GetRegion(MUserInfo.RegionCode).WholeName;
        }
    }

    protected void btnQuickReg_Click(object sender, EventArgs e)
    {
        Response.Redirect("CF_quickReg.aspx");
    }

    private void SendWxArticle_ToKefu(string toTags, LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "业务员拒绝该单";
        article.Description = "您指派的回收业务员拒绝该单，请您另行指派";
        article.Url = "http://weixin.lvbao111.com/WeixinQY/Kefu_Info/DispatchManage.aspx";
        sendmsg.SendArticleToTags(toTags, article, "5");
    }
}