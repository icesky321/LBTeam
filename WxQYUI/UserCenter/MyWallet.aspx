<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyWallet.aspx.cs" Inherits="UserCenter_MyWallet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>绿宝三益--我的钱包</title>
</head>


<body>
    <form id="form1" runat="server" data-ajax="false">
        <div id="page1" data-role="page" runat="server">
            <div class="weui-cells__title">
                <h2>我的钱包</h2>
            </div>
            <hr />
            <br />
            <h2>余额：
                    <asp:Label ID="lbTotalMoney" runat="server" Text=""></asp:Label>元
            </h2>
            <h2>在途资产：
                    <asp:Label ID="lbWaitMoney" runat="server" Text=""></asp:Label>元
            </h2>

            <asp:Button ID="btSure" runat="server" Text="提现" OnClick="btSure_Click" />

        </div>
        <div id="pageRegCompleted" data-role="page" runat="server">

            <div data-role="main" class="ui-content">
                <div class="weui-msg">
                    <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">操作成功</h2>
                        <p class="weui-msg__desc">因为银行系统到账时间因素，您的资金将在您发起申请后的48小时内到账，请及时关注您的银行账户！如有不便之处敬请谅解！</p>
                    </div>
                    <div id="show2">
                        <input type="button" value="关闭本窗口" onclick="WeixinJSBridge.call('closeWindow');" />
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
        <div id="errorPage" data-role="page" runat="server">

            <div data-role="main" class="ui-content">
                <div class="weui-msg">
                    <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">提现失败</h2>
                        <p class="weui-msg__desc">对不起，您的账户没有可用余额</p>
                    </div>
                    <div id="show">
                        <input type="button" value="关闭本窗口" onclick="WeixinJSBridge.call('closeWindow');" />
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
