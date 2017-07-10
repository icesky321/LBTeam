<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Syb_Dyywy_Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>111</asp:ListItem>
                <asp:ListItem>222</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <div data-role="content">

                <ul data-role="listview">
                    <li><a href="#page2" data-transition="slide">关于绿宝</a></li>
                    <li><a href="cjwt.aspx" data-transition="slide" rel="external">常见问题</a></li>
                    <li data-role="list-divider"></li>
                    <li>客服热线<br />
                        0574-86694505  (周一至周五 8:00-17:00)

                    </li>
                    <li data-role="list-divider"></li>
                    <li><a href="#page3" data-transition="slide">联系我们</a></li>
                    <li><a href="#">加入我们</a></li>
                    <li><a href="#">意见反馈</a></li>
                    <li data-role="list-divider"></li>
                    <li><a href="http://www.lvbao111.com/">访问绿宝PC版网站</a></li>
                </ul>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-lg btn-primary btn-block" />
        </div>
    </form>
</body>
</html>
