<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RetrievalPwd.aspx.cs" Inherits="Login_RetrievalPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <title></title>
</head>
<body ontouchstart>
    <form id="form1" runat="server" data-ajax="false">
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>取回密码</h2>
            </div>
            <div data-role="main" class="ui-content">
                请输入您的手机号码：<br />
                <asp:TextBox ID="tbMobileNum" runat="server"></asp:TextBox>
                <asp:Button ID="btnRetrievalPwd" runat="server" Text="取回密码" OnClick="btnRetrievalPwd_Click" data-role="button" data-ajax="false" />
            </div>

        </div>
    </form>
</body>
</html>
