<%@ page title="平台全局监控" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_Monitor_GlobalMonitor, App_Web_avejlpj1" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .state {
            width: 100%;
        }

            .state td {
                text-align: center;
                padding: 10px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>用户数据</div>
    <div>
        <table class="state">
            <tr>
                <td>用户总数<br />
                    <span style="font-size: 2em;">
                        <asp:Literal ID="ltlUserSum" runat="server" Text="0"></asp:Literal></span>
                </td>
                <td>认证用户<br />
                    <span style="font-size: 2em;">
                        <asp:Literal ID="ltlIsQYUserSum" runat="server" Text="0"></asp:Literal></span>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>

