﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestGetCode_OAuth2.aspx.cs" Inherits="WeixinQY_TestGetCode_OAuth2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            GetCodeUrl:<asp:Literal ID="Literal1" runat="server"></asp:Literal><br />
            <asp:Button ID="btnGetCode" runat="server" Text="获取Code" OnClick="btnGetCode_Click" /><br />
            Code:<asp:Literal ID="ltlCode" runat="server"></asp:Literal>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        </div>
    </form>
</body>
</html>
