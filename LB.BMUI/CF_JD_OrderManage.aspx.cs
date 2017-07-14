using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CF_JD_OrderManage : System.Web.UI.Page
{
    LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbInNum = e.Item.FindControl("lbInNum") as Label;
            Label lbInUserId = e.Item.FindControl("lbInUserId") as Label;
            LB.SQLServerDAL.UserInfo InMUserInfo = new LB.SQLServerDAL.UserInfo();
            InMUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(lbInUserId.Text));
            lbInNum.Text = InMUserInfo.MobilePhoneNum;
            Label lbOutNum = e.Item.FindControl("lbOutNum") as Label;
            Label lbOutUserId = e.Item.FindControl("lbOutUserId") as Label;
            LB.SQLServerDAL.UserInfo OutMUserInfo = new LB.SQLServerDAL.UserInfo();
            OutMUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(lbOutUserId.Text));
            lbOutNum.Text = OutMUserInfo.MobilePhoneNum;
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Audit")//判断这个Item里哪个控件响应的这个事件  
        {
            string CFId = (string)e.CommandArgument;//获取Item传过来的参数  
            MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(Guid.Parse(CFId));
            MCF_JD_Order.AuditOperator = User.Identity.Name;
            MCF_JD_Order.AuditDatetime = System.DateTime.Now;
            MCF_JD_Order.Audit = true;
            bll_cf_jd_order.UpdateCF_JD_Order(MCF_JD_Order);
            Repeater1.DataBind();
            //sendmsg.seSendTextToUsers("2", "哈哈哈");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = "有订单啦~~";
        article.Description = "这笔单子够我赚一笔啦/n 哈哈哈哈/n 啦啦啦啦啦啦啦/n 呵呵呵呵呵呵";
        article.Url = "http://www.163.com";
        sendmsg.SendArticleToUsers("2", article, "5");
    }
}