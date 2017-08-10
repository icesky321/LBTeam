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
                string userMobile = User.Identity.Name;
                hfJD_UserMobile.Value = User.Identity.Name;
                LB.SQLServerDAL.UserInfo user = bll_usermanage.GetUserInfoByTelNum(userMobile);
                if (user == null)
                    return;

                hfJD_UserId.Value = user.UserId.ToString();

                Load_SellInfoes(userMobile);
                Load_SellInfoesClosed(userMobile);
            }
        }

    }



    protected void BindData()
    {
        ltlCountTodo1.DataBind();
        ltlCountProcessing1.DataBind();

        ltlCountTodo2.DataBind();
        ltlCountProcessing2.DataBind();

        ltlCountTodo3.DataBind();
        ltlCountProcessing3.DataBind();
    }

    private void Load_SellInfoes(string userMobile)
    {
        var query = bll_sell.GetMySellInfo_NotClosed(userMobile);
        List<LB.SQLServerDAL.SellInfo> sellInfoes_Todo = new List<LB.SQLServerDAL.SellInfo>();
        List<LB.SQLServerDAL.SellInfo> sellInfoes_Doing = new List<LB.SQLServerDAL.SellInfo>();

        foreach (LB.SQLServerDAL.SellInfo sellInfo in query)
        {
            if (sellInfo.JD_TohandleTag == true && sellInfo.JD_AcceptedTag == false)
                sellInfoes_Todo.Add(sellInfo);

            if (sellInfo.JD_TohandleTag == true && sellInfo.JD_AcceptedTag == true)
                sellInfoes_Doing.Add(sellInfo);
        }

        if (sellInfoes_Todo.Count() == 0)
            divDataEmptyPrompt1.Visible = true;

        if (sellInfoes_Doing.Count() == 0)
            divDataEmptyPrompt2.Visible = true;

        hfCountTodo.Value = sellInfoes_Todo.Count().ToString();
        hfCountDoing.Value = sellInfoes_Doing.Count().ToString();

        rptSellInfoes_Todo.DataSource = sellInfoes_Todo;
        rptSellInfoes_Doing.DataSource = sellInfoes_Doing;

        rptSellInfoes_Todo.DataBind();
        rptSellInfoes_Doing.DataBind();

        BindData();
    }

    private void Load_SellInfoesClosed(string userMobile)
    {
        var query = bll_sell.GetMySellInfo_IsClosed(userMobile);

        rptSellInfoesClosed.DataSource = query;
        rptSellInfoesClosed.DataBind();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Guid infoId = Guid.Empty;
        Guid.TryParse(e.CommandArgument.ToString(), out infoId);

        if (infoId == Guid.Empty)
            return;


        if (e.CommandName == "Accept")
        {
            LB.SQLServerDAL.SellInfo sellInfo = bll_sell.GetSellInfo_ById(infoId);
            sellInfo.JD_AcceptedTag = true;
            sellInfo.StatusMsg = "回收业务员已接单";
            bll_sell.UpdateSellInfo(sellInfo);
            Load_SellInfoes(hfJD_UserMobile.Value);
        }


        if (e.CommandName == "Confirm")//判断这个Item里哪个控件响应的这个事件  
        {
            string url = "GoodsReceipt.aspx?infoId=" + e.CommandArgument.ToString();
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

    protected void btnQuickReg_Click(object sender, EventArgs e)
    {
        Response.Redirect("CF_quickReg.aspx");
    }
}