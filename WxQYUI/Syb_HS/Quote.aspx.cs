using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_HS_Quote : System.Web.UI.Page
{
    LB.BLL.QuotationManage bll_quote = new LB.BLL.QuotationManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTodayQuotation();
        }
    }



    protected void btnOneClickQuote_Click(object sender, EventArgs e)
    {
        List<LB.SQLServerDAL.Quotation> quotes = new List<LB.SQLServerDAL.Quotation>();

        foreach (RepeaterItem item in Repeater2.Items)
        {
            TextBox tbQuotedPrice = item.FindControl("tbQuotedPrice") as TextBox;
            HiddenField hfTSId = item.FindControl("hfTSId") as HiddenField;
            Literal ltlTSName = item.FindControl("ltlTSName") as Literal;

            LB.SQLServerDAL.Quotation quotation1 = new LB.SQLServerDAL.Quotation();
            quotation1.UserId = 1162;
            quotation1.UserName = "阿尔泰公司";
            quotation1.StandardUnit = "吨";
            quotation1.TSId = Convert.ToInt32(hfTSId.Value);
            quotation1.TSName = ltlTSName.Text;
            decimal price1 = 0m;
            decimal.TryParse(tbQuotedPrice.Text, out price1);
            quotation1.QuotedPrice = price1;
            if (quotation1.QuotedPrice > 0)
                bll_quote.NewQuotation_NotSubmit(quotation1);
        }

        bll_quote.SubmitChanges();
        LoadTodayQuotation();
    }

    protected void btnQuote1_Command(object sender, CommandEventArgs e)
    {
        Button btn = sender as Button;
        TextBox tbQuotedPrice = btn.FindControl("tbQuotedPrice") as TextBox;
        HiddenField hfTSId = btn.FindControl("hfTSId") as HiddenField;

        LB.SQLServerDAL.Quotation quotation = new LB.SQLServerDAL.Quotation();
        quotation.UserId = 1162;
        quotation.UserName = "阿尔泰公司";
        quotation.StandardUnit = "吨";

        decimal price = 0m;
        decimal.TryParse(tbQuotedPrice.Text, out price);
        quotation.QuotedPrice = price;

        quotation.TSName = e.CommandArgument.ToString();
        quotation.TSId = Convert.ToInt32(hfTSId.Value);

        bll_quote.NewQuotation(quotation);
        LoadTodayQuotation();
    }

    protected void LoadTodayQuotation()
    {
        var query = bll_quote.GetQuotation("宁波", DateTime.Now.Date);
        Repeater1.DataSource = query;
        Repeater1.DataBind();
    }

    protected void lbtnDelete_Command(object sender, CommandEventArgs e)
    {
        Guid quotId = Guid.Empty;
        Guid.TryParse(e.CommandArgument.ToString(), out quotId);

        bll_quote.DeleteQuotation(quotId);
        LoadTodayQuotation();
    }
}