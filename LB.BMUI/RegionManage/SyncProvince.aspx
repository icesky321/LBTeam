<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SyncProvince.aspx.cs" Inherits="SyncProvince" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="border-bottom: 1px solid #808080;">
                <asp:Button ID="btnSync" runat="server" Text="开始同步省份" OnClick="btnSync_Click" />
            </div>
            <div style="border-bottom: 1px solid #808080">
                <asp:TextBox ID="tbSyncCity" runat="server" Height="186px" Width="216px" TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="btnSyncCity" runat="server" Text="同步地级市" OnClick="btnSyncCity_Click" />
            </div>
            <div style="border-bottom: 1px solid #808080; padding: 20px;">
                <asp:TextBox ID="tbSyncCounty" runat="server" Height="186px" Width="216px" TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="btnSyncCounty" runat="server" Text="同步县区" OnClick="btnSyncCounty_Click" />
            </div>
            <div style="border-bottom: 1px solid #808080; padding: 20px;">
                <asp:Button ID="btnSyncStreet" runat="server" Text="同步街道" OnClick="btnSyncStreet_Click"  />
            </div>
        </div>
    </form>
</body>
</html>
