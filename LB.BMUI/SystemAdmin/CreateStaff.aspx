<%@ Page Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true"
    CodeFile="CreateStaff.aspx.cs" Inherits="SystemAdmin_CreateStaff" Title="创建新用户" %>

<%@ Register Src="~/UserControls/DDLAddress.ascx" TagName="DDLAddress" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <h4>创建用户</h4>
            <div>默认密码：12345678</div>
            <hr style="border-right: khaki 1px solid; border-top: khaki 1px solid; border-left: khaki 1px solid; border-bottom: khaki 1px solid" />
            <table>
                <tr>
                    <td>用户名：
                    </td>
                    <td>
                        <asp:TextBox ID="tbUserName" runat="server" ValidationGroup="CreateUser" Width="120px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="请输入用户名！"
                            ControlToValidate="tbUserName" ValidationGroup="CreateUser"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>真实姓名：
                    </td>
                    <td>
                        <asp:TextBox ID="tbRealName" runat="server" ValidationGroup="CreateUser" Width="120px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入真实姓名！"
                            ControlToValidate="tbRealName" ValidationGroup="CreateUser"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>工号：
                    </td>
                    <td>
                        <asp:TextBox ID="tbJobNumber" runat="server" ValidationGroup="CreateUser" Width="120px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入工号！"
                            ControlToValidate="tbJobNumber" ValidationGroup="CreateUser"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>手机号码</td>

                    <td>
                        <asp:TextBox ID="tbMobileNum" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入手机号码！"
                            ControlToValidate="tbMobileNum" ValidationGroup="CreateUser"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnCreateUser" runat="server" Text="创建用户" ValidationGroup="CreateUser"
                OnClick="btnCreateUser_Click" />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
