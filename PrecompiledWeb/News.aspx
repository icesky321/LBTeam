<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="News, App_Web_3x0vyrah" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <link rel="stylesheet" href="css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--===========layout-container================-->
    <div class="layout-container">
        <div class="section">
            <div class="container">

                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <div class="section--header">
                            <p class="section--description">
                                <h1>资讯信息</h1>
                            </p>
                        </div>
                        <hr />
                        <asp:GridView ID="gvNew" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                            Width="100%" SkinID="GridView4"
                            OnPageIndexChanging="gvNew_PageIndexChanging" OnRowCommand="gvNew_RowCommand" OnDataBound="gvNew_DataBound">
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
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <div class="section--header">
                            <p class="section--description">
                                <h1>区域价格资讯</h1>
                            </p>
                        </div>
                        <hr />
                        <asp:GridView ID="gvPrice" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                            Width="100%" SkinID="GridView4"
                            OnPageIndexChanging="gvNew_PageIndexChanging" OnRowCommand="gvNew_RowCommand" OnDataBound="gvPrice_DataBound">
                            <Columns>
                                <asp:TemplateField HeaderText=" " SortExpression="Title">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text="•"></asp:Label>
                                        <asp:LinkButton ID="lbtnTitle1"
                                            Style="text-decoration: none" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("id") %>'
                                            CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" " SortExpression="Content">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnTitle2"
                                            Style="text-decoration: none" runat="server" Text='<%# Bind("Content") %>' CommandArgument='<%#Eval("id") %>'
                                            CommandName="Detail" ToolTip='<%# Bind("Content") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" " SortExpression="UserName">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnTitle3"
                                            Style="text-decoration: none" runat="server" Text='<%# Bind("UserName") %>' CommandArgument='<%#Eval("id") %>'
                                            CommandName="Detail" ToolTip='<%# Bind("UserName") %>'></asp:LinkButton>
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
                                        <td style="text-align: right">
                                            <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
                                            <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
                                            <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                                            <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                                            <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                                            到第<asp:DropDownList ID="PageDropDownList1"
                                                AutoPostBack="true"
                                                OnSelectedIndexChanged="PageDropDownList1_SelectedIndexChanged"
                                                runat="server" />
                                            页  
                                        </td>
                                    </tr>
                                </table>
                            </PagerTemplate>
                        </asp:GridView>
                    </asp:View>
                </asp:MultiView>


            </div>
            </div>
        </div>
    </div>


</asp:Content>
