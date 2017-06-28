<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" charset="utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0">
    <title>绿宝登录</title>
    <link rel='stylesheet prefetch' href='css/bootstrap.min.css' />

    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    <div class="wrapper">
        <form id="form1" runat="server" class="form-signin">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div style="text-align: center; padding: 15px 0 15px 0;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Login/LvbaoCircleLogo.png" Width="150px" />
            </div>
            <h1 class="form-signin-heading" style="font-size: 18px;">绿宝登录</h1>
            <asp:TextBox ID="tbUserName" runat="server" CssClass="form-control" name="username" required="" autofocus="" placeholder="认证手机号码"></asp:TextBox>
            <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password" name="password" required="" placeholder="请输入密码"></asp:TextBox>
            <%--<label class="checkbox">
                <asp:CheckBox ID="cbRemember" runat="server" Text="记住密码" />
            </label>--%>
            <div style="margin: 20px 0 20px 0; color: red;">
                <asp:Literal ID="ltlErrorMsg" runat="server" Text="用户名或密码输入有误！" Visible="false"></asp:Literal>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnLogin_Click" />
            <div style="padding: 30px 0px 0 0px;">
                <div style="float: left;">忘记密码</div>
                <div style="float: right; text-align: right;">我没有账户，<a href="Register.aspx">注册账户</a></div>
            </div>
        </form>
    </div>
</body>
</html>
