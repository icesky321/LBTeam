<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="CF_JD_OrderManage.aspx.cs" Inherits="CF_JD_OrderManage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    街道业务员收货付款订单管理
                </p>
            </div>
            <hr />
            <br />
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <asp:Label ID="lbCFId" runat="server" Text='<%# Eval("CFId") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lbInUserId" runat="server" Text='<%# Eval("InUserId") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lbOutUserId" runat="server" Text='<%# Eval("OutUserId") %>' Visible="false"></asp:Label>
                    <table style="border: 1px solid #C0C0C0; width: 100%">
                        <tr style="height: 30px; background-color: #99FF33;">
                            <td>卖方(产废单位):
                        <asp:Label ID="lbInNum" runat="server" Text=""></asp:Label></td>
                            <td>买方(街道回收员):<asp:Label ID="lbOutNum" runat="server" Text=""></asp:Label>
                            </td>
                            <td>金额：￥<asp:Label ID="lbAmount" runat="server" Text='<%# Eval("Amount") %>' Font-Size="Medium" ForeColor="Red"></asp:Label>元
                            </td>
                            <td>转账时间：
                        <asp:Label ID="lbTransferDate" runat="server" Text='<%# Eval("TransferDate") %>'></asp:Label>
                            </td>
                            <td rowspan="2" style="background-color: #FFFFFF; text-align: center;">
                                <asp:Button ID="btAudit" runat="server" Text="资金到账确认" CommandName="Audit" CommandArgument='<%#Eval("CFId") %>' />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btAudit" ConfirmText="确认平台已收到该笔资金？" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GridView1" runat="server" DataSourceID="LinqDataSource2" AutoGenerateColumns="False">
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
                            </td>
                        </tr>
                    </table>


                </ItemTemplate>
                <SeparatorTemplate>
                    <div style="height: 30px;">
                    </div>
                </SeparatorTemplate>
            </asp:Repeater>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" OrderBy="TransferDate desc" Select="new (CFId, InUserId, OutUserId, Amount, TransferMethod, Remark, TransferDate, AuditOperator, AuditDatetime, Audit, OperateDate, Operator, OperatorConfirm)" TableName="CF_JD_Order" Where="Audit == @Audit">
                <WhereParameters>
                    <asp:Parameter DefaultValue="false" Name="Audit" Type="Boolean" />
                </WhereParameters>
            </asp:LinqDataSource>
        </div>
    </div>


</asp:Content>

