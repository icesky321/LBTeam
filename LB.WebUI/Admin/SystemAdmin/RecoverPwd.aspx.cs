using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_RecoverPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
    {
        e.Cancel = true;
        lbsubject.Text = Convert.ToString((e.Message.Subject));
        lbbody.Text = Convert.ToString((e.Message.Body));
    }
}
