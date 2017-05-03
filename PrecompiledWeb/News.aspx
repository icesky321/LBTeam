<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="News, App_Web_2u5vkwgg" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--===========layout-container================-->
    <div class="layout-container">
        <div class="section">
            <div class="container">
                <div class="section--header">
                    <asp:GridView ID="gvNew" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                        Width="100%" SkinID="GridView4"
                        OnPageIndexChanging="gvNew_PageIndexChanging" OnRowCommand="gvNew_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText=" " SortExpression="Title">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="•"></asp:Label><asp:LinkButton ID="lbtnTitle"
                                        Style="text-decoration: none" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("id") %>'
                                        CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" " SortExpression="NoteTime">
                                <%--                            <FooterTemplate>
                                <asp:LinkButton ID="lkbnMore" runat="server" Style="text-decoration: none">更多...</asp:LinkButton>
                            </FooterTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lbShowTime" runat="server" Text='<%# Bind("NoteTime","{0:yyyy-M-d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%" style="font-size: 12px;">
                                <tr>
                                    <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>'></asp:Label>页
                                    /共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount %>'></asp:Label>页
                                    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                                        Visible="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">首页</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                            CommandName="Page" Visible="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                                            Visible="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">尾页</asp:LinkButton>
                                        <asp:TextBox ID="txtNewPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>'
                                            Width="20px" AutoPostBack="true"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CommandArgument="GO" CommandName="Page"
                                            Text="GO" OnClick="btnGo_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
