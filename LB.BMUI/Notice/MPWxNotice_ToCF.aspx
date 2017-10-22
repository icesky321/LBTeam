<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="MPWxNotice_ToCF.aspx.cs" Inherits="Notice_MPWxNotice_ToCF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="viewport" content="width=device-width,initial-scale=1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="http://Weixin.lvbao111.com/WeixinQY/WS/CNRegionService.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <div>
        <div data-role="header">
            <h3>模板微信消息群发</h3>
            <p>该群发消息只能产废单位在服务号中接收</p>
        </div>
        <div data-role="main" class="ui-content">
            <div>
                <asp:HiddenField ID="hfRegionCode" runat="server" />
                选择省份：
                <asp:DropDownList ID="ddlProvince" runat="server"></asp:DropDownList>
                <ajaxToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlProvince" Category="Province" PromptText="请选择省份...." LoadingText="加载中，请稍后 ..." ServicePath="~/WS/CNRegionService.asmx" ServiceMethod="GetProvince" />
                选择地级市：
                <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
                <ajaxToolkit:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlCity" ParentControlID="ddlProvince" Category="City" PromptText="请选择城市...." LoadingText="加载中，请稍后 ..." ServicePath="~/WS/CNRegionService.asmx" ServiceMethod="GetCity" />
                <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
            </div>

        </div>
        
    </div>
</asp:Content>

