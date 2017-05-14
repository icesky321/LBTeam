<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="UserCenter_Supplier_LocalRecycling, App_Web_nxjwqwfp" theme="Default" %>

<%@ Register Src="~/UserControls/Aunth.ascx" TagName="Aunth" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/UnAunth.ascx" TagName="UnAunth" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/amazeui.js" type="text/javascript" charset="utf-8"></script>
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>当地回收业务员</h1>
                </p>
            </div>
            <hr />
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <uc2:Aunth ID="Aunth1" runat="server" Visible="false" />
                    <uc3:UnAunth ID="UnAunth1" runat="server" Visible="false" />
                    <div class="section">
                        <div class="container">
                            <table>
                                <tr>
                                    <td>用户名:</td>
                                    <td>
                                        <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' /></td>
                                </tr>
                                <tr>
                                    <td>联系电话:</td>
                                    <td>
                                        <asp:Label ID="MobilePhoneNumLabel" runat="server" Text='<%# Eval("MobilePhoneNum") %>' /></td>
                                </tr>
                                <tr>
                                    <td>地址:</td>
                                    <td>
                                        <asp:Label ID="ProvinceLabel" runat="server" Text='<%# Eval("Province") %>' /><asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' /><asp:Label ID="TownLabel" runat="server" Text='<%# Eval("Town") %>' /><asp:Label ID="StreetLabel" runat="server" Text='<%# Eval("Street") %>' /></td>
                                </tr>
                                <tr>
                                    <td>身份证审核:</td>
                                    <td>
                                        <asp:Label ID="IDAuthenticationLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("IDAuthentication"))?  Aunth1.msg : UnAunth1.msg %> ' /></td>
                                </tr>
                                <tr>
                                    <td>信用审核:</td>
                                    <td>
                                        <asp:Label ID="AuditLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("Audit"))? Aunth1.msg : UnAunth1.msg %> ' /></td>
                                </tr>
                                <tr>
                                    <td>开户行:</td>
                                    <td>
                                        <asp:Label ID="BankNameLabel" runat="server" Text='<%# Eval("BankName") %>' /></td>
                                </tr>
                                <tr>
                                    <td>银行账号</td>
                                    <td>
                                        <asp:Label ID="AccountLabel" runat="server" Text='<%# Eval("Account") %>' /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <ul>
                        <li>对不起，该地区暂空缺~
                        </li>
                    </ul>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>

