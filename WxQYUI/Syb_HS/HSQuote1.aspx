<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HSQuote1.aspx.cs" Inherits="Syb_HS_HSQuote1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <title>回收公司报价</title>
</head>
<body ontouchstart>
    <form id="form1" runat="server" data-ajax="false">
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>电瓶回收报价</h2>
            </div>
            <div data-role="main" class="ui-content">
                <p>选择电瓶品种</p>
                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="LinqDataSource1">
                    <HeaderTemplate>
                        <ol data-role="listview">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href='<%# "HSQuote2.aspx?id=" + Eval("TsCode").ToString() %>' rel="external">
                                <asp:HiddenField ID="hfTSId" runat="server" Value='<%# Eval("TSId") %>' />
                                <asp:Literal ID="ltlTSName" runat="server" Text='<%# Eval("TSName") %>'></asp:Literal>
                                <span class="ui-li-aside">
                                    <asp:Literal ID="ltlChangeUnit" runat="server" Text='<%# Eval("ChargeUnit") %>'></asp:Literal></span>
                            </a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ol>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" OrderBy="OrderNum" Select="new (TSId, TSName, ChargeUnit, TsCode)" TableName="TSInfo"></asp:LinqDataSource>
                <div style="height: 150px; padding: 20px 0 0 0; color: #989898;">
                    须知：废旧电瓶回收报价信息由本地回收公司发布，以吨为单位的报价信息供本市各区（县）范围内回收业务员参考，以个组等为单位的报价供产废单位参考。
                        
                   
                </div>
            </div>
            <div data-role="footer">

                <div style="text-align: center;">2016-2017 lvbao111.com</div>
            </div>
        </div>
    </form>
</body>
</html>
