<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NextReg.aspx.cs" Inherits="Login_NextReg" %>

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
    <title>完善资料</title>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
        <div id="pageMain" data-role="page">
            <div data-role="header">
                <h1>绿宝新用户注册</h1>
            </div>
            <div data-role="main" class="ui-content">
                <asp:HiddenField ID="hfTelNum" runat="server" />
                真实姓名：<asp:TextBox ID="tbRealName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="请输入真实姓名" ControlToValidate="tbRealName" Display="Dynamic" ValidationGroup="Reg1" ForeColor="Red"></asp:RequiredFieldValidator>
                <div style="border-bottom: 1px solid #999999; height: 2px; margin: 20px 0 20px 0;"></div>

                车牌号：<asp:TextBox ID="tbNiChen" runat="server"></asp:TextBox>
                <div style="border-bottom: 1px solid #999999; height: 2px; margin: 20px 0 20px 0;"></div>

                开户行信息：<asp:TextBox ID="tbBankInfo" runat="server"></asp:TextBox>
                <br />
                银行账号：<asp:TextBox ID="tbAccount" runat="server"></asp:TextBox><br />

                <div style="border-bottom: 1px solid #999999; height: 2px; margin: 20px 0 20px 0;"></div>

                <table>
                    <tr>
                        <td>身份证信息：<asp:Image ID="Image1" runat="server" Width="200px" Height="100px" /></td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                            <asp:Button ID="btUserNext" runat="server" Text="确定" OnClick="btUserNext_Click" ValidationGroup="Reg1" />

                        </td>
                    </tr>
                </table>
                <div style="height: 60px;"></div>

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

        <div id="pageRegCompleted" data-role="page">

            <div data-role="main" class="ui-content">
                <div class="weui-msg">
                    <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">提交成功，等待平台审核</h2>
                        <p class="weui-msg__desc">审核时间为一个工作日，如有疑问请致电0574-86694505</p>
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
