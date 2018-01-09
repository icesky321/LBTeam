<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Login_Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <link href="http://res.wx.qq.com/open/libs/weui/0.4.0/weui.min.css" rel="stylesheet" />
    <script type="text/javascript">        //$(function () { window.location.hash = "#title"; }) </script>
    <script type="text/javascript">
        $(function () { window.location.href = "#pos"; })
    </script>
    <title>用户注册</title>
</head>
<body ontouchstart>
    <form id="form1" runat="server" data-ajax="false">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/WS/CNRegionService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div id="pageMain" data-role="page">
            <div data-role="header">
                <h1>绿宝新用户注册</h1>
            </div>

            <div data-role="main" class="ui-content">
                <div>
                    注册说明：<br />
                    手机号码是平台登录的唯一凭证。<br />
                    请根据自己实际情况谨慎选择行业身份，一旦选定，不可变更。<a href="../ljlb/cjwt.aspx#page2" rel="external">了解行业身份</a><br />
                    回收公司加盟热线：137 7771 3333
                </div>
                <div style="padding: 20px 0;">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="错误信息" ShowMessageBox="True" />
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="请输入手机号码" ControlToValidate="tbMobile" Display="Dynamic" ValidationGroup="Reg1"></asp:RequiredFieldValidator>
                    <asp:Label ID="ltlErrorMsg" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                </div>
                <asp:DropDownList ID="ddlShenfen" runat="server" data-native-menu="false" DataTextField="UserTypeName" DataValueField="DataTypeId" AutoPostBack="true" OnSelectedIndexChanged="ddlShenfen_SelectedIndexChanged">
                </asp:DropDownList>

                <asp:TextBox ID="tbMobile" runat="server" placeholder="请输入手机号码" ValidationGroup="Reg1"></asp:TextBox>

                <asp:LinkButton ID="lbtnGetVeriCode" runat="server" OnClick="lbtnGetVeriCode_Click" ValidationGroup="Reg1">点击获取验证码</asp:LinkButton>&nbsp;&nbsp;<asp:Literal ID="ltlVeriMessage" runat="server" Text="正在获取中，请稍后" Visible="false"></asp:Literal>
                <asp:TextBox ID="tbVeriCode" runat="server" placeholder="输入验证码"></asp:TextBox>
                <div data-role="controlgroup">
                    密码：&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="密码不可为空" ControlToValidate="tbPassword" Display="Dynamic" ValidationGroup="Reg2" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <asp:TextBox ID="tbPassword" runat="server" placeholder="设置登录密码" ClientIDMode="Static" ValidationGroup="Reg2"></asp:TextBox>

                <div data-role="main" class="ui-content">
                    <%--                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <a href="#pos" id="title" name="title">省份</a>
                    <asp:HiddenField ID="hfRegionCode" runat="server" />
                    选择省份：
                <asp:DropDownList ID="ddlProvince" runat="server"></asp:DropDownList>
                    <asp:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlProvince" Category="Province" PromptText="请选择省份...." LoadingText="加载中，请稍后 ..." ServicePath="~/WS/CNRegionService.asmx" ServiceMethod="GetProvince" />
                    选择地级市：
                <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
                    <asp:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlCity" ParentControlID="ddlProvince" Category="City" PromptText="请选择城市...." LoadingText="加载中，请稍后 ..." ServicePath="~/WS/CNRegionService.asmx" ServiceMethod="GetCity" />
                    <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
                    选择县市：
            <asp:DropDownList ID="ddlCounty" runat="server"></asp:DropDownList>
                    <asp:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID="ddlCounty" ParentControlID="ddlCity" Category="County" PromptText="请选择县市...." LoadingText="加载中，请稍后 ..." ServicePath="~/WS/CNRegionService.asmx" ServiceMethod="GetCounty" />
                    镇或街道：
                 <asp:DropDownList ID="ddlStreet" runat="server"></asp:DropDownList>
                    <asp:CascadingDropDown ID="CascadingDropDown4" runat="server" TargetControlID="ddlStreet" ParentControlID="ddlCounty" Category="Street" PromptText="请选择街道...." LoadingText="加载中，请稍后 ..." ServicePath="~/WS/CNRegionService.asmx" ServiceMethod="GetStreet" />
                    详细地址：
                <asp:TextBox ID="tbAddress" runat="server" ValidationGroup="edit"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请填入详细地址" ControlToValidate="tbAddress" ValidationGroup="Reg2" ForeColor="Red"></asp:RequiredFieldValidator>
                    <p>注：为了回收业务员能准确及时地上门为您服务，请将地址填得尽可能详细精确</p>
                    <%--                        </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>

                <asp:Button ID="btnReg" runat="server" Text="注册" OnClick="btnReg_Click" ValidationGroup="Reg2" />
            </div>
            <div data-role="footer">
                <div class="page__bd page__bd_spacing">
                    <br>
                    <br>
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:void(0);" class="weui-footer__link"></a>
                        </p>
                        <p class="weui-footer__text">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</p>
                    </div>
                </div>
            </div>
        </div>


    </form>
</body>
</html>
