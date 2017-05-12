<%@ page language="C#" autoeventwireup="true" inherits="Login, App_Web_micuxpu2" theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>登录</title>
    <link rel="stylesheet" href="css/amazeui.css" />
    <link rel="stylesheet" href="css/other.min.css" />
</head>
<body class="login-container">

    <form runat="server" action="" class="am-form" data-am-validator>
        <div class="login-box">

            <img src="img/logo1.png" alt="" />
            <br /> <br /> <br />
            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" OnLoggingIn="Login1_LoggingIn"
                FailureText="登录失败！请重新登录" Width="310px">
                <LayoutTemplate>
                    <div class="am-form-group">
                        <asp:TextBox ID="UserName" runat="server" CssClass="" placeholder="请输入注册手机号" value="用户名"
                            onfocus="this.value=''" onblur="if(this.value=='')this.value='用户名'"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="am-form-group">
                        <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="请输入密码"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                            ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login1">密码不能为空</asp:RequiredFieldValidator>
                    </div>
                    <%--<div style="width: 900px; height: auto; float: left; display: inline; margin-bottom: 20px;"></div>--%>
                    <div class="am-form-group">
                        <asp:TextBox ID="tbVerify" runat="server" ToolTip="验证码全是数字" placeholder="请输入验证码(全是数字哦)" AutoCompleteType="Disabled"
                            Width="300px"></asp:TextBox>
                        <img id="imgVerify" src="VerifyCode/VerifyCode.aspx" alt="看不清？点击更换" onclick="this.src=this.src+'?'"
                            style="width: 100px; height: 40px" />
                        <asp:RequiredFieldValidator ID="VerifyRequired" runat="server" ControlToValidate="tbVerify"
                            ErrorMessage="必须填写“验证码”。" ToolTip="必须填写“验证码”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                    </div>
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    <div class="am-form-group" style=" text-align:center;">
                        <asp:Button ID="Button1" runat="server" CssClass="am-btn am-btn-secondary" CommandName="Login" Text="登录" ValidationGroup="Login1"
                            OnClick="LoginButton_Click" EnableTheming="True" /><asp:LinkButton ID="lbtnForget" runat="server" OnClick="lbtnForget_Click">忘记密码?</asp:LinkButton>
                    </div>
                </LayoutTemplate>
            </asp:Login>
        </div>
    </form>

</body>
</html>
