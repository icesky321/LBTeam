<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPassword.aspx.cs" Inherits="UserCenter_EditPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>修改密码</h2>
            </div>
            <div data-role="main" class="ui-content">
                <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/" EnableViewState="false" RenderOuterTable="false"
                    SuccessPageUrl="ChangePasswordSuccess.aspx" OnChangedPassword="ChangeUserPassword_ChangedPassword">
                    <ChangePasswordTemplate>
                        <span class="failureNotification">
                            <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                        </span>
                        <div class="accountInfo">

                            <p>
                                旧密码:<asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                    ErrorMessage="必须填写“密码”。"
                                    ValidationGroup="CUP" Display="Dynamic" ForeColor="Red">（旧密码不可为空）</asp:RequiredFieldValidator>
                                <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>

                            </p>
                            <p>
                                新密码:<asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                    ErrorMessage="(必须填写“新密码”。)"
                                    ValidationGroup="CUP" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>

                            </p>
                            <p>
                                确认新密码:<asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                    Display="Dynamic" ErrorMessage="(必须填写“确认新密码”。)"
                                    ValidationGroup="CUP" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    Display="Dynamic" ErrorMessage="(“确认新密码”与“新密码”项必须匹配。)" ForeColor="Red"
                                    ValidationGroup="CUP"></asp:CompareValidator>
                                <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>

                            </p>

                            <p style="text-align: center;">

                                <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="更改密码" data-icon="ui-icon-lock"
                                    ValidationGroup="CUP" data-inline="true" />
                                <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="  取消  " data-inline="true" />
                            </p>
                        </div>
                    </ChangePasswordTemplate>
                </asp:ChangePassword>
            </div>

        </div>
    </form>
</body>
</html>
