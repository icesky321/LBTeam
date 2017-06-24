<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="TradeleadsDetail, App_Web_pla5ct52" theme="Default" %>

<%@ Register Src="UserControls/Aunth.ascx" TagName="Aunth" TagPrefix="uc2" %>
<%@ Register Src="UserControls/UnAunth.ascx" TagName="UnAunth" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:Aunth ID="Aunth1" runat="server" Visible="false" />

    <uc3:UnAunth ID="UnAunth1" runat="server" Visible="false" />
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>
                        <asp:Label ID="lbTitle" runat="server" Text="Label"></asp:Label></h1>
                </p>
            </div>


            <div class="index-container">
                <div class="am-g">
                    <div class="am-u-md-12" style="text-align: center;">
                        <table class="am-u-sm-12" style="width: 100%">
                            <tr>
                                <td rowspan="8">
                                    <asp:Image ID="Image1" runat="server" Width="200px" Height="250px" />
                                </td>
                                <td colspan="2">供货总量：<asp:Label ID="lbVolume" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">型号规格：<asp:Label ID="lbType" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">交易价格：<asp:Label ID="lbPrice" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">所在地区：<asp:Label ID="lbAddress" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">联系人：<asp:Label ID="lbUserName" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">联系方式：
<%--                                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                        <asp:View ID="View1" runat="server">
                                            请先<asp:LinkButton ID="lbtnReg" runat="server" PostBackUrl="~/ChooseRoles.aspx">注册</asp:LinkButton>或<asp:LinkButton ID="lbtnLogin" runat="server" PostBackUrl="~/LoginM.aspx">登录</asp:LinkButton>
                                        </asp:View>
                                        <asp:View ID="View2" runat="server">
                                           请先成为<asp:LinkButton ID="lbtnDesposit" runat="server" PostBackUrl="~/UserCenter/Deposit.aspx">平台信用会员</asp:LinkButton>
                                        </asp:View>
                                        <asp:View ID="View3" runat="server">--%>
                                            <asp:Label ID="lbMobileNum" runat="server" Text="Label"></asp:Label>
<%--                                        </asp:View>
                                    </asp:MultiView>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>身份真实性认证：</td>
                                <td>
                                    <asp:Label ID="IDAuthenticationLabel" runat="server" Text="Label" /></td>
                            </tr>
                            <tr>
                                <td>信用认证:</td>
                                <td>
                                    <asp:Label ID="AuditLabel" runat="server" Text="Label" /></td>
                            </tr>
                            <tr>
                                <td>详细信息：</td>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lbDetail" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

