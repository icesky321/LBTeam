<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JDViewQuotation.aspx.cs" Inherits="Syb_JD_ViewQuotation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <title>报价查询</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfCountyId" runat="server" />
        <asp:HiddenField ID="hfUserName" runat="server" />

        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>报价查询</h2>
                <div data-role="navbar">
                    <ul>
                        <li><a href="#" class="ui-btn-active">收购价格</a></li>
                        <li><a href="#page2">出售价格</a></li>
                    </ul>
                </div>
            </div>
            <div data-role="main" class="ui-content">
                <p>
                    <asp:Literal ID="ltlRegionWholeName" runat="server"></asp:Literal>
                </p>
                <table style="padding: 0 0 20px 0; width: 100%;">
                    <tr>
                        <td>品种</td>
                        <td style="text-align: right;">最新价格</td>
                        <td style="text-align: right; width: 6em;">更新日期</td>
                    </tr>
                </table>

                <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
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

            </div>
            <div data-role="footer" style="text-align: center;">
                <span style="font-size: 0.75em;">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</span>
            </div>
        </div>


        <div id="page2" data-role="page">
            <div data-role="header">
                <h2>报价查询</h2>
                <div data-role="navbar">
                    <ul>
                        <li><a href="#page1">收购价格</a></li>
                        <li><a href="#" class="ui-btn-active">出售价格</a></li>
                    </ul>
                </div>
            </div>
            <div data-role="main" class="ui-content">
                <p>
                    <asp:Literal ID="ltlRegionWholeName2" runat="server"></asp:Literal>
                </p>
                <table style="padding: 0 0 20px 0; width: 100%;">
                    <tr>
                        <td>品种</td>
                        <td style="text-align: right;">最新价格</td>
                        <td style="text-align: right; width: 6em;">更新日期</td>
                    </tr>
                </table>

                <asp:Repeater ID="rptChuShou" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
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
            </div>
            <div data-role="footer" style="text-align: center;">
                <span style="font-size: 0.75em;">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</span>
            </div>
        </div>
    </form>
</body>
</html>
