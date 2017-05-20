<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenter.master" AutoEventWireup="true" CodeFile="Deposit.aspx.cs" Inherits="UserCenter_Deposit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>个人诚信保证金信息</h1>
                </p>
            </div>
            <hr />

            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sorry.jpg" Width="100px" Height="80px" />
                    <asp:Label ID="Label1" runat="server" Text="暂无保证金信息" Font-Bold="True" Font-Size="Larger" ForeColor="Gray"></asp:Label>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    保证金：<asp:Label ID="lbDeposit" runat="server" Text="Label"></asp:Label>元
                    缴纳时间：<asp:Label ID="lbInDate" runat="server" Text="Label"></asp:Label>
                    <br />
                    <hr />
                    <br />
                    <asp:Button ID="btOutDeposit" runat="server" Text="我要退诚信保证金" />
                    <asp:ConfirmButtonExtender ID="btOutDeposit_ConfirmButtonExtender" runat="server" ConfirmText="亲，真的打算退保证金吗？"
                        Enabled="True" TargetControlID="btOutDeposit"></asp:ConfirmButtonExtender>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>

