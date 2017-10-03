<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyOrderDetail.aspx.cs" Inherits="MP_MyOrderDetail" %>

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
        <div class="weui-form-preview">
            <div class="weui-form-preview__hd">
                <label class="weui-form-preview__label">付款金额</label>
                <em class="weui-form-preview__value">
                    <label class="weui-label">
                        ￥<asp:Label ID="lbAmount" runat="server" Text=""></asp:Label>
                    </label>
                </em>
            </div>
            <div class="weui-cells">
                <div class="weui-form-preview__item">
                    <label class="weui-form-preview__label">卖方(产废单位)</label>
                    <span class="weui-form-preview__value">
                        <label class="weui-label">
                            <asp:Label ID="lbCFDW" runat="server" Text=""></asp:Label>
                        </label>
                    </span>
                </div>
                <div class="weui-cells">
                    <label class="weui-form-preview__label">买方(街道回收员)</label>
                    <span class="weui-form-preview__value">
                        <label class="weui-label">
                            <asp:Label ID="lbJDYWY" runat="server" Text=""></asp:Label>
                        </label>
                    </span>
                </div>
                <div class="weui-cells">
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
                        <ItemTemplate>
                            <div class="weui-cell">
                                <div class="weui-cell__hd">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("GoodsDetail") %>'></asp:Label>
                                </div>
                                <div class="weui-cell__bd">
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                </div>
                                <div class="weui-cell__ft">
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("GoodsUnit") %>'></asp:Label>
                                </div>

                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" Select="new (ODId, GoodsDetail, CFId, Quantity, GoodsUnit)" TableName="CF_JD_OrderDetail" Where="CFId == @CFId">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="hfCFId" DbType="Guid" Name="CFId" PropertyName="Value" />
                        </WhereParameters>
                    </asp:LinqDataSource>
                    <asp:HiddenField ID="hfCFId" runat="server"/>
                    <asp:HiddenField ID="hfinfoId" runat="server" />
                    <%--<asp:Label ID="Label1" runat="server" Text="0c31f580-8be2-4d40-b506-f10f53c0073b"></asp:Label>--%>
                </div>
                <fieldset data-role="controlgroup" data-type="horizontal" data-inline="false" id="btn" runat="server" visible="false">
                    <asp:Button ID="btnAccept" runat="server" Text="订单确认" data-icon="check"  rel="external" data-mini="true" data-inline="true" OnClientClick='return confirm("该收货单确定无误吗？");' OnClick="btnAccept_Click" />
                    <asp:Button ID="btnReject" runat="server" Text="订单有误，退还业务员" data-icon="delete" rel="external" data-mini="true" data-inline="true" OnClientClick='return confirm("明细有误，确定要业务员重新填写吗？");' OnClick="btnReject_Click" />
                </fieldset>
            </div>
        </div>

    </form>
</body>
</html>
