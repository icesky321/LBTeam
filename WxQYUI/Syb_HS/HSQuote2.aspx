<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HSQuote2.aspx.cs" Inherits="Syb_HS_HSQuote2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.min.css" rel="stylesheet" />
    <title>回收公司报价</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>电瓶回收报价</h2>
            </div>
            <div data-role="main" class="ui-content">
                <div>
                    当前选定的电瓶品种为：<asp:Literal ID="ltlTSName" runat="server"></asp:Literal>
                </div>
                <p>按不同的市域分别报价</p>
                <div class="weui-cells weui-cells_form">
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
                        <ItemTemplate>
                            <div class="weui-cell weui-cell_vcode">
                                <div class="weui-cell__hd">
                                    <label class="weui-label">
                                        <asp:HiddenField ID="hfTSId" runat="server" Value='<%# Eval("TSId") %>' />
                                        <asp:Literal ID="ltlTSName" runat="server" Text='<%# Eval("TSName") %>'></asp:Literal></label>
                                </div>
                                <div class="weui-cell__bd">
                                    
                                    <asp:TextBox ID="tbQuotedPrice" runat="server" class="weui-input" type="text" placeholder="请输入报价"></asp:TextBox>
                                </div>
                                <div class="weui-cell__ft">
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("ChargeUnit") %>'></asp:Literal><asp:Button ID="btnAlone" runat="server" class="weui-vcode-btn" Text="单独报价" CommandName="OneQuote" CommandArgument='<%# Eval("TSName") %>' OnCommand="btnQuote1_Command"></asp:Button>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" OrderBy="TSId" Select="new (TSId, TSName, TsCode, ChargeUnit)" TableName="TSInfo"></asp:LinqDataSource>


                </div>
            </div>
            <div data-role="footer">
                <h2>footer</h2>
            </div>
        </div>
    </form>
</body>
</html>
