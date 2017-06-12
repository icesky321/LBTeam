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
            AccessToken:<asp:Button ID="btnGetAT" runat="server" Text="获取BaseAccessToken" OnClick="btnGetAT_Click" /><asp:TextBox ID="tbAccessToken" runat="server" Text="" Width="400px"></asp:TextBox>
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
