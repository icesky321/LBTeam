<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewQuotation.aspx.cs" Inherits="HS_ViewQuotation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfCityRegionCode" runat="server" />
        <div id="page1" data-role="page">
            <div data-role="panel" id="myPanel">
                <h3>
                    <asp:Literal ID="ltlCityName" runat="server"></asp:Literal></h3>
                <asp:Repeater ID="rptRegion" runat="server">
                    <HeaderTemplate>
                        <ul data-role="listview" style="width: 95%;">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href='<%# "ViewQuotation.aspx?CountyRegionCode=" + Eval("CountyId")  %>'>
                                <asp:Literal ID="ltlCountyName" runat="server" Text='<%# Eval("AreaName") %>'></asp:Literal></a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                </asp:Repeater>
            </div>
            <div data-role="header">
                <h2>查询回收报价</h2>
            </div>
            <div data-role="main" class="ui-content">
                <table>
                    <tr>
                        <td><a href="#myPanel" class="ui-btn ui-btn-inline">选择区县</a></td>
                        <td>
                            <asp:Literal ID="ltlRegionWholeName" runat="server"></asp:Literal></td>
                    </tr>
                </table>
                <asp:HiddenField ID="hfCountyId" runat="server" />
                <p>今日更新</p>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="weui-cell">
                            <div class="weui-cell__hd">
                                <label class="weui-label">
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("TSName").ToString() %>'></asp:Literal>
                                </label>
                            </div>
                            <div class="weui-cell__bd" style="text-align: right;">
                                <p>
                                    <asp:Literal ID="Literal2" runat="server" Text='<%# "<b>"+ Eval("QuotedPrice").ToString() + "</b>" %>'></asp:Literal>
                                </p>
                            </div>
                            <div class="weui-cell__ft">
                                元/<asp:Literal ID="Literal3" runat="server" Text='<%# Eval("ChargeUnit").ToString() %>'></asp:Literal>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <p>当前最新报价</p>
                <table style="padding: 0 0 20px 0; width: 100%;">
                    <tr>
                        <td>品种</td>
                        <td style="text-align: right;">最新价格</td>
                        <td style="text-align: right; width: 6em;">更新日期</td>
                    </tr>
                </table>

                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="ObjectDataSource1" OnItemDataBound="Repeater2_ItemDataBound">
                    <HeaderTemplate>
                        <ul data-role="listview">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hfTSId" runat="server" Value='<%# Eval("TSId") %>' />
                                        <asp:HiddenField ID="hfTsCode" runat="server" Value='<%# Eval("TsCode") %>' />
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("TSName").ToString() %>'></asp:Literal></td>
                                    <td style="text-align: right;"><b>
                                        <asp:Literal ID="ltlPrice" runat="server" Text=""></asp:Literal>
                                    </b>
                                        <asp:Literal ID="ltlChargeUnit" runat="server"></asp:Literal></td>
                                    <td style="text-align: right; width: 6em;">
                                        <div style="font-size: 0.7em;">
                                            <asp:Literal ID="ltlHS_UserName" runat="server" Text=""></asp:Literal><br />

                                            <asp:Literal ID="ltlDate" runat="server" Text=""></asp:Literal>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTSInfo" TypeName="LB.BLL.TSManage"></asp:ObjectDataSource>


                <div style="padding: 20px 0 0 0; color: #999999;">
                    须知：废旧电瓶回收报价信息由本地回收公司发布，本报价信息供本市域范围内回收业务员参考。
                        本报价信息不向产废单位提供。
                </div>
            </div>
            <div data-role="footer" style="text-align: center;">
                <span style="font-size: 0.75em;">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</span>
            </div>
        </div>

    </form>
</body>
</html>
