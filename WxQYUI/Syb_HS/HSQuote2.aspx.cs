using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_HS_HSQuote2 : System.Web.UI.Page
{
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.TSManage bll_ts = new LB.BLL.TSManage();
    LB.BLL.QuotationManage bll_quote = new LB.BLL.QuotationManage();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    #region 初始化加载
    private void Init_Load()
    {
        Load_TsInfo();
    }

    private void Load_TsInfo()
    {
        if (Request.QueryString["id"] != null)
        {
            string tsCode = string.Empty;
            tsCode = Request.QueryString["id"];

            LB.SQLServerDAL.TSInfo tsInfo = bll_ts.GetTS_ByCode(tsCode);

            if (tsInfo == null)
                return;

            ltlTSName.Text = tsInfo.TSName + " ，  按" + tsInfo.ChargeUnit + "计价";
        }
    }

    #endregion


    protected void btnQuote1_Command(object sender, CommandEventArgs e)
    {
        Button btn = sender as Button;
        TextBox tbQuotedPrice = btn.FindControl("tbQuotedPrice") as TextBox;
        HiddenField hfTSId = btn.FindControl("hfTSId") as HiddenField;

        LB.SQLServerDAL.Quotation quotation = new LB.SQLServerDAL.Quotation();
        quotation.UserId = 1162;
        quotation.UserName = "阿尔泰公司";
        quotation.StandardUnit = "吨";
        //quotation.City = "宁波";

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
}