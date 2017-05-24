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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvUserInfoDataBind();
        }
    }

    void gvUserInfoDataBind()
    {
        gvUserInfo.DataSource = bll_userinfo.GetUserInfoByUserTypeId(5);
        gvUserInfo.DataBind();
        foreach (GridViewRow gvRow in gvUserInfo.Rows)
        {
            string UserId = gvRow.Cells[0].Text;
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId)).IDAuthentication == true)
            {
                ((MultiView)(gvRow.Cells[6].FindControl("MultiView3"))).ActiveViewIndex = 1;
            }
            else
            {
                ((MultiView)(gvRow.Cells[6].FindControl("MultiView3"))).ActiveViewIndex = 0;
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
        gvUserInfoDataBind();
    }

    protected void gvUserInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "IDCard")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            string url = MUserInfo.IDCard;
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
        // Retrieve the pager row.        

        GridViewRow pagerRow = gvUserInfo.BottomPagerRow;

        // Retrieve the PageDropDownList DropDownList from the bottom pager row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        // Set the PageIndex property to display that page selected by the user.       

        gvUserInfo.PageIndex = pageList.SelectedIndex;

        gvUserInfoDataBind();  //数据绑定 
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