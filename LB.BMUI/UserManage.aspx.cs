using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserManage : System.Web.UI.Page
{
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.BLL.UserTypeInfo bll_usertypeinfo = new LB.BLL.UserTypeInfo();
    LB.SQLServerDAL.UserTypeInfo MUserTypeInfo = new LB.SQLServerDAL.UserTypeInfo();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvUserInfoDataBind();
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

    private void Load_County()
    {
        var counties = bll_region.GetRegions(ddlCity.SelectedValue);
        ddlCounty.Items.Clear();
        foreach (Cobe.CnRegion.SQLServerDAL.Region region in counties)
        {
            ddlCounty.Items.Add(new ListItem(region.AreaName, region.Id));
        }
        ddlCounty.Items.Insert(0, "--选择区县--");
    }

    private void Load_Street()
    {
        var streets = bll_region.GetRegions(ddlCounty.SelectedValue);
        ddlStreet.Items.Clear();
        foreach (Cobe.CnRegion.SQLServerDAL.Region region in streets)
        {
            ddlStreet.Items.Add(new ListItem(region.AreaName, region.Id));
        }
        ddlStreet.Items.Insert(0, "--选择区县--");
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
            Load_County();
        }
    }

    protected void ddlCounty_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCounty.SelectedIndex > 0)
        {
            hfRegionCode.Value = ddlCounty.SelectedValue;
            Load_Street();
        }
    }

    protected void ddlStreet_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStreet.SelectedIndex > 0)
        {
            hfRegionCode.Value = ddlStreet.SelectedValue;
        }
    }
    #endregion

    void gvUserInfoDataBind()
    {
        gvUserInfo.DataSource = bll_userinfo.GetUserInfoByUserTypeId_RegionCode_TelNum(5, hfRegionCode.Value, tbTelNum.Text);
        gvUserInfo.DataBind();
        foreach (GridViewRow gvRow in gvUserInfo.Rows)
        {
            string UserId = gvRow.Cells[0].Text;
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            if (!string.IsNullOrEmpty(MUserInfo.RegionCode))
            {
                ((Label)(gvRow.Cells[9].FindControl("lbAddress"))).Text = bll_region.GetRegion(MUserInfo.RegionCode).WholeName + MUserInfo.Address;
            }
            if (string.IsNullOrEmpty(bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).IDCard) == false)
            {
                if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).IDAuthentication == true)
                {
                    ((MultiView)(gvRow.Cells[6].FindControl("MultiView3"))).ActiveViewIndex = 1;
                }
                else
                {
                    ((MultiView)(gvRow.Cells[6].FindControl("MultiView3"))).ActiveViewIndex = 0;
                }
            }
            else
            {
                ((LinkButton)(gvRow.Cells[6].FindControl("lbtnIDCard"))).Visible = false;
                ((MultiView)(gvRow.Cells[6].FindControl("MultiView3"))).ActiveViewIndex = 2;
            }
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).Audit == true)
            {
                ((MultiView)(gvRow.Cells[6].FindControl("MultiView5"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[6].FindControl("MultiView5"))).ActiveViewIndex = 0;
            }
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).InCharge == true)
            {
                ((MultiView)(gvRow.Cells[6].FindControl("MultiView6"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[6].FindControl("MultiView6"))).ActiveViewIndex = 0;
            }
        }
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        if (ddlStreet.SelectedIndex > 0)
        {
            hfRegionCode.Value = ddlStreet.SelectedValue;
        }
        else if (ddlCounty.SelectedIndex > 0)
        {
            string str1 = ddlCounty.SelectedValue;
            hfRegionCode.Value = str1.Substring(0, 6);
        }
        else if (ddlCity.SelectedIndex > 0)
        {
            string str1 = ddlCity.SelectedValue;
            hfRegionCode.Value = str1.Substring(0, 4);
        }
        else if (ddlProvince.SelectedIndex > 0)
        {
            string str1 = ddlProvince.SelectedValue;
            hfRegionCode.Value = str1.Substring(0, 2);
        }
        gvUserInfoDataBind();
    }

    protected void gvUserInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "IDCard")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            string url = "../WebUI/IDCard/" + MUserInfo.IDCard;
            Response.Redirect(url);
        }
        if (e.CommandName == "IPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MUserInfo.IDAuthentication = true;
        }
        if (e.CommandName == "IUPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MUserInfo.IDAuthentication = false;
        }
        if (e.CommandName == "Pass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MUserInfo.Audit = true;
            MUserInfo.AuditDate = System.DateTime.Now;
        }
        if (e.CommandName == "UPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MUserInfo.Audit = false;
            MUserInfo.AuditDate = System.DateTime.Now;
        }
        if (e.CommandName == "ICPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MUserInfo.InCharge = true;
            MUserInfo.InChargeDate = System.DateTime.Now;
        }
        if (e.CommandName == "ICUPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MUserInfo.InCharge = false;
            MUserInfo.InChargeDate = System.DateTime.Now;
        }
        bll_userinfo.UpdateUserInfo(MUserInfo);
        gvUserInfoDataBind();
    }

    protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)

    {

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvUserInfo.BottomPagerRow;

        // Retrieve the PageDropDownList DropDownList from the bottom pager row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        // Set the PageIndex property to display that page selected by the user.       

        gvUserInfo.PageIndex = pageList.SelectedIndex;

        gvUserInfoDataBind();  //数据绑定 

    }

    protected void gvUserInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUserInfo.PageIndex = e.NewPageIndex;
        gvUserInfoDataBind();
    }

    protected void gvUserInfo_DataBound(object sender, EventArgs e)
    {
        gvUserInfo.BottomPagerRow.Visible = true;//只有一页数据的时候也再下面显示pagerrow，需要top的再加Top

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvUserInfo.BottomPagerRow;

        // Retrieve the DropDownList and Label controls from the row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");

        if (pageList != null)

        {

            // Create the values for the DropDownList control based on           

            // the  total number of pages required to display the data            

            // source.            

            for (int i = 0; i < gvUserInfo.PageCount; i++)

            {

                // Create a ListItem object to represent a page.                

                int pageNumber = i + 1;

                ListItem item = new ListItem(pageNumber.ToString());

                // If the ListItem object matches the currently selected                

                // page, flag the ListItem object as being selected. Because               

                // the DropDownList control is recreated each time the pager               

                // row gets created, this will persist the selected item in                

                // the DropDownList control.                  

                if (i == gvUserInfo.PageIndex)

                {

                    item.Selected = true;

                }

                // Add the ListItem object to the Items collection of the               

                // DropDownList.                

                pageList.Items.Add(item);

            }

        }

        if (pageLabel != null)

        {

            // Calculate the current page number.            

            int currentPage = gvUserInfo.PageIndex + 1;

            // Update the Label control with the current page information.           

            pageLabel.Text = "Page " + currentPage.ToString() +

             " of " + gvUserInfo.PageCount.ToString();

        }
    }
}