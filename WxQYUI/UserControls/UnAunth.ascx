<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UnAunth.ascx.cs" Inherits="UserControls_UnAunth" %>
<style type="text/css">
    .verified {
        display: block;
        background: #23cd08;
        border-radius: 4px;
        width: 56px;
        height: 22px;
        line-height: 22px;
        font-size: 14px;
        color: #fff;
        text-align: center;
        float: left;
        margin: 5px 0 0 8px;
    }

    .unverified {
        display: block;
        background: #eea236;
        border-radius: 4px;
        width: 56px;
        height: 22px;
        line-height: 22px;
        font-size: 14px;
        color: #fff;
        text-align: center;
        float: left;
        margin: 5px 0 0 8px;
    }
</style>
<asp:Label ID="Label1" runat="server" CssClass="unverified" Text="<span class='unverified'>未审核</span>"></asp:Label>