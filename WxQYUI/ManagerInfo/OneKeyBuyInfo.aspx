<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OneKeyBuyInfo.aspx.cs" Inherits="ManagerInfo_OneKeyBuyInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>订单明细</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page1" data-role="page" runat="server">
            <div class="weui-cells__title">
                <h2>订单明细</h2>
                <asp:HiddenField ID="hfCFId" runat="server" />
            </div>
            <div class="weui-cells weui-cells_form">
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
                    <ItemTemplate>
                        <div class="weui-cell weui-cell_vcode">
                            <div class="weui-cell__hd">
                                <label class="weui-label">
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("GoodsDetail") %>'></asp:Literal></label>
                            </div>
                            <div class="weui-cell__bd">
                                <label class="weui-label">
                                    <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Quantity") %>'></asp:Literal></label>
                            </div>
                            <div class="weui-cell__ft">
                                <label class="weui-label">
                                    <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("GoodsUnit") %>'></asp:Literal></label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" TableName="CF_JD_OrderDetail" Where="CFId == @CFId" Select="new (ODId, CFId, GoodsDetail, Quantity, GoodsUnit)">
                    <WhereParameters>
                        <asp:ControlParameter ControlID="hfCFId" DbType="Guid" Name="CFId" PropertyName="Value" />
                    </WhereParameters>
                </asp:LinqDataSource>

                <div class="weui-cell weui-cell_vcode">
                    <div class="weui-cell__hd">
                        <label class="weui-label">
                            总金额：
                        </label>
                    </div>
                    <div class="weui-cell__bd">
                        <asp:Label ID="lbAmount" runat="server" Text="" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="weui-cell__ft">
                        <label class="weui-label">
                            元
                        </label>
                    </div>
                </div>
                <div class="ui-field-contain">
                    <label for="fullname">备注：</label>
                    <asp:Label ID="lbReamrk" runat="server" Text=""></asp:Label>
                </div>
                <br />

            </div>
        </div>
    </form>
</body>
</html>
