<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Quote.aspx.cs" Inherits="Quotation_Quote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        .tbInput {
            padding: 0 7px 0 0;
            height: 30px;
        }

            .tbInput input {
                padding: 0 0 0 5px;
                height: 30px;
            }
    </style>
    <title></title>
</head>
<body style="padding: 0 20px 0 20px;">
    <form id="form1" runat="server">
        <div style="padding: 20px 0 20px 0; font-size: 1.5em; font-family: 'Microsoft JhengHei'; font-weight: bold;">
            回收公司报价平台
        </div>
        <div>报价区域：浙江省 杭州市</div>
        <asp:HiddenField ID="hfRegionCode" runat="server" Value="330100000000" />
        <div style="padding: 10px 0 10px 0;">
            选择品种：
            <asp:DropDownList ID="ddlDC" runat="server" DataTextField="TSName" DataValueField="TsCode" AutoPostBack="True" OnSelectedIndexChanged="ddlDC_SelectedIndexChanged"></asp:DropDownList>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="请选择品种" ControlToValidate="ddlDC" OnServerValidate="CustomValidator1_ServerValidate" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Quote"></asp:CustomValidator>
        </div>
        <div style="padding: 10px 0 10px 0;">
            说明：<asp:Literal ID="ltlDescription" runat="server"></asp:Literal>
            <asp:Literal ID="ltlChargeUnit" runat="server"></asp:Literal>
            <asp:HiddenField ID="hfTs" runat="server" Value="" />
        </div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="false" Width="800px" ShowHeader="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hfRegionCode" runat="server" Value='<%# Eval("Id") %>' />

                        <asp:Label ID="lbAreaName" runat="server" Text='<%# Eval("AreaName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:TextBox ID="tbPrice" runat="server" Text="" Width="100%" BorderStyle="None"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="tbInput" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="padding: 10px 0 0 0;">
            <asp:Button ID="btnQuote" runat="server" Text="保存当前报价" OnClick="btnQuote_Click" ValidationGroup="Quote" />
            &nbsp;&nbsp;
            <asp:Button ID="btnClear" runat="server" Text="清空当前数值，不影响已保存数值" OnClick="btnClear_Click" />
            &nbsp;&nbsp;
            <asp:LinkButton ID="lbtnQuery" runat="server" PostBackUrl="~/Quotation/ShowQuotation.aspx">查询最新价格</asp:LinkButton>
        </div>
    </form>
</body>
</html>
