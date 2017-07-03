<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="UserCenter_Address, App_Web_wkczwwiq" theme="Default" %>

<%@ Register Src="~/UserControls/DDLAddress.ascx" TagPrefix="uc2" TagName="DDLAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>用户地址信息</h1>
                </p>
            </div>

            <hr />

<%--            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            
                            用户名:<asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                            <hr />
                            联系电话:<asp:Label ID="MobilePhoneNumLabel" runat="server" Text='<%# Eval("MobilePhoneNum") %>' />
                            <hr />
                            地址:<asp:Label ID="ProvinceLabel" runat="server" Text='<%# Eval("Province") %>' /><asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' /><asp:Label ID="TownLabel" runat="server" Text='<%# Eval("Town") %>' /><asp:Label ID="StreetLabel" runat="server" Text='<%# Eval("Street") %>' />
                            <hr />
                            <asp:Button ID="btUpdate" runat="server" Text="修改地址信息" OnClick="btUpdate_Click" />
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            用户名：<asp:Label ID="lbUpdateUserName" runat="server" Text='<%# Eval("UserName") %>' />
                            <hr />
                            联系电话：<asp:Label ID="lbUpdateMobilePhoneNum" runat="server" Text='<%# Eval("MobilePhoneNum") %>' />
                            <hr />
                            地址:<uc2:DDLAddress runat="server" ID="DDLAddress" />
                            <hr />
                            <asp:Button ID="btSure" runat="server" Text="确认修改" OnClick="btSure_Click" />
                        </asp:View>
                    </asp:MultiView>
<%--                </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
</asp:Content>

