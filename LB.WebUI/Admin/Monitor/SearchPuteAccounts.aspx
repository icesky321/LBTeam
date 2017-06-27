<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manage.master" AutoEventWireup="true" CodeFile="SearchPuteAccounts.aspx.cs" Inherits="Admin_Monitor_SearchPuteAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>查询单纯性账户</div>
    <div>该页面将展示出所有未包含用户信息的单纯性的账户，此类账户将无法登录用户中心，无法测试各业务功能。</div>
    <asp:ListBox ID="lboxUsers" runat="server" Height="451px" Width="282px"></asp:ListBox>
    <asp:Button ID="btnDelete" runat="server" Text="删除用户" OnClick="btnDelete_Click" OnClientClick='return confirm("确定要删除该用户吗？")' Visible="false" />
</asp:Content>

