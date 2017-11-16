<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="CityManagerAccession.aspx.cs" Inherits="WeixinQY_CityManagerAccession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    手机号：<asp:TextBox ID="tbTelNum" runat="server"></asp:TextBox>
    <asp:HiddenField ID="hfUserId" runat="server" />
    <asp:Button ID="btSearch" runat="server" Text="确定" OnClick="btSearch_Click" />

    <asp:GridView ID="gvUserInfo" runat="server" AutoGenerateColumns="false" DataKeyNames="UserId" OnRowCommand="gvUserInfo_RowCommand">
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="Id" SortExpression="UserId" Visible="True" />
            <asp:BoundField DataField="RealName" HeaderText="用户" SortExpression="RealName" />
            <asp:BoundField DataField="MobilePhoneNum" HeaderText="联系号码" SortExpression="MobilePhoneNum" />
            <asp:TemplateField HeaderText="负责人身份证 " SortExpression="IDCard">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnIDCard" runat="server" Text="查看图片详情" CommandArgument='<%#Eval("UserId") %>'
                        CommandName="IDCard" ToolTip="负责人身份证"></asp:LinkButton>
                    <asp:MultiView ID="MultiView3" runat="server" ActiveViewIndex="0">
                        <asp:View ID="IView1" runat="server">
                            <asp:ImageButton ID="lbtnIP" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="IPass" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                            <%--<asp:LinkButton ID="lbtnIP" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="IPass">审核通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="IView2" runat="server">
                            <asp:ImageButton ID="lbtnIU" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="IUPass" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                            <%--<asp:LinkButton ID="lbtnIU" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="IUPass">取消通过</asp:LinkButton>--%>
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
                            <asp:ImageButton ID="lbtnPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="Pass" ImageUrl="~/images/cha.png" Width="30px" Height="30px" ToolTip="审核通过" />
                            <%--<asp:LinkButton ID="lbtnPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="Pass">审核通过</asp:LinkButton>--%>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <asp:ImageButton ID="lbtnUPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="UPass" ImageUrl="~/images/gou.png" Width="30px" Height="30px" ToolTip="取消通过" />
                            <%--<asp:LinkButton ID="lbtnUPass" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="UPass">取消通过</asp:LinkButton>--%>
                        </asp:View>
                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="CreateTime" HeaderText="注册时间" SortExpression="CreateTime" />
            <asp:TemplateField HeaderText="认证审核" SortExpression="Audit">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnChoose" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="choose">选择</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <h4>创建城市经理人</h4>
    <hr style="border-right: khaki 1px solid; border-top: khaki 1px solid; border-left: khaki 1px solid; border-bottom: khaki 1px solid" />
    <table>
        <tr>
            <td>城市经理人手机号码:</td>

            <td>
                <asp:Label ID="lbMobileNum" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>请选择管辖城市</td>
            <td>选择省份：   
                <asp:HiddenField ID="hfRegionCode" runat="server" />
                <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                选择地级市：
                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btSure" runat="server" Text="确定" OnClick="btSure_Click" />
    <asp:Label ID="lbMsg" runat="server" Text="更新成功!" ForeColor="Red" Font-Size="X-Large" Visible="false"></asp:Label>
</asp:Content>

