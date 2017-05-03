<%@ page title="" language="C#" masterpagefile="~/UserCenter.master" autoeventwireup="true" inherits="UserCenter1, App_Web_2u5vkwgg" theme="Default" %>

<%@ Register Src="UserControls/Aunth.ascx" TagName="Aunth" TagPrefix="uc2" %>
<%@ Register Src="UserControls/UnAunth.ascx" TagName="UnAunth" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <script src="js/amazeui.js" type="text/javascript" charset="utf-8"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <p class="title">
            个人中心
        </p>
        <div class="detail" style="text-align: center;">
            <div class="titlen">
                <div class="bt">
                    个人中心
                </div>

            </div>
            <uc2:Aunth ID="Aunth1" runat="server" Visible="false" />
            <uc3:UnAunth ID="UnAunth1" runat="server" Visible="false" />
            用户名:
                            <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
            <br />
            联系电话:
                            <asp:Label ID="MobilePhoneNumLabel" runat="server" Text='<%# Eval("MobilePhoneNum") %>' />
            <br />
            地址:
                            <asp:Label ID="ProvinceLabel" runat="server" Text='<%# Eval("Province") %>' />

            <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />

            <asp:Label ID="TownLabel" runat="server" Text='<%# Eval("Town") %>' />

            <asp:Label ID="StreetLabel" runat="server" Text='<%# Eval("Street") %>' />
            <br />
            身份证审核: 
            <%--<asp:Label ID="IDAuthenticationLabel" runat="server" Text='<%# (bool)Eval("IDAuthentication")?  Aunth1.msg : UnAunth1.msg%>' />--%>
            <%--<asp:Label ID="IDAuthenticationLabel" runat="server"  Text='<%#Convert.ToBoolean(Eval("IDAuthentication")) ? Aunth1.msg : UnAunth1.msg %>'></asp:Label>--%>
            <asp:Label ID="IDAuthenticationLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("IDAuthentication"))?  Aunth1.msg : UnAunth1.msg %> ' />
            <br />
            信用审核:
                            <%--<asp:Label ID="AuditLabel" runat="server" Text='<%# Eval("Audit") %>' />--%>
            <asp:Label ID="AuditLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("Audit"))? Aunth1.msg : UnAunth1.msg %> ' />
            <br />

            开户行:
                            <asp:Label ID="BankNameLabel" runat="server" Text='<%# Eval("BankName") %>' />
            <br />
            银行账号:
                            <asp:Label ID="AccountLabel" runat="server" Text='<%# Eval("Account") %>' />
            <br />
            <br />
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

