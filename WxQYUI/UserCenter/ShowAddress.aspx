<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowAddress.aspx.cs" Inherits="UserCenter_ShowAddress" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>我的地址</title>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="pageMain" data-role="page">
            <div data-role="header">
                <h2>我的地址</h2>
            </div>
            <div data-role="main" class="ui-content">
                <div style="border: 1px dotted #999999; padding: 20px;" class="ui-corner-all">
                    <asp:Literal ID="ltlWholeAreaName" runat="server"></asp:Literal><br />
                    详细地址：<asp:Literal ID="ltlAddress" runat="server"></asp:Literal>
                </div>
                <div class="ui-grid-a">
                    <div class="ui-block-a">
                        <a href="SaveAddress.aspx" data-role="button" rel="external">修改我的地址</a>
                    </div>
                    <div class="ui-block-b">
                        <a href="uc_cfdw.aspx" data-role="button" rel="external">回到个人中心</a>
                    </div>
                </div>



            </div>

        </div>



    </form>
</body>
</html>
