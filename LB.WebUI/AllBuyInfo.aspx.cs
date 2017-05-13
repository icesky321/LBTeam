using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AllBuyInfo : System.Web.UI.Page
{
    LB.BLL.Tradeleads bll_tradeleads = new LB.BLL.Tradeleads();
    LB.SQLServerDAL.Tradeleads MTradeleads = new LB.SQLServerDAL.Tradeleads();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvBuyInfo.DataSource = bll_tradeleads.GetTradeleadsInfoByAudit("true", "", "", "", "", "1");
            gvBuyInfo.DataBind();
            
        }
    }

    void gvBuyInfoDataBind()
    {
        gvBuyInfo.DataSource = bll_tradeleads.GetTradeleadsInfoByAudit("true", DDLAddress1.province, DDLAddress1.city, DDLAddress1.country, DDLAddress1.street, "1");

        gvBuyInfo.DataBind();
    }
    protected void gvBuyInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBuyInfo.PageIndex = e.NewPageIndex;
        gvBuyInfoDataBind();
    }
    protected void gvBuyInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string infoId = e.CommandArgument.ToString();
            string url = "~/TradeleadsDetail.aspx?infoId=" + infoId.ToString();
            Response.Redirect(url);
        }
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        gvBuyInfoDataBind();
    }

    protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)

    {

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvBuyInfo.BottomPagerRow;

        // Retrieve the PageDropDownList DropDownList from the bottom pager row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        // Set the PageIndex property to display that page selected by the user.       

        gvBuyInfo.PageIndex = pageList.SelectedIndex;

        gvBuyInfoDataBind();  //数据绑定 

    }
    protected void gvBuyInfo_DataBound(object sender, EventArgs e)
    {
        gvBuyInfo.BottomPagerRow.Visible = true;//只有一页数据的时候也再下面显示pagerrow，需要top的再加Top

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvBuyInfo.BottomPagerRow;

        // Retrieve the DropDownList and Label controls from the row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");

        if (pageList != null)

        {

            // Create the values for the DropDownList control based on           

            // the  total number of pages required to display the data            

            // source.            

            for (int i = 0; i < gvBuyInfo.PageCount; i++)

            {

                // Create a ListItem object to represent a page.                

                int pageNumber = i + 1;

                ListItem item = new ListItem(pageNumber.ToString());

                // If the ListItem object matches the currently selected                

                // page, flag the ListItem object as being selected. Because               

                // the DropDownList control is recreated each time the pager               

                // row gets created, this will persist the selected item in                

                // the DropDownList control.                  

                if (i == gvBuyInfo.PageIndex)

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

            int currentPage = gvBuyInfo.PageIndex + 1;

            // Update the Label control with the current page information.           

            pageLabel.Text = "Page " + currentPage.ToString() +

             " of " + gvBuyInfo.PageCount.ToString();

        }
    }
}