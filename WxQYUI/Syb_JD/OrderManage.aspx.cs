using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_JD_OrderManage : System.Web.UI.Page
{
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sell = new LB.BLL.SellInfoManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                LB.SQLServerDAL.UserInfo MUserInfo = bll_usermanage.GetUserInfoByTelNum(username);
                hfJD_UserId.Value= MUserInfo.UserId.ToString();
            }
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Confirm")//判断这个Item里哪个控件响应的这个事件  
        {
            string InfoId = (string)e.CommandArgument;//获取Item传过来的参数  
            string url = "GoodsReceipt.aspx?infoId=" + InfoId.ToString();
            Response.Redirect(url);
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbCFDW = e.Item.FindControl("lbCFDW") as Label;
            LB.SQLServerDAL.SellInfo MSellInfo = new LB.SQLServerDAL.SellInfo();
            Label lbCFRealname = e.Item.FindControl("lbCFRealname") as Label;
            Label lbAddress = e.Item.FindControl("lbAddress") as Label;
            Label lbInfoId = e.Item.FindControl("lbInfoId") as Label;
            LB.SQLServerDAL.UserInfo InUser = new LB.SQLServerDAL.UserInfo();
            MSellInfo = bll_sell.GetSellInfo_ById(Guid.Parse(lbInfoId.Text));
            LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
            MUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.CF_UserId);
            lbCFRealname.Text = MUserInfo.RealName;
            lbCFDW.Text = MUserInfo.MobilePhoneNum;
            lbAddress.Text = bll_region.GetRegion(MUserInfo.RegionCode).WholeName;
        }
    }
}