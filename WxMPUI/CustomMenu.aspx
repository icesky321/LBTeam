<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomMenu.aspx.cs" Inherits="CustomMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnCreateMenu" runat="server" Text="创建菜单" 
            onclick="btnCreateMenu_Click" />
        <asp:Label ID="lbMsg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
