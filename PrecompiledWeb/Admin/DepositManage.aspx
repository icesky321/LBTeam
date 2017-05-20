<%@ page title="" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_DepositManage, App_Web_pefw5kum" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Aunth.ascx" TagName="Aunth" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/UnAunth.ascx" TagName="UnAunth" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:Aunth ID="Aunth1" runat="server" Visible="true" />
    <uc3:UnAunth ID="UnAunth1" runat="server" Visible="true" />

    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>个人信用保证金管理</h1>
                </p>
            </div>
            <hr />
            请输入需要定位的手机号：<asp:TextBox ID="tbTelNum" runat="server"></asp:TextBox><asp:Button ID="btSearch" runat="server" Text="搜索" OnClick="btSearch_Click" />
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

