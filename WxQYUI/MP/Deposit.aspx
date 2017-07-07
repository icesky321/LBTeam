<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Deposit.aspx.cs" Inherits="MP_Deposit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>缴纳诚信保证金</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div data-role="page" id="page1">
            <div data-role="header">
                <h2>绿宝三益--缴纳诚信保证金</h2>
            </div>
            <div data-role="main" class="ui-content">
                <div data-role="collapsible">
                    <h2>诚信保证金说明（点击查看）</h2>
                    <p>
                        为约束平台会员在发布信息和交易环节中的规范性，平台会对部分角色会员收取部分金额作为诚信保证金。<br />

                    </p>
                    <div class="weui-cells">
                        <div class="weui-cell">
                            <div class="weui-cell__bd">
                                <p>街道回收员</p>
                            </div>
                            <div class="weui-cell__ft">2000元</div>
                        </div>
                    </div>
                    <div class="weui-cells">
                        <div class="weui-cell">
                            <div class="weui-cell__bd">
                                <p>回收公司</p>
                            </div>
                            <div class="weui-cell__ft">2000元</div>
                        </div>
                    </div>
                    <div class="weui-cells">
                        <div class="weui-cell">
                            <div class="weui-cell__bd">
                                <p>冶炼厂</p>
                            </div>
                            <div class="weui-cell__ft">2000元</div>
                        </div>
                    </div>
                    <div class="weui-cells">
                        <div class="weui-cell">
                            <div class="weui-cell__bd">
                                <p>产废单位或个人</p>
                            </div>
                            <div class="weui-cell__ft">暂免保证金</div>
                        </div>
                    </div>


                </div>
                <div class="ui-grid-a" runat="server" id="login">
                    <div class="ui-block-a" style="text-align: center;"><a href="../Login/Login.aspx" rel="external">我要登录</a></div>
                    <div class="ui-block-b" style="text-align: center;"><a href="../Login/Register.aspx" rel="external">我要注册</a></div>
                </div>
                <fieldset data-role="controlgroup">
                    <legend>付款方式</legend>
                    <div data-role="collapsible">
                        <h2>网银转账（点击查看）</h2>
                        <div class="weui-cells">
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>公司名称：</p>
                                </div>
                                <div class="weui-cell__ft">宁波绿宝信息科技有限公司</div>
                            </div>
                        </div>
                        <div class="weui-cells">
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>开户行：</p>
                                </div>
                                <div class="weui-cell__ft">宁波银行庄市支行</div>
                            </div>
                        </div>
                        <div class="weui-cells">
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>账号：</p>
                                </div>
                                <div class="weui-cell__ft">5204 0122 0002 10157</div>
                            </div>
                        </div>

                    </div>
                    <div data-role="collapsible">
                        <h2>微信转账（点击查看）</h2>
                        <p>
                            请长按此二维码<br />
                        </p>
                        <div class="weui-cells">
                            <div class="weui-cell">
                                <%-- <div class="weui-cell__bd">
                                    <p>开户行：</p>
                                </div>
                                <div class="weui-cell__ft">宁波银行庄市支行</div>--%>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/wxPay.jpg" Width="200px" Height="230px" /><br />
                            </div>
                        </div>
                    </div>
                </fieldset>
                <asp:Label ID="Label6" runat="server" Text="注：手机用户转账或微信支付完毕后请填写下页面底部的回执单，您的付款信息将会更快得到平台客服的核实!" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                <div class="ui-field-contain">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <label for="fname">汇款姓名：</label></td>
                            <td>
                                <input type="text" name="fname" id="tbName" runat="server" placeholder="请输入您的真实姓名" /></td>
                        </tr>
                        <tr>
                            <td>
                                <label for="fname">汇款账户：</label></td>
                            <td>
                                <input type="text" name="fnAccount" id="tbAccount" runat="server" placeholder="微信付款可忽略" /></td>
                        </tr>
                        <tr>
                            <td>
                                <label for="fname">汇款金额：</label></td>
                            <td>
                                <input type="text" name="fnAmount" id="tbAmount" runat="server" placeholder="请输入您汇款金额" /></td>
                        </tr>
                    </table>
                    <label for="info">附加信息：</label>
                    <input id="tbAdditionText" runat="server" textmode="MultiLine" rows="2" />


                </div>
                <div style="border-bottom: 1px solid #cccccc"></div>
                <asp:HiddenField ID="hfImcomplete" runat="server" Value="false" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" data-role="button" OnClick="btnSubmit_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>


            </div>
            <div data-role="footer">
                <div class="page__bd page__bd_spacing">
                    <br>
                    <br>
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:void(0);" class="weui-footer__link"></a>
                        </p>
                        <p class="weui-footer__text">Copyright &copy; 2016-2017 宁波绿宝三益 lvbao111.com</p>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
