using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public partial class Admin_Notice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNotice_Click(object sender, EventArgs e)
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        AppSettingsSection app = config.AppSettings;
        app.Settings.Remove("Notice");
        //app.Settings.Add("Notice", tbNotice.Text);
        app.Settings.Add("Notice", FreeTextBox1.Text);
        config.Save();
    }
}