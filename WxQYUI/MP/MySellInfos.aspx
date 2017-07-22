<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MySellInfos.aspx.cs" Inherits="MP_MySellInfos" %>

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
                <h2>我的出售</h2>
                <div data-role="navbar">
                    <ul>
                        <li><a href="#" class="ui-btn-active">进行中（<asp:Literal ID="ltlCount" runat="server"></asp:Literal>）</a></li>
                        <li><a href="#page2">历史消息</a></li>
                    </ul>
                </div>
            </div>
            <div data-role="content" class="ui-content">
                <asp:HiddenField ID="hfUserMobile" runat="server" />
                <asp:HiddenField ID="hfUserId" runat="server" />
                <asp:Repeater ID="rptSellInfos" runat="server">
                    <ItemTemplate>
                        <div data-role="collapsible" data-collapsed="false">
                            <h3>
                                <asp:Literal ID="ltlTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Literal><span style="float: right;">
                                    <asp:Literal ID="ltlCreateDate" runat="server" Text='<%# Eval("CreateDate", "{0:yyyy-MM-dd hh:mm}") %>'></asp:Literal></span></h3>
                            <p>
                                <asp:Literal ID="ltlDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                <br />
                                状态：<asp:Literal ID="ltlStatusMsg" runat="server" Text='<%# Eval("StatusMsg") %>'></asp:Literal>
                            </p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>

        <div id="page2" data-role="page">
            <div data-role="header">
                <h2>我的出售</h2>
                <div data-role="navbar">
                    <ul>
                        <li><a href="#page1">进行中（<asp:Literal ID="ltlCount2" runat="server"></asp:Literal>）</a></li>
                        <li><a href="#" class="ui-btn-active">历史消息</a></li>
                    </ul>
                </div>
            </div>
            <div data-role="content" class="ui-content">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <asp:Repeater ID="rptSellInfos2" runat="server">
                    <ItemTemplate>
                        <div data-role="collapsible" data-collapsed="false">
                            <h3>
                                <asp:Literal ID="ltlTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Literal><span style="float: right;">
                                    <asp:Literal ID="ltlCreateDate" runat="server" Text='<%# Eval("CreateDate", "{0:yyyy-MM-dd hh:mm}") %>'></asp:Literal></span></h3>
                            <p>
                                <asp:Literal ID="ltlDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                <br />
                                状态：<asp:Literal ID="Literal1" runat="server" Text='<%# Eval("StatusMsg") %>'></asp:Literal>
                            </p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
    </form>
</body>
</html>
