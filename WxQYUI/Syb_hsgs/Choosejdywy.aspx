<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Choosejdywy.aspx.cs" Inherits="Syb_hsgs_Choosejdywy" %>

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
    <title>绿宝三益--指派回收员</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="page1" data-role="page"  runat="server">
            <div class="weui-cells__title">
                <h2>指派回收员</h2>
            </div>
            <asp:HiddenField ID="hfInfoId" runat="server" />
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <div class="weui-cell weui-cell_vcode">
                        <div class="weui-cell__bd">
                            <p>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("RealName") %>'></asp:Label>
                            </p>
                        </div>
                        <div class="weui-cell__bd">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btSure" runat="server" Text="指派他" rel="external" CommandName="Confirm" CommandArgument='<%#Eval("UserId") %>' />
                                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btSure" ConfirmText="确定将该单指派给该业务员？" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" TableName="UserInfo" Where="UserTypeId == @UserTypeId &amp;&amp; IsQYUser == @IsQYUser">
                <WhereParameters>
                    <asp:Parameter DefaultValue="5" Name="UserTypeId" Type="Int32" />
                    <asp:Parameter DefaultValue="true" Name="IsQYUser" Type="Boolean" />
                </WhereParameters>
            </asp:LinqDataSource>
            <br />
        </div>

        <div id="pageRegCompleted" data-role="page" runat="server">

            <div data-role="main" class="ui-content">
                <div class="weui-msg">
                    <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">操作成功</h2>
                        <p class="weui-msg__desc">您已成功指派回收业务员处理该信息</p>
                    </div>
                    <div id="show">
                        <input type="button" value="关闭本窗口" onclick="WeixinJSBridge.call('closeWindow');" />
                    </div>
                    <div class="weui-msg__extra-area">
                        <div class="weui-footer">
                            <p class="weui-footer__links">
                                <a href="javascript:void(0);" class="weui-footer__link"></a>
                            </p>
                            <p class="weui-footer__text">Copyright &copy; 2016-2017 lvbao111.com</p>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </form>
</body>
</html>
