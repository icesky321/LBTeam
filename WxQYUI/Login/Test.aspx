<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Login_Test" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <link href="http://res.wx.qq.com/open/libs/weui/0.4.0/weui.min.css" rel="stylesheet" />
    <title>用户注册</title>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="main" class="ui-content">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Services>
                    <asp:ServiceReference Path="~/WS/CNRegionService.asmx" />
                </Services>
            </asp:ScriptManager>
            <asp:HiddenField ID="hfRegionCode" runat="server" />
            选择省份：
                <asp:DropDownList ID="ddlProvince" runat="server"></asp:DropDownList>
            <asp:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlProvince" Category="Province" PromptText="请选择省份...." LoadingText="加载中，请稍后 ..." ServicePath="~/WS/CNRegionService.asmx" ServiceMethod="GetProvince" />
            选择地级市：
                <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
            <asp:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlCity" ParentControlID="ddlProvince" Category="City" PromptText="请选择城市...." LoadingText="加载中，请稍后 ..." ServicePath="~/WS/CNRegionService.asmx" ServiceMethod="GetCity" />
            <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
            选择县市：
            <asp:DropDownList ID="ddlCounty" runat="server"></asp:DropDownList>
            <asp:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID="ddlCounty" ParentControlID="ddlCity" Category="County" PromptText="请选择县市...." LoadingText="加载中，请稍后 ..." ServicePath="~/WS/CNRegionService.asmx" ServiceMethod="GetCounty" />
            镇或街道：
                 <asp:DropDownList ID="ddlStreet" runat="server"></asp:DropDownList>
            <asp:CascadingDropDown ID="CascadingDropDown4" runat="server" TargetControlID="ddlStreet" ParentControlID="ddlCounty" Category="Street" PromptText="请选择街道...." LoadingText="加载中，请稍后 ..." ServicePath="~/WS/CNRegionService.asmx" ServiceMethod="GetStreet" />
            <br />

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
