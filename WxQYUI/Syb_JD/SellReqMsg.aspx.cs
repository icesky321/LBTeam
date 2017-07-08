using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_JD_SellReqMsg : System.Web.UI.Page
{
    LB.BLL.SellInfoManage bll_sellInfo = new LB.BLL.SellInfoManage();
    LB.BLL.UserManage bll_userManage = new LB.BLL.UserManage();
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
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            hfUserMobile.Value = HttpContext.Current.User.Identity.Name;
            LB.SQLServerDAL.UserInfo user = bll_userManage.GetUserInfoByTelNum(hfUserMobile.Value);
            if (user != null)
                hfJD_UserId.Value = user.UserId.ToString();
        }

        LoadSellReqToHandle();       // 加载我的持股
    }

    public void LoadSellReqToHandle()
    {
        int jd_UserId = 0;
        int.TryParse(hfJD_UserId.Value, out jd_UserId);

        if (jd_UserId == 0)
            return;

        var query = bll_sellInfo.GetSellInfo_ByJDTohandleTag(jd_UserId, true);

        lvSellInfo.DataSource = query.AsQueryable();
        lvSellInfo.DataBind();

        ltlCount.Text = bll_sellInfo.GetCount_JDTohandle(jd_UserId).ToString();
    }


    #endregion

    protected void lvSellInfo_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewItem item = e.Item as ListViewItem;
            LB.SQLServerDAL.SellInfo sellInfo = item.DataItem as LB.SQLServerDAL.SellInfo;

            if (sellInfo == null)
                return;

            int cf_userId = sellInfo.CF_UserId;
            LB.SQLServerDAL.UserInfo user = bll_userManage.GetUserInfoByUserId(cf_userId);

            if (user == null)
                return;

            Literal ltlCF_RealName = e.Item.FindControl("ltlCF_RealName") as Literal;
            ltlCF_RealName.Text = user.RealName;

            Literal ltlMobilePhone = e.Item.FindControl("ltlMobilePhone") as Literal;
            ltlMobilePhone.Text = user.MobilePhoneNum;

            Literal ltlAddress = e.Item.FindControl("ltlAddress") as Literal;
            ltlAddress.Text = user.Address;
        }

    }

    protected void btnCreateBill_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Create")
        {

        }
    }
}