<%@ Page Title="平台员工管理" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true"
    CodeFile="StaffManage.aspx.cs" Inherits="BasicConfig_SysUserManage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
    <div class="title">
        平台员工管理
    </div>
    <div class="prompt" style="background-color: #F0F0F0;">
        创建平台员工后,将会自动创建出以下内容：<br />
        1、将自动创建平台登录账户，登录名为其手机号码，默认密码为12345678。<br />
        2、自动创建用户信息记录。<br />
        3、自动创建平台员工记录。
    </div>
    <div class="contentArea">
        <div style="padding: 0 0 20px 0;">
            在该页面设置系统操作用户,当前共有系统用户：
            <asp:Label ID="lbCountOfUser" runat="server" Text="0"></asp:Label>
            个。<br />
        </div>
        <div style="padding: 10px 0 10px 0;">
            <asp:Button ID="btnCreateUser" runat="server" Text="创建平台员工" BorderStyle="Solid" BorderColor="#CCCCCC" OnClick="btnCreateUser_Click" />
        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="StaffId" OnRowCommand="gvUser_RowCommand" DataMember="JobNumber"
                    OnRowDeleting="gvUser_RowDeleting" CssClass="dataTable" RowStyle-Height="30px"
                    EmptyDataText="当前系统无用户，输入工号或姓名添加">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#  Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="StaffId" HeaderText="用户Id" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="JobNumber" HeaderText="工号" SortExpression="JobNumber" />
                        <asp:BoundField DataField="UserName" HeaderText="昵称" SortExpression="UserName" />
                        <asp:BoundField DataField="RealName" HeaderText="姓名" SortExpression="RealName" />
                        <asp:BoundField DataField="Sex" HeaderText="性别" SortExpression="Sex" />
                        <%--                        <asp:TemplateField HeaderText="微信标记">
                            <ItemTemplate>
                                <asp:Image ID="imgWeixin" runat="server" ImageUrl="~/App_Themes/Default/Images/weixin_user.png"
                                    Visible='<%# IsWeixinUser(Eval("JobNumber").ToString()) %>' ToolTip="企业微信用户" />
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>--%>

                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                    CommandArgument='<%# Eval("StaffId") %>' Text="删除" OnClientClick='return confirm("你确定要删除吗？");'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle Width="50px" />
                    <EmptyDataRowStyle Height="150px" HorizontalAlign="Center"
                        VerticalAlign="Middle" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
