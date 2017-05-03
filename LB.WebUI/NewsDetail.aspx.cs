using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewsDetail : System.Web.UI.Page
{
    LB.BLL.NewsInfo bll_newsinfo = new LB.BLL.NewsInfo();
    LB.SQLServerDAL.NewsInfo MNewsInfo = new LB.SQLServerDAL.NewsInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                MNewsInfo = bll_newsinfo.GetNewsInfoById(Id);
                lbTitle.Text = MNewsInfo.Title;
                lbShowTime.Text = MNewsInfo.NoteTime.ToString();
                lbUser.Text = MNewsInfo.UserName;
                lbHits.Text = MNewsInfo.Hits.ToString();
                lbContent.Text = MNewsInfo.Content;
                MNewsInfo.Hits = MNewsInfo.Hits + 1;
                bll_newsinfo.UpdateNewsInfo(MNewsInfo);
            }
        }
    }
}