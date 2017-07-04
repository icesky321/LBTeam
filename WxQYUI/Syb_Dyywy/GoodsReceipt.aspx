<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodsReceipt.aspx.cs" Inherits="Syb_Dyywy_GoodsReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>发布收货订单</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page1" data-role="page">
            <div class="weui-cells__title">
                回收废旧电瓶分类明细

                 
            </div>
            <div class="weui-cells weui-cells_form">
                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="LinqDataSource1">
                    <ItemTemplate>
                        <div class="weui-cell weui-cell_vcode">
                            <div class="weui-cell__hd">
                                <label class="weui-label">
                                    <asp:HiddenField ID="hfTSId" runat="server" Value='<%# Eval("TSId") %>' />
                                    <asp:Literal ID="ltlTSName" runat="server" Text='<%# Eval("TSName") %>'></asp:Literal></label>
                            </div>
                            <div class="weui-cell__bd">
                                <asp:TextBox ID="tbQuotedPrice" runat="server" class="weui-input" type="text" placeholder="请输入准确重量（元/吨）"></asp:TextBox>
                            </div>
                            <div class="weui-cell__ft">
                                <%--<asp:Button ID="btnAlone" runat="server" class="weui-vcode-btn" Text="单独报价" CommandName="OneQuote" CommandArgument='<%# Eval("TSName") %>' OnCommand="btnQuote1_Command"></asp:Button>--%>
                                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" OrderBy="TSId" Select="new (TSId, TSName)" TableName="TSInfo"></asp:LinqDataSource>


            </div>
            <div class="weui-cells__title"></div>
        </div>

    </form>
</body>
</html>
