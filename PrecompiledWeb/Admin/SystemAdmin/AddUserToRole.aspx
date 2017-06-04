<%@ page language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_AddUserToRole, App_Web_41e5i5ng" title="设置角色" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            &nbsp;<br />
            &nbsp; &nbsp;
            <fieldset style="width: 720px">
                <legend class="mainTitle">实现角色管理功能</legend>
                <br />
                <table border="0" cellpadding="2" cellspacing="2" class="Main" width="100%">
                    <tr>
                        <td align="center" class="Head" style="height: 22px">
                            <b>角色管理</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView  ID="gvUsers" runat="server" AutoGenerateColumns="False"
                                Font-Size="Small" GridLines="None" Width="100%" CellPadding="4" ForeColor="#333333"
                                PageSize="100" OnDataBound="gvUsers_DataBound" OnPageIndexChanging="gvUsers_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="用户名">
                                        <ItemTemplate>
                                            <asp:Label ID="lbUserName" runat="server" ForeColor="black" Text='<%#DataBinder.Eval(Container.DataItem, "UserName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Height="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img alt="add" src="../images/icon_edit.gif" /><asp:LinkButton
                                                ID="lbAddRole" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserName")%>'
                                                CommandName="AddRole" ForeColor="blue" OnCommand="LinkButtonClick" Text="添加角色"></asp:LinkButton>
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
<%--                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />--%>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="plListRole" runat="server" Visible="false">
                                <tr>
                                </tr>
                                <td align="center"></td>
                                <hr />
                                <asp:GridView SkinID="GridView2" ID="gvRoles" runat="server" AutoGenerateColumns="False"
                                    Font-Size="Small" GridLines="None" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="角色名">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItem.ToString() %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Height="25px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否分配">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbAddRoleToUser" runat="server" AutoPostBack="true" ForeColor="blue"
                                                    OnCheckedChanged="AddRoleToUserCheckBox_Click" ToolTip='<%#Container.DataItem.ToString() %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="lbMessage" runat="server" ForeColor="red"></asp:Label>
                            <a href="ListEmployee.aspx">返回</a>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
