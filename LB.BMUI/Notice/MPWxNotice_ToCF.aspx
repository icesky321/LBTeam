<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="MPWxNotice_ToCF.aspx.cs" Inherits="Notice_MPWxNotice_ToCF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <style>
        #TMBoard td {
            padding: 5px;
        }
    </style>
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
                <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                选择地级市：
                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
                <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <div style="margin: 20px 0 0 0; padding: 20px; background-color: white; border-radius: 10px; width: 500px;">
            <table id="TMBoard">
                <tr>
                    <td>报价提醒</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbFirst" runat="server" Width="400px" TextMode="MultiLine" Rows="3"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>交易编号：
                    <asp:TextBox ID="tbTradeId" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>报价日期：
                    <asp:TextBox ID="tbQuotationDate" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>备注信息：<br />
                        <asp:TextBox ID="tbRemark" runat="server" Width="400px" TextMode="MultiLine" Rows="3"></asp:TextBox></td>
                </tr>
            </table>
        </div>
        <div>
            当前队列中待发消息共有：<asp:Literal ID="ltlCountToSend" runat="server"></asp:Literal> 条。
        </div>
        <div>
            <asp:Button ID="btnPushIn" runat="server" Text="保存模板队列消息" OnClick="btnPushIn_Click" />
            <asp:Button ID="btnStartSend" runat="server" Text="批量发送队列消息" OnClick="btnStartSend_Click" />
        </div>
    </div>
</asp:Content>

