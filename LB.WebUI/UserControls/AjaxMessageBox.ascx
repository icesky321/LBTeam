<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AjaxMessageBox.ascx.cs"
    Inherits="AjaxControl_AjaxMessageBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<style type="text/css">
    .MessageDialog {
        background-color: #CCCCFF;
        border-width: 3px;
        border-style: solid;
        border-color: Gray;
        padding: 10px;
        width: 350px;
        text-align: center;
    }

    .MessageDialogBackground {
        background-color: #6699CC;
        filter: alpha(opacity=70);
        opacity: 0.7;
    }
</style>
<asp:Button ID="tbTest" runat="server" Text=""  Width="1px" Height="1px" />
<asp:Panel ID="pnlMessage" runat="server" Class="MessageDialog">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" OnLoad="UpdatePanel1_Load">
        <ContentTemplate>
            <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label><br />
            <div style="padding: 10px 0px 10px 0px; text-align: center;">
                <asp:Button ID="btnClose" runat="server" Text="确定" OnClick="btnClose_Click" CausesValidation="false" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="tbTest"
    PopupControlID="pnlMessage" BackgroundCssClass="MessageDialogBackground">
</asp:ModalPopupExtender>
