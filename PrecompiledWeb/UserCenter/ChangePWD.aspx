<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="UserCenter_ChangePWD, App_Web_kagry0hp" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="section--header" style="text-align: center">
                    <p class="section--description">
                        <h1>重置密码</h1>
                    </p>
                </div>
                <hr />
                用户名：<asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
                <br />
                <hr />
                原密码：<asp:TextBox ID="tbPwd" runat="server" ValidationGroup="CreateUser"></asp:TextBox>

                <br />
                <hr />
                密码：<asp:TextBox ID="tbPassword" runat="server" TextMode="Password" ValidationGroup="CreateUser"
                    Width="120px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="请输入3位以上的密码！"
                    ControlToValidate="tbPassword" ValidationExpression="^\w{3,30}" ValidationGroup="CreateUser"></asp:RegularExpressionValidator><br />
                <hr />
                确认密码：<asp:TextBox ID="tbConfirmPassword" runat="server" TextMode="Password" ValidationGroup="CreateUser"
                    Width="120px"></asp:TextBox><asp:CompareValidator ID="cvConfirmPassword" runat="server" ErrorMessage="两次密码输入不相同！"
                        ControlToCompare="tbPassword" ControlToValidate="tbConfirmPassword" ValidationGroup="CreateUser"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入检验密码！"
                    ControlToValidate="tbConfirmPassword" ValidationGroup="CreateUser"></asp:RequiredFieldValidator><br />
                <hr />

                <asp:Button ID="btSure" runat="server" Text="提交" OnClick="btSure_Click" ValidationGroup="CreateUser" />
                <asp:Label ID="lbMsg" runat="server" Text="密码更新成功！请牢记该密码~" Font-Bold="True" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

