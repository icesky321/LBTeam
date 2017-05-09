using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News : System.Web.UI.Page
{
    LB.BLL.NewsInfo bll_newsinfo = new LB.BLL.NewsInfo();
    LB.SQLServerDAL.NewsInfo MNewsInfo = new LB.SQLServerDAL.NewsInfo();
    LB.BLL.NewsType bll_newstype = new LB.BLL.NewsType();
    LB.SQLServerDAL.NewsType MNewsType = new LB.SQLServerDAL.NewsType();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                MNewsType = bll_newstype.GetNewTypeById(Id);
                //lbNewsType.Text = MNewsType.NewsType1.ToString();
                gvNewsDataBind(Convert.ToInt32(MNewsType.NewsTypeId));
                if (Id == 3)
                {
                    MultiView1.ActiveViewIndex = 1;
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }
    }

    void gvNewsDataBind(int TypeId)
    {
        gvNew.DataSource = bll_newsinfo.GetNewsInfoByType(TypeId);
        gvNew.DataBind();

        gvPrice.DataSource = bll_newsinfo.GetNewsInfoByType(TypeId);
        gvPrice.DataBind();
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        GridViewRow gridViewRow = gvNew.BottomPagerRow;
        TextBox numBox = (TextBox)gvNew.BottomPagerRow.FindControl("txtNewPageIndex");
        int inputNum = Convert.ToInt32(numBox.Text);
        gvNew.PageIndex = inputNum - 1;
        gvNewsDataBind(Convert.ToInt32(Request.QueryString["Id"]));
    }
    protected void gvNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNew.PageIndex = e.NewPageIndex;
        gvNewsDataBind(Convert.ToInt32(Request.QueryString["Id"]));
    }
    protected void gvNew_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string Id = e.CommandArgument.ToString();
            string url = "~/NewsDetail.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
    }

    protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)

    {

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvNew.BottomPagerRow;

        // Retrieve the PageDropDownList DropDownList from the bottom pager row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        // Set the PageIndex property to display that page selected by the user.       

        gvNew.PageIndex = pageList.SelectedIndex;

        gvNewsDataBind(Convert.ToInt32(Request.QueryString["Id"])); //数据绑定 

    }

    protected void PageDropDownList1_SelectedIndexChanged(Object sender, EventArgs e)

    {

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvNew.BottomPagerRow;

        // Retrieve the PageDropDownList DropDownList from the bottom pager row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        // Set the PageIndex property to display that page selected by the user.       

        gvNew.PageIndex = pageList.SelectedIndex;

        gvNewsDataBind(Convert.ToInt32(Request.QueryString["Id"]));  //数据绑定 

    }

    protected void gvNew_DataBound(object sender, EventArgs e)
    {
        gvNew.BottomPagerRow.Visible = true;//只有一页数据的时候也再下面显示pagerrow，需要top的再加Top

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvNew.BottomPagerRow;

        // Retrieve the DropDownList and Label controls from the row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");

        if (pageList != null)

        {

            // Create the values for the DropDownList control based on           

            // the  total number of pages required to display the data            

            // source.            

            for (int i = 0; i < gvNew.PageCount; i++)

            {

                // Create a ListItem object to represent a page.                

                int pageNumber = i + 1;

                ListItem item = new ListItem(pageNumber.ToString());

                // If the ListItem object matches the currently selected                

                // page, flag the ListItem object as being selected. Because               

                // the DropDownList control is recreated each time the pager               

                // row gets created, this will persist the selected item in                

                // the DropDownList control.                  

                if (i == gvNew.PageIndex)

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

            int currentPage = gvNew.PageIndex + 1;

            // Update the Label control with the current page information.           

            pageLabel.Text = "Page " + currentPage.ToString() +

             " of " + gvNew.PageCount.ToString();

        }
    }

    protected void gvPrice_DataBound(object sender, EventArgs e)
    {
        gvPrice.BottomPagerRow.Visible = true;//只有一页数据的时候也再下面显示pagerrow，需要top的再加Top

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvPrice.BottomPagerRow;

        // Retrieve the DropDownList and Label controls from the row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");

        if (pageList != null)

        {

            // Create the values for the DropDownList control based on           

            // the  total number of pages required to display the data            

            // source.            

            for (int i = 0; i < gvPrice.PageCount; i++)

            {

                // Create a ListItem object to represent a page.                

                int pageNumber = i + 1;

                ListItem item = new ListItem(pageNumber.ToString());

                // If the ListItem object matches the currently selected                

                // page, flag the ListItem object as being selected. Because               

                // the DropDownList control is recreated each time the pager               

                // row gets created, this will persist the selected item in                

                // the DropDownList control.                  

                if (i == gvPrice.PageIndex)

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

            int currentPage = gvPrice.PageIndex + 1;

            // Update the Label control with the current page information.           

            pageLabel.Text = "Page " + currentPage.ToString() +

             " of " + gvPrice.PageCount.ToString();

        }
    }
}