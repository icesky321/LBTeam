<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateLeads.aspx.cs" Inherits="MP_CreateLeads" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>发布出售信息</title>
</head>
<!-- 本页面街道业务员调用，创建电瓶出卖信息。 -->
<body>
    <form id="form1" runat="server" data-ajax="false">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <div data-role="page" id="page1">
            <div data-role="main" class="ui-content">
                <asp:Button ID="btSearch" runat="server" Text="查询今日回收价格" OnClick="btSearch_Click" rel="external" />
                <div style="font-size: 1em; color: red; padding: 1em;">
                    温馨提示：产废单位下单后，如果平台业务员电话确认并已到店，此时产废单位出现主动废单情况，业务员将收取100元车油费。
                </div>
                <fieldset data-role="controlgroup">
                    <legend>您要出售的电瓶品种</legend>
                    <asp:CheckBoxList ID="cblDP" runat="server" RepeatLayout="UnorderedList">
                    </asp:CheckBoxList>
                </fieldset>
                <div class="ui-field-contain">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <label for="fname">大约数量:</label></td>
                            <td>
                                <input type="text" name="fname" id="tbVolume" runat="server" placeholder="大约数量 吨/组/个" /></td>
                        </tr>
                    </table>
                    <label for="info">附加信息：</label>
                    <input id="tbAdditionText" runat="server" textmode="MultiLine" rows="2" />


                </div>
                <div style="border-bottom: 1px solid #cccccc"></div>
                <asp:HiddenField ID="hfImcomplete" runat="server" Value="false" />
                <div id="coll1" runat="server" data-role="collapsible">
                    <h2>卖方信息<asp:Literal ID="ltlContactMsg" runat="server"></asp:Literal></h2>
                    <p>
                        联系人：<asp:Literal ID="ltlRealName" runat="server"></asp:Literal><br />
                        联系电话：<asp:Literal ID="ltlTelNum" runat="server"></asp:Literal><br />
                        联系地址：<asp:Literal ID="ltlAddress" runat="server"></asp:Literal><br />
                        <a href="../UserCenter/uc_cfdw.aspx" rel="external">编辑个人信息</a>
                    </p>
                </div>
                <%--                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnSubmit" runat="server" Text="发布" data-role="button" OnClick="btnSubmit_Click" />
                <%--                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
            <div data-role="footer">
                <div class="page__bd page__bd_spacing">

                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:void(0);" class="weui-footer__link"></a>
                        </p>
                        <p class="weui-footer__text">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</p>
                    </div>
                </div>
            </div>

        </div>

        <div id="pageRegCompleted" data-role="page">

            <div data-role="main" class="ui-content">
                <div class="weui-msg">
                    <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">操作成功</h2>
                        <p class="weui-msg__desc">出售信息已发布成功，因为路程和人工因素，该单将在1-2个工作日内处理，请耐心等待，谢谢！</p>
                    </div>
                    <div class="weui-msg__opr-area">
                        <p class="weui-btn-area">
                            <a href="MySellInfos.aspx" class="weui-btn weui-btn_primary" rel="external">查看已发布信息</a>
                        </p>
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
