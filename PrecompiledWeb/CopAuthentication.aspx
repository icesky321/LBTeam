<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="CopAuthentication, App_Web_2u5vkwgg" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/amazeui.js" type="text/javascript" charset="utf-8"></script>
    <link rel="stylesheet" href="css/common.min.css" />
    <link rel="stylesheet" href="css/contact.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="layout">

        <!--===========layout-container================-->
        <div class="layout-container">
            <div class="section">
                <div class="container">
                    <div class="am-u-md-12">
                        <div class="section--header">
                            <h2 class="section--title">商家认证</h2>
                            <p class="section--description">
                                <%--                            云适配致力于为企业提供全球最先进的移动化技术帮助企业最高效安全实现生产力提升<br />
                            One Web，Any Device--%>
                            </p>
                        </div>
                        <asp:HiddenField ID="HFCopId" runat="server" />
                        银行账号开户行：<asp:TextBox ID="tbBankName" runat="server"></asp:TextBox><br />
                        银行账号：<asp:TextBox ID="tbAccount" runat="server"></asp:TextBox><br />
                        营业执照上传：
    <asp:FileUpload ID="FUBizlicense" runat="server" />
                        <asp:Image ID="Image1" runat="server" Width="200px" Height="100px" /><br />
                        危化许可证上传：<asp:FileUpload ID="FUHWPermit" runat="server" />
                        <asp:Image ID="Image2" runat="server" Width="200px" Height="100px" /><br />
                        负责人身份证上传：<asp:FileUpload ID="FUIDCard" runat="server" />
                        <asp:Image ID="Image3" runat="server" Width="200px" Height="100px" /><br />
                        协议上传：<asp:FileUpload ID="FUChop" runat="server" />
                        <asp:Image ID="Image4" runat="server" Width="200px" Height="100px" />

                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        <asp:Button ID="btUpLoad" runat="server" Text="上传" OnClick="btUpLoad_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

