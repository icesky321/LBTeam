<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Success.aspx.cs" Inherits="Syb_Dyywy_Success" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>付款确认</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="weui-msg">
            <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
            <div class="weui-msg__text-area">
                <h2 class="weui-msg__title">操作成功</h2>
                <p class="weui-msg__desc">该订单已提交回收公司，回收公司付款，平台审核通过后将以消息推送形式反馈到您企业号中，请耐心等待。如有疑问请咨询：0574-86694505</p>
            </div>
        </div>
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
                    <asp:HiddenField ID="hfCFId" runat="server" />
                    <%--<asp:Label ID="Label1" runat="server" Text="0c31f580-8be2-4d40-b506-f10f53c0073b"></asp:Label>--%>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
