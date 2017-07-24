<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellReqMsg.aspx.cs" Inherits="Syb_JD_SellReqMsg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link href="./WeUICSS/example.css" rel="stylesheet" />
    <link href="./WeUICSS/weui.css" rel="stylesheet" />
    <link href="./WeUICSS/weui.mini.css" rel="stylesheet" />
    <title>出售信息</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="weui-toptips weui-toptips_warn js_tooltips">错误提示</div>

        <div class="container" id="container"></div>

        <script type="text/html" id="tpl_home">
            <div class="page">
                <div style="padding: 20px;">
                    <h3>待办回收信息 （<asp:Literal ID="ltlCount" runat="server" Text="0"></asp:Literal>）
                    </h3>

                </div>
                <div class="page__bd page__bd_spacing">
                    <asp:HiddenField ID="hfUserMobile" runat="server" />
                    <asp:HiddenField ID="hfJD_UserId" runat="server" />
                    <ul>
                        <asp:ListView ID="lvSellInfo" runat="server" OnItemDataBound="lvSellInfo_ItemDataBound">
                            <ItemTemplate>
                                <li>
                                    <div class="weui-flex js_category">
                                        <p class="weui-flex__item">
                                            <asp:HiddenField ID="hfInfoId" runat="server" Value='<%# Eval("InfoId") %>'></asp:HiddenField>
                                            <b>
                                                <asp:Literal ID="ltlCF_RealName" runat="server" Text=""></asp:Literal></b>
                                            (<asp:Literal ID="ltlTradePlace" runat="server" Text='<%# Eval("TradePlace") %>'></asp:Literal>)<br />
                                            <span style="color: #DCDCDC;"></span>
                                        </p>

                                        <span style="font-size: 1em; font-family: Arial, Helvetica, sans-serif;">
                                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("CreateDate","{0:MM-dd HH:mm}") %>'></asp:Literal></span>
                                    </div>
                                    <div class="page__category js_categoryInner">
                                        <div class="weui-cells page__category-content">
                                            <a class="weui-cell">
                                                <div class="weui-cell__bd">
                                                    <p>
                                                        内容：<asp:Literal ID="ltlDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                                    </p>
                                                </div>
                                                <div class="weui-cell__ft"></div>
                                            </a>
                                            <a class="weui-cell">
                                                <div class="weui-cell__bd">
                                                    <p>
                                                        数量：<asp:Literal ID="ltlQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Literal>
                                                    </p>
                                                </div>
                                                <div class="weui-cell__ft"></div>
                                            </a>
                                            <a class="weui-cell">
                                                <div class="weui-cell__bd">
                                                    <p>
                                                        时间：<asp:Literal ID="ltlCreateDate" runat="server" Text='<%# Eval("CreateDate","{0:yyyy-MM-dd hh:mm}") %>'></asp:Literal>
                                                    </p>
                                                </div>
                                                <div class="weui-cell__ft"></div>
                                            </a>
                                            <a class="weui-cell">
                                                <div class="weui-cell__bd">
                                                    <p>
                                                        联系电话： <span style="color: #0094ff; font-size: 1em; font-weight: 600;">
                                                            <asp:Literal ID="ltlMobilePhone" runat="server" Text=""></asp:Literal></span>
                                                    </p>
                                                </div>
                                                <div class="weui-cell__ft"></div>
                                            </a>
                                            <a class="weui-cell">
                                                <div class="weui-cell__bd">
                                                    <p>
                                                        上门地址：<asp:Literal ID="ltlAddress" runat="server" Text=""></asp:Literal>
                                                    </p>
                                                </div>
                                                <div class="weui-cell__ft"></div>
                                            </a>
                                            <div class="weui-cell">
                                                <div class="weui-cell__hd">
                                                </div>
                                                <div class="weui-cell__bd">
                                                    <asp:LinkButton ID="btnCreateBill" runat="server" Text="创建回收单" class="weui-btn weui-btn_mini weui-btn_primary" OnCommand="btnCreateBill_Command" CommandName="Create" CommandArgument='<%# Eval("InfoId") %>' OnClientClick="return confirm('双方清点货物，并协商一致后创建回收单据。\n点击确定开始创建');"></asp:LinkButton>
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
