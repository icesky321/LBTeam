<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Choose_JD_Manage.aspx.cs" Inherits="Syb_hsgs_Choose_JD_Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>指派业务员管理</title>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
        <div class="weui-form-preview">
            <div class="weui-form-preview__bd">

                <div class="weui-cells">
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <div class="weui-cells weui-cells_form">
                                <label class="weui-form-preview__label"></label>
                                <span class="weui-form-preview__value">
                                    <label class="weui-label">
                                    </label>
                                </span>
                            </div>
                            <div data-role="collapsible" data-collapsed="false">
                                <h3>
                                    <asp:Literal ID="ltlTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Literal><span style="float: right;">
                                        <asp:Literal ID="ltlCreateDate" runat="server" Text='<%# Eval("CreateDate", "{0:yyyy-MM-dd hh:mm}") %>'></asp:Literal></span></h3>
                                <p>

                                    <asp:Label ID="lbInfoId" runat="server" Text='<%# Eval("InfoId") %>' Visible="false"></asp:Label>
                                    卖方(产废单位)
                                    <asp:Label ID="lbCFRealname" runat="server" Text=""></asp:Label><br />
                                    手机号：
                                        <asp:Label ID="lbCFDW" runat="server" Text=""></asp:Label><br />
                                    地址：
                                        <asp:Label ID="lbAddress" runat="server" Text=""></asp:Label><br />
                                    <asp:Literal ID="ltlDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                    <br />
                                    状态：<asp:Literal ID="Literal1" runat="server" Text='<%# Eval("StatusMsg") %>'></asp:Literal>
                                </p>
                            </div>
                            <div class="weui-form-preview__item">
                                <asp:Button ID="btChoose" runat="server" Text="查看详情" CommandName="Confirm" CommandArgument='<%#Eval("InfoId") %>'  rel="external"/>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="hfHS_UserId" runat="server" />

                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" TableName="SellInfo" Where="HS_UserId == @HS_UserId &amp;&amp; HS_TohandleTag == @HS_TohandleTag &amp;&amp; IsClosed == @IsClosed">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="hfHS_UserId" Name="HS_UserId" PropertyName="Value" Type="Int32" />
                            <asp:Parameter DefaultValue="True" Name="HS_TohandleTag" Type="Boolean" />
                            <asp:Parameter DefaultValue="False" Name="IsClosed" Type="Boolean" />
                        </WhereParameters>
                    </asp:LinqDataSource>

                </div>

            </div>
        </div>
    </form>
</body>
</html>
