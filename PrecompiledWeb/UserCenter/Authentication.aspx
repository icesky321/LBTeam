<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="UserCenter_Authentication, App_Web_fmgbfib2" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>个人认证信息</h1>
                </p>
            </div>
            <hr />

            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <table>
                        <tr>
                            <td>身份证信息：<asp:Image ID="Image1" runat="server" Width="200px" Height="100px" /></td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btUserAlter" runat="server" Text="修改认证信息" OnClick="btUserAlter_Click" /></td>
                        </tr>
                    </table>
                    <hr />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table>
                        <tr>
                            <td>身份证信息：<asp:Image ID="Image2" runat="server" Width="200px" Height="100px" /></td>
                            <td>
                                <asp:FileUpload ID="FUIDCard" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <hr />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>营业执照信息:<asp:Image ID="Image3" runat="server" Width="200px" Height="100px" /></td>
                            <td>
                                <asp:FileUpload ID="FUBizlicense" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <hr />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>危化许可证信息:<asp:Image ID="Image4" runat="server" Width="200px" Height="100px" /></td>
                            <td>
                                <asp:FileUpload ID="FUHWPermit" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <hr />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btCopAlter" runat="server" Text="修改认证信息" OnClick="btCopAlter_Click" /></td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
            <asp:Label ID="Label1" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>

