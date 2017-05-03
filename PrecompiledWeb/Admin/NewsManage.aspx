<%@ page title="" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_NewsManage, App_Web_jh3t2zmk" theme="Default" %>

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
    <asp:GridView ID="gvNewsInfo" runat="server" SkinID="GridView2" DataKeyNames="id"
        AutoGenerateColumns="False" OnRowDataBound="gvNewsInfo_RowDataBound" OnRowCommand="gvNewsInfo_RowCommand"
        OnRowDeleting="gvNewsInfo_RowDeleting">
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
                            <asp:ImageButton ID="lbtnShowP" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="Show" ImageUrl="~/img/gou.png" Width="30px" Height="30px" ToolTip="允许发布" />
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <asp:ImageButton ID="lbtnShowU" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="UnShow" ImageUrl="~/img/cha.png" Width="30px" Height="30px" ToolTip="不允许发布" />
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btDelete" runat="server" Text="删除" CommandName="Delete" />
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btDelete"
                        ConfirmText="亲~一失手成千古恨啊！ ">
                    </asp:ConfirmButtonExtender>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <%--            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div id="modalDiv">
                        <img src="images/ajax-loader.gif" alt="请稍候..." style="position: absolute; left: 50%;
                            top: 50%;" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
