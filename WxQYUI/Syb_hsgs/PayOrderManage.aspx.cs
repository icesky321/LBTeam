using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_hsgs_PayOrderManage : System.Web.UI.Page
{
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                LB.SQLServerDAL.UserInfo MUserInfo = bll_usermanage.GetUserInfoByTelNum(username);
                hfHS_UserId.Value = MUserInfo.UserId.ToString();
            }
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Confirm")//判断这个Item里哪个控件响应的这个事件  
        {
            string CFId = (string)e.CommandArgument;//获取Item传过来的参数  
            string url = "PayOrder.aspx?CFId=" + CFId.ToString();
            Response.Redirect(url);
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbCfId= e.Item.FindControl("lbCfId") as Label;
            LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
            Label lbAmount = e.Item.FindControl("lbAmount") as Label;
            Label lbReamrk = e.Item.FindControl("lbReamrk") as Label;
            LB.SQLServerDAL.UserInfo InUser = new LB.SQLServerDAL.UserInfo();
            MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(Guid.Parse(lbCfId.Text));
            lbAmount.Text = MCF_JD_Order.Amount.ToString();
            lbReamrk.Text = MCF_JD_Order.Remark;
        }
    }
}