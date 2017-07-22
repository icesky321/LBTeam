<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Success.aspx.cs" Inherits="ErrorPage_NoAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link href="./WeUICSS/example.css" rel="stylesheet" />
    <link href="./WeUICSS/weui.css" rel="stylesheet" />
    <link href="./WeUICSS/weui.mini.css" rel="stylesheet" />
    <title></title>
</head>
<body ontouchstart>
    <form id="form1" runat="server">
        <div class="weui-msg">
            <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
            <div class="weui-msg__text-area">
                <h2 class="weui-msg__title">操作成功</h2>
                <p class="weui-msg__desc">
                    绿色回收，益国、益民、益环境<br />
                    <asp:Label ID="lbRemark" runat="server" Text="" ForeColor="Red"></asp:Label>
                </p>
            </div>
            <div class="weui-msg__opr-area">
                <p class="weui-btn-area">
                    <a href="javascript:close_wechat();" class="weui-btn weui-btn_primary">关闭窗口</a>
                </p>
            </div>
            <div class="weui-msg__extra-area">
                <div class="weui-footer">
                    <p class="weui-footer__links">
                        绿宝三益
                    </p>
                    <p class="weui-footer__text">Copyright &copy; 2008-2016 lvbao111.com</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
