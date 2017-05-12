<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="BuyInfo, App_Web_nxjwqwfp" theme="Default" %>

<%@ Register Src="~/UserControls/DDLAddress.ascx" TagName="DDLAddress" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>发布求购信息</h1>
                </p>
            </div>
            <hr />
            <asp:HiddenField ID="hfUserTelNum" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />

            选择地区：<uc1:DDLAddress ID="DDLAddress1" runat="server" />
            <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

            <br />
            标题：<asp:TextBox ID="tbTitle" runat="server" Width="525px"></asp:TextBox>
            <br />
            货品类别：<asp:DropDownList ID="ddlTS" runat="server"></asp:DropDownList>
            <br />
            货品单位：<asp:DropDownList ID="ddlUnit" runat="server"></asp:DropDownList>
            <br />
            详细说明：<asp:TextBox ID="tbDetail" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            联系人：<asp:Label ID="lbContact" runat="server" Text=""></asp:Label>
            <br />
            联系方式：<asp:Label ID="lbTelNum" runat="server" Text=""></asp:Label>
            <br />
            求购总量：<asp:TextBox ID="tbTotalNum" runat="server" Width="525px"></asp:TextBox>
            <br />
            交易价格：<asp:TextBox ID="tbPrice" runat="server" Width="525px"></asp:TextBox>
            <br />
            图片信息：<asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="btPreview" runat="server" Text="预览" OnClick="btPreview_Click" Visible="false" />
            <br />
            <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" Visible="false" />
            <asp:HiddenField ID="hfFilePath" runat="server" />
            <br />

            <asp:Button ID="btBuy" runat="server" OnClick="btBuy_Click" Text="发布" />
            <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
        </div>
    </div>
</asp:Content>

