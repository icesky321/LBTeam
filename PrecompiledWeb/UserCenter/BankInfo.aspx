<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="UserCenter_BankInfo, App_Web_otqrewpd" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>银行卡信息</h1>
                </p>
            </div>

            <hr />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            银行卡所在开户行信息：<asp:Label ID="lbBankName" runat="server" Text=""></asp:Label>
                            银行卡账号：<asp:Label ID="lbAccount" runat="server" Text=""></asp:Label>
                            <asp:Button ID="btUpdate" runat="server" OnClick="btUpdate_Click" Text="修改银行卡信息" />
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            银行卡所在开户行信息：<asp:Textbox ID="tbUpdateBankName" runat="server" Text=""></asp:Textbox>
                            银行卡账号：<asp:Textbox ID="tbUpdateAccount" runat="server" Text=""></asp:Textbox>
                            <asp:Button ID="btSure" runat="server" Text="确定" OnClick="btSure_Click" />
                        </asp:View>
                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

