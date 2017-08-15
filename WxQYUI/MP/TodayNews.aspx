<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TodayNews.aspx.cs" Inherits="MP_TodayNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>今日资讯</title>
</head>
<body>
    <form id="form1" runat="server">
        <%--        <div class="page">
            <div class="page__hd">
                <div style="border: 1px dotted #999999; padding: 20px; margin: 10px 5px 0 5px;" class="ui-corner-all">
                    今日电瓶资讯：<asp:Literal ID="ltlRegionWholeName" runat="server"></asp:Literal>
                    <asp:HiddenField ID="hfCountyId" runat="server" />
                </div>
            </div>
        </div>--%>

        <div data-role="page" id="pageone">
            <div data-role="main" class="ui-content">
                <h2>今日电瓶资讯:</h2>
                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="LinqDataSource1">
                    <ItemTemplate>
                        <ul>
                            <li data-icon="collapsible"><a href="#">
                                <div data-role="collapsible">
                                    <h2>
                                        <label class="weui-label">
                                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Title").ToString() %>'></asp:Literal>（点击查看）<br />
                                            <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("ShowTime").ToString() %>'></asp:Literal>
                                        </label>
                                    </h2>
                                    <div class="weui-cells">
                                        <div class="weui-cell">
                                            <%--   <div class="weui-cell__bd">
                                                <p>公司名称：</p>
                                            </div>
                                            <div class="weui-cell__ft">宁波绿宝信息科技有限公司</div>--%>
                                            <asp:Label ID="lbContent" runat="server" Text='<%# Eval("Content").ToString() %>' Width="640px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </a></li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" OrderBy="ShowTime desc" TableName="NewsInfo" Where="ShowTime &gt; @ShowTime &amp;&amp; ShowTime &lt; @ShowTime1 &amp;&amp; NewsTypeId == @NewsTypeId">
                    <WhereParameters>
                        <asp:ControlParameter ControlID="hfBeginDate" Name="ShowTime" PropertyName="Value" Type="DateTime" />
                        <asp:ControlParameter ControlID="hfEndDate" Name="ShowTime1" PropertyName="Value" Type="DateTime" />
                        <asp:Parameter DefaultValue="2" Name="NewsTypeId" Type="Int32" />
                    </WhereParameters>
                </asp:LinqDataSource>
                <asp:HiddenField ID="hfBeginDate" runat="server" />
                <asp:HiddenField ID="hfEndDate" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
