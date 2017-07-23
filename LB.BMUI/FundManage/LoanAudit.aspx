<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="LoanAudit.aspx.cs" Inherits="FundManage_LoanAudit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <table style="max-width: 1000px; min-width: 800px; border: solid 1px #CCCCCC;">
                <tr style="border-top: solid 3px #0094ff;">
                    <td class="dataCell" style="border-bottom: solid 1px #CCCCCC;">
                        <div style="float: left;">
                            <asp:Label ID="lbTitle" runat="server" Text="产废单位提现申请"></asp:Label>
                        </div>
                        <div style="float: right;">
                            <asp:Label ID="lbCreateDate" runat="server" Text='<%# Eval("CreateDate") %>'></asp:Label>
                        </div>
                    </td>
                    <td rowspan="2" class="dataCell" style="border-left: solid 1px #CCCCCC; width: 400px; vertical-align: top;">产废单位信息<br />
                        <asp:HiddenField ID="hfQYUserId" runat="server" Value="" />
                        联系人：                               
                            <asp:Label ID="ltlRealName" runat="server" ForeColor="#6699ff"></asp:Label><br />

                        联系电话：                               
                            <asp:Label ID="ltlPhone" runat="server" ForeColor="#6699ff"></asp:Label><br />
                        汇款人姓名：                               
                            <asp:Label ID="ltlPayeeName" runat="server" ForeColor="#6699ff"></asp:Label><br />
                        银行开户行：                               
                            <asp:Label ID="ltlBankName" runat="server" ForeColor="#6699ff"></asp:Label><br />
                        银行账号：                               
                            <asp:Label ID="ltlAccount" runat="server" ForeColor="#6699ff"></asp:Label><br />
                        账户当前余额：
                        <asp:Label ID="lbTotalAmount" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="dataCell">提现金额：<b><asp:Literal ID="ltlDescription" runat="server" Text='<%# Eval("Amount") %>'></asp:Literal></b></td>
                </tr>
                <tr>
                    <td class="dataCell" colspan="2" style="border-top: solid 1px #CCCCCC; text-align: center;">
                        <asp:Button ID="btnAccept" runat="server" Text="打款后请点击" BorderStyle="Solid" BorderColor="#CCCCCC" CommandName="Accept" CommandArgument='<%# Eval("PDId") %>' />&nbsp;&nbsp;
                            <asp:Button ID="btnReject" runat="server" Text="作废，关闭信息" BorderStyle="Solid" BorderColor="#CCCCCC" CommandName="Reject" CommandArgument='<%# Eval("PDId") %>' />
                    </td>

                </tr>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <div style="height: 30px;"></div>
        </SeparatorTemplate>
    </asp:Repeater>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" OrderBy="CreateDate" TableName="PaymentDetail" Where="PayStatus == @PayStatus">
        <WhereParameters>
            <asp:Parameter DefaultValue="提款中" Name="PayStatus" Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
</asp:Content>

