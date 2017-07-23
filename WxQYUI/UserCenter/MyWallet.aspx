<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyWallet.aspx.cs" Inherits="UserCenter_MyWallet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>绿宝三益--我的钱包</title>
</head>


<body>
    <form id="form1" runat="server" data-ajax="false">
        <div id="page1" data-role="page" runat="server">
            <div class="weui-cells__title">
                <h2>我的钱包</h2>
            </div>
            <hr />
            <br />
            <h2>余额：
                    <asp:Label ID="lbTotalMoney" runat="server" Text=""></asp:Label>元
            </h2>
            <h2>在途资产：
                    <asp:Label ID="lbWaitMoney" runat="server" Text=""></asp:Label>元
            </h2>
            <asp:DropDownList ID="ddlTXType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTXType_SelectedIndexChanged" Visible="false">
                <asp:ListItem Value="0">--请选择提现方式--</asp:ListItem>
                <asp:ListItem Value="1">网银转账</asp:ListItem>
                <asp:ListItem Value="2">支付宝</asp:ListItem>
                <asp:ListItem Value="3">微信</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:MultiView ID="MultiView4" runat="server" ActiveViewIndex="0" Visible="false">
                <asp:View ID="viewShwoBankInfo" runat="server">
                    <div class="ui-corner-all" style="border: 1px dotted #999999; padding: 20px;">
                        汇款人姓名：<asp:Label ID="lbPayeeName" runat="server" Text="" />
                        <br />
                        开户行信息：<asp:Label ID="lbBankName" runat="server" Text="" />
                        <br />
                        银行账号:<asp:Label ID="lbAccount" runat="server" Text="" />
                        <br />
                    </div>
                    <asp:Button ID="btBankInfo" runat="server" data-icon="edit" OnClick="btnEditBankInfo_Click" Text="修改" />
                </asp:View>
                <asp:View ID="viewEditBankInfo" runat="server">
                    汇款人姓名：<asp:TextBox ID="tbPayeeName" runat="server"></asp:TextBox>
                    <br />
                    开户行信息：<asp:TextBox ID="tbBankInfo" runat="server"></asp:TextBox>
                    <br />
                    银行账号：<asp:TextBox ID="tbAccount" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="btSaveBankInfo" runat="server" data-icon="check" OnClick="btSaveBankInfo_Click" Text="确定保存" />
                </asp:View>
                <asp:View ID="viewShowZFB" runat="server">
                    <div class="ui-corner-all" style="border: 1px dotted #999999; padding: 20px;">
                        支付宝姓名：<asp:Label ID="lbZFBName" runat="server" Text="" />
                        <br />
                        支付宝账号:<asp:Label ID="lbZFBAccount" runat="server" Text="" />
                        <br />
                    </div>
                    <asp:Button ID="btZFBInfo" runat="server" data-icon="edit" OnClick="btnEditZFBInfo_Click" Text="修改" />
                </asp:View>
                <asp:View ID="viewEditZFBInfo" runat="server">
                    支付宝姓名：<asp:TextBox ID="tbZFBName" runat="server"></asp:TextBox>
                    <br />
                    支付宝账号：<asp:TextBox ID="tbZFBAccount" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="btSaveZFBInfo" runat="server" data-icon="check" OnClick="btSaveZFBInfo_Click" Text="确定保存" />
                </asp:View>
                <asp:View ID="viewShowWX" runat="server">
                    <div class="ui-corner-all" style="border: 1px dotted #999999; padding: 20px;">
                        微信账号姓名：<asp:Label ID="lbWXName" runat="server" Text="" />
                        <br />
                        微信账号:<asp:Label ID="lbWXAccount" runat="server" Text="" />
                        <br />
                    </div>
                    <asp:Button ID="Button1" runat="server" data-icon="edit" OnClick="btnEditWXInfo_Click" Text="修改" />
                </asp:View>
                <asp:View ID="viewEditWXInfo" runat="server">
                    微信账号姓名：<asp:TextBox ID="tbWXName" runat="server"></asp:TextBox>
                    <br />
                    微信账号：<asp:TextBox ID="tbWXAccount" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button2" runat="server" data-icon="check" OnClick="btSaveWXInfo_Click" Text="确定保存" />
                </asp:View>
            </asp:MultiView>
            <br />
            <asp:Button ID="btSure" runat="server" Text="提现" OnClick="btSure_Click" />

        </div>
        <div id="pageRegCompleted" data-role="page" runat="server">

            <div data-role="main" class="ui-content">
                <div class="weui-msg">
                    <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">操作成功</h2>
                        <p class="weui-msg__desc">因为银行系统到账时间因素，您的资金将在您发起申请后的48小时内到账，请及时关注您的银行账户！如有不便之处敬请谅解！</p>
                    </div>
                    <div id="show2">
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
        <div id="errorPage" data-role="page" runat="server">

            <div data-role="main" class="ui-content">
                <div class="weui-msg">
                    <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">提现失败</h2>
                        <p class="weui-msg__desc">对不起，您的账户没有可用余额</p>
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
