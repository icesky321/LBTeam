<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestBindData.aspx.cs" Inherits="Test_TestBindData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Text="红色" Value="红色"></asp:ListItem>
                <asp:ListItem Text="黄色" Value="黄色"></asp:ListItem>
                <asp:ListItem Text="蓝色" Value="蓝色"></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="label1" runat="server" Text='<%# DropDownList1.SelectedItem.Text %>'></asp:Label>
        </div>
    </form>
</body>
</html>
