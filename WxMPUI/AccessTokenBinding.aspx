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
            padding: 0px 0 0px 0;
        }
    </style>
    <script type="text/javascript">
        function close_wechat() {
            WeixinJSBridge.call("closeWindow");
        }
    </script>
</head>
<body style="background-color: #07B2E6;">
    <form id="form1" runat="server" data-ajax="false">
        <div style="max-width: 960px; height: auto; margin: 0 auto;">
            <asp:HiddenField ID="hfcode" runat="server" Value="" />
            <asp:HiddenField ID="hfAppId" runat="server" />
            <asp:HiddenField ID="hfAppSecret" runat="server" />
            <asp:HiddenField ID="hfAccessToken" runat="server" />
            <asp:HiddenField ID="hfOpenId" runat="server" />
            <div id="Logo" style="text-align: center; margin: 30px 0 0 0;">
                <asp:Image ID="imgLog" runat="server" ImageUrl="~/Images/LvbaoCircleLogo.png" Width="150px"
                    BorderWidth="0" />
            </div>
            <div style="text-align: center; margin: 2em 0 0 0;">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewTokenBind" runat="server">
                        免注册，授权您的微信帐户直接访问绿宝网站。<br />
                        <asp:Label ID="lbLoginError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                        <div style="margin: 0 auto; width: 290px;">
                            <table style="display: block; margin: 0 auto;" class="loginTable">
                                <tr>
                                    <td>手机：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbMobile" runat="server" Width="220px" placeholder="请输入手机号码"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:LinkButton ID="lbtnGetVeriCode" runat="server" OnClick="lbtnGetVeriCode_Click" ValidationGroup="Reg1">获取验证码</asp:LinkButton>
                                        &nbsp;&nbsp;<asp:Literal ID="ltlVeriMessage" runat="server" Text="正在获取中，请稍后" Visible="false"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="tbVeriCode" runat="server" placeholder="输入验证码"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="验证码未输入" ControlToValidate="tbVeriCode"
                                            Display="Dynamic"></asp:RequiredFieldValidator>
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
                        <div style="margin: 0 auto; width: 290px; text-align: center;">
                            绑定成功<br />
                            <asp:Label ID="lbLocalUser" runat="server" ForeColor="White"></asp:Label><br />
                            <br />
                            <%--                            <asp:Image ID="imgUserHead" runat="server" BorderWidth="0" Width="100px" /><br />
                            <asp:Label ID="lbNickName" runat="server" Text="" ForeColor="White"></asp:Label><br />
                            <br />--%>
                            <asp:Button ID="btnCloseWindow2" runat="server" Text="关闭窗口" OnClientClick="close_wechat();"
                                Width="280px" />
                            <asp:Button ID="btnQueryQuotation" runat="server" Text="查看回收报价" OnClick="btnQueryQuotation_Click" Width="280px" />
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </form>
</body>
</html>
