<%@ page title="" language="C#" autoeventwireup="true" inherits="ChooseRoles, App_Web_g2gvyyit" theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>用户注册</title>
    <link rel="stylesheet" href="css/amazeui.css" />
    <link rel="stylesheet" href="css/other.min.css" />
    <script src="https://static.yjsvip.com/static/js/fastclick.js"></script>
    <script type="text/javascript">
        $(function () {
            new FastClick(document.body);
        })
    </script>
</head>

<body class="login-container">

    <form runat="server" action="" class="am-form" data-am-validator>
        <div class="login-box">

            <img src="img/logo1.png" alt="" />
            <br />
            <br />
            <br />
            <div class="section" style="text-align: center;">
                <div class="container">
                    <div class="section--header" style="text-align: center">
                        <p class="section--description">
                            <h1>用户注册</h1>
                        </p>
                    </div>
                    <div class="am-g" style="border: 0px solid #eee; margin: 10px">
                        <%--                        <div class="am-u-md-4">
                            &nbsp;&nbsp;
                        </div>--%>
                        <div class="am-u-md-12">
                            <table style="text-align: center;">
                                <tr>
                                    <td>我是：</td>
                                    <td>
                                        <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择" ControlToValidate="ddlUserType" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                                </tr>
                            </table>

                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="AA" Checked="true" />个人
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="AA" />商家
                            </asp:Panel>
                            <br />
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" />我已认真阅读并同意<asp:LinkButton ID="lbtnProtocol" runat="server" PostBackUrl="~/Protocol.aspx">绿宝平台注册协议</asp:LinkButton><br />
                            <asp:Button ID="btSearch" runat="server" Text="确定" OnClick="btSearch_Click" ValidationGroup="1" />

                        </div>
                        <%--  <div class="am-u-md-4" style="text-align: left; margin-top: -50px;">
                            &nbsp;&nbsp;
                   电瓶产废单位或个人：有电瓶货源的个人或商家请选择此项；
                    
                   <br />
                    合法回收公司：有合法回收资质的电瓶回收企业；
                     
                   <br />
                    合法冶炼厂：有合法冶炼资质的冶炼企业；
                 
                   <br />
                    物流公司：拥有物流许可证的承包者；
                 
                   <br />
                    地域性回收员：地方回收街道回收员；
                 
                   <br />
                    其他公司：除以上范围外的企业；
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
