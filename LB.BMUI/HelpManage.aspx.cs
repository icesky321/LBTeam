using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_HelpManage : System.Web.UI.Page
{
    LB.BLL.TSType bll_tstype = new LB.BLL.TSType();
    LB.SQLServerDAL.TSType MTSType = new LB.SQLServerDAL.TSType();
    LB.BLL.Tradeleads bll_tradeleads = new LB.BLL.Tradeleads();
    LB.SQLServerDAL.Tradeleads MTradeleads = new LB.SQLServerDAL.Tradeleads();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //gvHelpDataBindByAudit(false);
        }
    }

    void gvHelpDataBindByAudit(bool Audit)
    {
        if (bll_tradeleads.GetTradeleadsInfoByAudit(Audit.ToString(), "", "", "", "", "", tbTelNum.Text).Count() != 0)
        {
            gvHelpInfo.Visible = true;
            lbMsg.Visible = false;
            gvHelpInfo.DataSource = bll_tradeleads.GetTradeleadsInfoByAudit(Audit.ToString(), "", "", "", "", "", tbTelNum.Text);
            gvHelpInfo.DataBind();
            foreach (GridViewRow gvRow in gvHelpInfo.Rows)
            {
                string Id = gvRow.Cells[0].Text;
                if (bll_tradeleads.GetTradeleadsByinfoId(Convert.ToInt32(Id)).Audit == false)
                {
                    ((MultiView)(gvRow.Cells[5].FindControl("MultiView1"))).ActiveViewIndex = 0;
                }
                else
                {
                    ((MultiView)(gvRow.Cells[5].FindControl("MultiView1"))).ActiveViewIndex = 1;
                }
            }
        }
        else
        {
            gvHelpInfo.Visible = false;
            lbMsg.Visible = true;
        }
    }

    void gvHelpDataBind()
    {
        gvHelpInfo.DataSource = bll_tradeleads.GetTradeleadsInfoByAll();
        gvHelpInfo.DataBind();
        foreach (GridViewRow gvRow in gvHelpInfo.Rows)
        {
            string Id = gvRow.Cells[0].Text;
            if (bll_tradeleads.GetTradeleadsByinfoId(Convert.ToInt32(Id)).Audit == false)
            {
                ((MultiView)(gvRow.Cells[5].FindControl("MultiView1"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[5].FindControl("MultiView1"))).ActiveViewIndex = 1;
            }
        }
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        if (ddlAudit.SelectedItem.Value == "true")
        {
            gvHelpDataBindByAudit(true);
        }
        else if (ddlAudit.SelectedItem.Value == "false")
        {
            gvHelpDataBindByAudit(false);
        }
        else
        {
            gvHelpDataBind();
        }
    }

    protected void gvHelpInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            string Id = e.CommandArgument.ToString();
            string url = "http://www.lvbao111.com/WebUI/TradeleadsDetail.aspx?infoId=" + Id.ToString();
            Response.Redirect(url);
        }
        if (e.CommandName == "Show")
        {
            string Id = e.CommandArgument.ToString();
            MTradeleads = bll_tradeleads.GetTradeleadsByinfoId(Convert.ToInt32(Id));
            MTradeleads.Audit = true;
            MTradeleads.AuditDatetime = System.DateTime.Now;
            bll_tradeleads.UpdateTradeleads(MTradeleads);
            gvHelpDataBind();
        }
        if (e.CommandName == "UnShow")
        {
            string Id = e.CommandArgument.ToString();
            MTradeleads = bll_tradeleads.GetTradeleadsByinfoId(Convert.ToInt32(Id));
            MTradeleads.Audit = false;
            MTradeleads.AuditDatetime = System.DateTime.Now;
            bll_tradeleads.UpdateTradeleads(MTradeleads);
            gvHelpDataBind();
        }
        if (e.CommandName == "Top")
        {
            string Id = e.CommandArgument.ToString();
            MTradeleads = bll_tradeleads.GetTradeleadsByinfoId(Convert.ToInt32(Id));
            MTradeleads.ReleaseDate = System.DateTime.Now;
            bll_tradeleads.UpdateTradeleads(MTradeleads);
            gvHelpDataBind();
        }
    }

    protected void gvHelpInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = gvHelpInfo.DataKeys[e.RowIndex].Values["infoId"].ToString();
        bll_tradeleads.DeleteTradeleads(Convert.ToInt32(Id));
        gvHelpInfo.EditIndex = -1;
        gvHelpDataBindByAudit(false);  //数据绑定 
    }

    protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)

    {

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvHelpInfo.BottomPagerRow;

        // Retrieve the PageDropDownList DropDownList from the bottom pager row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        // Set the PageIndex property to display that page selected by the user.       

        gvHelpInfo.PageIndex = pageList.SelectedIndex;

        gvHelpDataBind();  //数据绑定 

    }
    protected void gvHelpInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHelpInfo.PageIndex = e.NewPageIndex;
        gvHelpDataBind();
    }

    protected void gvHelpInfo_DataBound(object sender, EventArgs e)
    {
        if (gvHelpInfo.DataSource != null)
        {

            gvHelpInfo.BottomPagerRow.Visible = true;//只有一页数据的时候也再下面显示pagerrow，需要top的再加Top

            // Retrieve the pager row.        

            GridViewRow pagerRow = gvHelpInfo.BottomPagerRow;

            // Retrieve the DropDownList and Label controls from the row.        

            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");

            if (pageList != null)

            {

                // Create the values for the DropDownList control based on           

                // the  total number of pages required to display the data            

                // source.            

                for (int i = 0; i < gvHelpInfo.PageCount; i++)

                {

                    // Create a ListItem object to represent a page.                

                    int pageNumber = i + 1;

                    ListItem item = new ListItem(pageNumber.ToString());

                    // If the ListItem object matches the currently selected                

                    // page, flag the ListItem object as being selected. Because               

                    // the DropDownList control is recreated each time the pager               

                    // row gets created, this will persist the selected item in                

                    // the DropDownList control.                  

                    if (i == gvHelpInfo.PageIndex)

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

                int currentPage = gvHelpInfo.PageIndex + 1;

                // Update the Label control with the current page information.           

                pageLabel.Text = "Page " + currentPage.ToString() +

                 " of " + gvHelpInfo.PageCount.ToString();

            }
        }
    }


}