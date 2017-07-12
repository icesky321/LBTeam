using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_TestArea : System.Web.UI.Page
{
    private const String host = "http://ali-city.showapi.com";
    private const String path = "/areaName";
    private const String method = "GET";
    private const String appcode = "0456ad6afcc9476cac4e51fca86df3e1";
    protected void Page_Load(object sender, EventArgs e)
    {
        //String querys = "areaName=%E4%B8%8A%E6%B5%B7&level=1&maxSize=10&page=1";
        String querys = "areaName=杭州&level=2&maxSize=10&page=1";
        String bodys = "";
        String url = host + path;
        HttpWebRequest httpRequest = null;
        HttpWebResponse httpResponse = null;

        if (0 < querys.Length)
        {
            url = url + "?" + querys;
        }

        if (host.Contains("https://"))
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            httpRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
        }
        else
        {
            httpRequest = (HttpWebRequest)WebRequest.Create(url);
        }
        httpRequest.Method = method;
        httpRequest.Headers.Add("Authorization", "APPCODE " + appcode);
        if (0 < bodys.Length)
        {
            byte[] data = Encoding.UTF8.GetBytes(bodys);
            using (Stream stream = httpRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }
        try
        {
            httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        }
        catch (WebException ex)
        {
            httpResponse = (HttpWebResponse)ex.Response;
        }

        System.Text.StringBuilder sb = new StringBuilder();
        //sb.AppendLine(httpResponse.StatusCode.ToString());
        //sb.AppendLine(httpResponse.Method.ToString());
        //sb.AppendLine(httpResponse.Headers.ToString());
        Stream st = httpResponse.GetResponseStream();
        StreamReader reader = new StreamReader(st, Encoding.GetEncoding("utf-8"));
        sb.AppendLine(reader.ReadToEnd());

        TextBox1.Text = sb.ToString();




    }

    public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
    {
        return true;
    }
}