<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestShowUserInfo.aspx.cs" Inherits="WeixinQY_TestShowUserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Code:<asp:Literal ID="ltlCode" runat="server"></asp:Literal><br />
    <asp:ListBox ID="ListBox1" runat="server" Height="285px" Width="258px"></asp:ListBox>
    </div>
    </form>
</body>
</html>
