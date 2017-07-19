using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_Dyywy_Success : System.Web.UI.Page
{
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["CFId"] != null)
            {
                string CFId = Request.QueryString["CFId"];
                hfCFId.Value = CFId;
                MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(Guid.Parse(hfCFId.Value));
                lbAmount.Text = MCF_JD_Order.Amount.ToString();

            }
        }
    }
}