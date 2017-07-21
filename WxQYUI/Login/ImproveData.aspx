<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImproveData.aspx.cs" Inherits="Login_ImproveData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>完善个人资料</title>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
        <div data-role="page" id="page1">

            <div data-role="main" class="ui-content">
                <div class="weui-msg">
                    <div class="weui-msg__icon-area"></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">请耐心等待客服审核</h2>
                        <p class="weui-msg__desc">如有疑问请拨打电话0574-86694505</p>
                    </div>
                    <div id="show2">
                        <asp:Button ID="btImprove" runat="server" Text="如未完善资料，继续完善个人资料请点击" OnClick="btImprove_Click"  rel="external" />
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
