<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="GoodIdea, App_Web_scxnt4bh" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>集思广益</h1>
                </p>
            </div>

            <hr />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <asp:Label ID="Label2" runat="server" Text="如果您有什么好的想法及建议，请提交给平台，如果平台采纳，说不定会给您惊喜哦~谢谢！~" Font-Size="Medium"></asp:Label><br /><hr />
                            建议内容（请简要描述您的意见或建议）<asp:TextBox ID="tbUserNotice" runat="server" TextMode="MultiLine" Width="600px"></asp:TextBox>

                            <br />
                            <hr />
                            <asp:Button ID="btGoodIdea" runat="server" Text="提交好意见" OnClick="btGoodIdea_Click" />
                            <br />
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <asp:Label ID="Label1" runat="server" Text="感谢您的好建议，如果平台采纳，说不定会给您惊喜哦~" Font-Size="Medium"></asp:Label>
                        </asp:View>
                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

