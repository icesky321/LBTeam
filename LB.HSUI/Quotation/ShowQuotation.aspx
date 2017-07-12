<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowQuotation.aspx.cs" Inherits="Quotation_ShowQuotation" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        .tdTitle {
            padding: 5px;
            border-bottom: 2px solid #808080;
        }

        .row:link {
            color: #11ef06;
            text-decoration: none;
        }

        .row:hover {
            background-color: #7ffeac;
            text-decoration: none;
        }
    </style>
    <title></title>
</head>
<body style="padding: 0 20px 0 20px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div style="padding: 20px 0 20px 0; font-size: 1.5em; font-family: 'Microsoft JhengHei'; font-weight: bold;">
            回收公司报价平台
        </div>
        <div>区域：浙江省 杭州市</div>
        <div style="padding: 20px 0 0px 0;">
            <asp:LinkButton ID="lbtnQuote" runat="server" PostBackUrl="~/Quotation/Quote.aspx">我要报价</asp:LinkButton>
        </div>
        <div style="padding: 20px 0 10px 0;">
            <asp:HiddenField ID="hfUserId" runat="server" Value="" />
            <asp:HiddenField ID="hfCityCode" runat="server" Value="330100000000" />
            <asp:Repeater ID="rptRegion" runat="server" OnItemDataBound="rptRegion_ItemDataBound">
                <HeaderTemplate>
                    <table style="border-collapse: collapse; border-top: 2px solid #000000;">
                        <thead>
                            <td class="tdTitle">区县\品种</td>
                            <asp:Repeater ID="rptTS" runat="server">
                                <ItemTemplate>
                                    <td style="width: 120px;" class="tdTitle">
                                        <asp:Literal ID="ltlTSName" runat="server" Text='<%# Eval("TSName") %>'></asp:Literal><br />
                                        <asp:Literal ID="ltlUnit" runat="server" Text='<%# "(元/"+ Eval("ChargeUnit").ToString() + ")" %>'></asp:Literal>
                                    </td>
                                </ItemTemplate>
                            </asp:Repeater>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="height: 40px; border-bottom: solid 1px #bebebe;" class="row">
                        <td>
                            <asp:Literal ID="ltlRegionName" runat="server" Text='<%# Eval("AreaName") %>'></asp:Literal>
                            <asp:HiddenField ID="hfCountyCode" runat="server" Value='<%# Eval("Id") %>' />
                        </td>

                        <asp:Repeater ID="rptTS2" runat="server" OnItemDataBound="rptTS2_ItemDataBound">
                            <ItemTemplate>
                                <td style="width: 100px;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Literal ID="ltlPrice" runat="server" Text=""></asp:Literal>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
    </form>
</body>
</html>
