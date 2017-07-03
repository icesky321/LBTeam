<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="Deposit.aspx.cs" Inherits="Deposit" %>

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
                    <h1>平台用户信用保证金变更信息</h1>
                </p>
            </div>

            <asp:TabContainer ID="TabContainer2" runat="server">
                <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="押金信息未处理">
                    <ContentTemplate>
                        <asp:GridView ID="gvUnDeal" runat="server" AutoGenerateColumns="false" DataKeyNames="UserId">
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
                                                 <asp:Image ID="lbtnPass" runat="server" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过"/>
                                               
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                 <asp:Image ID="lbtnUPass" runat="server" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过"/>
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
                                                <asp:Image ID="lbtnSPass" runat="server" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过"/>
                                            </asp:View>
                                            <asp:View ID="View4" runat="server">
                                                <asp:Image ID="lbtnUSPass" runat="server" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过"/>
                                            </asp:View>
                                        </asp:MultiView>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="押金信息已处理">
                    <ContentTemplate>
                        <asp:GridView ID="gvDeal" runat="server" AutoGenerateColumns="false" DataKeyNames="UserId">
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
                                                 <asp:Image ID="lbtnDealPass" runat="server" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过"/>
                                            </asp:View>
                                            <asp:View ID="View6" runat="server">
                                                <asp:Image ID="lbtnDealUPass" runat="server" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过"/>
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
                                                <asp:Image ID="lbtnDealSPass" runat="server" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过"/>
                                            </asp:View>
                                            <asp:View ID="View8" runat="server">
                                                <asp:Image ID="lbtnDealUSPass" runat="server" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过"/>
                                            </asp:View>
                                        </asp:MultiView>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>


            <br />
            <hr />
</asp:Content>

