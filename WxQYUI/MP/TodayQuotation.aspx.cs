using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MP_TodayQuotation : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.BLL.TSManage bll_ts = new LB.BLL.TSManage();
    LB.BLL.QuotationManage bll_quote = new LB.BLL.QuotationManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_UserInfo();
            LoadTodayQuotation();
        }
    }



    #region 初始化加载

    private void Load_UserInfo()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(User.Identity.Name);
        if (user == null)
            return;

        string regionCode = user.RegionCode;
        Cobe.CnRegion.SQLServerDAL.Region region = bll_region.GetRegion(regionCode);
        if (region == null)
            return;

        int level = 0;
        level = region.Level ?? 0;

        if (level < 3)
            Response.Redirect("UserInfoIncomplete.aspx");
        else
        {
            ltlRegionWholeName.Text = bll_region.GetRegion(region.CountyId).WholeName;
            hfCountyId.Value = region.CountyId;
        }

    }

    protected void LoadTodayQuotation()
    {
        // TODO： 发布前要修改
        //var query = bll_quote.GetQuotation("宁波", DateTime.Now.Date);
        //Repeater1.DataSource = query;
        //Repeater1.DataBind();
    }
    #endregion

    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LB.SQLServerDAL.TSInfo ts = e.Item.DataItem as LB.SQLServerDAL.TSInfo;
            LB.SQLServerDAL.Quotation quotation = bll_quote.GetLastQuotedPrice(ts.TsCode, hfCountyId.Value);
            Literal ltlHS_UserName = e.Item.FindControl("ltlHS_UserName") as Literal;
            Literal ltlPrice = e.Item.FindControl("ltlPrice") as Literal;
            Literal ltlDate = e.Item.FindControl("ltlDate") as Literal;
            if (quotation != null)
            {

                ltlHS_UserName.Text = quotation.UserName;
                ltlPrice.Text = quotation.QuotedPrice.ToString() + "&nbsp;元/" + quotation.StandardUnit;
                ltlDate.Text = quotation.OfferDate.ToShortDateString();
            }
            else
            {
                ltlPrice.Text = "---";
                ltlDate.Text = "";
            }
        }
    }
}