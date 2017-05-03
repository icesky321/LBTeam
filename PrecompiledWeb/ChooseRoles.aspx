<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="ChooseRoles, App_Web_2u5vkwgg" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <br />
    <br />
    我是：用户类型：<asp:DropDownList ID="ddlUserType" runat="server"></asp:DropDownList>
    <asp:Button ID="btSearch" runat="server" Text="确定" OnClick="btSearch_Click" />
</asp:Content>

