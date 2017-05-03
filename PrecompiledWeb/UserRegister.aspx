<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="UserRegister, App_Web_2u5vkwgg" theme="Default" %>

<%@ Register Src="UserControls/DDLAddress.ascx" TagName="DDLAddress" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <p class="title">
            用户注册
        </p>
        <div class="detail">
            <div class="titlen">
                <div class="bt">
                    用户注册
                </div>
            </div>
            <asp:DropDownList ID="ddlUser" runat="server" Visible="false"></asp:DropDownList>
            <asp:HiddenField ID="hfUserTypeId" runat="server" />
            <br />
            所在地：<uc1:DDLAddress ID="DDLAddress1" runat="server" />
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    联系人称呼：<asp:TextBox ID="tbContacts" runat="server"></asp:TextBox><br />
                    注册手机号：<asp:TextBox ID="tbMobileNum" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="免费获取验证码" OnClick="Button1_Click" /><asp:Label ID="lbMsg" runat="server" Text=""></asp:Label><br />
                    请输入短信验证码：<asp:TextBox ID="tbCode" runat="server"></asp:TextBox><br />
                    密码：<asp:TextBox ID="tbPassword" runat="server" TextMode="Password" ValidationGroup="CreateUser"
                        Width="120px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="请输入3位以上的密码！"
                        ControlToValidate="tbPassword" ValidationExpression="^\w{3,30}" ValidationGroup="CreateUser"></asp:RegularExpressionValidator><br />
                    确认密码：<asp:TextBox ID="tbConfirmPassword" runat="server" TextMode="Password" ValidationGroup="CreateUser"
                        Width="120px"></asp:TextBox><asp:CompareValidator ID="cvConfirmPassword" runat="server" ErrorMessage="两次密码输入不相同！"
                            ControlToCompare="tbPassword" ControlToValidate="tbConfirmPassword" ValidationGroup="CreateUser"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入检验密码！"
                        ControlToValidate="tbConfirmPassword" ValidationGroup="CreateUser"></asp:RequiredFieldValidator>

                    <asp:Button ID="btSure" runat="server" Text="提交" OnClick="btSure_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

