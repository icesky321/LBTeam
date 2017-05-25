<%@ page title="" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_NewsManage, App_Web_jsqmqrzk" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <br />
    <br />
    请选择发布资讯的类别：<asp:DropDownList ID="ddlNewsType" runat="server" ValidationGroup="1">
    </asp:DropDownList>
    <asp:Button ID="btSearch" runat="server" Text="搜索" OnClick="btSearch_Click" />
    <br />
    <br />
    <asp:GridView ID="gvNewsInfo" runat="server" DataKeyNames="id"
        AutoGenerateColumns="False" OnRowCommand="gvNewsInfo_RowCommand"
        OnRowDeleting="gvNewsInfo_RowDeleting" OnPageIndexChanging="gvNewsInfo_PageIndexChanging" OnDataBound="gvNewsInfo_DataBound">
        <Columns>
            <%--<asp:BoundField DataField="id" HeaderText="编号" ReadOnly="True" />--%>
            <asp:BoundField DataField="id" HeaderText="Id" SortExpression="id" Visible="True" />
            <asp:TemplateField HeaderText="资讯标题 " SortExpression="Title">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnTitle" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("id") %>'
                        CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                    <%--    <asp:Label ID="Title" runat="server" Text='<%# Bind("Title") %>'></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否发布">
                <ItemTemplate>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <asp:ImageButton ID="lbtnShowP" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="Show" ImageUrl="~/img/cha.png" Width="30px" Height="30px" ToolTip="允许发布" />
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <asp:ImageButton ID="lbtnShowU" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="UnShow" ImageUrl="~/img/gou.png" Width="30px" Height="30px" ToolTip="不允许发布" />
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btDelete" runat="server" Text="删除" CommandName="Delete" />
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btDelete"
                        ConfirmText="亲~一失手成千古恨啊！ "></asp:ConfirmButtonExtender>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <table width="100%" style="font-size: 12px;">
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
                        <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
                        <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                        <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                        <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                        到第<asp:DropDownList ID="PageDropDownList"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged"
                            runat="server" />
                        页  
                    </td>
                </tr>
            </table>
        </PagerTemplate>
    </asp:GridView>
</asp:Content>
