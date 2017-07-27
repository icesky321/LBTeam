<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HSQuote2.aspx.cs" Inherits="Syb_HS_HSQuote2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.min.css" rel="stylesheet" />
    <title>回收公司报价</title>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
        <asp:HiddenField ID="hfUserId" runat="server" />
        <asp:HiddenField ID="hfUserName" runat="server" />
        <asp:HiddenField ID="hfCopName" runat="server" />
        <div id="page1" data-role="page">
            <div data-role="header" data-add-back-btn="true" data-back-btn-text="上一页">
                <h2>电瓶回收报价</h2>
            </div>
            <div data-role="main" class="ui-content">
                <div style="padding: 20px 15px 0 15px;">
                    电瓶品种为：<asp:Literal ID="ltlTSName" runat="server"></asp:Literal>&nbsp;&nbsp;(<asp:Literal ID="ltlTsCode" runat="server"></asp:Literal>)
                    <asp:Literal ID="ltlChargeUnit" runat="server"></asp:Literal>
                    <asp:HiddenField ID="hfTsInfo" runat="server" />
                </div>

                <div class="weui-cells weui-cells_form">
                    <p style="padding: 10px;">
                        按不同的市域分别报价，页面默认加载当日最新报价。
                    </p>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <div class="weui-cell weui-cell_vcode" style="height: 2.5em;">
                                <div class="weui-cell__hd">
                                    <label class="weui-label" style="width: 7em;">
                                        <asp:HiddenField ID="hfRegionCode" runat="server" Value='<%# Eval("id") %>' />
                                        <asp:Literal ID="ltlRegionWholeName" runat="server" Text='<%# Eval("AreaName") %>'></asp:Literal></label>
                                </div>
                                <div class="weui-cell__bd">
                                    <div style="float: left;">
                                        <asp:TextBox ID="tbQuotedPrice" runat="server" class="weui-input" type="text" placeholder="0.00"></asp:TextBox>
                                    </div>
                                    <div style="float: right;">
                                        元/<asp:Literal ID="Literal1" runat="server" Text='<%# DataBinder.GetPropertyValue(ltlChargeUnit,"Text") %>'></asp:Literal>
                                    </div>
                                </div>
                                <%--<div class="weui-cell__ft">

                                    <asp:Button ID="btnAlone" runat="server" class="weui-vcode-btn" Text="单独报价" CommandName="OneQuote" CommandArgument='<%# Eval("id") %>' OnCommand="btnQuote1_Command"></asp:Button>
                                </div>--%>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
                <div style="padding: 10px 20px 10px 20px;">
                    <asp:Button ID="btnOneClickQuote" runat="server" Text="保存报价数据" class="weui-btn weui-btn_primary" OnClick="btnOneClickQuote_Click" />
                </div>

            </div>

        </div>

    </form>
</body>
</html>
