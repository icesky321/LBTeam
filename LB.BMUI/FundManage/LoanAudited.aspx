<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="LoanAudited.aspx.cs" Inherits="FundManage_LoanAudited" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <table style="max-width: 1000px; min-width: 800px; border: solid 1px #CCCCCC;">
                <tr style="border-top: solid 3px #0094ff;">
                    <td class="dataCell" style="border-bottom: solid 1px #CCCCCC;">
                        <div style="float: left;">
                            <asp:Label ID="lbTitle" runat="server" Text="产废单位提现申请"></asp:Label><br />
                            提现编号：<asp:Label ID="lbPDId" runat="server" Text='<%# Eval("PDId") %>'></asp:Label>
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
                        <asp:MultiView ID="MultiView4" runat="server"  ActiveViewIndex="0">
                            <asp:View ID="viewShwoBankInfo" runat="server">
                                汇款人姓名：                               
                            <asp:Label ID="ltlPayeeName" runat="server" ForeColor="#6699ff"></asp:Label><br />
                                银行开户行：                               
                            <asp:Label ID="ltlBankName" runat="server" ForeColor="#6699ff"></asp:Label><br />
                                银行账号：                               
                            <asp:Label ID="ltlAccount" runat="server" ForeColor="#6699ff"></asp:Label><br />
                            </asp:View>

                            <asp:View ID="viewShowZFB" runat="server">
                                支付宝姓名：<asp:Label ID="lbZFBName" runat="server" Text="" />
                                <br />
                                支付宝账号:<asp:Label ID="lbZFBAccount" runat="server" Text="" />
                                <br />
                            </asp:View>
                            <asp:View ID="viewShowWX" runat="server">
                                微信账号姓名：<asp:Label ID="lbWXName" runat="server" Text="" />
                                <br />
                                微信账号:<asp:Label ID="lbWXAccount" runat="server" Text="" />
                                <br />
                            </asp:View>
                        </asp:MultiView>
                        账户当前余额：
                        <asp:Label ID="lbTotalAmount" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="dataCell">提现金额：<b><asp:Label ID="ltlDescription" runat="server" Text='<%# Eval("Amount") %>' Font-Size="Medium" ForeColor="Red"></asp:Label>元</b>(提现方式：<asp:Label ID="lbTransferMethod" runat="server" Text='<%# Eval("TransferMethod") %>'></asp:Label>)</td>
                </tr>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <div style="height: 30px;"></div>
        </SeparatorTemplate>
    </asp:Repeater>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" OrderBy="CreateDate" TableName="PaymentDetail" Where="PayStatus == @PayStatus">
        <WhereParameters>
            <asp:Parameter DefaultValue="结清" Name="PayStatus" Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
</asp:Content>

