<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmOrder.aspx.cs" Inherits="MP_ConfirmOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>订单确认</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hfInUserId" runat="server" />
        <div data-role="page" id="page1">
            <div data-role="header">
                <h2>绿宝三益--订单确认</h2>
            </div>

            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <div style="border-width: thick; border-color: #00FF00; border-top-style: groove;">
                        <div class="ui-field-contain">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <label for="fullname">产废单位：</label>
                                        <asp:Label ID="lbCFId" runat="server" Text='<%# Eval("CFId") %>' Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbcfdw" runat="server" Text='<%# Eval("InUserId") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbcfName" runat="server" Text=""></asp:Label>(
                                        <asp:Label ID="lbcfPhone" runat="server" Text=""></asp:Label>)
                                    </td>
                                    <td>
                                        <label for="fullname">回收公司：</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbjdywy" runat="server" Text='<%# Eval("OutUserId") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbjdName" runat="server" Text=""></asp:Label>(
                                        <asp:Label ID="lbjdPhone" runat="server" Text=""></asp:Label>)
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="ui-field-contain">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <label for="fullname">交易时间：</label>
                                    </td>
                                    ,<td>
                                        <asp:Label ID="lbDate" runat="server" Text='<%# Eval("AuditDatetime") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <label for="fullname">交易金额：</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div data-role="main" class="ui-content">
                            <div data-role="collapsible">
                                <h2>交易货品明细（点击查看）</h2>
                                <asp:GridView ID="GridView1" runat="server" DataSourceID="LinqDataSource2" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="GoodsDetail" HeaderText="电瓶类别" SortExpression="" />
                                        <asp:BoundField DataField="Quantity" HeaderText="交易数量" SortExpression="" />
                                        <asp:BoundField DataField="GoodsUnit" HeaderText="单位名称" SortExpression="" />
                                    </Columns>
                                </asp:GridView>
                                <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" Select="new (ODId, CFId, GoodsDetail, Quantity, GoodsUnit)" TableName="CF_JD_OrderDetail" Where="CFId == @CFId">
                                    <WhereParameters>
                                        <asp:ControlParameter ControlID="lbCFId" DbType="Guid" Name="CFId" PropertyName="Text" />
                                    </WhereParameters>
                                </asp:LinqDataSource>
                            </div>
                        </div>
                        <asp:Button ID="btConfirm" runat="server" Text="确认" CommandName="Confirm" CommandArgument='<%#Eval("CFId") %>' />
                        <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btConfirm" ConfirmText="货物明细确认无误？" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" Select="new (CFId, InUserId, OutUserId, Amount, TransferMethod, Remark, TransferDate, AuditOperator, AuditDatetime, OperateDate, Operator, OperatorConfirm, Audit)" TableName="CF_JD_Order" Where="Audit == @Audit &amp;&amp; OperatorConfirm == @OperatorConfirm &amp;&amp; InUserId == @InUserId">
            <WhereParameters>
                <asp:Parameter DefaultValue="true" Name="Audit" Type="Boolean" />
                <asp:Parameter DefaultValue="false" Name="OperatorConfirm" Type="Boolean" />
                <asp:ControlParameter ControlID="hfInUserId" Name="InUserId" PropertyName="Value" Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
    </form>
</body>
</html>
