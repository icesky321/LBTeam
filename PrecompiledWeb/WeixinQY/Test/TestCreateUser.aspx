<%@ page language="C#" autoeventwireup="true" inherits="WeixinQY_Test_TestCreateUser, App_Web_sgdfgv4q" theme="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            AccessToken:<asp:TextBox ID="tbAccessToken" runat="server" Text="kRZgNakNomddBrQLYWQgxLROWH3s9z3i8nBLGfPJk376Jy9PKwIyJtNqFj02BNBc"></asp:TextBox>
            <table style="">
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
                        <asp:Button ID="btnCreate" runat="server" Text="使用Senparc接口创建用户" OnClick="btnCreate_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnCreate2" runat="server" Text="使用LB接口创建用户" OnClick="btnCreate2_Click" />

                    </td>
                    <td>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
