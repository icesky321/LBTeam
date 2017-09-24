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
                    <asp:Image ID="Image1" runat="server" Width="70%" />
                </div>

                <asp:Button ID="btnSetMode" runat="server" Text="开启接单模式" OnClick="btnSetMode_Click" />
            </div>

        </div>
    </form>
</body>
</html>
