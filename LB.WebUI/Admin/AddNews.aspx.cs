using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewsManage : System.Web.UI.Page
{
    LB.SQLServerDAL.NewsType MNewTYpe = new LB.SQLServerDAL.NewsType();
    LB.BLL.NewsType bll_newtype = new LB.BLL.NewsType();
    LB.SQLServerDAL.NewsInfo MNewsInfo = new LB.SQLServerDAL.NewsInfo();
    LB.BLL.NewsInfo bll_newsinfo = new LB.BLL.NewsInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillNewsType();
            tbNoteDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }

    void FillNewsType()
    {
        IQueryable<LB.SQLServerDAL.NewsType> newstypes = bll_newtype.GetNewsType();
        foreach (LB.SQLServerDAL.NewsType NewType in newstypes)
        {
            ddlNewsType.Items.Add(new ListItem(NewType.NewsType1, NewType.NewsTypeId.ToString()));
        }
        ddlNewsType.Items.Insert(0, "");
    }



    protected void btPreview_Click(object sender, EventArgs e)
    {
        MNewsInfo.Title = tbTitle.Text;
        MNewsInfo.NoteTime = Convert.ToDateTime(tbNoteDate.Text);
        MNewsInfo.Content = this.FreeTextBox1.Text;
        MNewsInfo.UserName = HttpContext.Current.User.Identity.Name;
        MNewsInfo.IsShow = false;
        MNewsInfo.IsCommend = false;
        MNewsInfo.NewsTypeId = Convert.ToInt32(ddlNewsType.SelectedItem.Value);
        MNewsInfo.Hits = 0;
        MNewsInfo.ShowTime = Convert.ToDateTime("1900-1-1");
        bll_newsinfo.NewNewsInfo(MNewsInfo);
        Response.Redirect("NewsManage.aspx");
    }
    protected void ddlNewsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNewsType.SelectedItem.Text == "区域价格资讯")
        {
            TabContainer1.Visible = true;
            MultiView1.ActiveViewIndex = 1;
        }
        else
        {
            TabContainer1.Visible = true;
            MultiView1.ActiveViewIndex = 0;
        }
    }
    protected void btSure_Click(object sender, EventArgs e)
    {
        MNewsInfo.Title = tbName.Text;
        MNewsInfo.NoteTime = System.DateTime.Now;
        MNewsInfo.UserName = Request.Params["province"].ToString();
        MNewsInfo.Content = tbPrice.Text;
        MNewsInfo.IsShow = false;
        MNewsInfo.IsCommend = false;
        MNewsInfo.Hits = 0;
        MNewsInfo.NewsTypeId = Convert.ToInt32(ddlNewsType.SelectedItem.Value);
        MNewsInfo.ShowTime = Convert.ToDateTime("1900-1-1");
        bll_newsinfo.NewNewsInfo(MNewsInfo);
        Response.Redirect("NewsManage.aspx");
    }
}