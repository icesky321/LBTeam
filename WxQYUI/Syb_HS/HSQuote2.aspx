<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HSQuote2.aspx.cs" Inherits="Syb_HS_HSQuote2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.min.css" rel="stylesheet" />
    <title>回收公司报价</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>电瓶回收报价</h2>
            </div>
            <div data-role="main" class="ui-content">
                <div>
                    当前选定的电瓶品种为：<asp:Literal ID="ltlTSName" runat="server"></asp:Literal>
                </div>
                <p>按不同的市域分别报价</p>
                <ul data-role="listview">
                    <li style="padding: 0; margin: 0;">
                        <table style="width: 100%; border-collapse: collapse;">
                            <tr>
                                <td>宁波市</td>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server" BorderStyle="None" Style="border: 0 none;" CssClass="tbPrice"></asp:TextBox></td>
                                <td>吨</td>
                            </tr>
                        </table>
                    </li>
                    <li></li>
                </ul>


            </div>
            <div data-role="footer">
                <h2>footer</h2>
            </div>
        </div>
    </form>
</body>
</html>
