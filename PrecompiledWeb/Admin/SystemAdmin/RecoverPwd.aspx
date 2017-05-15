<%@ page language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_RecoverPwd, App_Web_kysj3zbc" title="Untitled Page" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset style="width: 327px; float: left;">
                <legend class="mainTitle" style="width: 122px">取回密码</legend>
                <br />
                <table border="0" cellpadding="2" cellspacing="2" class="Main" width="100%">
                    <tr>
                        <td align="center" class="Head" style="height: 19px; width: 680px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 680px">
                            <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" OnSendingMail="PasswordRecovery1_SendingMail">
                            </asp:PasswordRecovery>
                            &nbsp; &nbsp;<asp:Label ID="lbsubject" runat="server" Height="19px" Width="381px"></asp:Label><br />
                            <asp:Label ID="lbbody" runat="server" Height="52px" Width="504px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
