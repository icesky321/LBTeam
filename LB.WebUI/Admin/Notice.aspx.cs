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
        if (!IsPostBack)
        {
            FreeTextBox1.Text = ConfigurationManager.AppSettings["Notice"];
            tbPBPrice.Text = ConfigurationManager.AppSettings["PBPrice"];
            tbDPPrice.Text = ConfigurationManager.AppSettings["DPPrice"];
        }
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

    protected void btPBPrice_Click(object sender, EventArgs e)
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        AppSettingsSection app = config.AppSettings;
        app.Settings.Remove("PBPrice");
        //app.Settings.Add("Notice", tbNotice.Text);
        app.Settings.Add("PBPrice", tbPBPrice.Text);
        config.Save();
    }

    protected void btDPPrice_Click(object sender, EventArgs e)
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        AppSettingsSection app = config.AppSettings;
        app.Settings.Remove("DPPrice");
        app.Settings.Add("DPPrice", tbDPPrice.Text);
        config.Save();
    }
}