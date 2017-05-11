<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" debug="true" inherits="Company, App_Web_3zbaw2c4" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="UserControls/DDLAddress.ascx" TagName="DDLAddress" TagPrefix="uc1" %>
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
                    <h1>商家信息</h1>
                </p>
            </div>
            <hr />
            <uc1:DDLAddress ID="DDLAddress1" runat="server" />
            <%--            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <asp:Button ID="btSearch" runat="server" CssClass="btn-facebook-login" Text="搜索" OnClick="btSearch_Click" />
            <br /><br /><br />
            <div class="index-container">
                <div class="am-g">
                    <div class="am-u-md-12">
                        <asp:DataList ID="DLCopInfo" runat="server" OnItemCommand="DLCopInfo_ItemCommand" RepeatColumns="4" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>公司名称:</td>
                                        <td>
                                            <asp:LinkButton ID="CopNameLabel" runat="server" Text='<%# Eval("CopName") %>' CommandName="Detail" CommandArgument='<%# Eval("CopId") %>'></asp:LinkButton></td>
                                    </tr>
                                    <tr>
                                        <td>公司地址：</td>
                                        <td>
                                            <asp:Label ID="ProvinceLabel" runat="server" Text='<%# Eval("Province") %>' />省<asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />市
                                            <asp:Label ID="TownLabel" runat="server" Text='<%# Eval("Town") %>' />区<asp:Label ID="StreetLabel" runat="server" Text='<%# Eval("Street") %>' /></td>
                                    </tr>
                                    <tr>
                                        <td>公司详情：</td>
                                        <td>
                                            <asp:Label ID="CopDetailLabel" runat="server" Text='<%# Eval("CopDetail") %>' /></td>
                                    </tr>
                                    <tr>
                                        <td>营业执照认证：</td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToBoolean(Eval("BAuthentication")) ? Aunth1.msg : UnAunth1.msg %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>危化品执照认证:</td>
                                        <td>
                                            <asp:Label ID="HWAuthenticationLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("HWAuthentication")) ? Aunth1.msg : UnAunth1.msg %> ' /></td>
                                    </tr>
                                    <tr>
                                        <td>负责人身份证认证:</td>
                                        <td>
                                            <asp:Label ID="IDAuthenticationLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("IDAuthentication"))? Aunth1.msg : UnAunth1.msg %> ' /></td>
                                    </tr>
                                    <tr>
                                        <td>信用认证:</td>
                                        <td>
                                            <asp:Label ID="AuditLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("Audit"))? Aunth1.msg : UnAunth1.msg %> ' /></td>
                                    </tr>
                                    <tr>
                                        <td>协议签署</td>
                                        <td>
                                            <asp:Label ID="ChopAuthenticationLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("ChopAuthentication"))? Aunth1.msg : UnAunth1.msg  %>' /></td>
                                    </tr>
                                </table>
                                <asp:Label ID="CopIdLabel" runat="server" Text='<%# Eval("CopId") %>' Visible="false" />
                            </ItemTemplate>
                        </asp:DataList>
                    </div>

                </div>
            </div>


            <%--                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
</asp:Content>
