<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="CopDetail, App_Web_scxnt4bh" theme="Default" %>

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
            <%--            <div class="titlen">
                <div class="bt">
                    企业资源
                </div>
            </div>--%>
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>
                        <asp:Label ID="CopNameLabel" runat="server" Text='<%# Eval("CopName") %>' /></h1>
                </p>
            </div>
            <hr />
            <asp:Label ID="CopIdLabel" runat="server" Text='<%# Eval("CopId") %>' Visible="false" />
            <br />

            <br />
            UserName:
                    <asp:Label ID="ContactLabel" runat="server" Text='<%# Eval("UserName") %>' />
            <br />
            MobilePhoneNum:
                    <asp:Label ID="TelNumLabel" runat="server" Text='<%# Eval("MobilePhoneNum") %>' />
            <br />
            Province:
                    <asp:Label ID="ProvinceLabel" runat="server" Text='<%# Eval("Province") %>' />
            <br />
            City:
                    <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
            <br />
            Town:
                    <asp:Label ID="TownLabel" runat="server" Text='<%# Eval("Town") %>' />
            <br />
            Street:
                    <asp:Label ID="StreetLabel" runat="server" Text='<%# Eval("Street") %>' />
            <br />

            营业执照认证：:

                           <asp:Label ID="Label2" runat="server" Text='<%# Eval("BAuthentication") %> ' />
            <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToBoolean(Eval("BAuthentication")) ? Aunth1.msg : UnAunth1.msg %>'></asp:Label>
            <br />
            HWAuthentication:
                    <asp:Label ID="HWAuthenticationLabel" runat="server" Text='<%# Eval("HWAuthentication") %>' />
            <br />
            IDAuthentication:
                    <asp:Label ID="IDAuthenticationLabel" runat="server" Text='<%# Eval("IDAuthentication") %>' />
            <br />
            CopDetail:
                    <asp:Label ID="CopDetailLabel" runat="server" Text='<%# Eval("CopDetail") %>' />
            <br />
            Audit:
                    <asp:Label ID="AuditLabel" runat="server" Text='<%# Eval("Audit") %>' />
            <br />
            AuditDate:
                    <asp:Label ID="AuditDateLabel" runat="server" Text='<%# Eval("AuditDate") %>' />
            <br />
            BankName:
                    <asp:Label ID="BankNameLabel" runat="server" Text='<%# Eval("BankName") %>' />
            <br />
            Account:
                    <asp:Label ID="AccountLabel" runat="server" Text='<%# Eval("Account") %>' />
            <br />
            ChopAuthentication:
                    <asp:Label ID="ChopAuthenticationLabel" runat="server" Text='<%# Eval("ChopAuthentication") %>' />
        </div>
    </div>

</asp:Content>

