<%@ page title="" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_UserManage, App_Web_wpzlokeo" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <br />
    <asp:Button ID="btSearch" runat="server" Text="确定" OnClick="btSearch_Click" />
    <asp:GridView ID="gvUserInfo" runat="server" AutoGenerateColumns="false" DataKeyNames="UserId" OnRowCommand="gvUserInfo_RowCommand" OnDataBound="gvUserInfo_DataBound" OnPageIndexChanging="gvUserInfo_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="Id" SortExpression="UserId" Visible="True" />
            <asp:BoundField DataField="UserName" HeaderText="用户" SortExpression="UserName" />
            <asp:BoundField DataField="MobilePhoneNum" HeaderText="联系号码" SortExpression="MobilePhoneNum" />
            <asp:TemplateField HeaderText="地址 " SortExpression="CopId">
                <ItemTemplate>
                    <asp:Label ID="lbProvince" runat="server" Text='<%# Bind("Province") %>'></asp:Label>
                    <asp:Label ID="lbCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                    <asp:Label ID="lbTown" runat="server" Text='<%# Bind("Town") %>'></asp:Label>
                    <asp:Label ID="lbStreet" runat="server" Text='<%# Bind("Street") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="银行账号 " SortExpression="Account">
                <ItemTemplate>
                    <asp:Label ID="lbBankAcccount" runat="server" Text='<%# Bind("Account") %>' ToolTip='<%# Bind("BankName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="负责人身份证 " SortExpression="IDCard">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnIDCard" runat="server" Text="查看图片详情" CommandArgument='<%#Eval("UserId") %>'
                        CommandName="IDCard" ToolTip="负责人身份证"></asp:LinkButton>
                    <asp:MultiView ID="MultiView3" runat="server" ActiveViewIndex="0">
                        <asp:View ID="IView1" runat="server">
                            <asp:ImageButton ID="lbtnIP" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="IPass" ImageUrl="~/img/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                            <%--<asp:LinkButton ID="lbtnIP" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="IPass">审核通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="IView2" runat="server">
                            <asp:ImageButton ID="lbtnIU" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="IUPass" ImageUrl="~/img/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                            <%--<asp:LinkButton ID="lbtnIU" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="IUPass">取消通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="IView3" runat="server">
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="保证金审核" SortExpression="Audit" Visible="false">
                <ItemTemplate>
                    <%--                    <asp:LinkButton ID="lbtnChop1" runat="server" Text="查看图片详情" CommandArgument='<%#Eval("CopId") %>'
                        CommandName="Chop" ToolTip="协议"></asp:LinkButton>--%>
                    <asp:MultiView ID="MultiView5" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <asp:ImageButton ID="lbtnPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="Pass" ImageUrl="~/img/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                            <%--<asp:LinkButton ID="lbtnPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="Pass">审核通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <asp:ImageButton ID="lbtnUPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="UPass" ImageUrl="~/img/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                            <%--<asp:LinkButton ID="lbtnUPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="UPass">取消通过</asp:LinkButton>--%>
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="街道责任审核" SortExpression="InCharge" Visible="false">
                <ItemTemplate>
                    <asp:MultiView ID="MultiView6" runat="server" ActiveViewIndex="0">
                        <asp:View ID="ICView1" runat="server">
                            <asp:ImageButton ID="imPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="ICPass" ImageUrl="~/img/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                        </asp:View>
                        <asp:View ID="ICView2" runat="server">
                            <asp:ImageButton ID="imUPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="ICUPass" ImageUrl="~/img/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <table width="100%" style="font-size: 12px;">
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
                        <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
                        <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                        <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                        <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                        到第<asp:DropDownList ID="PageDropDownList"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged"
                            runat="server" />
                        页  
                    </td>
                </tr>
            </table>
        </PagerTemplate>
    </asp:GridView>
</asp:Content>

