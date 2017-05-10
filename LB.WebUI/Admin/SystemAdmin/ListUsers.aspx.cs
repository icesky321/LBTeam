using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_ListUsers : System.Web.UI.Page
{
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //绑定用户和角色信息
            gvUsers.DataSource = Membership.GetAllUsers();
            gvUsers.DataBind();
            gvRoles.DataSource = Roles.GetAllRoles();
            gvRoles.DataBind();
        }
    }

    protected void LinkButtonClick(object sender, CommandEventArgs e)
    {
        // 如果进行用户编辑，则转到EditUser.aspx页面
        if (e.CommandName.Equals("EditUser"))
        {
            Response.Redirect("EditUser.aspx?user=" + e.CommandArgument.ToString());
        }
        // 如果进行删除用户，则调用DeleteUser方法
        if (e.CommandName.Equals("DeleteUser"))
        {
            if (Membership.DeleteUser(e.CommandArgument.ToString()))
            {
                //如果删除的是自身，则重定向到登录页面；否则显示删除信息，并重新绑定数据
                if (e.CommandArgument.ToString() == User.Identity.Name)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/LoginM.aspx");
                }
                else
                {
                    gvUsers.DataSource = Membership.GetAllUsers();
                    gvUsers.DataBind();
                    lbMessage.Text = "删除成功.";
                }
            }
            else
            {
                lbMessage.Text = "未能删除成功.";
            }
        }
        // 如果进行添加角色
        if (e.CommandName.Equals("AddRole"))
        {
            //如果当前没有角色，则重定向创建新角色
            if (Roles.GetAllRoles().Length == 0)
            {
                Response.Redirect("ListRoles.aspx");
                return;
            }
            //显示角色信息，主要设置CheckBox的选中状态
            string username = e.CommandArgument.ToString();
            gvRoles.Caption = "设置用户<b>" + username + "</b>的角色";
            for (int i = 0; i < Roles.GetAllRoles().Length; i++)
            {
                CheckBox cb = (CheckBox)gvRoles.Rows[i].FindControl("cbAddRoleToUser");
                string roleName = cb.ToolTip;
                cb.Checked = Roles.IsUserInRole(username, roleName);
                //将用户信息传递到显示角色信息的列表中
                cb.Attributes["user"] = username;
            }
            plListRole.Visible = true;
        }
    }

    protected void CheckBox_Click(object sender, EventArgs e)
    {
        try
        {
            //更新用户信息，并重新绑定
            CheckBox cbIsApproved = (CheckBox)sender;
            string username = cbIsApproved.ToolTip;
            MembershipUser mu = Membership.GetUser(username);
            mu.IsApproved = cbIsApproved.Checked;
            Membership.UpdateUser(mu);
            gvUsers.DataSource = Membership.GetAllUsers();
            gvUsers.DataBind();
            lbMessage.Text = "更新成功.";
        }
        catch (System.Configuration.Provider.ProviderException ex)
        {
            //抛出异常
            lbMessage.Text = ex.Message;
        }
    }
    protected void AddRoleToUserCheckBox_Click(object sender, EventArgs e)
    {
        try
        {
            //为用户分配角色
            CheckBox cbAddRoleToUser = (CheckBox)sender;
            string username = cbAddRoleToUser.Attributes["user"];
            string roleName = cbAddRoleToUser.ToolTip;
            //如果用户已经分配角色，则删除；否则为用户添加角色
            if (!cbAddRoleToUser.Checked)
            {
                Roles.RemoveUserFromRole(username, roleName);
            }
            else
            {
                Roles.AddUserToRole(username, roleName);
            }
            lbMessage.Text = "更新成功.";
        }
        catch (System.Configuration.Provider.ProviderException ex)
        {
            //抛出异常
            lbMessage.Text = ex.Message;
        }
    }
    protected void lbtExit_Click(object sender, EventArgs e)
    {
        //退出系统，并重定向
        FormsAuthentication.SignOut();
        Response.Redirect("~/LoginM.aspx");
    }

    protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUsers.PageIndex = e.NewPageIndex;
        gvUsers.DataSource = Membership.GetAllUsers();
        gvUsers.DataBind();
    }

    protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)

    {

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvUsers.BottomPagerRow;

        // Retrieve the PageDropDownList DropDownList from the bottom pager row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        // Set the PageIndex property to display that page selected by the user.       

        gvUsers.PageIndex = pageList.SelectedIndex;

        gvUsers.DataSource = Membership.GetAllUsers();
        gvUsers.DataBind(); //数据绑定 

    }

    protected void gvUsers_DataBound(object sender, EventArgs e)
    {
        gvUsers.BottomPagerRow.Visible = true;//只有一页数据的时候也再下面显示pagerrow，需要top的再加Top

        // Retrieve the pager row.        

        GridViewRow pagerRow = gvUsers.BottomPagerRow;

        // Retrieve the DropDownList and Label controls from the row.        

        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

        Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");

        if (pageList != null)

        {

            // Create the values for the DropDownList control based on           

            // the  total number of pages required to display the data            

            // source.            

            for (int i = 0; i < gvUsers.PageCount; i++)

            {

                // Create a ListItem object to represent a page.                

                int pageNumber = i + 1;

                ListItem item = new ListItem(pageNumber.ToString());

                // If the ListItem object matches the currently selected                

                // page, flag the ListItem object as being selected. Because               

                // the DropDownList control is recreated each time the pager               

                // row gets created, this will persist the selected item in                

                // the DropDownList control.                  

                if (i == gvUsers.PageIndex)

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

            int currentPage = gvUsers.PageIndex + 1;

            // Update the Label control with the current page information.           

            pageLabel.Text = "Page " + currentPage.ToString() +

             " of " + gvUsers.PageCount.ToString();

        }
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        gvUsers.DataSource =  bll_userinfo.GetUserInfoByTelNumFuzzy(tbTelNum.Text);
        gvUsers.DataBind();
    }

    protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}
