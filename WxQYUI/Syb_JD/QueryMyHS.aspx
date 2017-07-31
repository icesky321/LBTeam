<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QueryMyHS.aspx.cs" Inherits="Syb_JD_QueryMyHS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link href="./WeUICSS/example.css" rel="stylesheet" />
    <link href="./WeUICSS/weui.css" rel="stylesheet" />
    <link href="./WeUICSS/weui.mini.css" rel="stylesheet" />
    <title>查询回收公司</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="weui-toptips weui-toptips_warn js_tooltips">错误提示</div>

        <div class="container" id="container"></div>

        <script type="text/html" id="tpl_home">
            <div class="page">
                <div style="padding: 20px;">
                    <h3>本市回收公司 （<asp:Literal ID="ltlCount" runat="server" Text="0"></asp:Literal>）
                    </h3>
                    <p class="page__desc">
                        <asp:HiddenField ID="hfCityRegionCode" runat="server" />
                        <asp:Literal ID="ltlCityWholeName" runat="server"></asp:Literal>

                    </p>
                </div>
                <div class="page__bd page__bd_spacing">
                    <asp:HiddenField ID="hfUserMobile" runat="server" />
                    <asp:HiddenField ID="hfJD_UserId" runat="server" />
                    <ul>
                        <asp:ListView ID="lvUserInfo" runat="server" OnItemDataBound="lvUserInfo_ItemDataBound">
                            <ItemTemplate>
                                <li>
                                    <div class="weui-flex js_category">
                                        <p class="weui-flex__item">
                                            <asp:HiddenField ID="hfUserId" runat="server" Value='<%# Eval("UserId") %>'></asp:HiddenField>
                                            <b>
                                                <asp:Literal ID="ltlHS_CopName" runat="server" Text='<%# GetCopName(Eval("UserId").ToString()) %>'></asp:Literal>
                                            </b>
                                            <br />
                                            <span style="color: #DCDCDC;"></span>
                                        </p>

                                        <span style="font-size: 1em; font-family: Arial, Helvetica, sans-serif;">
                                            <asp:Literal ID="ltlMobile" runat="server" Text='<%# Eval("MobilePhoneNum") %>'></asp:Literal></span>
                                    </div>
                                    <div class="page__category js_categoryInner">
                                        <div class="weui-cells page__category-content">
                                            <a class="weui-cell">
                                                <div class="weui-cell__bd">
                                                    <p>
                                                        联系电话： <span style="color: #0094ff; font-size: 1em; font-weight: 600;">
                                                            <asp:Literal ID="ltlMobilePhone" runat="server" Text='<%# Eval("MobilePhoneNum") %>'></asp:Literal></span>
                                                    </p>
                                                </div>
                                                <div class="weui-cell__ft"></div>
                                            </a>
                                            <a class="weui-cell">
                                                <div class="weui-cell__bd">
                                                    <p>
                                                        详细地址：<asp:Literal ID="ltlAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Literal>
                                                    </p>
                                                </div>
                                                <div class="weui-cell__ft"></div>
                                            </a>
                                            <div class="weui-cell">
                                                <div class="weui-cell__hd">
                                                </div>
                                                <div class="weui-cell__bd">
                                                    <a href="javascript:;" class="weui-btn weui-btn_mini weui-btn_default">在线沟通</a>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>
                    </ul>
                </div>
                <div class="page__ft">
                    <a href="javascript:home()">
                        <img src="./images/icon_footer.png" /></a>
                </div>
            </div>
            <script type="text/javascript">
                $(function () {
                    var winH = $(window).height();
                    var categorySpace = 10;

                    $('.js_item').on('click', function () {
                        var id = $(this).data('id');
                        window.pageManager.go(id);
                    });
                    $('.js_category').on('click', function () {
                        var $this = $(this),
                            $inner = $this.next('.js_categoryInner'),
                            $page = $this.parents('.page'),
                            $parent = $(this).parent('li');
                        var innerH = $inner.data('height');
                        bear = $page;

                        if (!innerH) {
                            $inner.css('height', 'auto');
                            innerH = $inner.height();
                            $inner.removeAttr('style');
                            $inner.data('height', innerH);
                        }

                        if ($parent.hasClass('js_show')) {
                            $parent.removeClass('js_show');
                        } else {
                            $parent.siblings().removeClass('js_show');

                            $parent.addClass('js_show');
                            if (this.offsetTop + this.offsetHeight + innerH > $page.scrollTop() + winH) {
                                var scrollTop = this.offsetTop + this.offsetHeight + innerH - winH + categorySpace;

                                if (scrollTop > this.offsetTop) {
                                    scrollTop = this.offsetTop - categorySpace;
                                }

                                $page.scrollTop(scrollTop);
                            }
                        }
                    });
                });
            </script>
        </script>
        <script src="./zepto.min.js"></script>
        <script type="text/javascript" src="https://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
        <script src="./example.js"></script>
    </form>
</body>
</html>
