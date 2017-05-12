<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="_Default, App_Web_uns12dtv" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="css/main.css" />
    <link rel="stylesheet" href="css/product.min.css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery.sequence-min.js"></script>
    <script type="text/javascript" src="js/template.js"></script>
    <style type="text/css">
        @media only screen and (max-width:640px) {
            .companywarpslider {
                display: none;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="homepage-slider companywarpslider">
        <div id="sequence">
            <ul class="sequence-canvas">
                <!-- Slide 1 -->
                <li class="bg4">
                    <!-- Slide Title -->
                    <h2 class="title" style="font-family: 微软雅黑; font-weight: bold">参与电池回收，共建生态文明</h2>
                    <!-- Slide Text -->
                    <h3 class="subtitle" style="font-family: 微软雅黑; font-weight: bold; font-size: 20px;">Participate in battery recycling, Build ecological civilization</h3>
                    <!-- Slide Image -->
                    <img class="slide-img" src="img/homepage-slider/slide1.png" alt="Slide 1" />
                </li>
                <!-- End Slide 1 -->
                <!-- Slide 2 -->
                <li class="bg3">
                    <!-- Slide Title -->
                    <h2 class="title" style="font-family: 微软雅黑; font-weight: bold">我们，专注于打造一个废旧电瓶回收平台！</h2>
                    <!-- Slide Text -->
                    <h3 class="subtitle" style="font-family: 微软雅黑; font-weight: bold; font-size: 20px;">We focus on creating an old battery recycling platform!</h3>
                    <!-- Slide Image -->
                    <img class="slide-img" src="img/homepage-slider/slide2.png" alt="Slide 2" />
                </li>
                <!-- End Slide 2 -->
                <!-- Slide 3 -->
                <li class="bg1">
                    <!-- Slide Title -->
                    <h2 class="title" style="font-family: 微软雅黑; font-weight: bold">支持正规合法回收流程!</h2>
                    <!-- Slide Text -->
                    <h3 class="subtitle" style="font-family: 微软雅黑; font-weight: bold; font-size: 20px;">Support formal legal recycling process!</h3>
                    <!-- Slide Image -->
                    <img class="slide-img" src="img/homepage-slider/slide3.png" alt="Slide 3" />
                </li>
                <!-- End Slide 3 -->
            </ul>
            <div class="sequence-pagination-wrapper">
                <ul class="sequence-pagination">
                    <li>1</li>
                    <li>2</li>
                    <li>3</li>
                </ul>
            </div>
        </div>
    </div>
    <div class="section">
        <div class="container">
            <%--            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>行情资讯</h1>
                </p>
            </div>
            <hr />--%>
            <div class="am-g" style="border: 0px solid #eee; margin: 10px">
                <div class="am-u-md-6">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TabContainer ID="TabContainer1" runat="server">
                                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="沪铅主力">
                                    <ContentTemplate>
                                        <asp:Image ID="Image3" runat="server" ImageUrl="http://pifm3.eastmoney.com/EM_Finance2014PictureInterface/Index.aspx?id=PBM1&imageType=rf&token=44c9d251add88e27b65ed86506f6e5da"
                                            Width="500" Height="276" alt="沪铅主力" />
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="LME铅">
                                    <ContentTemplate>
                                        <asp:Image ID="Image7" runat="server" ImageUrl="http://pifm3.eastmoney.com/EM_Finance2014PictureInterface/Index.aspx?imagetype=RF&id=LLDS0&token=44c9d251add88e27b65ed86506f6e5da"
                                            Width="500" Height="276" alt="LME铅" />
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="am-u-md-3">
                    <asp:TabContainer ID="TabContainer4" runat="server">
                        <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="平台公告" Height="276px">
                            <ContentTemplate>
                                <marquee direction="up"> sdfasdfsdfsdfsdf</marquee>

                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </div>
                <div class="am-u-md-3">
                    <asp:TabContainer ID="TabContainer5" runat="server">
                        <asp:TabPanel ID="TabPanel8" runat="server" HeaderText="平台动态" Height="276px">
                            <ContentTemplate>
                                <marquee direction="up">sdfasdfsdfsdfsdf<br />sdfasdfsdfsdfsdf<br />sdfasdfsdfsdfsdf<br />sdfasdfsdfsdfsdf<br />sdfasdfsdfsdfsdf<br />sdfasdfsdfsdfsdf<br /></marquee>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </div>
            </div>


        </div>
    </div>
    
    <div class="section">
        <div class="container">
            <%--            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>市场资讯</h1>
                </p>
            </div>
            <hr />--%>
            <div class="am-g" style="border: 0px solid #eee; margin: 10px">
                <div class="am-u-md-6">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:TabContainer ID="TabContainer2" runat="server">
                                <asp:TabPanel ID="TabPanel3" runat="server" HeaderText=" 财经资讯" Height="276px">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvNews" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                                            SkinID="GridView3" Width="500" OnRowCommand="gvNews_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText=" " SortExpression="Title">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 400px; text-align: left;">
                                                            <asp:Label ID="Label1" runat="server" Text="•"></asp:Label><asp:LinkButton ID="lbtnTitle"
                                                                Style="text-decoration: none" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("id") %>'
                                                                CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" " SortExpression="NoteTime">
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="lkbnMore" runat="server" Style="text-decoration: none" CommandArgument='<%#Eval("id") %>'
                                                            CommandName="AllNews">更多...</asp:LinkButton>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbShowTime" runat="server" Text='<%# Bind("NoteTime","{0:yyyy-M-d}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="铅电瓶资讯" Height="276px">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvPBNew" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                                            SkinID="GridView3" Width="500" OnRowCommand="gvPBNew_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText=" " SortExpression="Title">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 400px; text-align: left;">
                                                            <asp:Label ID="Label2" runat="server" Text="•"></asp:Label><asp:LinkButton ID="LinkButton1"
                                                                Style="text-decoration: none" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("id") %>'
                                                                CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" " SortExpression="ShowTime">
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" Style="text-decoration: none" CommandArgument='<%#Eval("id") %>'
                                                            CommandName="AllNews">更多...</asp:LinkButton>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ShowTime","{0:yyyy-M-d}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="区域价格" Height="276px">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvPrice" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                                            SkinID="GridView3" Width="500" OnRowCommand="gvPrice_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText=" " SortExpression="Title">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px; text-align: left;">
                                                            <asp:Label ID="Label4" runat="server" Text="•"></asp:Label><asp:LinkButton ID="LinkButton3"
                                                                Style="text-decoration: none" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("id") %>'
                                                                CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" " SortExpression="UserName">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 100px; text-align: left;">
                                                            <asp:LinkButton ID="lbtnArea" Style="text-decoration: none" runat="server" Text='<%# Bind("UserName") %>'
                                                                CommandArgument='<%#Eval("id") %>' CommandName="Detail" ToolTip='<%# Bind("UserName") %>'></asp:LinkButton>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" " SortExpression="Content">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 100px; text-align: left;">
                                                            <asp:LinkButton ID="lbtnPrice" Style="text-decoration: none" runat="server" Text='<%# Bind("Content") %>'
                                                                CommandArgument='<%#Eval("id") %>' CommandName="Detail" ToolTip='<%# Bind("Content") %>'></asp:LinkButton>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" " SortExpression="ShowTime">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ShowTime","{0:yyyy-M-d}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" Style="text-decoration: none" CommandArgument='<%#Eval("id") %>'
                                                            CommandName="AllNews">更多...</asp:LinkButton>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel9" runat="server" HeaderText="政策法规" Height="276px">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvLaw" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                                            SkinID="GridView3" Width="500" OnRowCommand="gvLaw_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText=" " SortExpression="Title">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 400px; text-align: left;">
                                                            <asp:Label ID="lbLawTitle" runat="server" Text="•"></asp:Label><asp:LinkButton ID="LinkButton1"
                                                                Style="text-decoration: none" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("id") %>'
                                                                CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" " SortExpression="ShowTime">
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="lbtnLaw" runat="server" Style="text-decoration: none" CommandArgument='<%#Eval("id") %>'
                                                            CommandName="AllNews">更多...</asp:LinkButton>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbLawShowTime" runat="server" Text='<%# Bind("ShowTime","{0:yyyy-M-d}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="am-u-md-6">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:TabContainer ID="TabContainer3" runat="server">
                                <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="供应信息" Height="276px">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvSellInfo" runat="server" DataKeyNames="infoId" AutoGenerateColumns="False"
                                            Width="100%" SkinID="GridView4" OnRowCommand="gvSellInfo_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="标题 " SortExpression="Title">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px; text-align: left;">
                                                            <asp:Label ID="Label6" runat="server" Text="•"></asp:Label><asp:LinkButton ID="LinkButton5"
                                                                Style="text-decoration: none" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("infoId") %>'
                                                                CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="区域 " SortExpression="infoId">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 100px; text-align: left;">
                                                            <asp:Label ID="lbProvince" runat="server" Text='<%# Bind("Province") %>'></asp:Label>
                                                            <asp:Label ID="lbCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                                            <asp:Label ID="lbTown" runat="server" Text='<%# Bind("Town") %>'></asp:Label>
                                                            <asp:Label ID="lbStreet" runat="server" Text='<%# Bind("Street") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="发布人 " SortExpression="发布人">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 100px; text-align: left;">
                                                            <asp:Label ID="lbUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" " SortExpression="ReleaseDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbReleaseDate" runat="server" Text='<%# Bind("ReleaseDate","{0:yyyy-M-d}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="LinkButton6" runat="server" Style="text-decoration: none" CommandArgument='<%#Eval("infoId") %>'
                                                            CommandName="AllSell">更多...</asp:LinkButton>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel10" runat="server" HeaderText="求购信息" Height="276px">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvBuyInfo" runat="server" DataKeyNames="infoId" AutoGenerateColumns="False"
                                            Width="100%" SkinID="GridView4" OnRowCommand="gvBuyInfo_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="标题 " SortExpression="Title">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px; text-align: left;">
                                                            <asp:Label ID="Label7" runat="server" Text="•"></asp:Label><asp:LinkButton ID="LinkButton7"
                                                                Style="text-decoration: none" runat="server" Text='<%# Bind("Title") %>' CommandArgument='<%#Eval("infoId") %>'
                                                                CommandName="Detail" ToolTip='<%# Bind("Title") %>'></asp:LinkButton>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="区域 " SortExpression="infoId">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 100px; text-align: left;">
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Province") %>'></asp:Label>
                                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("Town") %>'></asp:Label>
                                                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("Street") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="发布人 " SortExpression="发布人">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 100px; text-align: left;">
                                                            <asp:Label ID="Label12" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" " SortExpression="ReleaseDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("ReleaseDate","{0:yyyy-M-d}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="LinkButton8" runat="server" Style="text-decoration: none" CommandArgument='<%#Eval("infoId") %>'
                                                            CommandName="AllBuy">更多...</asp:LinkButton>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>


        </div>
    </div>

    <div class="section" style="margin-top: 0px; background-image: url('images/pattern-light.png');">
        <div class="container">
            <%--            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>商家信息</h1>
                </p>
            </div>
            <hr />--%>
            <!--index-container start-->
            <div class="index-container">
                <div class="am-g">
                    <div class="am-u-md-12">
                        <div class="product3-main">
                            <div class="am-g">
                                <div class="am-u-md-3 am-u-sm-6 product3-main-box" onclick="location.href='Company.aspx?Id=3';">
                                    <div class="product3-icon">
                                        <i class="am-icon-star-o"></i>
                                    </div>
                                    <div class="product3-content">
                                        <h3>冶炼厂</h3>
                                       <%-- <p>基于风靡社区的React.js封装组件沿袭高性能、可复用、易扩展等特性保证企业应用技术栈保持国际领先</p>--%>
                                        <hr class="split-line">
                                    </div>
                                </div>
                                <div class="am-u-md-3 am-u-sm-6 product3-main-box" onclick="location.href='Company.aspx?Id=2';">
                                    <div class="product3-icon">
                                        <i class="am-icon-heart-o"></i>
                                    </div>
                                    <div class="product3-content">
                                        <h3>回收公司</h3>
                                       <%-- <p>基于风靡社区的React.js封装组件沿袭高性能、可复用、易扩展等特性保证企业应用技术栈保持国际领先</p>--%>
                                        <hr class="split-line">
                                    </div>
                                </div>
                                <div class="am-u-md-3 am-u-sm-6 product3-main-box">
                                    <div class="product3-icon">
                                        <i class="am-icon-send-o"></i>
                                    </div>
                                    <div class="product3-content">
                                        <h3>回收业务员</h3>
                                       <%-- <p>基于风靡社区的React.js封装组件沿袭高性能、可复用、易扩展等特性保证企业应用技术栈保持国际领先</p>--%>
                                        <hr class="split-line">
                                    </div>
                                </div>
                                <div class="am-u-md-3 am-u-sm-6 product3-main-box">
                                    <div class="product3-icon">
                                        <i class="am-icon-diamond"></i>
                                    </div>
                                    <div class="product3-content">
                                        <h3>供货商</h3>
                                       <%-- <p>基于风靡社区的React.js封装组件沿袭高性能、可复用、易扩展等特性保证企业应用技术栈保持国际领先</p>--%>
                                        <hr class="split-line">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <!--index-container end-->
        </div>
    </div>
</asp:Content>

