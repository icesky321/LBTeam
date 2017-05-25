<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="ErrorPage, App_Web_ny0diclq" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="css/other.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="layout">
        <!--===========layout-container================-->
        <div class="layout-container">
            <div class="error error-light">
                <div class="container">
                    <h2>404</h2>
                    <p>Page Not Found</p>
                    <p>对不起,没有找到您所需要的页面,可能是URL不确定,或者页面已被移除。</p>
                    <button type="button" class="am-btn am-btn-secondary" onclick="window.location.href='Default.aspx'">Home</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

