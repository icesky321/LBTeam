﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenter.master" AutoEventWireup="true" CodeFile="SellInfo.aspx.cs" Inherits="SellInfo" %>

<%@ Register Src="~/UserControls/DDLAddress.ascx" TagName="DDLAddress" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/main.css" />
    <style type="text/css">
        .table1 {
            border: 0;
            margin: 0;
            border-collapse: collapse;
        }

            .table1 td {
                padding: 4px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>发布供应信息</h1>
                </p>
            </div>
            <hr />
            <asp:HiddenField ID="hfUserTelNum" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <table class="table1">
                <tr>
                    <td>选择地区：</td>
                    <td>
                        <uc1:DDLAddress ID="DDLAddress1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>标题：</td>
                    <td>
                        <asp:TextBox ID="tbTitle" runat="server" Width="525px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>货品类别：</td>
                    <td>
                        <asp:DropDownList ID="ddlTS" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>货品单位：</td>
                    <td>
                        <asp:DropDownList ID="ddlUnit" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>供货总量：</td>
                    <td>
                        <asp:TextBox ID="tbTotalNum" runat="server" Width="525px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>交易价格：</td>
                    <td>
                        <asp:TextBox ID="tbPrice" runat="server" Width="525px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>详细说明：</td>
                    <td>
                        <asp:TextBox ID="tbDetail" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>联系人：</td>
                    <td>
                        <asp:Label ID="lbContact" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>联系方式：</td>
                    <td>
                        <asp:Label ID="lbTelNum" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>图片信息：</td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btSell" runat="server" OnClick="btSell_Click" Text="发布" /></td>
                    <td></td>
                </tr>
            </table>
            <asp:HiddenField ID="hfFilePath" runat="server" />
        </div>
    </div>
</asp:Content>

