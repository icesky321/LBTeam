using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_hsgs_Choosejdywy : System.Web.UI.Page
{
    LB.SQLServerDAL.SellInfo MSellInfo = new LB.SQLServerDAL.SellInfo();
    LB.BLL.SellInfoManage bll_sellInfo = new LB.BLL.SellInfoManage();
    LB.SQLServerDAL.UserInfo MSellUser = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    //LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["InfoId"] != null)
            {
                string InfoId = Request.QueryString["InfoId"];

                hfInfoId.Value = InfoId;
                if (bll_cf_jd_order.ExistInfoId(Guid.Parse(InfoId)))
                {
                    page1.Visible = false;
                    pageRegCompleted.Visible = true;
                }
            }
            else
            {
                hfInfoId.Value = "b3cc01d1-dd37-495d-a69f-687b2fc4c4b6";
                if (bll_cf_jd_order.ExistInfoId(Guid.Parse(hfInfoId.Value)))
                {
                    page1.Visible = false;
                    pageRegCompleted.Visible = true;
                }
            }
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Confirm")//判断这个Item里哪个控件响应的这个事件  
        {
            string UserId = (string)e.CommandArgument;
            MSellUser = bll_userManage.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MSellInfo = bll_sellInfo.GetSellInfo_ById(Guid.Parse(hfInfoId.Value));
            MSellInfo.JD_TohandleTag = true;
            MSellInfo.JD_UserId = Convert.ToInt32(UserId);
            bll_sellInfo.UpdateSellInfo(MSellInfo);
            SendWxArticle_ToCF(Guid.Parse(hfInfoId.Value), MSellUser.QYUserId);
            Response.Redirect("Choosejdywy.aspx#pageRegCompleted", true);
        }
    }

    private void SendWxArticle_ToCF(Guid infoId, string QYId)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        MSellInfo = bll_sellInfo.GetSellInfo_ById(infoId);
        MSellUser = bll_userManage.GetUserInfoByUserId(MSellInfo.CF_UserId);
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "街道回收员调度单（产废单位出售信息）";
        article.Description = "卖主姓名：" + MSellUser.RealName + "\n" + "手机号：" + MSellUser.MobilePhoneNum + "\n" + "详细地址：" + MSellUser.Province + MSellUser.City + MSellUser.Town + MSellUser.Street + "\n" + "内容：" + MSellInfo.Description + MSellInfo.Quantity;
        article.Url = "http://weixin.lvbao111.com/WeixinQY/Syb_JD/GoodsReceipt.aspx?InfoId=" + infoId;
        sendmsg.SendArticleToUsers(QYId, article, "5");
    }
}