<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChooseJD.aspx.cs" Inherits="Syb_hsgs_ChooseJD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>指派回收员</title>
</head>
<body>
    <form id="form1" runat="server">
<%--        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div data-role="page" id="page1">
            <div data-role="header">
                <h2>绿宝三益--指派回收员</h2>
            </div>
            <asp:HiddenField ID="hfInfoId" runat="server" />
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <div class="weui-cell weui-cell_vcode">
                        <div class="weui-cell__bd">
                            <p>
                                <asp:Label class="weui-cell weui-check__label" for="s11" ID="Label1" runat="server" Text='<%# Eval("RealName") %>'></asp:Label>
                            </p>
                        </div>
                        <div class="weui-cell__bd">
                            <asp:Button ID="btSure" runat="server" Text="指派他" rel="external" CommandName="Confirm" CommandArgument='<%#Eval("UserId") %>' />
                            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btSure" ConfirmText="确定将该单指派给该业务员？" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" TableName="UserInfo" Where="UserTypeId == @UserTypeId">
                <WhereParameters>
                    <asp:Parameter DefaultValue="5" Name="UserTypeId" Type="Int32" />
                </WhereParameters>
            </asp:LinqDataSource>

            <br />

        </div>--%>
    </form>
</body>
</html>
