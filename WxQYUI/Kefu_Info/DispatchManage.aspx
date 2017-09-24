<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DispatchManage.aspx.cs" Inherits="Kefu_Info_DispatchManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <title>订单指派管理</title>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
        <asp:HiddenField ID="hfJD_UserMobile" runat="server" />
        <asp:HiddenField ID="hfJD_UserId" runat="server" />
        <asp:HiddenField ID="hfCountTodo" runat="server" Value="0" />
        <asp:HiddenField ID="hfCountDoing" runat="server" Value="0" />
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>派单管理</h2>
                <div data-role="navbar">
                    <ul>
                        <li><a href="#" class="ui-btn-active">待指派订单（<asp:Literal ID="ltlCountTodo1" runat="server" Text='<%# DataBinder.Eval(hfCountTodo,"Value").ToString() %>'></asp:Literal>）</a></li>
                        <li><a href="#page2">已指派未响应订单（<asp:Literal ID="ltlCountProcessing1" runat="server" Text='<%# DataBinder.GetPropertyValue(hfCountDoing,"Value").ToString() %>'></asp:Literal>）</a></li>
                        <li><a href="#page3">已接收订单</a></li>
                    </ul>
                </div>
            </div>
            <div data-role="main" class="ui-content">
                <p style="font-size: 0.8em; color: darkgrey;">产废单位有废电瓶出售意愿，向平台发起出售信息，请指派该出售信息给相应的回收业务员。</p>
                <asp:Repeater ID="rptSellInfoes_Todo" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <div data-role="collapsible" data-collapsed="false">
                            <h3>
                                <asp:Literal ID="ltlTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Literal><span style="float: right;">
                                    <asp:Literal ID="ltlCreateDate" runat="server" Text='<%# Eval("CreateDate", "{0:yyyy-MM-dd HH:mm}") %>'></asp:Literal></span></h3>
                            <p>

                                <asp:Label ID="lbInfoId" runat="server" Text='<%# Eval("InfoId") %>' Visible="false"></asp:Label>
                                卖方(产废单位)：
                                    <asp:Label ID="lbCFRealname" runat="server" Text=""></asp:Label><br />
                                手机号：
                                        <asp:Label ID="lbCFDW" runat="server" Text=""></asp:Label><br />
                                地址：
                                        <asp:Label ID="lbAddress" runat="server" Text=""></asp:Label><br />
                                <asp:Literal ID="ltlDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                <br />
                                状态：<asp:Literal ID="Literal1" runat="server" Text='<%# Eval("StatusMsg") %>'></asp:Literal>
                            </p>
                            <fieldset data-role="controlgroup" data-type="horizontal" data-inline="false">
                                <asp:Button ID="btnAccept" runat="server" Text="指派业务员" data-icon="check" CommandName="Confirm" CommandArgument='<%#Eval("InfoId") %>' rel="external" data-mini="true" data-inline="true" />
                            </fieldset>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


            </div>
            <div data-role="footer" style="text-align: center;">
                <span style="font-size: 0.75em;">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</span>
            </div>
        </div>
        <div id="page2" data-role="page">
            <div data-role="header">
                <h2>派单管理</h2>
                <div data-role="navbar">
                    <ul>
                        <li><a href="#page1">待指派订单（<asp:Literal ID="ltlCountTodo2" runat="server" Text='<%# DataBinder.GetPropertyValue(hfCountTodo,"Value") %>'></asp:Literal>）</a></li>
                        <li><a href="#" class="ui-btn-active">已指派未响应订单（<asp:Literal ID="ltlCountProcessing2" runat="server" Text='<%# DataBinder.GetPropertyValue(hfCountDoing,"Value") %>'></asp:Literal>）</a></li>
                        <li><a href="#page3">已接收订单</a></li>
                    </ul>
                </div>
            </div>
            <div data-role="main" class="ui-content">
                <asp:Repeater ID="rptSellInfoes_Doing" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <div data-role="collapsible" data-collapsed="false">
                            <h3>
                                <asp:Literal ID="ltlTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Literal><span style="float: right;">
                                    <asp:Literal ID="ltlCreateDate" runat="server" Text='<%# Eval("CreateDate", "{0:yyyy-MM-dd HH:mm}") %>'></asp:Literal></span></h3>
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
                            <p style="font-size: 0.9em; color: burlywood;">
                                <label for="fullname">街道回收员：</label>
                                <asp:Label ID="lbjd" runat="server" Text=""></asp:Label>
                                <asp:Label ID="tbjdywy" runat="server" Text=""></asp:Label>
                            </p>
                            <asp:Button ID="btChoose" runat="server" Text="发微信催一下" CommandName="SendWX" CommandArgument='<%#Eval("InfoId") %>' rel="external" data-inline="true" />
                        </div>

                    </ItemTemplate>

                </asp:Repeater>
            </div>
            <div data-role="footer" style="text-align: center;">
                <span style="font-size: 0.75em;">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</span>
            </div>
        </div>
        <div id="page3" data-role="page">
            <div data-role="header">
                <h2>派单管理</h2>
                <div data-role="navbar">
                    <ul>
                        <li><a href="#page1">待指派订单（<asp:Literal ID="ltlCountTodo3" runat="server" Text='<%# DataBinder.GetPropertyValue(hfCountTodo,"Value") %>'></asp:Literal>）</a></li>
                        <li><a href="#page2">已指派未响应订单（<asp:Literal ID="ltlCountProcessing3" runat="server" Text='<%# DataBinder.GetPropertyValue(hfCountDoing,"Value") %>'></asp:Literal>）</a></li>
                        <li><a href="#" class="ui-btn-active">已接收订单</a></li>
                    </ul>
                </div>
            </div>
            <div data-role="main" class="ui-content">
                <asp:Repeater ID="rptSellInfoesClosed" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <div data-role="collapsible" data-collapsed="true">
                            <h3>
                                <asp:Literal ID="ltlTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Literal><span style="float: right;">
                                    <asp:Literal ID="ltlCreateDate" runat="server" Text='<%# Eval("CreateDate", "{0:yyyy-MM-dd HH:mm}") %>'></asp:Literal></span></h3>
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
                            <p style="font-size: 0.9em; color: burlywood;">
                                <label for="fullname">街道回收员：</label>
                                <asp:Label ID="lbjd1" runat="server" Text=""></asp:Label>
                                <asp:Label ID="tbjdywy1" runat="server" Text=""></asp:Label>
                            </p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div data-role="footer" style="text-align: center;">
                <span style="font-size: 0.75em;">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</span>
            </div>
        </div>
    </form>
</body>
</html>
