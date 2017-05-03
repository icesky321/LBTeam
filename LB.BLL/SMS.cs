using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace LB.BLL
{
    public class SMS
    {
        public void SendSMS(string mobileNum, string Content)
        {
            Random rad = new Random();
            int mobile_code = rad.Next(1000, 10000);
            //Session["mobile_code"] = mobile_code.ToString();
            string param = "action=send&userid=546&account=lvbaoxxhy6&password=5AfpTxHs&content=" + Content + "&mobile=" + mobileNum + "&sendTime=&extno=";
            byte[] bs = Encoding.UTF8.GetBytes(param);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://hy6.nbark.com:7602/sms.aspx");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            using (WebResponse wr = req.GetResponse())
            {
                StreamReader sr = new StreamReader(wr.GetResponseStream(), System.Text.Encoding.Default);
            }
        }
    }
}
