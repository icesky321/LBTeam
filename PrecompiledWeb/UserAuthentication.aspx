<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="UserAuthentication, App_Web_vk1i312r" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            border: 1px solid #999999;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>用户认证资料上传</h1>
                </p>
            </div>
            <hr />
            <asp:HiddenField ID="hfUserId" runat="server" />

            <table class="auto-style1">
                <tr>
                    <td class="auto-style1">银行账号开户行：</td>
                    <td colspan="3" class="auto-style1">
                        <asp:TextBox ID="tbBankName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style1">银行账号：</td>
                    <td colspan="3" class="auto-style1">
                        <asp:TextBox ID="tbAccount" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td rowspan="2" class="auto-style1">身份证上传：</td>
                    <td class="auto-style1" rowspan="2">
                        <asp:Image ID="Image9" runat="server" Height="168px" ImageUrl="~/images/IDSample.jpg" Width="155px" />
                    </td>
                    <td class="auto-style1">
                        <asp:FileUpload ID="FUIDCard" runat="server" />
                    </td>
                    <td rowspan="2" class="auto-style1">
                        <asp:Image ID="Image1" runat="server" Width="200px" Height="100px" /></td>
                </tr>
                <tr>
                    <td class="auto-style1">请手持本人身份证拍照，参考左侧示例，身份证号码必须清晰可辨</td>
                </tr>
<%--                <tr>
                    <td rowspan="2" class="auto-style1">协议上传：</td>
                    <td class="auto-style1" rowspan="2">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:FileUpload ID="FUChop" runat="server" />
                    </td>
                    <td rowspan="2" class="auto-style1">
                        <asp:Image ID="Image2" runat="server" Width="200px" Height="100px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">请先下载协议，充分了解后确认签字，企业单位需盖公章，拍照后上传</td>
                </tr>--%>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
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
</asp:Content>

