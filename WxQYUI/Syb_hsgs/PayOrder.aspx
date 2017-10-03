<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayOrder.aspx.cs" Inherits="Syb_hsgs_PayOrder" %>

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
<%--                <div data-role="collapsible" data-collapsed="false">
                    <h1>绿宝第三方支付账户</h1>
                    <p>公司名称：宁波绿宝信息科技有限公司</p>
                    <p>开户行：宁波银行庄市支行</p>
                    <p>账号：5204 0122 0002 10157</p>
                </div>--%>

                <asp:Button ID="btSure" runat="server" Text="付款后请点击确认" OnClick="btSure_Click" ValidationGroup="1" Visible="false" />

            </div>
        </div>
        <div id="pageRegCompleted" data-role="page" runat="server">

            <div data-role="main" class="ui-content">
                <div class="weui-msg">
                    <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">操作成功</h2>
                        <p class="weui-msg__desc">付款信息已提交绿宝三益后台审核，请留意绿宝企业号消息提醒</p>
                    </div>
                    <%--                    <div class="weui-msg__opr-area">
                        <p class="weui-btn-area">
                            <a href="MyTradeLeads.aspx" class="weui-btn weui-btn_primary" rel="external">查看已发布信息</a>
                        </p>
                    </div>--%>
                    <div class="weui-msg__extra-area">
                        <div class="weui-footer">
                            <p class="weui-footer__links">
                                <a href="javascript:void(0);" class="weui-footer__link"></a>
                            </p>
                            <p class="weui-footer__text">Copyright &copy; 2016-2017 lvbao111.com</p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
