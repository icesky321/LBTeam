<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rehandle.aspx.cs" Inherits="ErrorPage_NoAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link href="./WeUICSS/example.css" rel="stylesheet" />
    <link href="./WeUICSS/weui.css" rel="stylesheet" />
    <link href="./WeUICSS/weui.mini.css" rel="stylesheet" />
    <script src="http://res.wx.qq.com/open/js/jweixin-1.2.0.js"></script>
    <title></title>
</head>
<body ontouchstart>
    <form id="form1" runat="server">
        <div class="weui-msg">
            <div class="weui-msg__icon-area"><i class="weui-icon-warn weui-icon_msg"></i></div>
            <div class="weui-msg__text-area">
                <h2 class="weui-msg__title">操作失败</h2>
                <p class="weui-msg__desc">此信息曾被处理，无需再次处理</p>
            </div>
            <div class="weui-msg__opr-area">
                <p class="weui-btn-area">

                    <a href="javascript:wx.closeWindow();" class="weui-btn weui-btn_primary" rel="external">关闭窗口</a>
                </p>
            </div>
            <div class="weui-msg__extra-area">
                <div class="weui-footer">
                    <p class="weui-footer__links">
                        绿宝三益
                    </p>
                    <p class="weui-footer__text">Copyright &copy; 2016-2017 lvbao111.com</p>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
