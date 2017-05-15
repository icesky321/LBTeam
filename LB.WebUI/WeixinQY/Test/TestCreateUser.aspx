<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestCreateUser.aspx.cs" Inherits="WeixinQY_Test_TestCreateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            AccessToken:<asp:TextBox ID="tbAccessToken" runat="server"></asp:TextBox>
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
                        <asp:Button ID="btnCreate" runat="server" Text="创建用户" OnClick="btnCreate_Click" /></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
