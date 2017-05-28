<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="WaitingForAudit, App_Web_r1xdel2n" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="css/other.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="layout">
        <!--===========layout-container================-->
        <div class="layout-container">
            <div class="error error-light">
                <div class="container">
                    <h2 style="font-size:40px">正在审核中</h2>
                    <p>您的申请已提交成功，我们将尽快进行审核工作，请您耐心等待</p>
                    <button type="button" class="am-btn am-btn-secondary" onclick="window.location.href='Default.aspx'">返回首页</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

