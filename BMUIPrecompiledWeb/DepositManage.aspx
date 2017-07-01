<%@ page title="" language="C#" masterpagefile="~/Manage.master" autoeventwireup="true" inherits="Admin_DepositManage, App_Web_pzkznn5t" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Aunth.ascx" TagName="Aunth" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/UnAunth.ascx" TagName="UnAunth" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:Aunth ID="Aunth1" runat="server" Visible="false" />
    <uc3:UnAunth ID="UnAunth1" runat="server" Visible="false" />

    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>个人信用保证金管理</h1>
                </p>
            </div>

            <asp:TabContainer ID="TabContainer2" runat="server">
                <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="押金信息未处理">
                    <ContentTemplate>
                        <asp:GridView ID="gvUnDeal" runat="server" AutoGenerateColumns="false" DataKeyNames="UserId" OnRowCommand="gvUnDeal_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="UserId" HeaderText="Id" SortExpression="UserId" Visible="True" />
                                <asp:BoundField DataField="UserTypeName" HeaderText="用户类型" SortExpression="UserTypeName" />
                                <asp:BoundField DataField="UserName" HeaderText="用户" SortExpression="UserName" />
                                <asp:BoundField DataField="MobilePhoneNum" HeaderText="联系号码" SortExpression="MobilePhoneNum" />
                                <asp:BoundField DataField="Ammount" HeaderText="押金金额(元)" SortExpression="Ammount" />
                                <asp:TemplateField HeaderText="银行账号 " SortExpression="Account">
                                    <ItemTemplate>
                                        <asp:Label ID="lbBankAcccount" runat="server" Text='<%# Bind("Account") %>' ToolTip='<%# Bind("AccountName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="保证金审核" SortExpression="Audit">
                                    <ItemTemplate>
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View1" runat="server">
                                                <asp:ImageButton ID="lbtnPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="Pass" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lbtnPass" ConfirmText="点击前请确认押金已付" />
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                <asp:ImageButton ID="lbtnUPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="UPass" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="lbtnUPass" ConfirmText="点击前请确认押金已退" />
                                            </asp:View>
                                        </asp:MultiView>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Message" HeaderText="留言" SortExpression="Message" />
                                <asp:BoundField DataField="CreateDate" HeaderText="提交时间" SortExpression="CreateDate" />
                                <asp:TemplateField HeaderText="任务处理是否完成" SortExpression="Status">
                                    <ItemTemplate>
                                        <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View3" runat="server">
                                                <asp:ImageButton ID="lbtnSPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="SPass" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="lbtnSPass" ConfirmText="别忘了先进行押金操作哦" />
                                            </asp:View>
                                            <asp:View ID="View4" runat="server">
                                                <asp:ImageButton ID="lbtnUSPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="USPass" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" TargetControlID="lbtnUSPass" ConfirmText="别忘了先进行押金操作哦" />
                                            </asp:View>
                                        </asp:MultiView>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbOperate" runat="server" CommandArgument='<%#Eval("MobilePhoneNum")%>'
                                            CommandName="Operate">押金操作</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="押金信息已处理">
                    <ContentTemplate>
                        <asp:GridView ID="gvDeal" runat="server" AutoGenerateColumns="false" DataKeyNames="UserId" OnRowCommand="gvDeal_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="UserId" HeaderText="Id" SortExpression="UserId" Visible="True" />
                                <asp:BoundField DataField="UserTypeName" HeaderText="用户类型" SortExpression="UserTypeName" />
                                <asp:BoundField DataField="UserName" HeaderText="用户" SortExpression="UserName" />
                                <asp:BoundField DataField="MobilePhoneNum" HeaderText="联系号码" SortExpression="MobilePhoneNum" />
                                <asp:BoundField DataField="Ammount" HeaderText="押金金额(元)" SortExpression="Ammount" />
                                <asp:TemplateField HeaderText="银行账号 " SortExpression="Account">
                                    <ItemTemplate>
                                        <asp:Label ID="lbBankAcccount" runat="server" Text='<%# Bind("Account") %>' ToolTip='<%# Bind("AccountName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="保证金审核" SortExpression="Audit">
                                    <ItemTemplate>
                                        <asp:MultiView ID="MultiView3" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View5" runat="server">
                                                <asp:ImageButton ID="lbtnDealPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="DealPass" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="lbtnDealPass" ConfirmText="点击前请确认押金已付" />
                                            </asp:View>
                                            <asp:View ID="View6" runat="server">
                                                <asp:ImageButton ID="lbtnDealUPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="DealUPass" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender6" runat="server" TargetControlID="lbtnDealUPass" ConfirmText="点击前请确认押金已退" />
                                            </asp:View>
                                        </asp:MultiView>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Message" HeaderText="留言" SortExpression="Message" />
                                <asp:BoundField DataField="CreateDate" HeaderText="提交时间" SortExpression="CreateDate" />
                                <asp:TemplateField HeaderText="任务处理是否完成" SortExpression="Status">
                                    <ItemTemplate>
                                        <asp:MultiView ID="MultiView4" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View7" runat="server">
                                                <asp:ImageButton ID="lbtnDealSPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="DealSPass" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender7" runat="server" TargetControlID="lbtnDealSPass" ConfirmText="别忘了先进行押金操作哦" />
                                            </asp:View>
                                            <asp:View ID="View8" runat="server">
                                                <asp:ImageButton ID="lbtnDealUSPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="DealUSPass" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender8" runat="server" TargetControlID="lbtnDealUSPass" ConfirmText="别忘了先进行押金操作哦" />
                                            </asp:View>
                                        </asp:MultiView>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbDealOperate" runat="server" CommandArgument='<%#Eval("MobilePhoneNum")%>'
                                            CommandName="DealOperate">押金操作</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>


            <br />
            <hr />
            <br />
            <asp:TextBox ID="tbTelNum" runat="server" Visible="false"></asp:TextBox><asp:Button ID="btSearch" runat="server" Text="搜索" OnClick="btSearch_Click" Visible="false" />
            <asp:Panel ID="Panel1" runat="server">
                用户名:<asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                <br />
                <hr />
                <br />
                联系电话:<asp:Label ID="MobilePhoneNumLabel" runat="server" Text='<%# Eval("MobilePhoneNum") %>' />
                <hr />
                地址:<asp:Label ID="ProvinceLabel" runat="server" Text='<%# Eval("Province") %>' /><asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' /><asp:Label ID="TownLabel" runat="server" Text='<%# Eval("Town") %>' /><asp:Label ID="StreetLabel" runat="server" Text='<%# Eval("Street") %>' />
                <br />
                <hr />
                <br />
                <table>
                    <tr>
                        <td>身份证审核:</td>
                        <td>
                            <asp:Label ID="IDAuthenticationLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("IDAuthentication"))?  Aunth1.msg : UnAunth1.msg %>' Font-Bold="True" ForeColor="Red" /></td>
                    </tr>
                </table>


                <br />
                <hr />
                <br />
                <table>
                    <tr>
                        <td>信用审核:
                        </td>
                        <td>
                            <asp:Label ID="AuditLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("Audit"))? Aunth1.msg : UnAunth1.msg %>' Font-Bold="True" ForeColor="Red" />
                        </td>
                    </tr>
                </table>


                <br />
                <hr />
                <br />
                开户行:<asp:Label ID="BankNameLabel" runat="server" Text='<%# Eval("BankName") %>' />
                <hr />
                银行账号:
                            <asp:Label ID="AccountLabel" runat="server" Text='<%# Eval("Account") %>' />
                <br />
                <hr />
                <br />
                <asp:TabContainer ID="TabContainer1" runat="server">
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="入保证金">
                        <ContentTemplate>
                            请输入诚信保证金金额：<asp:TextBox ID="tbInDeposit" runat="server"></asp:TextBox>元
                            <hr />
                            入金时间：<asp:TextBox ID="tbIndate" runat="server"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbIndate" />
                            <asp:Button ID="btInSure" runat="server" Text="确定" OnClick="btInSure_Click" />
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="出保证金">
                        <ContentTemplate>
                            请输入退出诚信保证金金额：<asp:TextBox ID="tbOutDeposit" runat="server"></asp:TextBox>元
                            <hr />
                            出金时间：<asp:TextBox ID="tbOutDate" runat="server"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tbOutDate" />
                            <asp:Button ID="btOutSure" runat="server" Text="确定" OnClick="btOutSure_Click" />
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
                <asp:Label ID="lbmsg" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                <asp:HiddenField ID="hfTelNum" runat="server" />
                <%--                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                    </asp:View>
                </asp:MultiView>--%>
            </asp:Panel>
        </div>
    </div>

</asp:Content>

