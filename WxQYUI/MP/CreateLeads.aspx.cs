using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class MP_CreateLeads : System.Web.UI.Page
{
    LB.BLL.TSInfo bll_ts = new LB.BLL.TSInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LoadTS();
        }
    }

    private void LoadTS()
    {
        CheckBoxList1.DataSource = bll_ts.GetTSInfo();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        LB.SQLServerDAL.Tradeleads leads = new LB.SQLServerDAL.Tradeleads();

        leads.Title = "废电瓶出售";
        leads.TId = 2;

        if (User.Identity.IsAuthenticated)
        {
            
        }
        List<string> listTSName = new List<string>();
        foreach(ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected)
                listTSName.Add(item.Text);
        }
        string tsNames = string.Join("、", listTSName.ToArray());
        Response.Redirect("CreateLeads.aspx");
    }
}