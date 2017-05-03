<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserAuthentication.aspx.cs" Inherits="UserAuthentication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <p class="title">
            用户认证
        </p>
        <div class="detail">
            <div class="titlen">
                <div class="bt">
                    用户认证
                </div>
            </div>
            <asp:HiddenField ID="hfUserId" runat="server" />
            银行账号开户行：<asp:TextBox ID="tbBankName" runat="server"></asp:TextBox><br />
            银行账号：<asp:TextBox ID="tbAccount" runat="server"></asp:TextBox><br />
            身份证上传：<asp:FileUpload ID="FUIDCard" runat="server" />
            <asp:Image ID="Image1" runat="server" Width="200px" Height="100px" /><br />
            协议上传：<asp:FileUpload ID="FUChop" runat="server" />
            <asp:Image ID="Image2" runat="server" Width="200px" Height="100px" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btUpLoad" runat="server" Text="上传" OnClick="btUpLoad_Click" />
        </div>
    </div>
</asp:Content>

