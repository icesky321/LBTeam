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

        LoadSellReqToHandle();
    }

    public void LoadSellReqToHandle()
    {
        int jd_UserId = 0;
        int.TryParse(hfJD_UserId.Value, out jd_UserId);

        if (jd_UserId == 0)
            return;

        var query = bll_sellInfo.GetMySellInfo_ByStatusMsg(jd_UserId, "回收公司工单指派完成，等待回收业务员处理");

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
        LB.SQLServerDAL.SellInfo MSellInfo = new LB.SQLServerDAL.SellInfo();
        if (e.CommandName == "Create")
        {
            string InfoId = (string)e.CommandArgument;//获取Item传过来的参数 
            MSellInfo = bll_sellInfo.GetSellInfo_ById(Guid.Parse(InfoId));
            //string url = "~/Syb_hsgs/GoodsReceipt.aspx?InUserId=" + MSellInfo.CF_UserId + "&OutUserId=" + MSellInfo.JD_UserId + "&InfoId=" + MSellInfo.InfoId;
            string url = "GoodsReceipt.aspx?InfoId=" + InfoId;
            Response.Redirect(url);
                
        }
    }
}