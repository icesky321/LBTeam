<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AllSellInfo.aspx.cs" Inherits="AllSellInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="UserControls/DDLAddress.ascx" TagName="DDLAddress" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>供货信息</h1>
                </p>
            </div>
            <hr />
            <uc1:DDLAddress ID="DDLAddress1" runat="server" />
                    <asp:Button ID="btSearch" runat="server" Text="搜索" OnClick="btSearch_Click" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <br />
                    <div style="text-align: left; margin: 20px 0 0 30px;">
                        <asp:GridView ID="gvBuyInfo" runat="server" DataKeyNames="infoId" AutoGenerateColumns="False"
                            Width="100%" SkinID="GridView4"
                            OnPageIndexChanging="gvBuyInfo_PageIndexChanging" OnRowCommand="gvBuyInfo_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="标题 " SortExpression="Title">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text="•"></asp:Label><asp:LinkButton ID="lbtnTitle"
                                            Style="text-decoration: none" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("infoId") %>'
                                            CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="区域 " SortExpression="infoId">
                                    <ItemTemplate>
                                        <asp:Label ID="lbProvince" runat="server" Text='<%# Bind("Province") %>'></asp:Label>
                                        <asp:Label ID="lbCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                        <asp:Label ID="lbTown" runat="server" Text='<%# Bind("Town") %>'></asp:Label>
                                        <asp:Label ID="lbStreet" runat="server" Text='<%# Bind("Street") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发布人 " SortExpression="发布人">
                                    <ItemTemplate>
                                        <asp:Label ID="lbUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" " SortExpression="ReleaseDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lbReleaseDate" runat="server" Text='<%# Bind("ReleaseDate","{0:yyyy-M-d}") %>'></asp:Label>
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


                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

