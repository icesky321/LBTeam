<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="CopInfoManage.aspx.cs" Inherits="Admin_CopInfoManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <asp:GridView ID="gvCopInfo" runat="server" AutoGenerateColumns="false" DataKeyNames="CopId" OnRowCommand="gvCopInfo_RowCommand">
        <Columns>
            <asp:BoundField DataField="CopId" HeaderText="CopId" SortExpression="CopId" Visible="True" />
            <asp:BoundField DataField="CopName" HeaderText="企业名称" SortExpression="CopName" />
            <asp:BoundField DataField="RealName" HeaderText="联系人" SortExpression="RealName" />
            <asp:BoundField DataField="MobilePhoneNum" HeaderText="联系号码" SortExpression="MobilePhoneNum" />
            <asp:TemplateField HeaderText="公司地址 " SortExpression="CopId">
                <ItemTemplate>
                    <asp:Label ID="lbProvince" runat="server" Text='<%# Bind("Province") %>'></asp:Label>
                    <asp:Label ID="lbCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                    <asp:Label ID="lbTown" runat="server" Text='<%# Bind("Town") %>'></asp:Label>
                    <asp:Label ID="lbStreet" runat="server" Text='<%# Bind("Street") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="公司银行账号 " SortExpression="Account">
                <ItemTemplate>
                    <asp:Label ID="lbBankAcccount" runat="server" Text='<%# Bind("Account") %>' ToolTip='<%# Bind("BankName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="营业执照 " SortExpression="Bizlicense">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnBizlicense" runat="server" Text="查看图片详情" CommandArgument='<%#Eval("CopId") %>'
                        CommandName="Bizlicense" ToolTip="营业执照"></asp:LinkButton>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="BView1" runat="server">
                            <asp:ImageButton ID="lbtnBP" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="BPass" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                            <%--<asp:LinkButton ID="lbtnBP" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="BPass">审核通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="BView2" runat="server">
                            <asp:ImageButton ID="lbtnBU" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="BUPass" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                            <%--<asp:LinkButton ID="lbtnBU" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="BUPass">取消通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="BView3" runat="server">
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="危化许可证 " SortExpression="HWPermit">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnHWPermit" runat="server" Text="查看图片详情" CommandArgument='<%#Eval("CopId") %>'
                        CommandName="HWPermit" ToolTip="危化许可证"></asp:LinkButton>
                    <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                        <asp:View ID="HView1" runat="server">
                            <asp:ImageButton ID="lbtnHP" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="HPass" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                            <%--<asp:LinkButton ID="lbtnHP" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="HPass">审核通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="HView2" runat="server">
                            <asp:ImageButton ID="lbtnHU" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="HUPass" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                            <%--<asp:LinkButton ID="lbtnHU" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="HUPass">取消通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="HView3" runat="server">
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="负责人身份证 " SortExpression="IDCard">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnIDCard" runat="server" Text="查看图片详情" CommandArgument='<%#Eval("CopId") %>'
                        CommandName="IDCard" ToolTip="负责人身份证"></asp:LinkButton>
                    <asp:MultiView ID="MultiView3" runat="server" ActiveViewIndex="0">
                        <asp:View ID="IView1" runat="server">
                            <asp:ImageButton ID="lbtnIP" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="IPass" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                            <%--<asp:LinkButton ID="lbtnIP" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="IPass">审核通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="IView2" runat="server">
                            <asp:ImageButton ID="lbtnIU" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="IUPass" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                            <%--<asp:LinkButton ID="lbtnIU" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="IUPass">取消通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="IView3" runat="server">
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="认证审核" SortExpression="Audit">
                <ItemTemplate>
                    <%--                    <asp:LinkButton ID="lbtnChop1" runat="server" Text="查看图片详情" CommandArgument='<%#Eval("CopId") %>'
                        CommandName="Chop" ToolTip="协议"></asp:LinkButton>--%>
                    <asp:MultiView ID="MultiView5" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <asp:ImageButton ID="lbtnPass" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="Pass" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                            <%--<asp:LinkButton ID="lbtnPass" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="Pass">审核通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <asp:ImageButton ID="lbtnUPass" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="UPass" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                            <%--<asp:LinkButton ID="lbtnUPass" runat="server" CommandArgument='<%#Eval("CopId") %>' CommandName="UPass">取消通过</asp:LinkButton>--%>
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CreateTime" HeaderText="注册时间" SortExpression="CreateTime" />
            <asp:TemplateField HeaderText="地址 " SortExpression="Region">
                <ItemTemplate>
                    <asp:Label ID="lbAddress" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

