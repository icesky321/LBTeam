<%@ Page Title="回收公司报价查询" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="ShowQuotation.aspx.cs" Inherits="BusiQuery_ShowQuotation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .tdTitle {
            padding: 5px;
            border-bottom: 2px solid #808080;
        }

        .rowHead {
            height: 30px;
        }

        .rowData {
            height: 40px;
            color: darkred;
        }

            .rowData:hover {
                background-color: #7ffeac;
            }

            .rowData td {
                padding: 5px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
    <div style="padding: 20px 0 20px 0; font-size: 1.5em; font-family: 'Microsoft JhengHei'; font-weight: bold;">
        回收公司报价平台
    </div>
    <div>区域：浙江省 杭州市</div>
    <div style="padding: 20px 0 0px 0;">
        <asp:LinkButton ID="lbtnQuote" runat="server" PostBackUrl="~/Quotation/Quote.aspx">我要报价</asp:LinkButton>
    </div>
    <div style="padding: 20px 0 50px 0;">
        <asp:DropDownList ID="ddlHS" runat="server"></asp:DropDownList>
        <asp:HiddenField ID="hfUserId" runat="server" Value="" />
        <asp:HiddenField ID="hfCityCode" runat="server" Value="330100000000" />
        <asp:Repeater ID="rptTS" runat="server" OnItemDataBound="rptTS_ItemDataBound">
            <HeaderTemplate>
                <table style="border-collapse: collapse; border-top: 2px solid #000000; width: 100%;">
                    <tr class="rowHead">
                        <td class="tdTitle" style="width: 80px;">品种\区县</td>
                        <asp:Repeater ID="rptRegion" runat="server">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfCountyCode" runat="server" Value='<%# Eval("Id") %>' />
                                <td style="width: 100px;" class="tdTitle">
                                    <asp:Literal ID="ltlRegionName" runat="server" Text='<%# Eval("AreaName") %>'></asp:Literal>
                                </td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="border-bottom: solid 1px #bebebe;" class="rowData">
                    <td style="width: 80px; text-align: left;">
                        <asp:Literal ID="ltlTSName" runat="server" Text='<%# Eval("TSName") %>'></asp:Literal><br />
                        <asp:Literal ID="ltlUnit" runat="server" Text='<%# "(元/"+ Eval("ChargeUnit").ToString() + ")" %>'></asp:Literal>
                        <asp:HiddenField ID="hfTsCode" runat="server" Value='<%# Eval("TsCode") %>' />
                    </td>

                    <asp:Repeater ID="rptRegion2" runat="server" OnItemDataBound="rptRegion2_ItemDataBound">
                        <ItemTemplate>
                            <td style="width: 100px;">
                                <asp:Literal ID="ltlPrice" runat="server" Text=""></asp:Literal>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
