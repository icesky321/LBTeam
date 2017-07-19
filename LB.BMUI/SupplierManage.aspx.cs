using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SupplierManage : System.Web.UI.Page
{
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.Model.UserInfoModel MUserInfoModel = new LB.Model.UserInfoModel();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvCopInfoDataBind();
        }
    }

    void gvCopInfoDataBind()
    {
        gvCopInfo.DataSource = bll_userinfo.GetUserInfosBySEO("", "", "", "", "1", "");
        //gvCopInfo.DataSource = bll_copinfo.GetCopInfoByUserType(1);
        gvCopInfo.DataBind();
        foreach (GridViewRow gvRow in gvCopInfo.Rows)
        {
            string UserId = gvRow.Cells[0].Text;
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(UserId));
            MCopInfo = bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(UserId));
            if (!string.IsNullOrEmpty(MUserInfo.RegionCode))
            {
                ((Label)(gvRow.Cells[8].FindControl("lbAddress"))).Text = bll_region.GetRegion(MUserInfo.RegionCode).WholeName;
            }

            if (string.IsNullOrEmpty(bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(Convert.ToInt32(UserId))).IDCard) == false)//如果用户身份证已上传
            {
                if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(Convert.ToInt32(UserId))).IDAuthentication == false)
                {
                    ((MultiView)(gvRow.Cells[7].FindControl("MultiView3"))).ActiveViewIndex = 0;
                }
                else
                {
                    ((MultiView)(gvRow.Cells[7].FindControl("MultiView3"))).ActiveViewIndex = 1;
                }
            }
            else
            {
                ((LinkButton)(gvRow.Cells[7].FindControl("lbtnIDCard"))).Visible = false;
                ((MultiView)(gvRow.Cells[7].FindControl("MultiView3"))).ActiveViewIndex = 2;
            }
            if (bll_copinfo.ExistUseId(Convert.ToInt32(UserId)))//如果企业含有该用户的话
            {
                if (string.IsNullOrEmpty(bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(UserId)).Bizlicense) == false)
                {
                    if (bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(UserId)).BAuthentication == false)
                    {
                        ((MultiView)(gvRow.Cells[6].FindControl("MultiView1"))).ActiveViewIndex = 0;
                    }
                    else
                    {
                        ((MultiView)(gvRow.Cells[6].FindControl("MultiView1"))).ActiveViewIndex = 1;
                    }
                }
                else
                {
                    ((LinkButton)(gvRow.Cells[6].FindControl("lbtnBizlicense"))).Visible = false;
                    ((MultiView)(gvRow.Cells[6].FindControl("MultiView1"))).ActiveViewIndex = 2;
                }
            }
            else
            {
                ((LinkButton)(gvRow.Cells[6].FindControl("lbtnBizlicense"))).Visible = false;
                ((MultiView)(gvRow.Cells[6].FindControl("MultiView1"))).ActiveViewIndex = 2;
            }
            if (bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(Convert.ToInt32(UserId))).Audit == false)
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView5"))).ActiveViewIndex = 0;
            }
            else
            {
                ((MultiView)(gvRow.Cells[8].FindControl("MultiView5"))).ActiveViewIndex = 1;
            }
        }
    }

    protected void gvCopInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //string UserId = e.CommandArgument.ToString();
        //MCopInfo = bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(UserId));
        //MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(Convert.ToInt32(UserId)));
        if (e.CommandName == "Bizlicense")
        {
            string UserId = e.CommandArgument.ToString();
            MCopInfo = bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(UserId));
            string url = "../WebUI/Bizlicense/" + MCopInfo.Bizlicense;
            Response.Redirect(url);
        }
        if (e.CommandName == "BPass")
        {
            string UserId = e.CommandArgument.ToString();
            MCopInfo = bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(UserId));
            MCopInfo.BAuthentication = true;
        }
        if (e.CommandName == "BUPass")
        {
            string UserId = e.CommandArgument.ToString();
            MCopInfo = bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(UserId));
            MCopInfo.BAuthentication = false;
        }
        if (e.CommandName == "HWPermit")
        {
            string UserId = e.CommandArgument.ToString();
            MCopInfo = bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(UserId));
            string url = "../WebUI/HWPermit/" + MCopInfo.HWPermit;
            Response.Redirect(url);
        }
        if (e.CommandName == "HPass")
        {
            string UserId = e.CommandArgument.ToString();
            MCopInfo = bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(UserId));
            MCopInfo.HWAuthentication = true;
        }
        if (e.CommandName == "HUPass")
        {
            string UserId = e.CommandArgument.ToString();
            MCopInfo = bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(UserId));
            MCopInfo.HWAuthentication = false;
        }
        if (e.CommandName == "IDCard")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(Convert.ToInt32(UserId)));
            string url = "../WebUI/IDCard/"+ MUserInfo.IDCard;
            Response.Redirect(url);
        }
        if (e.CommandName == "IPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(Convert.ToInt32(UserId)));
            MUserInfo.IDAuthentication = true;
        }
        if (e.CommandName == "IUPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(Convert.ToInt32(UserId)));
            MUserInfo.IDAuthentication = false;
        }
        if (e.CommandName == "Pass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(Convert.ToInt32(UserId)));
            MUserInfo.Audit = true;
            MUserInfo.AuditDate = System.DateTime.Now;
        }
        if (e.CommandName == "UPass")
        {
            string UserId = e.CommandArgument.ToString();
            MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(Convert.ToInt32(UserId)));
            MUserInfo.Audit = false;
            MUserInfo.AuditDate = System.DateTime.Now;
        }
        bll_userinfo.UpdateUserInfo(MUserInfo);
        bll_copinfo.UpdateCopInfo(MCopInfo);
        gvCopInfoDataBind();
    }

    protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)

    {

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvCopInfo.BottomPagerRow;

        // Retrieve the PageDropDownList DropDownList from the bottom pager row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        // Set the PageIndex property to display that page selected by the user.       

        gvCopInfo.PageIndex = pageList.SelectedIndex;

        gvCopInfoDataBind();  //数据绑定 

    }

    protected void gvCopInfo_DataBound(object sender, EventArgs e)
    {
        gvCopInfo.BottomPagerRow.Visible = true;//只有一页数据的时候也再下面显示pagerrow，需要top的再加Top

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvCopInfo.BottomPagerRow;

        // Retrieve the DropDownList and Label controls from the row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");

        if (pageList != null)

        {

            // Create the values for the DropDownList control based on           

            // the  total number of pages required to display the data            

            // source.            

            for (int i = 0; i < gvCopInfo.PageCount; i++)

            {

                // Create a ListItem object to represent a page.                

                int pageNumber = i + 1;

                ListItem item = new ListItem(pageNumber.ToString());

                // If the ListItem object matches the currently selected                

                // page, flag the ListItem object as being selected. Because               

                // the DropDownList control is recreated each time the pager               

                // row gets created, this will persist the selected item in                

                // the DropDownList control.                  

                if (i == gvCopInfo.PageIndex)

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

            int currentPage = gvCopInfo.PageIndex + 1;

            // Update the Label control with the current page information.           

            pageLabel.Text = "Page " + currentPage.ToString() +

             " of " + gvCopInfo.PageCount.ToString();

        }
    }

    protected void gvCopInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCopInfo.PageIndex = e.NewPageIndex;
        gvCopInfoDataBind();
    }
}