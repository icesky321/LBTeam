<%@ page title="" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_UserNoticeManage, App_Web_jsqmqrzk" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <h2>用户互动信息管理</h2>
    <hr />
    <br />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="未处理信息">
            <ContentTemplate>
                <asp:GridView ID="gvUnDealUserNoticeInfo" runat="server" DataKeyNames="NoticeId"
                    AutoGenerateColumns="False" OnRowCommand="gvUnDealUserNoticeInfo_RowCommand"
                    OnRowDeleting="gvUnDealUserNoticeInfo_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="NoticeId" HeaderText="NoticeId" SortExpression="NoticeId" Visible="True" />
                        <asp:BoundField DataField="UserNotice" HeaderText="信息" SortExpression="UserNotice" />
                        <asp:BoundField DataField="CreateDate" HeaderText="提交时间" SortExpression="CreateDate" />
                        <asp:TemplateField HeaderText="是否处理">
                            <ItemTemplate>
                                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                    <asp:View ID="View1" runat="server">
                                        <asp:ImageButton ID="lbtnShowP" runat="server" CommandArgument='<%#Eval("NoticeId") %>' CommandName="Show" ImageUrl="~/img/cha.png" Width="30px" Height="30px" ToolTip="已处理" />
                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <asp:ImageButton ID="lbtnShowU" runat="server" CommandArgument='<%#Eval("NoticeId") %>' CommandName="UnShow" ImageUrl="~/img/gou.png" Width="30px" Height="30px" ToolTip="未处理" />
                                    </asp:View>
                                </asp:MultiView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btDelete" runat="server" Text="删除" CommandName="Delete" />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btDelete"
                                    ConfirmText="亲~一失手成千古恨啊！ "></asp:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="已处理信息">
            <ContentTemplate>
                <asp:GridView ID="gvDealUserNoticeInfo" runat="server" DataKeyNames="NoticeId"
                    AutoGenerateColumns="False" OnRowCommand="gvDealUserNoticeInfo_RowCommand"
                    OnRowDeleting="gvDealUserNoticeInfo_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="NoticeId" HeaderText="NoticeId" SortExpression="NoticeId" Visible="True" />
                        <asp:BoundField DataField="UserNotice" HeaderText="信息" SortExpression="UserNotice" />
                        <asp:BoundField DataField="CreateDate" HeaderText="提交时间" SortExpression="CreateDate" />
                        <asp:TemplateField HeaderText="是否处理">
                            <ItemTemplate>
                                <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                                    <asp:View ID="View3" runat="server">
                                        <asp:ImageButton ID="lbtnShowP1" runat="server" CommandArgument='<%#Eval("NoticeId") %>' CommandName="Show" ImageUrl="~/img/cha.png" Width="30px" Height="30px" ToolTip="已处理" />
                                    </asp:View>
                                    <asp:View ID="View4" runat="server">
                                        <asp:ImageButton ID="lbtnShowU1" runat="server" CommandArgument='<%#Eval("NoticeId") %>' CommandName="UnShow" ImageUrl="~/img/gou.png" Width="30px" Height="30px" ToolTip="未处理" />
                                    </asp:View>
                                </asp:MultiView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btDelete1" runat="server" Text="删除" CommandName="Delete" />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btDelete1"
                                    ConfirmText="亲~一失手成千古恨啊！ "></asp:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>

</asp:Content>

