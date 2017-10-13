<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderManage.aspx.cs" Inherits="Syb_JD_OrderManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <title>订单管理</title>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
        <asp:HiddenField ID="hfJD_UserMobile" runat="server" />
        <asp:HiddenField ID="hfJD_UserId" runat="server" />

        <asp:HiddenField ID="hfCountTodo" runat="server" Value="0" />
        <asp:HiddenField ID="hfCountDoing" runat="server" Value="0" />
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>接单管理</h2>
                <div data-role="navbar">
                    <ul>
                        <li><a href="#" class="ui-btn-active">未接单（<asp:Literal ID="ltlCountTodo1" runat="server" Text='<%# DataBinder.Eval(hfCountTodo,"Value").ToString() %>'></asp:Literal>）</a></li>
                        <li><a href="#page2">已接单（<asp:Literal ID="ltlCountProcessing1" runat="server" Text='<%# DataBinder.GetPropertyValue(hfCountDoing,"Value").ToString() %>'></asp:Literal>）</a></li>
                        <li><a href="#page3">历史订单</a></li>
                    </ul>
                </div>
            </div>
            <div data-role="main" class="ui-content">
                <p style="font-size: 0.8em; color: darkgrey;">产废单位有废电瓶出售意愿，向平台发起出售信息，经平台初步审核后，将会发送给相应的回收业务员。</p>
                <div id="divDataEmptyPrompt1" runat="server" visible="false" style="border: 1px solid #808080; padding: 5em 3em 5em 3em; text-align: center; vertical-align: middle; border-radius: 10px; color: chocolate;">
                    任务已接，请在12小时内尽快处理业务单<br />
                    <%--<asp:Button ID="btnQuickReg" runat="server" Text="快速注册产废单位通道" rel="external" OnClick="btnQuickReg_Click" />--%>
                </div>
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
                                <asp:Label ID="lbCFDW" runat="server" Text=""></asp:Label>
                                <asp:HyperLink ID="HyperLink1" runat="server">点击拨打此号码</asp:HyperLink>
                                <%--<a href="tel://15267863162" runat="server">111</a>--%>
                                <br />
                                地址：
                                        <asp:Label ID="lbAddress" runat="server" Text=""></asp:Label><%--<asp:Button ID="btCopy" runat="server" Text="点击复制此地址" CommandName="Copy" CommandArgument='<%#Eval("InfoId") %>' />--%>
                                <br />
                                <asp:Literal ID="ltlDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                <br />
                                状态：<asp:Literal ID="Literal1" runat="server" Text='<%# Eval("StatusMsg") %>'></asp:Literal>
                            </p>
                            <fieldset data-role="controlgroup" data-type="horizontal" data-inline="false">
                                <asp:Button ID="btnAccept" runat="server" Text="接单" data-icon="check" CommandName="Accept" CommandArgument='<%#Eval("InfoId") %>' rel="external" data-mini="true" data-inline="true" OnClientClick='return confirm("确定要接单吗？");' />
                                <asp:Button ID="btnReject" runat="server" Text="拒单" data-icon="delete" CommandName="Reject" CommandArgument='<%# Eval("InfoId") %>' rel="external" data-mini="true" data-inline="true" OnClientClick='return confirm("确定此单作废吗？");' Visible="false" />
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
                <h2>接单管理</h2>
                <div data-role="navbar">
                    <ul>
                        <li><a href="#page1">未接单（<asp:Literal ID="ltlCountTodo2" runat="server" Text='<%# DataBinder.GetPropertyValue(hfCountTodo,"Value") %>'></asp:Literal>）</a></li>
                        <li><a href="#" class="ui-btn-active">已接单（<asp:Literal ID="ltlCountProcessing2" runat="server" Text='<%# DataBinder.GetPropertyValue(hfCountDoing,"Value") %>'></asp:Literal>）</a></li>
                        <li><a href="#page3">历史订单</a></li>
                    </ul>
                </div>
            </div>
            <div data-role="main" class="ui-content">
                <div id="divDataEmptyPrompt2" runat="server" visible="false" style="border: 1px solid #808080; padding: 5em 3em 5em 3em; text-align: center; vertical-align: middle; border-radius: 10px; color: chocolate;">
                    当前无废旧电瓶出售信息，请尽快发展您自己的产废单位吧。
                </div>
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
                                        <asp:Label ID="lbCFDW" runat="server" Text=""></asp:Label>
                                <asp:HyperLink ID="HyperLink1" runat="server">点击拨打此号码</asp:HyperLink><br />
                                地址：
                                        <asp:Label ID="lbAddress" runat="server" Text=""></asp:Label><br />
                                <asp:Literal ID="ltlDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                <br />
                                状态：<asp:Literal ID="Literal1" runat="server" Text='<%# Eval("StatusMsg") %>'></asp:Literal>
                            </p>
                            <p style="font-size: 0.9em; color: burlywood;">
                                接单后，请尽快与产废单位联系，并安排上门收货。清点货物完毕，请点击“登记收货信息”按钮，开始登记并创建收货单据。
                            </p>
                            <asp:Button ID="btChoose" runat="server" Text="登记收货信息" CommandName="Confirm" CommandArgument='<%#Eval("InfoId") %>' rel="external" data-inline="true" />
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
                <h2>接单管理</h2>
                <div data-role="navbar">
                    <ul>
                        <li><a href="#page1">未接单（<asp:Literal ID="ltlCountTodo3" runat="server" Text='<%# DataBinder.GetPropertyValue(hfCountTodo,"Value") %>'></asp:Literal>）</a></li>
                        <li><a href="#page2">已接单（<asp:Literal ID="ltlCountProcessing3" runat="server" Text='<%# DataBinder.GetPropertyValue(hfCountDoing,"Value") %>'></asp:Literal>）</a></li>
                        <li><a href="#" class="ui-btn-active">历史订单</a></li>
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
                                        <asp:Label ID="lbCFDW" runat="server" Text=""></asp:Label>
                                <asp:HyperLink ID="HyperLink1" runat="server">点击拨打此号码</asp:HyperLink><br />
                                地址：
                                        <asp:Label ID="lbAddress" runat="server" Text=""></asp:Label><br />
                                <asp:Literal ID="ltlDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                <br />
                                状态：<asp:Literal ID="Literal1" runat="server" Text='<%# Eval("StatusMsg") %>'></asp:Literal>
                            </p>
                        </div>
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
