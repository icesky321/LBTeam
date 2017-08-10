<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QueryCF.aspx.cs" Inherits="Syb_HS_QueryCF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>产废单位统计</h2>
            </div>
            <div data-role="main" class="ui-content">
                <asp:HiddenField ID="hfUserMobile" runat="server" />
                <asp:HiddenField ID="hfHS_UserId" runat="server" />
                <asp:HiddenField ID="hfCityRegionCode" runat="server" />
                <p>
                    <asp:Literal ID="ltlCityWholeName" runat="server"></asp:Literal>
                </p>
                <asp:Repeater ID="rptCounty" runat="server" OnItemDataBound="rptCounty_ItemDataBound">
                    <ItemTemplate>
                        <div data-role="collapsible">
                            <h3>
                                <asp:Literal ID="ltlCountyName" runat="server" Text='<%# Eval("AreaName") %>'></asp:Literal><span class="ui-li-count">
                                    <asp:Literal ID="ltlUserNum" runat="server"></asp:Literal></span></h3>

                            <asp:Repeater ID="rptStreet" runat="server" OnItemDataBound="rptStreet_ItemDataBound">
                                <HeaderTemplate>
                                    <ul data-role="listview" style="background-color: white ;">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <a href="#">
                                            <asp:Literal ID="ltlStreetName" runat="server" Text='<%# Eval("AreaName") %>'></asp:Literal>
                                            <span class="ui-li-count">
                                                <asp:Literal ID="ltlUserNum" runat="server"></asp:Literal>
                                            </span>
                                        </a></li>

                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>

                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>

        </div>
    </form>
</body>
</html>
