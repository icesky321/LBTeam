﻿<%@ Page Language="C#" MasterPageFile="~/Admin/Manage.master" AutoEventWireup="true"
    CodeFile="RecoverPwd.aspx.cs" Inherits="Admin_RecoverPwd" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset style="width: 327px; float: left;">
                <legend class="mainTitle" style="width: 122px">重置密码</legend>
                <br />
                <table border="0" cellpadding="2" cellspacing="2" class="Main" width="100%">
                    <tr>
                        <td align="center" class="Head" style="height: 19px; width: 680px;"></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 680px">
                            用户名：<asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
                            <br />
                            <hr />
                            原密码：<asp:TextBox ID="tbPwd" runat="server" ValidationGroup="CreateUser"></asp:TextBox>
                            
                            <br />
                            <hr />
                            密码：<asp:TextBox ID="tbPassword" runat="server" TextMode="Password" ValidationGroup="CreateUser"
                                Width="120px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="请输入3位以上的密码！"
                                ControlToValidate="tbPassword" ValidationExpression="^\w{3,30}" ValidationGroup="CreateUser"></asp:RegularExpressionValidator><br />
                            <hr />
                            确认密码：<asp:TextBox ID="tbConfirmPassword" runat="server" TextMode="Password" ValidationGroup="CreateUser"
                                Width="120px"></asp:TextBox><asp:CompareValidator ID="cvConfirmPassword" runat="server" ErrorMessage="两次密码输入不相同！"
                                    ControlToCompare="tbPassword" ControlToValidate="tbConfirmPassword" ValidationGroup="CreateUser"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入检验密码！"
                                ControlToValidate="tbConfirmPassword" ValidationGroup="CreateUser"></asp:RequiredFieldValidator><br />
                            <hr />

                            <asp:Button ID="btSure" runat="server" Text="提交" OnClick="btSure_Click" ValidationGroup="CreateUser" />
                            <asp:Label ID="lbMsg" runat="server" Text="密码更新成功！请牢记该密码~" Font-Bold="True" ForeColor="Red" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
