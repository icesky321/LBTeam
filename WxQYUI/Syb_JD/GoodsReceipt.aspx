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
            <div data-role="header">
                创建收货订单
                <asp:HiddenField ID="hfInfoId" runat="server" />
            </div>
            <div data-role="main" class="ui-content">
                <label for="fullname">卖方：</label>
                <asp:TextBox ID="tbcfdw" runat="server" Text="" Enabled="false"></asp:TextBox>
                <label for="fullname">买方：</label>
                <asp:TextBox ID="tbjdywy" runat="server" Text="" Enabled="false"></asp:TextBox>

                <div data-role="collapsible" data-collapsed="false">
                    <h1>绿宝第三方支付账户</h1>
                    <p>公司名称：宁波绿宝信息科技有限公司</p>
                    <p>开户行：宁波银行庄市支行</p>
                    <p>账号：5204 0122 0002 10157</p>
                </div>

                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
                    <ItemTemplate>
                        <div class="weui-cell weui-cell_vcode">
                            <div class="weui-cell__hd">
                                <label class="weui-label">
                                    <asp:HiddenField ID="hfTSId" runat="server" Value='<%# Eval("TSId") %>' />
                                    <asp:Literal ID="ltlTSName" runat="server" Text='<%# Eval("TSName") %>'></asp:Literal></label>
                            </div>
                            <div class="weui-cell__bd">
                                <asp:TextBox ID="tbNum" runat="server" class="weui-input" type="text" placeholder="请输入准确重量/数量"></asp:TextBox>
                            </div>
                            <div class="weui-cell__ft">
                                <label class="weui-label">
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("ChargeUnit") %>'></asp:Literal></label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" OrderBy="OrderNum" TableName="TSInfo"></asp:LinqDataSource>

                <div class="weui-cell weui-cell_vcode">
                    <div class="weui-cell__hd">
                        <label class="weui-label">
                            总金额：
                        </label>
                    </div>
                    <div class="weui-cell__bd">
                        <asp:TextBox ID="tbAmount" runat="server" class="weui-input" type="text" placeholder="请输入付款金额" ValidationGroup="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入金额！" ValidationGroup="1" ControlToValidate="tbAmount"></asp:RequiredFieldValidator>
                    </div>
                    <div class="weui-cell__ft">
                        <label class="weui-label">
                            元
                        </label>
                    </div>
                </div>
                <div class="ui-field-contain">
                    <label for="fullname">备注：</label>
                    <asp:TextBox ID="tbRemark" runat="server" Text="" placeholder="如有补充说明请在这里输入"></asp:TextBox>

                </div>
                <br />
                <%--<asp:DropDownList ID="ddlCop" runat="server"></asp:DropDownList>--%>
                <asp:Button ID="btSure" runat="server" Text="提交" OnClick="btSure_Click" rel="external" ValidationGroup="1" />


            </div>

        </div>

    </form>
</body>
</html>
