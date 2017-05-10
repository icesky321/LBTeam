<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="UserCenter1, App_Web_jji1h45o" theme="Default" %>

<%@ Register Src="~/UserControls/Aunth.ascx" TagName="Aunth" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/UnAunth.ascx" TagName="UnAunth" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/amazeui.js" type="text/javascript" charset="utf-8"></script>
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <uc2:Aunth ID="Aunth1" runat="server" Visible="false" />
    <uc3:UnAunth ID="UnAunth1" runat="server" Visible="false" />
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>个人信息中心</h1>
                </p>
            </div>
            <hr />
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
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:Button ID="btComplete" runat="server" Text="继续补全个人资料" OnClick="btComplete_Click" />
                </asp:View>
                <asp:View ID="View2" runat="server">

                    <asp:Button ID="btComplete1" runat="server" OnClick="btComplete1_Click" Text="继续补全个人资料" />
                </asp:View>
                <asp:View ID="View3" runat="server">
                </asp:View>
                <asp:View ID="View4" runat="server">
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>

