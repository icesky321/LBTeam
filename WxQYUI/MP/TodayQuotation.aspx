﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TodayQuotation.aspx.cs" Inherits="MP_TodayQuotation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="page">
            <div class="page__hd">
                <div style="border: 1px dotted #999999; padding: 20px; margin: 10px 5px 0 5px;" class="ui-corner-all">
                    报价区域：<asp:Literal ID="ltlRegionWholeName" runat="server"></asp:Literal>
                    <asp:HiddenField ID="hfCountyId" runat="server" />
                </div>
            </div>
            <div class="page__bd">
                <div class="weui-cells__title">
                    今日更新
                </div>
                <div class="weui-cells">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="weui-cell">
                                <div class="weui-cell__hd">
                                    <label class="weui-label">
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("TSName").ToString() %>'></asp:Literal>
                                    </label>
                                </div>
                                <div class="weui-cell__bd">
                                    <p>
                                        <asp:Literal ID="Literal2" runat="server" Text='<%# "<b>"+ Eval("QuotedPrice").ToString() + "</b>" %>'></asp:Literal>
                                    </p>
                                </div>
                                <div class="weui-cell__ft">
                                    元/吨
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="weui-cells__title">当前最新报价</div>
                <div class="weui-cells">
                    <div class="weui-cell">
                        <div class="weui-cell__hd">
                            <label class="weui-label">
                                品种
                            </label>
                        </div>
                        <div class="weui-cell__bd">
                            <p>
                                最新价格
                            </p>
                        </div>
                        <div class="weui-cell__ft">
                            更新日期
                        </div>
                    </div>
                    <asp:Repeater ID="Repeater2" runat="server" DataSourceID="ObjectDataSource1" OnItemDataBound="Repeater2_ItemDataBound">
                        <ItemTemplate>
                            <div class="weui-cell">
                                <div class="weui-cell__hd">
                                    <label class="weui-label">
                                        <asp:HiddenField ID="hfTSId" runat="server" Value='<%# Eval("TSId") %>' />
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("TSName").ToString() %>'></asp:Literal>
                                    </label>
                                </div>
                                <div class="weui-cell__bd">
                                    <b>
                                        <asp:Literal ID="ltlPrice" runat="server" Text=""></asp:Literal>
                                    </b>
                                </div>
                                <div class="weui-cell__ft">
                                    <div style="font-size: 0.7em;">
                                        <asp:Literal ID="ltlHS_UserName" runat="server" Text=""></asp:Literal><br />

                                        <asp:Literal ID="ltlDate" runat="server" Text=""></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTSInfo" TypeName="LB.BLL.TSManage"></asp:ObjectDataSource>
                </div>

                <label for="weuiAgree" class="weui-agree">
                    <span class="weui-agree__text">须知：废旧电瓶回收报价信息由本地回收公司面向所有产废单位报价。<br />
                        汽车80AA：代表型号80AH以上的汽车电池。<br />
                        汽车80AB：代表型号80AH以下的汽车电池。<br />
                    </span>
                </label>
            </div>
            <div class="page__bd page__bd_spacing">
                <br>
                <br>
                <div class="weui-footer">
                    <p class="weui-footer__links">
                        <a href="javascript:void(0);" class="weui-footer__link"></a>
                    </p>
                    <p class="weui-footer__text">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</p>
                </div>
            </div>
        </div>

    </form>
</body>
</html>