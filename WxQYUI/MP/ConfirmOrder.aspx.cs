using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MP_ConfirmOrder : System.Web.UI.Page
{
    LB.BLL.UserManage bll_usemanage = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.SQLServerDAL.CF_JD_Order MCF_JD_Order = new LB.SQLServerDAL.CF_JD_Order();
    LB.BLL.CF_JD_Order bll_cf_jd_order = new LB.BLL.CF_JD_Order();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                MUserInfo = bll_usemanage.GetUserInfoByTelNum(username);
                hfInUserId.Value = MUserInfo.UserId.ToString();
                Repeater1.DataBind();
            }
            else
            {
                Response.Redirect("~/Login/Login.aspx");
            }
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbCFId = e.Item.FindControl("lbCFId") as Label;
            MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(Guid.Parse(lbCFId.Text));
            Label lbcfName = e.Item.FindControl("lbcfName") as Label;
            Label lbcfPhone = e.Item.FindControl("lbcfPhone") as Label;
            Label lbjdName = e.Item.FindControl("lbCFId") as Label;
            Label lbjdPhone = e.Item.FindControl("lbjdPhone") as Label;
            LB.SQLServerDAL.UserInfo InUser = new LB.SQLServerDAL.UserInfo();
            InUser = bll_usemanage.GetUserInfoByUserId(Convert.ToInt32(MCF_JD_Order.InUserId));
            lbcfName.Text = InUser.RealName;
            lbcfPhone.Text = InUser.MobilePhoneNum;
            LB.SQLServerDAL.UserInfo OutUser = new LB.SQLServerDAL.UserInfo();
            OutUser = bll_usemanage.GetUserInfoByUserId(Convert.ToInt32(MCF_JD_Order.OutUserId));
            lbjdName.Text = OutUser.RealName;
            lbjdPhone.Text = OutUser.MobilePhoneNum;

        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Confirm")//判断这个Item里哪个控件响应的这个事件  
        {
            string CFId = (string)e.CommandArgument;//获取Item传过来的参数  
            MCF_JD_Order = bll_cf_jd_order.GetCF_JD_OrderById(Guid.Parse(CFId));
            MCF_JD_Order.OperateDate = System.DateTime.Now;
            MCF_JD_Order.Operator = User.Identity.Name;
            MCF_JD_Order.OperatorConfirm = true;
            bll_cf_jd_order.UpdateCF_JD_Order(MCF_JD_Order);
            Repeater1.DataBind();
        }
    }
}