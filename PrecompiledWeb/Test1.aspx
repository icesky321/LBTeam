<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Test1, App_Web_oowd1m0l" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/main.css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery.sequence-min.js"></script>
    <script type="text/javascript" src="js/template.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div class="homepage-slider">
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
</asp:Content>

