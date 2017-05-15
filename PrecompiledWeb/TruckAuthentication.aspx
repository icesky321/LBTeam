<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="TruckAuthentication, App_Web_mx1oxp1l" theme="Default" %>

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
                    <h1>货车主资料上传</h1>
                </p>
            </div>
            <hr />
            <asp:HiddenField ID="hfTruckId" runat="server" />

        </div>
    </div>
</asp:Content>

