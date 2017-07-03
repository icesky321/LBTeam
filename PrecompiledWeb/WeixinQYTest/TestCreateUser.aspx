<%@ page language="C#" autoeventwireup="true" inherits="WeixinQYTest_TestCreateUser, App_Web_1qgbem5b" theme="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="">
                <tr>
                    <td>所在部门ID：</td>
                    <td>
                        <asp:TextBox ID="tbDeps" runat="server" Text="2"></asp:TextBox>只能输入一个部门</td>
                    <td></td>
                </tr>
                <tr>
                    <td>姓名：</td>
                    <td>
                        <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td>账号（UserId）：</td>
                    <td>
                        <asp:TextBox ID="tbUserId" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td>手机：</td>
                    <td>
                        <asp:TextBox ID="tbMobile" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnCreate" runat="server" Text="使用LBWS接口创建用户" OnClick="btnCreate_Click" />

                    </td>
                    <td>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
