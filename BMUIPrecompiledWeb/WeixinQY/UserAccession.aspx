<%@ page title="" language="C#" masterpagefile="~/Manage.master" autoeventwireup="true" inherits="Admin_WeixinQY_UserAccession, App_Web_clv5me42" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="font-size: 1.2em; margin-bottom: 10px;">业务员准入管理</div>
    <span style="color: burlywood;">已交押金，且实名认证完毕的街道业务员可允许准入企业号</span>
    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" RowStyle-Height="30px" OnRowCommand="gvUsers_RowCommand">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="姓名" />
            <asp:BoundField DataField="MobilePhoneNum" HeaderText="账户（认证手机）" />
            <asp:TemplateField HeaderText="地址">
                <ItemTemplate>
                    <%--                    <asp:Literal ID="ltlProvince" runat="server"></asp:Literal>&nbsp;&nbsp;
                    <asp:Literal ID="ltlCity" runat="server"></asp:Literal>&nbsp;&nbsp;
                    <asp:Literal ID="ltlTown" runat="server"></asp:Literal>&nbsp;&nbsp;
                    <asp:Literal ID="ltlStreet" runat="server"></asp:Literal>&nbsp;&nbsp;--%>
                    <asp:Label ID="lbProvince" runat="server" Text='<%# Bind("Province") %>'></asp:Label>
                    <asp:Label ID="lbCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                    <asp:Label ID="lbTown" runat="server" Text='<%# Bind("Town") %>'></asp:Label>
                    <asp:Label ID="lbStreet" runat="server" Text='<%# Bind("Street") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CreateTime" HeaderText="创建时间" />
            <asp:BoundField DataField="AuditDate" HeaderText="认证时间" />
            <asp:TemplateField HeaderText="认证标记">
                <ItemTemplate>
                    <asp:Label ID="lbAudit" runat="server" Text='<%# Convert.ToBoolean(Eval("Audit"))?"√":"" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="企业号用户标记">
                <ItemTemplate>
                    <asp:Label ID="lbQYUser" runat="server" Text='<%# Convert.ToBoolean(Eval("IsQYUser"))?"√":"否" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnCreate" runat="server" ToolTip="准许该用户进入企业号" CommandName="Create" CommandArgument='<%# Eval("UserId") %>'>准入</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        <RowStyle Height="30px"></RowStyle>
    </asp:GridView>
    <asp:Label ID="lbResult" runat="server" Text="结果"></asp:Label>
</asp:Content>

