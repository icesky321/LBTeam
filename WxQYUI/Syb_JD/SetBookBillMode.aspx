<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetBookBillMode.aspx.cs" Inherits="Syb_JD_SetBookBillMode" %>

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
    <form id="form1" runat="server" data-ajax="false">
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>接单模式设置</h2>
            </div>
            <div data-role="main" class="ui-content">
                当前接单模式状态：<br />
                <div style="text-align: center; padding: 30px 0 0 0;">
                    <asp:HiddenField ID="hfMode" runat="server" Value="on" />
                    <asp:Label ID="lbMode" runat="server" Text="" Font-Size="1.5em" ForeColor="#6699ff"></asp:Label><br />
                    <br />
                    <div id="divregioncode" runat="server" visible="false">
                        选择您所在的省份：
                <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                        选择您所在的地级市：
                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
                        <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
                        选择您所在的县市：
            <asp:DropDownList ID="ddlCounty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCounty_SelectedIndexChanged"></asp:DropDownList>
                        您所在的镇或街道：
                 <asp:DropDownList ID="ddlStreet" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStreet_SelectedIndexChanged"></asp:DropDownList>
                        <asp:HiddenField ID="hfRegionCode" runat="server" />
                    </div>
                    <asp:Image ID="Image1" runat="server" Width="70%" />
                </div>

                <asp:Button ID="btnSetMode" runat="server" Text="开启接单模式" OnClick="btnSetMode_Click" />
            </div>

        </div>
    </form>
</body>
</html>
