<%@ page language="C#" autoeventwireup="true" inherits="WeixinQY_TestGetAccessToken, App_Web_dcvcmbjc" theme="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            从绿宝Weixin接口直接获取AccessToken<br />
            <asp:Button ID="btnGetAT_ByLB" runat="server" Text="获取AccessToken" OnClick="btnGetAT_ByLB_Click" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <div style="margin-top: 50px;">
            从绿宝AccessToken中央服务器获取<br />
            <asp:Button ID="btnGetAT_ATC" runat="server" Text="获取AccessToken" OnClick="btnGetAT_ATC_Click" /><br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
