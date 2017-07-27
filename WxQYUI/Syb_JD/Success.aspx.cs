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
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    Cobe.CnRegion.RegionManage region = new Cobe.CnRegion.RegionManage();
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
                LB.SQLServerDAL.UserInfo InUserInfo = new LB.SQLServerDAL.UserInfo();
                LB.SQLServerDAL.UserInfo OutUserInfo = new LB.SQLServerDAL.UserInfo();
                InUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(MCF_JD_Order.InUserId));
                OutUserInfo = bll_usermanage.GetUserInfoByUserId(Convert.ToInt32(MCF_JD_Order.OutUserId));
                lbCFDW.Text = InUserInfo.RealName + "(手机号：" + InUserInfo.MobilePhoneNum + ")\n地址：" + region.GetRegion(InUserInfo.RegionCode).WholeName + InUserInfo.Address;
                lbJDYWY.Text = OutUserInfo.RealName + "(手机号：" + OutUserInfo.MobilePhoneNum + ")\n地址：" + region.GetRegion(OutUserInfo.RegionCode).WholeName + InUserInfo.Address;

            }
        }
    }
}