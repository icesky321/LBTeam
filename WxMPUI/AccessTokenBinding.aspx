<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccessTokenBinding.aspx.cs"
    Inherits="AccessTokenBinding" %>

<!DOCTYPE html">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=2.0,user-scalable=no;" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="format-detection" content="telephone=no" />
    <style type="text/css">
        .loginTable td {
            color: White;
            padding: 10px 0 10px 0;
        }
    </style>
    <script type="text/javascript">
        function close_wechat() {
            WeixinJSBridge.call("closeWindow");
        }
    </script>
</head>
<body style="background-color: #07B2E6;">
    <form id="form1" runat="server">
        <div style="max-width: 960px; height: auto; margin: 0 auto;">
            <asp:HiddenField ID="hfcode" runat="server" Value="" />
            <asp:HiddenField ID="hfAppId" runat="server" />
            <asp:HiddenField ID="hfAppSecret" runat="server" />
            <asp:HiddenField ID="hfAccessToken" runat="server" />
            <asp:HiddenField ID="hfOpenId" runat="server" />
            <div id="Logo" style="text-align: center; margin: 50px 0 0 0;">
                <asp:Image ID="imgLog" runat="server" ImageUrl="~/App_Themes/Default/Images/WeinxinZpitLogo.png"
                    BorderWidth="0" />
            </div>
            <div style="text-align: center; margin: 2em 0 0 0; color: White;">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewTokenBind" runat="server">
                        授权您的微信帐户允许访问绿宝网站。<br />
                        <asp:Label ID="lbLoginError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                        <div style="margin: 0 auto; width: 290px;">
                            <table style="display: block; margin: 0 auto;" class="loginTable">
                                <tr>
                                    <td>手机：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbJobNumber" runat="server" CssClass="loginTextBox" Width="220px" placeholder="请输入手机号码"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnBinding" runat="server" Text="授权绑定" CssClass="bigButton" Width="280px"
                                            OnClick="btnBinding_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="bigButton" Width="280px"
                                            OnClick="btnCancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="viewErrorMsg" runat="server">
                        <asp:Label ID="lbErrorMsg" runat="server"></asp:Label>
                        <asp:Button ID="btnCloseWindow1" runat="server" Text="关闭窗口" OnClientClick="close_wechat();"
                            Width="280px" CssClass="bigButton" />
                    </asp:View>
                    <asp:View ID="viewLocalUserInfo" runat="server">
                        <br />
                        <div style="margin: 0 auto; width: 290px; text-align: center; color: White;">
                            <asp:Label ID="lbLocalUser" runat="server" ForeColor="White"></asp:Label><br />
                            <br />
                            <asp:Image ID="imgUserHead" runat="server" BorderWidth="0" Width="100px" /><br />
                            <asp:Label ID="lbNickName" runat="server" Text="" ForeColor="White"></asp:Label><br />
                            <br />
                            <asp:Button ID="btnCloseWindow2" runat="server" Text="关闭窗口" OnClientClick="close_wechat();"
                                Width="280px" CssClass="bigButton" />
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </form>
</body>
</html>
