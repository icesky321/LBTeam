<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="UserAccession.aspx.cs" Inherits="Admin_WeixinQY_UserAccession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="font-size: 1.2em; margin-bottom: 10px;">用户账户企业号准入管理</div>
    <span style="color: burlywood;">已交押金，且实名认证完毕的冶炼厂、回收公司、回收业务员可允许准入企业号</span>
    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" RowStyle-Height="30px" OnRowCommand="gvUsers_RowCommand" OnRowDataBound="gvUsers_RowDataBound">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="姓名" />
            <asp:BoundField DataField="MobilePhoneNum" HeaderText="账户（认证手机）" />
            <asp:TemplateField HeaderText="行业角色">
                <ItemTemplate>
                    <asp:HiddenField ID="hfVocationTypeId" runat="server" Value='<%# Eval("UserTypeId") %>' />
                    <asp:Literal ID="ltlVocationType" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="地址">
                <ItemTemplate>
                    <asp:HiddenField ID="hfRegionCode" runat="server" Value='<%# Eval("RegionCode") %>' />
                    <asp:Label ID="lbRegionWholeName" runat="server"></asp:Label>
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

