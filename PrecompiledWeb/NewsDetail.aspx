<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="NewsDetail, App_Web_kbxfc0ac" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="css/news.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section news-section">
        <div class="container">
            <!--news-section left start-->
            <div class="am-u-md-12">
                <div class="article">
                    <div class="article--header">
                        <h2 class="article--title" style=" text-align:center;">
                            <asp:Label ID="lbTitle" runat="server" Text=""></asp:Label></h2>
                        <ul class="article--meta" style="text-align:right;">
                            <li class="article--meta_item"><i class="am-icon-calendar"></i>
                                <asp:Label ID="lbShowTime" runat="server" Text=""></asp:Label></li>
                            <li class="article--meta_item"><i class="am-icon-user"></i>
                                <asp:Label ID="lbUser" runat="server" Text=""></asp:Label></li>
                            <li class="article--meta_item"><i class="am-icon-commenting-o"></i>
                                <asp:Label ID="lbHits" runat="server" Text=""></asp:Label></li>
                        </ul>
                    </div>
                    <hr />
                    <div class="article--content">
                        <asp:Label ID="lbContent" runat="server" Text=""></asp:Label>
                    </div>
                </div>

            </div>

        </div>
    </div>

</asp:Content>
