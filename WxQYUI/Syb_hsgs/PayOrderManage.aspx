<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayOrderManage.aspx.cs" Inherits="Syb_hsgs_PayOrderManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>付款确认信息</title>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
        <div data-role="page" id="page1">
            <div class="weui-form-preview__bd">
                <div data-role="collapsible" data-collapsed="false">
                    <h1>绿宝第三方支付账户</h1>
                    <p>公司名称：宁波绿宝信息科技有限公司</p>
                    <p>开户行：宁波银行庄市支行</p>
                    <p>账号：5204 0122 0002 10157</p>
                </div>
                <div class="weui-cells">
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <div class="weui-cell weui-cell_vcode">
                                <div class="weui-cell__hd">
                                    <label class="weui-label">
                                        总金额：
                                    </label>
                                </div>
                                <div class="weui-cell__bd">
                                    <asp:Label ID="lbAmount" runat="server" Font-Size="Medium" ForeColor="Red" Text=""></asp:Label>
                                </div>
                                <div class="weui-cell__ft">
                                    <label class="weui-label">
                                        元
                                    </label>
                                </div>
                            </div>
                            <div class="ui-field-contain">
                                <label for="fullname">备注：</label>
                                 <asp:Label ID="lbCfId" runat="server" Text='<%# Eval("CFId") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbReamrk" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="weui-form-preview__item">
                                <asp:Button ID="btChoose" runat="server" Text="点击查看明细并确认已付款" CommandName="Confirm" CommandArgument='<%#Eval("CFId") %>' rel="external" />
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>
                    <asp:HiddenField ID="hfHS_UserId" runat="server" />

                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" TableName="CF_JD_Order" Where="CopUserId == @CopUserId &amp;&amp; CopUserAudit == @CopUserAudit">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="hfHS_UserId" Name="CopUserId" PropertyName="Value" Type="Int32" />
                            <asp:Parameter DefaultValue="false" Name="CopUserAudit" Type="Boolean" />
                        </WhereParameters>
                    </asp:LinqDataSource>

                </div>

            </div>
        </div>
    </form>
</body>
</html>
