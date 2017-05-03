<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="TradeleadsDetail, App_Web_2u5vkwgg" theme="Default" %>

<%@ Register Src="UserControls/Aunth.ascx" TagName="Aunth" TagPrefix="uc2" %>
<%@ Register Src="UserControls/UnAunth.ascx" TagName="UnAunth" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:Aunth ID="Aunth1" runat="server" Visible="false" />

    <uc3:UnAunth ID="UnAunth1" runat="server" Visible="false" />
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>
                        <asp:Label ID="lbTitle" runat="server" Text="Label"></asp:Label></h1>
                </p>
            </div>

            供货总量：<asp:Label ID="lbVolume" runat="server" Text="Label"></asp:Label>
            型号规格：<asp:Label ID="lbType" runat="server" Text="Label"></asp:Label>
            交易价格：<asp:Label ID="lbPrice" runat="server" Text="Label"></asp:Label>
            所在地区：<asp:Label ID="lbAddress" runat="server" Text="Label"></asp:Label>
            详细信息：<asp:Label ID="lbDetail" runat="server" Text="Label"></asp:Label>
            <asp:Image ID="Image1" runat="server" />
            联系人：<asp:Label ID="lbUserName" runat="server" Text="Label"></asp:Label>
            联系方式：<asp:Label ID="lbMobileNum" runat="server" Text="Label"></asp:Label>
            <span class="verified">已核实</span>
            <span class="unverified">未核实</span>
            <span class="verified">已审核</span>
            <span class="unverified">未审核</span>
        </div>
    </div>
</asp:Content>

