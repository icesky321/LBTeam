using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_hsgs_ChooseJD : System.Web.UI.Page
{
    LB.SQLServerDAL.SellInfo MSellInfo = new LB.SQLServerDAL.SellInfo();
    LB.BLL.SellInfoManage bll_sellInfo = new LB.BLL.SellInfoManage();
    LB.SQLServerDAL.UserInfo MSellUser = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();
    LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Request.QueryString["InfoId"] != null)
            //{
            //    string InfoId = Request.QueryString["InfoId"];
            //    hfInfoId.Value = InfoId;
            //}
        }
    }


    //protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    if (e.CommandName == "Confirm")//判断这个Item里哪个控件响应的这个事件  
    //    {
    //        string UserId= (string)e.CommandArgument;
    //        MSellUser = bll_userManage.GetUserInfoByUserId(Convert.ToInt32(UserId));
    //        SendWxArticle_ToCF(Guid.Parse(hfInfoId.Value), MSellUser.QYUserId);
    //    }
    //}

    private void SendWxArticle_ToCF(Guid infoId,string QYId)
    {
        //TODO: 发布前修改微信发布逻辑
        MSellInfo = bll_sellInfo.GetSellInfo_ById(infoId);
        MSellUser = bll_userManage.GetUserInfoByUserId(MSellInfo.CF_UserId);
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = MSellInfo.Title;
        article.Description = "卖主姓名：" + MSellUser.RealName + "\n" + "手机号：" + MSellUser.MobilePhoneNum + "\n" + "详细地址：" + MSellUser.Province + MSellUser.City + MSellUser.Town + MSellUser.Street;
        //article.Url = "http://weixin.lvbao111.com/WeixinQY/Syb_hsgs/ChooseJD.aspx?InfoId=" + infoId;
        sendmsg.SendArticleToUsers(QYId, article, "5");
    }
}