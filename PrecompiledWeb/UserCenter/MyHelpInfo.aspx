﻿<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="UserCenter_MyHelpInfo, App_Web_kagry0hp" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>我的帮帮忙信息</h1>
                </p>
            </div>

            <hr />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <br />
                    <div style="text-align: left; margin: 20px 0 0 30px;">
                        <asp:GridView ID="gvBuyInfo" runat="server" DataKeyNames="infoId" AutoGenerateColumns="False"
                            Width="100%" SkinID="GridView4"
                            OnPageIndexChanging="gvBuyInfo_PageIndexChanging" OnDataBound="gvBuyInfo_DataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="标题 " SortExpression="Title">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 40%; text-align: left;">
                                            <asp:Label ID="Label1" runat="server" Text="•"></asp:Label><asp:Label ID="lbTitle"
                                                Style="text-decoration: none" runat="server" Text='<%# Bind("Title") %>' ToolTip='<%# Bind("Title") %>'></asp:Label>
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
                    </div>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
