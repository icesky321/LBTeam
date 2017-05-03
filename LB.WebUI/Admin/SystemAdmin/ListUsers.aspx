<%@ Page Language="C#" MasterPageFile="~/Admin/Manage.master" AutoEventWireup="true"
    CodeFile="ListUsers.aspx.cs" Inherits="Admin_ListUsers" Title="成员和角色管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            &nbsp;&nbsp;
            <br />
            &nbsp; &nbsp;
            <fieldset style="width: 720px">
                <legend class="mainTitle">实现成员和角色管理功能</legend>
                <br />
                <table border="0" cellpadding="2" cellspacing="2" class="Main" width="500px">
                    <tr>
                        <td align="center" class="Head" style="height: 19px; width: 137px;">
                            <b>用户管理</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 500px">
                            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" Font-Size="Small"
                                OnPageIndexChanging="gvUsers_PageIndexChanging" AllowPaging="True" PageSize="15">
                                <Columns>
                                    <asp:TemplateField HeaderText="用户名">
                                        <ItemTemplate>
                                            <asp:Label ID="lbUserName" runat="server" ForeColor='black' Text='<%#DataBinder.Eval(Container.DataItem, "UserName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Height="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="启用">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbActive" runat="server" AutoPostBack="true" Checked='<%# DataBinder.Eval(Container.DataItem, "IsApproved")%>'
                                                ForeColor="blue" OnCheckedChanged="CheckBox_Click" ToolTip='<%#DataBinder.Eval(Container.DataItem, "UserName")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img alt="add" src="../images/icon_edit.gif" /><asp:LinkButton
                                                ID="lbAddRole" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserName")%>'
                                                CommandName="AddRole" ForeColor="blue" OnCommand="LinkButtonClick" Text="添加角色"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 137px">
                            <asp:Label ID="lbMessage" runat="server" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Head" style="height: 23px; width: 137px;">
                            <!-- <a href="CreateRole.aspx">为角色设置用户</a>-->
                            <asp:Panel ID="plListRole" runat="server" Visible="false">
                                <hr />
                                <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False" Font-Size="Small">
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
                            <asp:LinkButton ID="lbtExit" runat="server" OnClick="lbtExit_Click" Visible="False">退出系统</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
