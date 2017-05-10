<%@ page title="" language="C#" masterpagefile="~/Admin/Manage.master" autoeventwireup="true" inherits="Admin_TradeleadsManage, App_Web_trdrr22g" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <asp:GridView ID="gvTradeleadsInfo" runat="server" SkinID="GridView2" DataKeyNames="infoId"
        AutoGenerateColumns="False" OnRowCommand="gvTradeleadsInfo_RowCommand"
        OnRowDeleting="gvTradeleadsInfo_RowDeleting">
        <Columns>
            <asp:BoundField DataField="infoId" HeaderText="infoId" SortExpression="infoId" Visible="True" />
            <asp:TemplateField HeaderText="资讯标题 " SortExpression="Title">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnTitle" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("infoId") %>'
                        CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否发布">
                <ItemTemplate>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <asp:ImageButton ID="lbtnShowP" runat="server" CommandArgument='<%#Eval("infoId") %>' CommandName="Show" ImageUrl="~/img/cha.png" Width="30px" Height="30px" ToolTip="允许发布" />
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <asp:ImageButton ID="lbtnShowU" runat="server" CommandArgument='<%#Eval("infoId") %>' CommandName="UnShow" ImageUrl="~/img/gou.png" Width="30px" Height="30px" ToolTip="不允许发布" />
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btDelete" runat="server" Text="删除" CommandName="Delete" />
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btDelete"
                        ConfirmText="亲~一失手成千古恨啊！ ">
                    </asp:ConfirmButtonExtender>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

