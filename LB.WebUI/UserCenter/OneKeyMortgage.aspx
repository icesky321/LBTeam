<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenter.master" AutoEventWireup="true" CodeFile="OneKeyMortgage.aspx.cs" Inherits="UserCenter_OneKeyMortgage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>一键押货</h1>
                </p>
            </div>

            <hr />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <asp:Label ID="Label2" runat="server" Text="当你点击这个按钮时，您的压货需求信息就会发送给客服，试试呗！~" Font-Size="Medium"></asp:Label>
                            <asp:Button ID="btSell" runat="server" Text="一键卖押货" OnClick="btMortgage_Click" />
                            <br />
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <asp:Label ID="Label1" runat="server" Text="您的押货需求信息后台客服已知晓，将会尽快联系您，请耐心等待！" Font-Size="Medium"></asp:Label>
                        </asp:View>
                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

