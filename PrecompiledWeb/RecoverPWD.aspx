<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="RecoverPWD, App_Web_ai5ykitv" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="css/amazeui.css" />
    <link rel="stylesheet" href="css/other.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="layout">
        <div class="section">
            <div class="container">
                <div class="section--header" style="text-align:center;">
                    <h1 class="section--title">取回密码</h1>
                    <hr />
                    <%--                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <fieldset style="width: 327px;">
                                <legend class="mainTitle" style="width: 122px"></legend>
                                <br />--%>
                    <table border="0" cellpadding="2" cellspacing="2" class="Main" width="100%">
                        <tr>
                            <td align="center" class="Head" style="height: 19px; width: 680px;"></td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 680px">请输入注册手机号：<asp:TextBox ID="tbUserName" runat="server"></asp:TextBox><asp:Button ID="btSure" runat="server" Text="取回密码" OnClick="btSure_Click" />
                                &nbsp; &nbsp;<asp:Label ID="lbsubject" runat="server" Height="19px" Width="381px"></asp:Label><br />
                                <asp:Label ID="lbbody" runat="server" Height="52px" Width="504px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <%--                            </fieldset>
                        </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <p class="section--description">
                    </p>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

