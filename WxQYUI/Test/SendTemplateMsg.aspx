<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendTemplateMsg.aspx.cs"
    Inherits="SendTemplateMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Keyword1:<asp:TextBox ID="tbKeyword1" runat="server"></asp:TextBox>
        <asp:Button ID="btnSend" runat="server" Text="发送模板信息" OnClick="btnSend_Click" />
    </div>
    </form>
</body>
</html>
