<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellInfoAPV.aspx.cs" Inherits="Syb_HS_SellInfoAPV" %>

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
                <h2>工单指派</h2>

            </div>
            <div data-role="main" class="ui-content">
                <asp:HiddenField ID="hfSellInfoId" runat="server" />
                <asp:HiddenField ID="hfhs_userId" runat="server" />
                <asp:HiddenField ID="hfhs_mobileNum" runat="server" />
                <p>指派本区回收业务员处理产废单位的出售请求信息</p>
                <div data-role="collapsible" data-collapsed="false">
                    <h2>
                        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h2>
                    <p>
                        <asp:Literal ID="ltlDescription" runat="server"></asp:Literal><br />
                        数量：<asp:Literal ID="ltlQuantity" runat="server"></asp:Literal><br />
                        <br />
                        联系人：<asp:Literal ID="ltlRealName" runat="server"></asp:Literal><br />
                        电话：<asp:Literal ID="ltlMobileNum" runat="server"></asp:Literal><br />
                        详细地址：<asp:Literal ID="ltlAddress" runat="server"></asp:Literal><br />
                        <br />
                        绿宝审核备注：<asp:Literal ID="ltlLvbaoLeaveMsg" runat="server"></asp:Literal>
                    </p>
                </div>
                <div>
                    指派回收业务员：<asp:DropDownList ID="ddlJD" runat="server"></asp:DropDownList>
                    附言：
                    <asp:TextBox ID="tbRemark" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
                <div id="divMsg" runat="server" visible="false">
                    <p style="color: red;">该笔业务已经处理，无需再次处理。</p>
                </div>
                <asp:Button ID="btnAllocation" runat="server" Text="确定指派" OnClick="btnAllocation_Click" />
            </div>

        </div>
    </form>
</body>
</html>
