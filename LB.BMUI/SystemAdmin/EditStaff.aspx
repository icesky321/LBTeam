<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="EditStaff.aspx.cs" Inherits="SystemAdmin_EditStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .infoBlock {
            margin: 20px 0 0 0;
            border-top: 1px solid #808080;
        }

        .title {
            font-size: 1.5em;
            padding: 10px 0 10px 0;
        }

        .data {
            color: blue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfStaffId" runat="server" />
    <asp:HiddenField ID="hfMobileNum" runat="server" />
    <asp:HiddenField ID="hfUserId" runat="server" />
    <div class="infoBlock">
        <div class="title">
            平台员工基本信息
        </div>
        <div style="line-height: 2em;">
            姓名：<asp:Label ID="lbRealName" runat="server" Text="" CssClass="data"></asp:Label><br />
            昵称：<asp:Label ID="lbUserName" runat="server" Text="" CssClass="data"></asp:Label><br />
            手机号码：<asp:Label ID="lbMobileNum" runat="server" Text="" CssClass="data"></asp:Label><br />

        </div>
    </div>

    <div class="infoBlock">
        <div class="title">
            修改行政区域
        </div>
        <div>
            <asp:HiddenField ID="hfRegionCode" runat="server" />
            当前所在行政区划：<asp:Label ID="lbRegionWholeName" runat="server" Text="" CssClass="data"></asp:Label><br />
            选择省份：
                <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
            选择地级市：
                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
            <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
            选择县市：
            <asp:DropDownList ID="ddlCounty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCounty_SelectedIndexChanged"></asp:DropDownList>
            镇或街道：
                 <asp:DropDownList ID="ddlStreet" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStreet_SelectedIndexChanged"></asp:DropDownList>
            <asp:Button ID="btnSaveRegionCode" runat="server" Text="保存行政区划" OnClick="btnSaveRegionCode_Click" />
            <br />
        </div>
    </div>

    <div class="infoBlock">
        <div class="title">变更行业身份</div>
        <div>
            当前行业身份：<asp:Label ID="lbHangyeIdentity" runat="server" Text="" CssClass="data"></asp:Label><br />
            <asp:DropDownList ID="ddlHangyeIdentity" runat="server"></asp:DropDownList>
            <asp:Button ID="btnSaveHangyeIdentity" runat="server" Text="保存行业身份" OnClick="btnSaveHangyeIdentity_Click" />
        </div>
    </div>
</asp:Content>

