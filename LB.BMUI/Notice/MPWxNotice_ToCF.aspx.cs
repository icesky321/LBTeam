using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB.WeixinMP;

public partial class Notice_MPWxNotice_ToCF : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.WeixinMP.TMQueue tmQueue = new LB.WeixinMP.TMQueue();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //gvCopInfoDataBind();
            Load_Province();
        }
    }


    #region  加载省市县
    private void Load_Province()
    {
        var provinces = bll_region.GetRegions("0");
        ddlProvince.Items.Clear();
        foreach (Cobe.CnRegion.SQLServerDAL.Region region in provinces)
        {
            ddlProvince.Items.Add(new ListItem(region.AreaName, region.Id));
        }
        ddlProvince.Items.Insert(0, "--选择省份--");
    }

    private void Load_City()
    {
        var cities = bll_region.GetRegions(ddlProvince.SelectedValue);
        ddlCity.Items.Clear();
        foreach (Cobe.CnRegion.SQLServerDAL.Region region in cities)
        {
            ddlCity.Items.Add(new ListItem(region.AreaName, region.Id));
        }
        ddlCity.Items.Insert(0, "--选择城市--");
    }


    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProvince.SelectedIndex > 0)
        {
            hfRegionCode.Value = ddlProvince.SelectedValue;
            Load_City();
        }
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex > 0)
        {
            hfRegionCode.Value = ddlCity.SelectedValue;
        }
    }

    #endregion

    protected void btnPushIn_Click(object sender, EventArgs e)
    {
        IQueryable<LB.SQLServerDAL.UserInfo> users = bll_user.GetUserInfo_CF_InCity(hfRegionCode.Value);
        int count = 0;
        if (users.Count() > 0)
        {
            foreach (LB.SQLServerDAL.UserInfo user in users)
            {
                if (string.IsNullOrEmpty(user.OpenId))
                    continue;

                TMData_报价提醒 data = new TMData_报价提醒();
                data.first.value = tbFirst.Text;
                data.keyword1.value = tbTradeId.Text;
                data.keyword2.value = tbQuotationDate.Text;
                data.remark.value = tbRemark.Text;

                tmQueue.PushInTM(user.OpenId, data);
                count++;
            }
            ltlCountToSend.Text = count.ToString();
        }
    }

    protected void btnStartSend_Click(object sender, EventArgs e)
    {
        tmQueue.StartSend();
        // TODO: 以下代码并不严谨， 应该从队列中读出未发消息数目。
        ltlCountToSend.Text = "0";
    }
}