<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Login_Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <link href="http://res.wx.qq.com/open/libs/weui/0.4.0/weui.min.css" rel="stylesheet" />
    <title>用户注册</title>
</head>
<body ontouchstart>
    <form id="form1" runat="server" data-ajax="false">
        <div id="pageMain" data-role="page">
            <div data-role="header">
                <h1>绿宝新用户注册</h1>
            </div>
            <div data-role="main" class="ui-content">
                <div>
                    注册说明：<br />
                    手机号码是平台登录的唯一凭证。<br />
                    请根据自己实际情况谨慎选择行业身份，一旦选定，不可变更。<a href="../ljlb/cjwt.aspx#page2" rel="external">了解行业身份</a>

                </div>
                <div style="padding: 20px 0;">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="错误信息" ShowMessageBox="True" />
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="请输入手机号码" ControlToValidate="tbMobile" Display="Dynamic" ValidationGroup="Reg1"></asp:RequiredFieldValidator>
                    <asp:Label ID="ltlErrorMsg" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                </div>
                <asp:DropDownList ID="ddlShenfen" runat="server" data-native-menu="false" DataTextField="UserTypeName" DataValueField="DataTypeId">
                </asp:DropDownList>
                <asp:TextBox ID="tbMobile" runat="server" placeholder="请输入手机号码" ValidationGroup="Reg1"></asp:TextBox>

                <asp:LinkButton ID="lbtnGetVeriCode" runat="server" OnClick="lbtnGetVeriCode_Click" ValidationGroup="Reg1">获取验证码</asp:LinkButton>&nbsp;&nbsp;<asp:Literal ID="ltlVeriMessage" runat="server" Text="正在获取中，请稍后" Visible="false"></asp:Literal>
                <asp:TextBox ID="tbVeriCode" runat="server" placeholder="输入验证码"></asp:TextBox>
                <div data-role="controlgroup">
                    密码：&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="密码不可为空" ControlToValidate="tbPassword" Display="Dynamic" ValidationGroup="Reg2" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <asp:TextBox ID="tbPassword" runat="server" placeholder="设置登录密码" ClientIDMode="Static" ValidationGroup="Reg2"></asp:TextBox>

                <asp:Button ID="btnReg" runat="server" Text="注册" OnClick="btnReg_Click" ValidationGroup="Reg2" />
            </div>
            <div data-role="footer">
                <div class="page__bd page__bd_spacing">
                    <br>
                    <br>
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:void(0);" class="weui-footer__link"></a>
                        </p>
                        <p class="weui-footer__text">Copyright &copy; 2016-2017 宁波绿宝三益 lvbao111.com</p>
                    </div>
                </div>
            </div>
        </div>

        <div id="pageRegCompleted" data-role="page">

            <div data-role="main" class="ui-content">
                <div class="weui-msg">
                    <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">用户注册成功</h2>
                        <p class="weui-msg__desc">请返回登录界面，用刚才注册的手机号登录</p>
                    </div>
                    <div class="weui-msg__opr-area">
                        <p class="weui-btn-area">
                            <a href="Login.aspx" class="weui-btn weui-btn_primary" rel="external">返回登录</a>
                        </p>
                    </div>
                    <div class="weui-msg__extra-area">
                        <div class="weui-footer">
                            <p class="weui-footer__links">
                                <a href="javascript:void(0);" class="weui-footer__link"></a>
                            </p>
                            <p class="weui-footer__text">Copyright &copy; 2016-2017 lvbao111.com</p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
