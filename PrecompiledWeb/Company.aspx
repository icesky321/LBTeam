<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" debug="true" inherits="Company, App_Web_c0neqvdw" theme="Default" %>

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
            <asp:Button ID="btSearch" runat="server" CssClass="btn-facebook-login" Text="搜索" OnClick="btSearch_Click" /><asp:HiddenField ID="hfId" runat="server" />
            <br />
            <br />
            <br />
            <div class="index-container">
                <div class="am-g">
                    <div class="am-u-md-12">
                        <asp:DataList ID="DLCopInfo" runat="server" OnItemCommand="DLCopInfo_ItemCommand" RepeatColumns="3" RepeatDirection="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Both">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <ItemStyle ForeColor="#000066" />
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>公司名称:</td>
                                        <td>
                                            <%--<asp:LinkButton ID="CopNameLabel" runat="server" Text='<%# Eval("CopName") %>' CommandName="Detail" CommandArgument='<%# Eval("CopId") %>'></asp:LinkButton>--%>
                                            <asp:Label ID="CopNameLabel" runat="server" Text='<%# Eval("CopName") %>' />
                                        </td>
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
                                        <td>联系人：</td>
                                        <td>
                                            <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' /></td>
                                    </tr>
                                    <tr>
                                        <td>联系方式：</td>
                                        <td>
                                            <%--<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                                <asp:View ID="View1" runat="server">
                                                    请先<asp:LinkButton ID="lbtnReg" runat="server" PostBackUrl="~/ChooseRoles.aspx">注册</asp:LinkButton>或<asp:LinkButton ID="lbtnLogin" runat="server" PostBackUrl="~/LoginM.aspx">登录</asp:LinkButton>
                                                </asp:View>
                                                <asp:View ID="View2" runat="server">
                                                    请先成为<asp:LinkButton ID="lbtnDesposit" runat="server" PostBackUrl="~/UserCenter/Deposit.aspx">平台信用会员</asp:LinkButton>
                                                </asp:View>
                                                <asp:View ID="View3" runat="server">--%>
                                                    <asp:Label ID="MobilePhoneNumLabel" runat="server" Text='<%# Eval("MobilePhoneNum") %>' />
                                             <%--   </asp:View>
                                            </asp:MultiView>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>营业执照认证：</td>
                                        <td>
                                            <asp:Label ID="BAuthenticationLabel" runat="server" Text='<%#Convert.ToBoolean(Eval("BAuthentication")) ? Aunth1.msg : UnAunth1.msg %>'></asp:Label></td>
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
                                </table>
                                <asp:Label ID="CopIdLabel" runat="server" Text='<%# Eval("CopId") %>' Visible="false" />
                            </ItemTemplate>
                            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
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
