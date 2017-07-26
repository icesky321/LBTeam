<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Quote.aspx.cs" Inherits="Syb_HS_Quote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <%--    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>--%>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.min.css" rel="stylesheet" />
    <title>电瓶回收报价</title>
</head>
<body ontouchstart>
    <form id="form1" runat="server">
        <div id="page1" data-role="page">
            <div class="weui-cells__title">
                废旧电瓶分类报价

                 
            </div>
            <div class="weui-cells weui-cells_form">
                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="LinqDataSource1">
                    <ItemTemplate>
                        <div class="weui-cell weui-cell_vcode">
                            <div class="weui-cell__hd">
                                <label class="weui-label">
                                    <asp:HiddenField ID="hfTSId" runat="server" Value='<%# Eval("TSId") %>' />
                                    <asp:Literal ID="ltlTSName" runat="server" Text='<%# Eval("TSName") %>'></asp:Literal></label>
                            </div>
                            <div class="weui-cell__bd">
                                <asp:TextBox ID="tbQuotedPrice" runat="server" class="weui-input" type="text" placeholder="请输入报价"></asp:TextBox>
                            </div>
                            <div class="weui-cell__ft">
                                <asp:Button ID="btnAlone" runat="server" class="weui-vcode-btn" Text="单独报价" CommandName="OneQuote" CommandArgument='<%# Eval("TSName") %>' OnCommand="btnQuote1_Command"></asp:Button>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" OrderBy="TSId" Select="new (TSId, TSName)" TableName="TSInfo"></asp:LinqDataSource>


            </div>
            <div class="weui-cells__title"></div>
            <div data-role="page">
                <asp:Button ID="btnOneClickQuote" runat="server" Text="一键全部报价" class="weui-btn weui-btn_primary" OnClick="btnOneClickQuote_Click" />
            </div>


        </div>

        <div class="page">
            <div class="page__bd">
                <div class="weui-cells__title">今日电瓶报价</div>
                <div class="weui-cells">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="weui-cell">
                                <div class="weui-cell__hd">
                                    <label class="weui-label">
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("TSName").ToString() %>'></asp:Literal>
                                    </label>
                                </div>
                                <div class="weui-cell__bd">
                                    <p>
                                        <asp:Literal ID="Literal2" runat="server" Text='<%# "<b>"+ Eval("QuotedPrice").ToString() + "</b>" %>'></asp:Literal>
                                    </p>
                                </div>
                                <div class="weui-cell__ft">
                                    <asp:Button ID="lbtnDelete" runat="server" class="weui-btn weui-btn_mini weui-btn_default" CommandName="Delete" CommandArgument='<%# Eval("QuotId") %>' OnCommand="lbtnDelete_Command" Text="删除"></asp:Button>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <label for="weuiAgree" class="weui-agree">

                    <span class="weui-agree__text">须知：废旧电瓶回收报价信息由本地回收公司发布，本报价信息供本市域范围内回收业务员参考。
                        本报价信息不向产废单位提供。
                    </span>
                </label>
            </div>
            <div class="page__bd page__bd_spacing">
                <br>
                <br>
                <div class="weui-footer">
                    <p class="weui-footer__links">
                        <a href="javascript:void(0);" class="weui-footer__link"></a>
                    </p>
                    <p class="weui-footer__text">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</p>
                </div>

            </div>
        </div>

    </form>
</body>
</html>
