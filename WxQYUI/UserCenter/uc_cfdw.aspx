<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uc_cfdw.aspx.cs" Inherits="UserCenter_uc_cfdw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>个人中心</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="pageMain" data-role="page">
            <div data-role="header1">
                <div style="color: #fff; height: 50px; background: linear-gradient(green,#34712c); padding: 10px;">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 60px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/UserCenter/Images/User.png" /></td>
                            <td style="font-size: 11px; font-weight: lighter; vertical-align: text-top; font-family: 'Microsoft YaHei'; padding-top: 5px;">会员名称:<asp:Literal ID="ltlUserName1" runat="server"></asp:Literal><br />
                                行业身份:<asp:Literal ID="ltlBusiIdentity" runat="server"></asp:Literal></td>
                            <td style="width: 60px; text-align: right;">
                                <asp:LoginStatus ID="LoginStatus1" runat="server" Font-Size="12px" />
                            </td>
                        </tr>
                    </table>

                </div>
            </div>
            <div data-role="main" class="ui-content">
                <ul data-role="listview">
                    <%--                    <li>行业身份<p class="ui-li-aside">
                        <asp:Literal ID="ltlBusiIdentity1" runat="server"></asp:Literal>
                    </p>
                    </li>--%>
                    <li><a href="../MP/TodayQuotation.aspx" data-transition="slide" rel="external">今日价格</a>
                    </li>
                    <li><a href="../MP/CreateLeads.aspx" data-transition="slide" rel="external">我要卖货</a>
                    </li>
                    <li id="audit1" runat="server" visible="false"><a href="#" data-transition="slide" rel="external">用户名<p class="ui-li-aside">
                        <asp:Literal ID="ltlUserName" runat="server"></asp:Literal>
                    </p>
                    </a></li>
                    <li id="audit2" runat="server" visible="false"><a href="#page2" data-transition="slide">手机号码<p class="ui-li-aside">
                        <asp:Literal ID="ltlMobile" runat="server"></asp:Literal>
                    </p>
                    </a></li>

                    <li id="audit3" runat="server"><a href="EditRealName.aspx" data-transition="slide" rel="external">实名认证<p class="ui-li-aside">
                        <asp:Literal ID="ltlRealNameVerify" runat="server"></asp:Literal>
                    </p>
                    </a></li>
                    <li id="audit4" runat="server"><a href="CopAuth.aspx" data-transition="slide" rel="external">公司资质审核<p class="ui-li-aside">
                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                    </p>
                    </a></li>
                    <li id="audit5" runat="server"><a href="ShowAddress.aspx" data-transition="slide" rel="external">联系地址<p class="ui-li-aside">
                        <asp:Literal ID="ltlAddress" runat="server"></asp:Literal>
                    </p>
                    </a></li>


                    <%--                    </div>--%>

                    <%--                    <li><a href="../MP/Deposit.aspx" data-transition="slide" rel="external">诚信保证金<p class="ui-li-aside">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </p>
                    </a></li>--%>
<%--                    <li><a href="MyWallet.aspx" data-transition="slide" rel="external">我的钱包
                    </a></li>--%>

                    <li><a href="#pageMima" data-transition="slide" rel="external">密码管理</a></li>


                    <li data-role="list-divider"></li>
<%--                    <li><a href="../MP/MySellInfos.aspx">我的订单</a></li>--%>
                    <li><a href="#" data-transition="slide">消息订阅</a></li>
                    <li data-role="list-divider"></li>

                    <li><a href="../ljlb/Default.aspx">了解绿宝</a></li>
                    <li><a href="#">意见反馈</a></li>
                </ul>
            </div>
            <div data-role="footer">
                <div class="page__bd page__bd_spacing">
                    <br />
                    <br />
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:void(0);" class="weui-footer__link"></a>
                        </p>
                        <p class="weui-footer__text">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</p>
                    </div>
                </div>
            </div>
        </div>

        <div id="pageMima" data-role="page">
            <div data-role="header" data-add-back-btn="true" data-back-btn-text="返回">
                <h1>密码管理</h1>
            </div>
            <div data-role="main" class="ui-content">
                <ul data-role="listview">
                    <li data-role="list-divider"></li>
                    <li><a href="EditPassword.aspx" rel="external">修改登录密码</a></li>
                    <li data-role="list-divider"></li>
                    <li><a href="#" data-transition="slide" rel="external">修改交易密码</a></li>
                </ul>
            </div>
            <div data-role="footer">
            </div>
        </div>
    </form>
</body>
</html>
