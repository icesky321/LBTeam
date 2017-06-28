<%@ Page Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true"
    CodeFile="EditUser.aspx.cs" Inherits="Admin_EditUser" Title="成员管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            &nbsp;
            <br />
            &nbsp;&nbsp;
            <fieldset style="width: 300px">
                <legend class="mainTitle">实现成员管理功能</legend>
                <br />
                <table border="0" cellpadding="2" cellspacing="2" class="Main" width="100%">
                    <tr>
                        <td align="center" class="Head" colspan="2">
                            <b>用户编辑</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 30%; height: 26px">
                            用户名：
                        </td>
                        <td style="width: 70%; height: 26px">
                            <asp:TextBox ID="txtUsername" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            电子邮件：
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 26px">
                            备注：
                        </td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lbMessage" runat="server" ForeColor="red"></asp:Label><br />
                            <asp:Button ID="btSubmit" runat="server" OnClick="btSubmit_Click" Text=" 保存 " />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Head" colspan="2" style="height: 23px">
                            <a class="Head" href="ListUsers.aspx">返回用户列表</a>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
