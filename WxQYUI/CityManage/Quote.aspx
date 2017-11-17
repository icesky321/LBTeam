<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Quote.aspx.cs" Inherits="CityManage_Quote" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <style>
        .dataCell {
            padding: 10px;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
        <div style="padding: 20px 0 20px 0; font-size: 1.5em; font-family: 'Microsoft JhengHei'; font-weight: bold;">
            回收公司报价平台
        </div>
        <div>报价区域：<asp:Literal ID="ltlCityName" runat="server"></asp:Literal></div>
        <asp:HiddenField ID="hfUserId" runat="server" />
        <asp:HiddenField ID="hfRegionCode" runat="server" Value="330100000000" />
        <div style="padding: 10px 0 10px 0;">
            选择品种：
            <asp:DropDownList ID="ddlDC" runat="server" DataTextField="TSName" DataValueField="TsCode" AutoPostBack="True" OnSelectedIndexChanged="ddlDC_SelectedIndexChanged"></asp:DropDownList>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="请选择品种" ControlToValidate="ddlDC" OnServerValidate="CustomValidator1_ServerValidate" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Quote"></asp:CustomValidator>
        </div>
        <div style="padding: 10px 0 10px 0;">
            价格单位：<asp:Literal ID="ltlDescription" runat="server"></asp:Literal>
            <asp:Literal ID="ltlChargeUnit" runat="server"></asp:Literal>
            <asp:HiddenField ID="hfTs" runat="server" Value="" />
            <br />
            若各区县价格统一，为提高输入效率，可用此价格填充小工具：<asp:TextBox ID="tbPriceSample" runat="server" CssClass="textbox"></asp:TextBox><asp:LinkButton ID="btnFillup" runat="server" Text="填充" OnClick="btnFillup_Click" /><br />
        </div>
        <table style="width: 100%; border-top: 2px solid #808080;">
            <tr>
                <td style="width: 150px; text-align: center;">报价区域</td>
                <td style="width: 150px; text-align: center;">最新报价</td>
                <td style="padding: 0 0 0 40px;">更新报价</td>
                <td style="width: 150px; text-align: center;">价格单位</td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="false" Width="100%" ShowHeader="false" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hfRegionCode" runat="server" Value='<%# Eval("Id") %>' />
                        <asp:Label ID="lbAreaName" runat="server" Text='<%# Eval("AreaName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lbLastPrice" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:TextBox ID="tbPrice" runat="server" Text="" Width="100%" BorderStyle="None"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="tbInput" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lbUnit" runat="server" Text='<%# DataBinder.GetPropertyValue(ltlChargeUnit,"Text") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="padding: 10px 0 50px 0;">
            <asp:Button ID="btnQuote" runat="server" Text="保存当前报价" OnClick="btnQuote_Click" ValidationGroup="Quote" />
            &nbsp;&nbsp;
            <asp:Button ID="btnClear" runat="server" Text="清空当前数值，不影响已保存数值" OnClick="btnClear_Click" />
            &nbsp;&nbsp;
            <asp:LinkButton ID="lbtnQuery" runat="server" PostBackUrl="~/Quotation/ShowQuotation.aspx" Visible="false">查询最新价格</asp:LinkButton>
        </div>
        <asp:Label ID="lbMsg" runat="server" Text="保存成功！" ForeColor="Red" Visible="false"></asp:Label>
    </form>
</body>
</html>
