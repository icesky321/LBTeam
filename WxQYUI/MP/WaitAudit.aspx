<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WaitAudit.aspx.cs" Inherits="MP_WaitAudit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>操作成功</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="weui-msg">
            <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
            <div class="weui-msg__text-area">
                <h2 class="weui-msg__title">操作成功</h2>
                <p class="weui-msg__desc">您的申请已提交成功，我们将尽快进行审核工作，请您耐心等待</p>
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
    </form>
</body>
</html>
