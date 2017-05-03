using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;

public partial class UserCenter : System.Web.UI.MasterPage
{
    LB.BLL.NewsInfo bll_newsinfo = new LB.BLL.NewsInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiViewBind();
            LoginName2.Attributes["value"] = getRoleTel(Page.User.Identity.Name);
            
        }
    }

    void MultiViewBind()
    {
        if (Request.IsAuthenticated)
        {
            MultiView2.ActiveViewIndex = 1;
        }
        else
        {
            MultiView2.ActiveViewIndex = 0;
        }
    }

    public string getRoleTel(string tel)
    {
        Regex re = new Regex("", RegexOptions.None);
        int tellen = tel.Length;
        switch (tellen)
        {
            case 5:
                re = new Regex("(\\d{3})(\\d{2})", RegexOptions.None);
                tel = re.Replace(tel, "$1****");
                break;
            case 6:
                re = new Regex("(\\d{3})(\\d{3})", RegexOptions.None);
                tel = re.Replace(tel, "$1****");
                break;
            case 7:
                re = new Regex("(\\d{3})(\\d{4})", RegexOptions.None);
                tel = re.Replace(tel, "$1****");
                break;
            case 8:
                re = new Regex("(\\d{3})(\\d{4})(\\d{1})", RegexOptions.None);
                tel = re.Replace(tel, "$1****$3");
                break;
            case 9:
                re = new Regex("(\\d{3})(\\d{4})(\\d{2})", RegexOptions.None);
                tel = re.Replace(tel, "$1****$3");
                break;
            case 10:
                re = new Regex("(\\d{3})(\\d{4})(\\d{3})", RegexOptions.None);
                tel = re.Replace(tel, "$1****$3");
                break;
            case 11:
                re = new Regex("(\\d{3})(\\d{4})(\\d{4})", RegexOptions.None);
                tel = re.Replace(tel, "$1****$3");
                break;
            case 12:
                re = new Regex("(\\d{3})(\\d{4})(\\d{5})", RegexOptions.None);
                tel = re.Replace(tel, "$1****$3");
                break;
            default:
                re = new Regex("(\\d{3})(\\d{4})(\\d{13})", RegexOptions.None);
                tel = re.Replace(tel, "$1****$3");
                break;
        }
        return tel;
    }
}
