using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TradeleadsDetail : System.Web.UI.Page
{
    LB.BLL.Tradeleads bll_tradeleads = new LB.BLL.Tradeleads();
    LB.SQLServerDAL.Tradeleads MTradeleads = new LB.SQLServerDAL.Tradeleads();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["infoId"] != null)
            {
                int infoId = Convert.ToInt32(Request.QueryString["infoId"]);
                MTradeleads = bll_tradeleads.GetTradeleadsByinfoId(infoId);
                lbTitle.Text = MTradeleads.Title;
                lbDetail.Text = MTradeleads.DetailInfo;
            }
        }
    }
}