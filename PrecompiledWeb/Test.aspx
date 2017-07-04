<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Test, App_Web_45zsbvmj" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LoginName ID="LoginName2" runat="server"/>
                                                                        <asp:LoginStatus ID="LoginStatus2" runat="server" LogoutPageUrl="~/Default.aspx" LogoutAction="Redirect" LogoutText="退出" />
</asp:Content>

