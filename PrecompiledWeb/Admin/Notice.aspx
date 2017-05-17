<%@ page title="" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_Notice, App_Web_unoc1clr" validaterequest="false" theme="Default" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset style="width: 581px; height: 285px;">
        <legend>公告设置</legend>
        <div style="padding: 20px;">
            公告：            <FTB:FreeTextBox ID="FreeTextBox1" runat="server" Height="276px" Width="250px">
            </FTB:FreeTextBox>
            <br />

            <asp:Button ID="btnNotice" runat="server" Text="保存" OnClick="btnNotice_Click"
                ValidationGroup="Notice" />

        </div>
    </fieldset>
</asp:Content>

