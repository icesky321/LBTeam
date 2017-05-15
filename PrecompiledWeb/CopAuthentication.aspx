<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="CopAuthentication, App_Web_mx1oxp1l" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/amazeui.js" type="text/javascript" charset="utf-8"></script>
    <link rel="stylesheet" href="css/common.min.css" />
    <link rel="stylesheet" href="css/contact.min.css" />
    <style type="text/css">
        .auto-style1 {
            border: 1px solid #999999;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="layout">

        <!--===========layout-container================-->
        <div class="section" style="text-align:center;">
            <div class="container">
                <div class="section--header" style="text-align: center">
                    <p class="section--description">
                        <h1>企业商家认证</h1>
                    </p>
                </div>
                <hr />
                <asp:HiddenField ID="HFCopId" runat="server" />

                <table class="auto-style1">
                    <tr>
                        <td class="auto-style1">银行账号开户行：</td>
                        <td class="auto-style1" colspan="2">
                            <asp:TextBox ID="tbBankName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">银行账号：</td>
                        <td class="auto-style1" colspan="2">
                            <asp:TextBox ID="tbAccount" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style1" rowspan="2">营业执照上传：</td>
                        <td class="auto-style1">
                            <asp:FileUpload ID="FUBizlicense" runat="server" /></td>
                        <td class="auto-style1" rowspan="2">
                            <asp:Image ID="Image1" runat="server" Width="200px" Height="100px" /></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">gdsfsdfsdfsdfsfsdfsdfsfsdfsfsfsdfsfsfsdfsdfsfsdfsadfasfsdfads</td>
                    </tr>
                    <tr>
                        <td class="auto-style1" rowspan="2">危化许可证上传：</td>
                        <td class="auto-style1">
                            <asp:FileUpload ID="FUHWPermit" runat="server" />
                        </td>
                        <td class="auto-style1" rowspan="2">
                            <asp:Image ID="Image2" runat="server" Width="200px" Height="100px" /></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">dsfasdfsdfasdfdsvxfdsfsdafs</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style1">
                            <asp:Button ID="btUpLoad" runat="server" Text="上传" OnClick="btUpLoad_Click" />

                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style1">&nbsp;</td>
                    </tr>
                </table>

            </div>
        </div>
    </div>

</asp:Content>

