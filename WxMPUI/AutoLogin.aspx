<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AutoLogin.aspx.cs" Inherits="AutoLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfAppId" runat="server" />
            <asp:HiddenField ID="hfAppSecret" runat="server" />
        </div>
    </form>
</body>
</html>
