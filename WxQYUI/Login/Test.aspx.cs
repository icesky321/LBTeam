using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

public partial class Login_Test : System.Web.UI.Page
{
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    CNRegionService cnregion = new CNRegionService();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        //string id = ddlStreet.SelectedItem.Value;
        //string name = ddlStreet.SelectedItem.Text;
        ////values.Add(new CascadingDropDownNameValue(name, id));
        //if (id=="")
        //{
        //    lbMsg.Visible = true;
        //    lbMsg.Text = "请完善地址信息";
        //}
        //else
        //{
        //    lbMsg.Visible = true;
        //    lbMsg.Text = ddlStreet.SelectedValue;
        //}
        SendWxArticle_ToCF("2", "标签测试", "TestTestTestTest");
    }

    private void SendWxArticle_ToCF(string QYTag, string title, string description)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = title;
        article.Description = description;
        sendmsg.SendArticleToTags(QYTag, article, "5");
    }
}