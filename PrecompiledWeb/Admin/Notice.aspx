<%@ page title="" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_Notice, App_Web_tyh5dbga" validaterequest="false" theme="Default" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/amazeui.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset style="width: 581px; height: 285px;">
        <legend>前台公告信息设置</legend>
        <div class="am-u-md-12">
            公告：           
            <FTB:FreeTextBox ID="FreeTextBox1" runat="server" Height="276px" Width="250px">
            </FTB:FreeTextBox>
            <br />

            <asp:Button ID="btnNotice" runat="server" Text="保存" OnClick="btnNotice_Click"
                ValidationGroup="Notice" />
            <br />
            <hr />
        </div>
        <div class="am-u-md-12">
            今日铅价<%--<asp:TextBox ID="tbPBPrice" runat="server"></asp:TextBox>--%>
            <FTB:FreeTextBox ID="tbPBPrice" runat="server" Height="276px" Width="250px">
            </FTB:FreeTextBox>
            <asp:Button ID="btPBPrice" runat="server" Text="保存" OnClick="btPBPrice_Click" />
            <br />
            <hr />
        </div>
        <div class="am-u-md-12">
            今日废旧电瓶回收价格：<%--<asp:TextBox ID="tbDPPrice" runat="server"></asp:TextBox>--%>
            <FTB:FreeTextBox ID="tbDPPrice" runat="server" Height="276px" Width="250px">
            </FTB:FreeTextBox>
            <asp:Button ID="btDPPrice" runat="server" Text="保存" OnClick="btDPPrice_Click" />
        </div>



    </fieldset>
</asp:Content>

