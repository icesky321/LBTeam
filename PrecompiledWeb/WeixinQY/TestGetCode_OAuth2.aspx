<%@ page language="C#" autoeventwireup="true" inherits="WeixinQY_TestGetCode_OAuth2, App_Web_lhduw22k" theme="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Code:<asp:Literal ID="Literal1" runat="server"></asp:Literal><br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    </div>
    </form>
</body>
</html>
