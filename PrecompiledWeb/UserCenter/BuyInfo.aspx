<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="BuyInfo, App_Web_wkczwwiq" theme="Default" %>

<%@ Register Src="~/UserControls/DDLAddress.ascx" TagName="DDLAddress" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/main.css" />
    <style type="text/css">
        .table1 {
            border: 0;
            margin: 0;
            border-collapse: collapse;
        }

            .table1 td {
                padding: 4px;
            }
    </style>
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
            <table class="table1">
                <tr>
                    <td>选择地区：</td>
                    <td>
                        <uc1:DDLAddress ID="DDLAddress1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>标题：</td>
                    <td>
                        <asp:TextBox ID="tbTitle" runat="server" Width="525px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>货品类别：</td>
                    <td>
                        <asp:DropDownList ID="ddlTS" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>货品单位：</td>
                    <td>
                        <asp:DropDownList ID="ddlUnit" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>求购总量：</td>
                    <td>
                        <asp:TextBox ID="tbTotalNum" runat="server" Width="525px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>交易价格：</td>
                    <td>
                        <asp:TextBox ID="tbPrice" runat="server" Width="525px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>详细说明：</td>
                    <td>
                        <asp:TextBox ID="tbDetail" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>联系人：</td>
                    <td>
                        <asp:Label ID="lbContact" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>联系方式：</td>
                    <td>
                        <asp:Label ID="lbTelNum" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>图片信息：</td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="btPreview" runat="server" Text="预览" OnClick="btPreview_Click" Visible="false" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" Visible="false" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btBuy" runat="server" OnClick="btBuy_Click" Text="发布" /></td>
                </tr>
            </table>
            <asp:HiddenField ID="hfFilePath" runat="server" />
        </div>
    </div>
</asp:Content>

