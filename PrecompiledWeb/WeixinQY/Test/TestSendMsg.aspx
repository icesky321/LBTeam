<%@ page language="C#" autoeventwireup="true" inherits="WeixinQY_Test_TestSendMsg, App_Web_vngadehh" theme="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnSendMsg" runat="server" Text="使用Senparc接口发送消息" OnClick="btnSendMsg_Click" /><br />
            <br />
            <asp:Button ID="btnSendMsgByLB" runat="server" Text="使用LB接口发送消息" OnClick="btnSendMsgByLB_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnSendArticleByLB" runat="server" Text="使用LB接口发送文章消息" OnClick="btnSendArticleByLB_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnSendFileByLB" runat="server" Text="使用LB接口发送图文素材" OnClick="btnSendFileByLB_Click" />
        </div>
    </form>
</body>
</html>
