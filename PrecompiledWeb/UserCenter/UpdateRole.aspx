<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="UserCenter_UpdateRole, App_Web_fmgbfib2" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/DDLAddress.ascx" TagName="DDLAddress" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="section--header" style="text-align: center">
            <p class="section--description">
                <h1>资料不全</h1>
            </p>
        </div>
        <hr />
        注意：平台改版，为了老用户更好地体验，请补全一下信息,谢谢!<br />
        <asp:HiddenField ID="hfUserId" runat="server" />
        我是：<asp:DropDownList ID="ddlUserType" runat="server"></asp:DropDownList>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择" ControlToValidate="ddlUserType" ValidationGroup="1"></asp:RequiredFieldValidator>
<%--        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="AA" Checked="true" />个人
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="AA" />商家
        </asp:Panel>--%>
        <br />
        我所在地区：<uc1:DDLAddress ID="DDLAddress1" runat="server" />
        <br /> <br /> <br />
        <asp:Button ID="btSure" runat="server" Text="完成" OnClick="btSure_Click" />
    </div>
</asp:Content>

