<%@ page language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_CreateRole, App_Web_3e424shh" title="角色管理" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <fieldset style="width: 800px;">
                <legend class="mainTitle">实现角色管理功能</legend>
                <br />
                <table border="0" cellpadding="2" cellspacing="2" class="Main" width="100%">
                    <tr>
                        <td align="center" class="Head" colspan="2">
                            <b>角色管理</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            添加角色：<asp:TextBox ID="txtRole" runat="server" Width="120px"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text=" 确定 " />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="vertical-align: top; width:500px">
                            <asp:GridView SkinID="GridView2" ID="gvRoles" runat="server" AutoGenerateColumns="False"
                                Font-Size="Small" GridLines="None" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="角色名">
                                        <ItemTemplate>
                                            <asp:Label ID="lbRoleName" runat="server" ForeColor="black" Text="<%# Container.DataItem.ToString() %>"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Height="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img alt="edit" src="../images/icon_edit.gif" /><asp:LinkButton
                                                ID="lbEdit" runat="server" CommandArgument='<%# Container.DataItem.ToString() %>'
                                                CommandName="EditRole" ForeColor="blue" OnCommand="LinkButtonClick" Text="编辑"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img alt="del" src="../images/icon_delete.gif" /><asp:LinkButton
                                                ID="lbDel" runat="server" CommandArgument='<%# Container.DataItem.ToString() %>'
                                                CommandName="DeleteRole" ForeColor="blue" OnClientClick="return confirm('确定删除该角色吗？');"
                                                OnCommand="LinkButtonClick" Text="删除"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width:400px;">
                            Admin:系统核心管理员，掌管全系统所有权限；<br />
                            CEMetalFactory:信用审核通过后的冶炼厂；<br />
                            CERecyclingCop:信用审核通过后的回收公司；<br />
                            CESupplier:信用审核通过后的产废单位或个人；<br />
                            CEUser:信用审核通过后的街道回收员；<br />
                            general:注册后未审核的普通用户；<br />
                            InfoManage:资讯管理审核员；<br />
                            UserManage:用户管理审核员；<br />
                        </td>
                    </tr>
                    <asp:Panel ID="plUsers" runat="server" Visible="false">
                        <hr />
                        <asp:GridView SkinID="GridView2" ID="gvUsers" runat="server" AutoGenerateColumns="False"
                            Font-Size="Small" GridLines="None" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="用户名">
                                    <ItemTemplate>
                                        <asp:Label ID="lbUserName" runat="server" ForeColor='black' Text='<%#DataBinder.Eval(Container.DataItem,"UserName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Height="25px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="是否属于角色">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbUserInRole" runat="server" AutoPostBack="true" ForeColor="blue"
                                            OnCheckedChanged="CheckBox_Click" ToolTip='<%#DataBinder.Eval(Container.DataItem,"UserName") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle Height="25px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lbMessage" runat="server" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Head" style="height: 23px">
                            <a href="AddUserToRole.aspx">为用户设置角色</a>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
