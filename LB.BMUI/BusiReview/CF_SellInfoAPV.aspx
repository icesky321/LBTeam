<%@ Page Title="产废单位出售信息审核" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="CF_SellInfoAPV.aspx.cs" Inherits="BusiReview_CF_SellInfoAPV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .dataCell {
            padding: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-bottom: 30px;">产废单位出售信息审核</div>
    <div>
        待审核记录数：<asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <table style="max-width: 1000px; min-width: 700px; border: solid 1px #CCCCCC;">
                    <tr style="border-top: solid 3px #0094ff;">
                        <td class="dataCell" style="border-bottom: solid 1px #CCCCCC;">
                            <div style="float: left;">
                                <asp:Label ID="lbTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                            </div>
                            <div style="float: right;">
                                <asp:Label ID="lbCreateDate" runat="server" Text='<%# Eval("CreateDate") %>'></asp:Label>
                            </div>
                        </td>
                        <td rowspan="2" class="dataCell" style="border-left: solid 1px #CCCCCC; width: 200px; vertical-align: top;">产废单位信息<br />
                            <asp:HiddenField ID="hfQYUserId" runat="server" Value="" />
                            联系人：                               
                            <asp:Label ID="ltlRealName" runat="server" ForeColor="#6699ff"></asp:Label><br />

                            联系电话：                               
                            <asp:Label ID="ltlPhone" runat="server" ForeColor="#6699ff"></asp:Label><br />

                            联系地址：                               
                            <asp:Label ID="ltlAddress" runat="server" ForeColor="#6699ff"></asp:Label><br />

                        </td>
                    </tr>
                    <tr>
                        <td class="dataCell">出售信息：<b><asp:Literal ID="ltlDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal></b><br />
                            数量：<b><asp:Literal ID="ltlQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Literal></b></td>

                    </tr>
                    <tr>
                        <td class="dataCell" colspan="2" style="border-top: solid 1px #CCCCCC;">
                            <asp:Button ID="btnHandle" runat="server" Text="接单处理" BorderStyle="Solid" BorderColor="#CCCCCC" CommandName="ToHandle" CommandArgument='<%# Eval("InfoId") %>' />
                        </td>

                    </tr>
                </table>
            </ItemTemplate>
            <SeparatorTemplate>
                <div style="height: 30px;"></div>
            </SeparatorTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetSellInfo_ByKefuTohandleTag" TypeName="LB.BLL.SellInfoManage">
            <SelectParameters>
                <asp:Parameter DefaultValue="true" Name="kefuToHandleTag" Type="Boolean" />
                <asp:Parameter DefaultValue="5" Name="count" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

