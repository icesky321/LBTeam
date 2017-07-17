<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="SellInfo_Handle.aspx.cs" Inherits="BusiReview_SellInfo_Handle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .dataCell {
            padding: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-bottom: 30px;">产废单位出售信息接单处理</div>
    <div>
        <asp:HiddenField ID="hfInfoId" runat="server" />
        <asp:HiddenField ID="hfCF_UserId" runat="server" Value="" />
        <asp:HiddenField ID="hfCF_QYUserId" runat="server" Value="" />
        <asp:HiddenField ID="hfRegionCode" runat="server" />
        <table style="max-width: 1000px; min-width: 700px; border: solid 1px #CCCCCC;">
            <tr style="border-top: solid 3px #0094ff;">
                <td class="dataCell" style="border-bottom: solid 1px #CCCCCC;">
                    <div style="float: left;">
                        <asp:Label ID="lbTitle" runat="server" Text=""></asp:Label>
                    </div>
                    <div style="float: right;">
                        <asp:Label ID="lbCreateDate" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td rowspan="2" class="dataCell" style="border-left: solid 1px #CCCCCC; width: 200px; vertical-align: top;">产废单位信息<br />
                    联系人：                               
                            <asp:Label ID="ltlRealName" runat="server" ForeColor="#6699ff"></asp:Label><br />

                    联系电话：                               
                            <asp:Label ID="ltlPhone" runat="server" ForeColor="#6699ff"></asp:Label><br />

                    行政区划：<asp:Label ID="lbRegionWholeName" runat="server" Text="" ForeColor="#6699ff" Font-Bold="true"></asp:Label><br />
                    详细地址：                               
                            <asp:Label ID="ltlAddress" runat="server" ForeColor="#6699ff"></asp:Label><br />

                </td>
            </tr>
            <tr>
                <td class="dataCell">出售信息：<b><asp:Literal ID="ltlDescription" runat="server" Text=""></asp:Literal></b><br />
                    数量：<b><asp:Literal ID="ltlQuantity" runat="server" Text=""></asp:Literal></b></td>

            </tr>
            <tr>
                <td class="dataCell" colspan="2" style="border-top: solid 1px #CCCCCC;">指派回收业务员：<asp:Literal ID="ltlJD_UserName" runat="server"></asp:Literal>
                    <asp:HiddenField ID="hfJD_UserId" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="dataCell" colspan="2" style="border-top: solid 1px #CCCCCC;">客服留言：<br />
                    <asp:TextBox ID="tbRemark" runat="server" Rows="2" TextMode="MultiLine" Width="100%" Style="margin-bottom: 10px;"></asp:TextBox>
                    <asp:Button ID="btnAccept" runat="server" Text="审核通过" BorderStyle="Solid" BorderColor="#CCCCCC" CommandName="Accept" CommandArgument='<%# Eval("InfoId") %>' OnCommand="CommandButton_Click" />&nbsp;&nbsp;
                            <asp:Button ID="btnReject" runat="server" Text="作废，关闭信息" BorderStyle="Solid" BorderColor="#CCCCCC" CommandName="Reject" CommandArgument='<%# Eval("InfoId") %>' OnCommand="CommandButton_Click" />&nbsp;&nbsp;
                </td>

            </tr>
        </table>
    </div>
</asp:Content>

