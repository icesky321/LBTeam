﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRealName.aspx.cs" Inherits="UserCenter_EditRealName" %>

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
    <form id="form1" runat="server" data-ajax="false">
        <div id="pageMain" data-role="page">
            <div data-role="header">
                <h2>我的姓名</h2>
            </div>
            <div data-role="main" class="ui-content">

                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewRealName" runat="server">
                        <div style="border: 1px dotted #999999; padding: 20px;" class="ui-corner-all">
                            真实姓名：<asp:Literal ID="ltlRealName" runat="server"></asp:Literal>

                        </div>
                        <asp:Button ID="btnEditRealName" runat="server" Text="修改" OnClick="btnEditRealName_Click" data-icon="edit" />
                    </asp:View>
                    <asp:View ID="viewEditRealName" runat="server">
                        真实姓名：<asp:TextBox ID="tbRealName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSaveRealName" runat="server" Text="确定保存" OnClick="btnSaveRealName_Click" data-icon="check" />
                    </asp:View>
                </asp:MultiView>

                <div style="border-bottom: 1px solid #999999; height: 2px; margin: 20px 0 20px 0;"></div>

                <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewShowNiChen" runat="server">
                        <div style="border: 1px dotted #999999; padding: 20px;" class="ui-corner-all">
                            昵称：<asp:Literal ID="ltlNiChen" runat="server"></asp:Literal>

                        </div>
                        <asp:Button ID="btnEditNiChen" runat="server" Text="修改" OnClick="btnEditNiChen_Click" data-icon="edit" />
                    </asp:View>
                    <asp:View ID="viewEditNiChen" runat="server">
                        昵称：<asp:TextBox ID="tbNiChen" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSaveNiChen" runat="server" Text="确定保存" OnClick="btnSaveNiChen_Click" data-icon="check" />
                    </asp:View>
                </asp:MultiView>
                <div style="height: 60px;"></div>
                
            </div>

        </div>
    </form>
</body>
</html>
