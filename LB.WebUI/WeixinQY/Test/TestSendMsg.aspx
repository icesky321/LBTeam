<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestSendMsg.aspx.cs" Inherits="WeixinQY_Test_TestSendMsg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnSendMsg" runat="server" Text="发送消息" OnClick="btnSendMsg_Click" />
        </div>
    </form>
</body>
</html>
