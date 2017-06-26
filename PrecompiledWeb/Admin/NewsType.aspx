<%@ page title="" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" enableeventvalidation="false" inherits="Admin_NewsType, App_Web_y4yzchvr" theme="Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <br />
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="资讯类别">
            <ContentTemplate>
               新增资讯类别名称： <asp:TextBox ID="tbNewType" runat="server"></asp:TextBox>
                <asp:Button ID="btSure" runat="server" Text="确定" OnClick="btSure_Click" />
                <br />
                <asp:GridView ID="gvNewType" runat="server" AutoGenerateColumns="False" DataKeyNames="NewsTypeId"
                    SkinID="GridView2" OnRowCancelingEdit="gvNewType_RowCancelingEdit" OnRowEditing="gvNewType_RowEditing"
                    OnRowUpdating="gvNewType_RowUpdating" OnRowDeleting="gvNewType_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="NewsTypeId" HeaderText="Id" SortExpression="NewsTypeId"
                            Visible="False" />
                        <asp:TemplateField HeaderText="资讯类别" SortExpression="NewsType1">
                            <ItemTemplate>
                                <asp:Label ID="lbNewsType1" runat="server" Text='<%# Bind("NewsType1") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="tbEditNewsType1" runat="server" Text='<%# Bind("NewsType1") %>'></asp:TextBox>
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
    <%--            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div id="modalDiv">
                        <img src="images/ajax-loader.gif" alt="请稍候..." style="position: absolute; left: 50%;
                            top: 50%;" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
