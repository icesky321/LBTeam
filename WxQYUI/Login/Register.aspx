<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Login_Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>用户注册</title>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
        <div id="pageMain" data-role="page">
            <div data-role="header">
                <h1>绿宝新用户注册</h1>
            </div>
            <div data-role="main" class="ui-content">
                <div>
                    注册说明：<br />
                    手机号码是平台登录的唯一凭证。<br />
                    请根据自己实际情况谨慎选择行业身份，一旦选定，不可变更。<a href="../ljlb/cjwt.aspx#page2" rel="external">了解行业身份</a>

                </div>
                <div style="padding: 20px 0;">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="错误信息" ShowMessageBox="True" />
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="请输入手机号码" ControlToValidate="tbMobile" Display="Dynamic" ValidationGroup="Reg1"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入密码" ControlToValidate="tbPassword" Display="Dynamic" ValidationGroup="Reg2"></asp:RequiredFieldValidator>
                </div>
                <asp:DropDownList ID="ddlShenfen" runat="server" data-native-menu="false">
                    <asp:ListItem Text="选择行业身份" Value="">                    </asp:ListItem>
                    <asp:ListItem Text="供废单位（个人）" Value="">

                    </asp:ListItem>
                    <asp:ListItem Text="回收公司"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbMobile" runat="server" placeholder="请输入手机号码" ValidationGroup="Reg1"></asp:TextBox>

                <asp:LinkButton ID="lbtnGetVeriCode" runat="server" OnClick="lbtnGetVeriCode_Click" ValidationGroup="Reg1">获取验证码</asp:LinkButton>&nbsp;&nbsp;<asp:Literal ID="ltlVeriMessage" runat="server" Text="正在获取中，请稍后" Visible="false"></asp:Literal>
                <asp:TextBox ID="tbVeriCode" runat="server" placeholder="输入验证码"></asp:TextBox>
                <label for="tbPassword">密码：</label>
                <asp:TextBox ID="tbPassword" runat="server" placeholder="设置登录密码" ClientIDMode="Static" ValidationGroup="Reg2"></asp:TextBox>

                <asp:Button ID="btnReg" runat="server" Text="注册" OnClick="btnReg_Click" ValidationGroup="Reg2" />
            </div>
            <div data-role="footer">
                <h2>footer</h2>
            </div>
        </div>
    </form>
</body>
</html>
