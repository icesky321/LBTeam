using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewsManage : System.Web.UI.Page
{
    LB.BLL.NewsInfo bll_newsinfo = new LB.BLL.NewsInfo();
    LB.SQLServerDAL.NewsInfo MNewsInfo = new LB.SQLServerDAL.NewsInfo();
    LB.SQLServerDAL.NewsType MNewTYpe = new LB.SQLServerDAL.NewsType();
    LB.BLL.NewsType bll_newtype = new LB.BLL.NewsType();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillNewsType();
            gvNewsDataBind();
        }
    }

    void FillNewsType()
    {
        IQueryable<LB.SQLServerDAL.NewsType> newstypes = bll_newtype.GetNewsType();
        foreach (LB.SQLServerDAL.NewsType NewType in newstypes)
        {
            ddlNewsType.Items.Add(new ListItem(NewType.NewsType1, NewType.NewsTypeId.ToString()));
        }
        ddlNewsType.Items.Insert(0, "");
    }


    void gvNewsDataBind()
    {
        gvNewsInfo.DataSource = bll_newsinfo.GetNewsInfo();
        gvNewsInfo.DataBind();

        foreach (GridViewRow gvRow in gvNewsInfo.Rows)
        {
            string Id = gvRow.Cells[0].Text;
            if (bll_newsinfo.GetNewsInfoById(Convert.ToInt32(Id)).IsShow == false)
            {
                ((MultiView)(gvRow.Cells[3].FindControl("MultiView1"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[3].FindControl("MultiView1"))).ActiveViewIndex = 1;
            }
        }

    }
    protected void gvNewsInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string Id = e.CommandArgument.ToString();
            string url = "~/NewsDetail.aspx?Id=" + Id.ToString();
            Response.Redirect(url);
        }
        if (e.CommandName == "Show")
        {
            string Id = e.CommandArgument.ToString();
            MNewsInfo = bll_newsinfo.GetNewsInfoById(Convert.ToInt32(Id));
            MNewsInfo.IsShow = true;
            MNewsInfo.ShowTime = System.DateTime.Now;
            bll_newsinfo.UpdateNewsInfo(MNewsInfo);
            gvNewsDataBind();
        }
        if (e.CommandName == "UnShow")
        {
            string Id = e.CommandArgument.ToString();
            MNewsInfo = bll_newsinfo.GetNewsInfoById(Convert.ToInt32(Id));
            MNewsInfo.IsShow = false;
            MNewsInfo.ShowTime = System.DateTime.Now;
            bll_newsinfo.UpdateNewsInfo(MNewsInfo);
            gvNewsDataBind();
        }

    }
    protected void gvNewsInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = gvNewsInfo.DataKeys[e.RowIndex].Values["id"].ToString();
        bll_newsinfo.DeleteNewsInfo(Convert.ToInt32(Id));
        gvNewsInfo.EditIndex = -1;
        gvNewsDataBind();
    }
    protected void btSearch_Click(object sender, EventArgs e)
    {
        if (ddlNewsType.SelectedItem.Text != "")
        {
            gvNewsInfo.DataSource = bll_newsinfo.GetNewsInfoByType(Convert.ToInt32(ddlNewsType.SelectedItem.Value));
            gvNewsInfo.DataBind();
            foreach (GridViewRow gvRow in gvNewsInfo.Rows)
            {
                string Id = gvRow.Cells[0].Text;
                if (bll_newsinfo.GetNewsInfoById(Convert.ToInt32(Id)).IsShow == false)
                {
                    ((MultiView)(gvRow.Cells[3].FindControl("MultiView1"))).ActiveViewIndex = 0;
                }
                else
                {
                    ((MultiView)(gvRow.Cells[3].FindControl("MultiView1"))).ActiveViewIndex = 1;
                }
            }
        }
        else
        {
            gvNewsDataBind();
        }

    }

    protected void gvNewsInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNewsInfo.PageIndex = e.NewPageIndex;
        gvNewsDataBind();
    }

    protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)

    {

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvNewsInfo.BottomPagerRow;

        // Retrieve the PageDropDownList DropDownList from the bottom pager row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        // Set the PageIndex property to display that page selected by the user.       

        gvNewsInfo.PageIndex = pageList.SelectedIndex;

        gvNewsDataBind();  //数据绑定 

    }

    protected void gvNewsInfo_DataBound(object sender, EventArgs e)
    {

        gvNewsInfo.BottomPagerRow.Visible = true;//只有一页数据的时候也再下面显示pagerrow，需要top的再加Top

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvNewsInfo.BottomPagerRow;

        // Retrieve the DropDownList and Label controls from the row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");

        if (pageList != null)

        {

            // Create the values for the DropDownList control based on           

            // the  total number of pages required to display the data            

            // source.            

            for (int i = 0; i < gvNewsInfo.PageCount; i++)

            {

                // Create a ListItem object to represent a page.                

                int pageNumber = i + 1;

                ListItem item = new ListItem(pageNumber.ToString());

                // If the ListItem object matches the currently selected                

                // page, flag the ListItem object as being selected. Because               

                // the DropDownList control is recreated each time the pager               

                // row gets created, this will persist the selected item in                

                // the DropDownList control.                  

                if (i == gvNewsInfo.PageIndex)

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

            int currentPage = gvNewsInfo.PageIndex + 1;

            // Update the Label control with the current page information.           

            pageLabel.Text = "Page " + currentPage.ToString() +

             " of " + gvNewsInfo.PageCount.ToString();

        }
    }
}