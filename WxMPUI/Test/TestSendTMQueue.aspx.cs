using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB.WeixinMP;

public partial class Test_TestSendTMQueue : System.Web.UI.Page
{
    LB.WeixinMP.TMQueue tmQueue = new LB.WeixinMP.TMQueue();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPushTM1_Click(object sender, EventArgs e)
    {
        TMData_报价提醒 data = new TMData_报价提醒();
        data.first.value = "从即日起，杭州地区的电瓶回收价格上提5%。\n";
        data.keyword1.value = "20171021001";
        data.keyword1.color = "#00FF00";
        data.keyword2.value = DateTime.Now.Date.ToShortDateString();
        data.keyword2.color = "#527F76";
        data.remark.value = "\n这是测试消息，请勿受精!! ୧ʘ̆ںʘ̆୨";
        data.remark.color = "#FF0000";
        tmQueue.PushInTM("oOP4JwivBNerfDcFyetChe5cw2Vw", data); //发给李峰

    }

    protected void btnSendStart_Click(object sender, EventArgs e)
    {
        tmQueue.StartSend();
    }

    protected void btnPushTM2_Click(object sender, EventArgs e)
    {
        TMData_报价提醒 data = new TMData_报价提醒();
        data.first.value = "从即日起，杭州地区的电瓶回收价格上提5%。\n";
        data.keyword1.value = "20171021001";
        data.keyword1.color = "#00FF00";
        data.keyword2.value = DateTime.Now.Date.ToShortDateString();
        data.keyword2.color = "#527F76";
        data.remark.value = "\n这是测试消息，请勿受精!! ୧ʘ̆ںʘ̆୨";
        data.remark.color = "#FF0000";
        tmQueue.PushInTM("oOP4JwmLfZaGeHomkHVvhEHMoeAY", data); //发给曹俊
    }

    protected void btnPushTM3_Click(object sender, EventArgs e)
    {
        TMData_报价提醒 data = new TMData_报价提醒();
        data.first.value = "从即日起，杭州地区的电瓶回收价格上提5%。\n";
        data.keyword1.value = "20171021001";
        data.keyword1.color = "#00FF00";
        data.keyword2.value = DateTime.Now.Date.ToShortDateString();
        data.keyword2.color = "#527F76";
        data.remark.value = "\n这是测试消息，请勿受精!! ୧ʘ̆ںʘ̆୨";
        data.remark.color = "#FF0000";
        tmQueue.PushInTM("oOP4JwvTaafrC0GREH_Q_ENj7H8c", data); //发给李鑫
    }
}