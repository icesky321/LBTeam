<%@ page title="" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_UserTypeInfo, App_Web_unoc1clr" theme="Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="用户类别">
            <ContentTemplate>
               新增用户类别名称： <asp:TextBox ID="tbUserType" runat="server"></asp:TextBox>
                <asp:Button ID="btSure" runat="server" Text="确定" OnClick="btSure_Click" />
                <br />
                <asp:GridView ID="gvUserType" runat="server" AutoGenerateColumns="False" DataKeyNames="UserTypeId"
                    SkinID="GridView2" OnRowCancelingEdit="gvUserType_RowCancelingEdit" OnRowEditing="gvUserType_RowEditing"
                    OnRowUpdating="gvUserType_RowUpdating" OnRowDeleting="gvUserType_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="UserTypeId" HeaderText="Id" SortExpression="UserTypeId"
                            Visible="False" />
                        <asp:TemplateField HeaderText="用户类别" SortExpression="UserTypeName">
                            <ItemTemplate>
                                <asp:Label ID="lbUserTypeName" runat="server" Text='<%# Bind("UserTypeName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="tbEditUserTypeName" runat="server" Text='<%# Bind("UserTypeName") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btEdit" runat="server" Text="编辑" CommandName="Edit" />
                                <asp:Button ID="btDelete" runat="server" Text="删除" CommandName="Delete" />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btDelete"
                                    ConfirmText="亲~一失手成千古恨啊！ ">
                                </asp:ConfirmButtonExtender>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button ID="btUpdate" runat="server" Text="更新" CommandName="Update" />
                                <asp:Button ID="btCancel" runat="server" Text="取消" CommandName="Cancel" />
                            </EditItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="gvHeader" />
                </asp:GridView>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</asp:Content>

