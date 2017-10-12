using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB.Weixin.Message;
using Senparc.Weixin.QY.AdvancedAPIs.Mass;


public partial class Kefu_Info_DispatchManage : System.Web.UI.Page
{
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sell = new LB.BLL.SellInfoManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
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

                Load_SellInfoes();
                //Load_SellInfoesClosed(userMobile);
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

    private void Load_SellInfoes()
    {
        var query = bll_sell.GetSellInfo_ByKefuTohandleTag(true, 10);
        List<LB.SQLServerDAL.SellInfo> sellInfoes_Todo = new List<LB.SQLServerDAL.SellInfo>();

        var query1 = bll_sell.GetAllSellInfoBy_JD_NotClosed();
        List<LB.SQLServerDAL.SellInfo> sellInfoes_Doing = new List<LB.SQLServerDAL.SellInfo>();
        List<LB.SQLServerDAL.SellInfo> sellInfoes_Done = new List<LB.SQLServerDAL.SellInfo>();
        foreach (LB.SQLServerDAL.SellInfo sellInfo in query)
        {
            if (sellInfo.Kefu_TohandleTag == true)
                sellInfoes_Todo.Add(sellInfo);


        }
        foreach (LB.SQLServerDAL.SellInfo sellInfo in query1)
        {
            if (sellInfo.JD_TohandleTag == true && sellInfo.JD_AcceptedTag == false)
                sellInfoes_Doing.Add(sellInfo);
            if (sellInfo.JD_TohandleTag == true && sellInfo.JD_AcceptedTag == true)

                sellInfoes_Done.Add(sellInfo);
        }

        hfCountTodo.Value = bll_sell.GetCount_KefuTohandle().ToString();
        hfCountDoing.Value = sellInfoes_Doing.Count().ToString();

        rptSellInfoes_Todo.DataSource = sellInfoes_Todo;
        rptSellInfoes_Doing.DataSource = sellInfoes_Doing;
        rptSellInfoesClosed.DataSource = sellInfoes_Done;
        rptSellInfoes_Todo.DataBind();
        rptSellInfoes_Doing.DataBind();
        rptSellInfoesClosed.DataBind();
        BindData();
    }

    //private void Load_SellInfoesClosed(string userMobile)
    //{
    //    var query = bll_sell.GetMySellInfo_IsClosed(userMobile);

    //    rptSellInfoesClosed.DataSource = query;
    //    rptSellInfoesClosed.DataBind();
    //}

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Guid infoId = Guid.Empty;
        Guid.TryParse(e.CommandArgument.ToString(), out infoId);

        if (infoId == Guid.Empty)
            return;


        if (e.CommandName == "SendWX")
        {
            LB.SQLServerDAL.SellInfo sellInfo = bll_sell.GetSellInfo_ById(infoId);
            //sellInfo.JD_AcceptedTag = true;
            //sellInfo.StatusMsg = "回收业务员已接单";
            //bll_sell.UpdateSellInfo(sellInfo);
            //Load_SellInfoes();
            SendWxArticle_ToJD(sellInfo);
        }

        if (e.CommandName == "Reject")
        {
            LB.SQLServerDAL.SellInfo sellInfo = bll_sell.GetSellInfo_ById(infoId);
            sellInfo.JD_AcceptedTag = false;
            sellInfo.JD_TohandleTag = false;
            sellInfo.Kefu_TohandleTag = true;
            sellInfo.StatusMsg = "回收业务员拒绝该单";
            bll_sell.UpdateSellInfo(sellInfo);
            Load_SellInfoes();
        }


        if (e.CommandName == "Confirm")//判断这个Item里哪个控件响应的这个事件  
        {
            string url = "SellInfo_Handle.aspx?infoId=" + e.CommandArgument.ToString();
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
            Label lbjd = e.Item.FindControl("lbjd") as Label;
            Label tbjdywy = e.Item.FindControl("tbjdywy") as Label;
            //Label lbjd1 = e.Item.FindControl("lbjd1") as Label;
            //Label tbjdywy1 = e.Item.FindControl("tbjdywy1") as Label;
            Label lbQuantity = e.Item.FindControl("lbQuantity") as Label;
            LB.SQLServerDAL.UserInfo InUser = new LB.SQLServerDAL.UserInfo();
            MSellInfo = bll_sell.GetSellInfo_ById(Guid.Parse(lbInfoId.Text));
            LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
            MUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.CF_UserId);


            if (rptSellInfoesClosed.Items.Count > 0)
            {
                if (MSellInfo.JD_UserId != 0)
                {
                    LB.SQLServerDAL.UserInfo MJDUserInfo = new LB.SQLServerDAL.UserInfo();
                    MJDUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.JD_UserId);
                    lbjd.Text = MJDUserInfo.RealName;
                    tbjdywy.Text = MJDUserInfo.MobilePhoneNum;
                    lbCFRealname.Text = MUserInfo.RealName;
                    lbCFDW.Text = MUserInfo.MobilePhoneNum;
                    lbQuantity.Text = MSellInfo.Quantity;
                    lbAddress.Text = bll_region.GetRegion(MUserInfo.RegionCode).WholeName;
                }
            }
            if (rptSellInfoes_Doing.Items.Count > 0)
            {
                if (MSellInfo.JD_UserId != 0)
                {
                    LB.SQLServerDAL.UserInfo MJDUserInfo1 = new LB.SQLServerDAL.UserInfo();
                    MJDUserInfo1 = bll_usermanage.GetUserInfoByUserId(MSellInfo.JD_UserId);
                    lbjd.Text = MJDUserInfo1.RealName;
                    tbjdywy.Text = MJDUserInfo1.MobilePhoneNum;
                    lbCFRealname.Text = MUserInfo.RealName;
                    lbCFDW.Text = MUserInfo.MobilePhoneNum;
                    lbQuantity.Text = MSellInfo.Quantity;
                    lbAddress.Text = bll_region.GetRegion(MUserInfo.RegionCode).WholeName;
                }
            }
            else
            {
                lbCFRealname.Text = MUserInfo.RealName;
                lbCFDW.Text = MUserInfo.MobilePhoneNum;
                lbQuantity.Text = MSellInfo.Quantity;
                lbAddress.Text = bll_region.GetRegion(MUserInfo.RegionCode).WholeName;
            }

        }
    }

    #region 发送微信信息
    private string SendWxArticle_ToJD(LB.SQLServerDAL.SellInfo sellInfo)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.SQLServerDAL.UserInfo cf_User = bll_usermanage.GetUserInfoByUserId(sellInfo.CF_UserId);
        LB.SQLServerDAL.UserInfo jd_User = bll_usermanage.GetUserInfoByUserId(sellInfo.JD_UserId);
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "新业务提醒";
        article.Description = sellInfo.Title + "\n\n卖家姓名：" + cf_User.RealName + "\n手机号：" + cf_User.MobilePhoneNum + "\n详细地址：" +
             cf_User.Address + "\n出售信息：" + sellInfo.Description;
        //article.Url = "http://weixin.lvbao111.com/WeixinQY/Syb_JD/GoodsReceipt.aspx?InfoId=" + sellInfo.InfoId.ToString();
        article.Url = "http://weixin.lvbao111.com/WeixinQY/Syb_JD/OrderManage.aspx";
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