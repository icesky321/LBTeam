<%@ page title="" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_HelpManage, App_Web_y4yzchvr" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    是否审核：<asp:DropDownList ID="ddlAudit" runat="server" ValidationGroup="1">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem Value="true">已审核</asp:ListItem>
        <asp:ListItem Value="false">未审核</asp:ListItem>
    </asp:DropDownList>
    手机号：<asp:TextBox ID="tbTelNum" runat="server"></asp:TextBox>(*可模糊查询)
    <asp:Button ID="btSearch" runat="server" Text="搜索" OnClick="btSearch_Click" />
    <br />
    <br />
    <asp:GridView ID="gvHelpInfo" runat="server" DataKeyNames="infoId" AutoGenerateColumns="False" OnDataBound="gvHelpInfo_DataBound" OnPageIndexChanging="gvHelpInfo_PageIndexChanging" OnRowCommand="gvHelpInfo_RowCommand" OnRowDeleting="gvHelpInfo_RowDeleting">
        <Columns>
            <%--<asp:BoundField DataField="id" HeaderText="编号" ReadOnly="True" />--%>
            <asp:BoundField DataField="infoId" HeaderText="infoId" SortExpression="infoId" Visible="True" />
            <asp:TemplateField HeaderText="资讯标题 " SortExpression="Title">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnTitle" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("infoId") %>'
                        CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                    <%--    <asp:Label ID="Title" runat="server" Text='<%# Bind("Title") %>'></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="地区" SortExpression="Title">
                <ItemTemplate>
                    <asp:Label ID="lbProvince" runat="server" Text='<%# Bind("Province") %>'></asp:Label>
                    <asp:Label ID="lbCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                    <asp:Label ID="lbTown" runat="server" Text='<%# Bind("Town") %>'></asp:Label>
                    <asp:Label ID="lbStreet" runat="server" Text='<%# Bind("Street") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发布人 " SortExpression="UserName">
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; text-align: left;">
                        <asp:Label ID="lbUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发布时间" SortExpression="ReleaseDate">
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; text-align: left;">
                        <asp:Label ID="lbReleaseDate" runat="server" Text='<%# Bind("ReleaseDate","{0:yyyy-M-d}") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否发布">
                <ItemTemplate>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <asp:ImageButton ID="lbtnShowP" runat="server" CommandArgument='<%#Eval("infoId") %>' CommandName="Show" ImageUrl="~/img/cha.png" Width="30px" Height="30px" ToolTip="允许发布" />
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <asp:ImageButton ID="lbtnShowU" runat="server" CommandArgument='<%#Eval("infoId") %>' CommandName="UnShow" ImageUrl="~/img/gou.png" Width="30px" Height="30px" ToolTip="不允许发布" />
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btTop" runat="server" Text="置顶" CommandName="Top" CommandArgument='<%#Eval("infoId") %>' />
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btTop"
                        ConfirmText="确定将发布日期更新为今天？ "></asp:ConfirmButtonExtender>
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

