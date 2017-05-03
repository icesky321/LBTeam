using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //yzm();
            SendSMS();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string yzm = Session["mobile_code"].ToString(); //获取当前Session的值（即验证码的值）  
        if (TextBox1.Text == yzm)
        {
            Label2.Text = "正确";
        }
        else
        {
            Label2.Text = "错误";
        }
    }

    //跟换新的验证码(当用户看不清楚验证码时候，点击跟换新的验证码  
    protected void Button2_Click(object sender, EventArgs e)
    {

        SendSMS();
        Button2.Enabled = false;

    }

    //产生验证码的方法  
    protected void yzm()
    {
        int x = new Random(DateTime.Now.Millisecond).Next(-9, 10);  //以当地时间的毫秒作为随机数的种子  
        int y = new Random(DateTime.Now.Second).Next(-9, 10);   //以当地时间的秒作为随机数的种子  


        int rnd = new Random().Next(0, 3);  //产生一个0-2的随机数  
        switch (rnd)
        {
            case 0:

                Label1.Text = x + "加上" + y + "等于";
                Session["value"] = x + y;  //将验证码的值保持到Session中  
                break;
            case 1:

                Label1.Text = x + "减去" + y + "等于";
                Session["value"] = x - y;  //将验证码的值保持到Session中  
                break;
            case 2:

                Label1.Text = x + "乘以" + y + "等于";
                Session["value"] = x * y;  //将验证码的值保持到Session中  
                break;

        }
    }

    [System.Web.Services.WebMethod()]
    public void SendSMS()
    {
        Random rad = new Random();
        int mobile_code = rad.Next(1000, 10000);
        Session["mobile_code"] = mobile_code.ToString();
        Label1.Text = mobile_code.ToString();
        //string param = "action=send&userid=546&account=lvbaoxxhy6&password=5AfpTxHs&content=您的验证码是：" + mobile_code.ToString() + "【绿宝】&mobile=" + "15267863162" + "&sendTime=&extno=";
        //byte[] bs = Encoding.UTF8.GetBytes(param);

        //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://hy6.nbark.com:7602/sms.aspx");
        //req.Method = "POST";
        //req.ContentType = "application/x-www-form-urlencoded";
        //req.ContentLength = bs.Length;

        //using (Stream reqStream = req.GetRequestStream())
        //{
        //    reqStream.Write(bs, 0, bs.Length);
        //}
        //using (WebResponse wr = req.GetResponse())
        //{
        //    StreamReader sr = new StreamReader(wr.GetResponseStream(), System.Text.Encoding.Default);
        //}
    }


    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //SendSMS();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Label3.Text = DDLAddress1.province;
        Label4.Text = DDLAddress1.city;
        if (DDLAddress1.city=="")

        {
            DDLAddress1.setMsg("不能为空!");
        }
        //Label5.Text = DDLAddress1.country;
        //Label6.Text = DDLAddress1.street;
    }
}