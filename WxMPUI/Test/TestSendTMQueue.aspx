<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestSendTMQueue.aspx.cs" Inherits="Test_TestSendTMQueue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnPushTM1" runat="server" Text="Push To Cobe" OnClick="btnPushTM1_Click" />
        <asp:Button ID="btnPushTM2" runat="server" Text="Push To Caojun" OnClick="btnPushTM2_Click" />
        <asp:Button ID="btnPushTM3" runat="server" Text="Pudh To Lixin" OnClick="btnPushTM3_Click" />
        <br />
        <br />
        <asp:Button ID="btnSendStart" runat="server" Text="开始发送"  OnClick="btnSendStart_Click"/>
    </div>
    </form>
</body>
</html>
