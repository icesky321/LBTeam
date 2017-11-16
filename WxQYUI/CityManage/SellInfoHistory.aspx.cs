using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB.Weixin.Message;
using Senparc.Weixin.QY.AdvancedAPIs.Mass;

public partial class Kefu_Info_SellInfoHistory : System.Web.UI.Page
{
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.BLL.SellInfoManage bll_sell = new LB.BLL.SellInfoManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userMobile = User.Identity.Name;
                hfJD_UserMobile.Value = User.Identity.Name;
                LB.SQLServerDAL.UserInfo user = bll_usermanage.GetUserInfoByTelNum(userMobile);
                if (user == null)
                    return;

                hfJD_UserId.Value = user.UserId.ToString();
                hfCityManagerRegionCode.Value = user.RegionCode.ToString();
                Load_SellInfoes();
                //Load_SellInfoesClosed(userMobile);
            }
        }
    }

    protected void BindData()
    {
        //ltlCountTodo1.DataBind();
        //ltlCountProcessing1.DataBind();

        //ltlCountTodo2.DataBind();
        ltlCountProcessing2.DataBind();
    }

    private void Load_SellInfoes()
    {
        var query1 = bll_sell.GetAllSellInfoBy_CityManage_JD_Wait(hfCityManagerRegionCode.Value.Substring(0, 4));
        List<LB.SQLServerDAL.SellInfo> sellInfoes_Wait = new List<LB.SQLServerDAL.SellInfo>();
        foreach (LB.SQLServerDAL.SellInfo sellInfo in query1)
        {
            if (sellInfo.JD_TohandleTag == false && sellInfo.JD_AcceptedTag == false && sellInfo.Kefu_TohandleTag==false)
                sellInfoes_Wait.Add(sellInfo);


        }

        var query = bll_sell.GetAllSellInfoBy_CityManage_JD_Wait(hfCityManagerRegionCode.Value.Substring(0, 4));
        List<LB.SQLServerDAL.SellInfo> sellInfoes_Done = new List<LB.SQLServerDAL.SellInfo>();
        foreach (LB.SQLServerDAL.SellInfo sellInfo in query)
        {
            sellInfoes_Done.Add(sellInfo);
        }

        hfCountDoing.Value = sellInfoes_Wait.Count().ToString();
        hfCountDone.Value = sellInfoes_Done.Count().ToString();

        rptSellInfoes_Done.DataSource = sellInfoes_Done;
        rptSellInfoes_Wait.DataSource = sellInfoes_Wait;
        rptSellInfoes_Done.DataBind();
        rptSellInfoes_Wait.DataBind();
        BindData();
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
            Label lbjd = e.Item.FindControl("lbjd") as Label;
            Label tbjdywy = e.Item.FindControl("tbjdywy") as Label;
            HyperLink hlTelNum = e.Item.FindControl("HyperLink1") as HyperLink;
            LB.SQLServerDAL.UserInfo InUser = new LB.SQLServerDAL.UserInfo();
            if (!string.IsNullOrEmpty(lbInfoId.Text))
            {
                MSellInfo = bll_sell.GetSellInfo_ById(Guid.Parse(lbInfoId.Text));

                LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
                MUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.CF_UserId);

                lbCFRealname.Text = MUserInfo.RealName;
                lbCFDW.Text = MUserInfo.MobilePhoneNum;

                lbAddress.Text = bll_region.GetRegion(MUserInfo.RegionCode).WholeName;
                LB.SQLServerDAL.UserInfo MJDUserInfo = new LB.SQLServerDAL.UserInfo();
                MJDUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.JD_UserId);
                lbjd.Text = MJDUserInfo.RealName;
                tbjdywy.Text = MJDUserInfo.MobilePhoneNum;
                hlTelNum.NavigateUrl = "tel://" + MJDUserInfo.MobilePhoneNum;
            }
        }
    }

    protected void rptSellInfoes_Done_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Guid infoId = Guid.Empty;
        Guid.TryParse(e.CommandArgument.ToString(), out infoId);

        if (infoId == Guid.Empty)
            return;


        if (e.CommandName == "Detail")
        {
            string url = "~/MP/MyOrderDetail.aspx?infoId=" + e.CommandArgument.ToString();
            Response.Redirect(url);
        }
    }

    protected void rptSellInfoes_Done_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbCFDW = e.Item.FindControl("lbCFDW") as Label;
            LB.SQLServerDAL.SellInfo MSellInfo = new LB.SQLServerDAL.SellInfo();
            Label lbCFRealname = e.Item.FindControl("lbCFRealname") as Label;
            Label lbAddress = e.Item.FindControl("lbAddress") as Label;
            Label lbInfoId = e.Item.FindControl("lbInfoId") as Label;
            Label lbjd = e.Item.FindControl("lbjd") as Label;
            Label tbjdywy = e.Item.FindControl("tbjdywy") as Label;
            HyperLink hlTelNum = e.Item.FindControl("HyperLink1") as HyperLink;
            LB.SQLServerDAL.UserInfo InUser = new LB.SQLServerDAL.UserInfo();
            if (!string.IsNullOrEmpty(lbInfoId.Text))
            {
                MSellInfo = bll_sell.GetSellInfo_ById(Guid.Parse(lbInfoId.Text));

                LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
                MUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.CF_UserId);

                lbCFRealname.Text = MUserInfo.RealName;
                lbCFDW.Text = MUserInfo.MobilePhoneNum;

                lbAddress.Text = bll_region.GetRegion(MUserInfo.RegionCode).WholeName;
                LB.SQLServerDAL.UserInfo MJDUserInfo = new LB.SQLServerDAL.UserInfo();
                if (MSellInfo.JD_UserId != 0)
                {
                    MJDUserInfo = bll_usermanage.GetUserInfoByUserId(MSellInfo.JD_UserId);
                    lbjd.Text = MJDUserInfo.RealName;
                    tbjdywy.Text = MJDUserInfo.MobilePhoneNum;
                    hlTelNum.NavigateUrl = "tel://" + MJDUserInfo.MobilePhoneNum;
                }

            }
        }
    }
}