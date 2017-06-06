<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CopAuthentication.aspx.cs" Inherits="CopAuthentication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="css/main.css" />
    <script src="js/amazeui.js" type="text/javascript" charset="utf-8"></script>
    <link rel="stylesheet" href="css/common.min.css" />
    <link rel="stylesheet" href="css/contact.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="layout">

        <!--===========layout-container================-->
        <div class="section" style="text-align: center;">
            <div class="container">
                <div class="section--header" style="text-align: center">
                    <p class="section--description">
                        <h1>企业商家认证</h1>
                    </p>
                </div>
                <hr />
                <asp:HiddenField ID="HFUserId" runat="server" />
                <hr />
                <table>
                    <tr>
                        <td>银行账号开户行：</td>
                        <td>
                            <asp:TextBox ID="tbBankName" runat="server"></asp:TextBox></td>
                    </tr>
                </table>

                <br />
                <hr />
                <br />
                <table>
                    <tr>
                        <td>银行账号：</td>
                        <td>
                            <asp:TextBox ID="tbAccount" runat="server"></asp:TextBox></td>
                    </tr>
                </table>

                <br />
                <hr />
                <br />
                <table>
                    <tr>
                        <td rowspan="2">负责人身份证上传：</td>
                        <td rowspan="2">
                            <asp:Image ID="Image9" runat="server" Height="168px" ImageUrl="~/images/IDSample.jpg" Width="155px" />
                        </td>
                        <td>

                            <asp:FileUpload ID="FUIDCard" runat="server" /><asp:Image ID="Image3" runat="server" Width="200px" Height="100px" /></td>
                    </tr>
                </table>
                <br />
                <hr />
                <br />
                <table>
                    <tr>
                        <td>营业执照上传：</td>
                        <td>
                            <asp:FileUpload ID="FUBizlicense" runat="server" />
                            <asp:Image ID="Image1" runat="server" Width="200px" Height="100px" /></td>
                    </tr>
                </table>

                <br />
                <hr />
                <br />
                <table>
                    <tr>
                        <td>危化许可证上传：</td>
                        <td>
                            <asp:FileUpload ID="FUHWPermit" runat="server" />
                            <asp:Image ID="Image2" runat="server" Width="200px" Height="100px" />注：如供货商用户，此项可不填</td>
                    </tr>
                </table>

                <br />
                <hr />
                <br />
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btUpLoad" runat="server" Text="上传" OnClick="btUpLoad_Click" />
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>




                <%--<table class="auto-style1">
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
                        <td rowspan="2" class="auto-style1">负责人身份证上传：</td>
                        <td class="auto-style1" rowspan="2">
                            <asp:Image ID="Image9" runat="server" Height="168px" ImageUrl="~/images/IDSample.jpg" Width="155px" />
                        </td>
                        <td class="auto-style1">
                            <asp:FileUpload ID="FUIDCard" runat="server" />
                        </td>
                        <td rowspan="2" class="auto-style1">
                            <asp:Image ID="Image3" runat="server" Width="200px" Height="100px" /></td>
                    </tr>
                    <tr>
                        <td class="auto-style1" rowspan="2">营业执照上传：</td>
                        <td class="auto-style1">
                            <asp:FileUpload ID="FUBizlicense" runat="server" /></td>
                        <td class="auto-style1" rowspan="2">
                            <asp:Image ID="Image1" runat="server" Width="200px" Height="100px" /></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">请上传商家的营业执照照片</td>
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
                        <td class="auto-style1">请上传商家的危化许可证照片</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style1">
                            <asp:Button ID="btUpLoad" runat="server" Text="上传" OnClick="btUpLoad_Click" />

                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style1">&nbsp;</td>
                    </tr>
                </table>--%>
            </div>
        </div>
    </div>

</asp:Content>

