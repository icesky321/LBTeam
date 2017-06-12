<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="JoinUS, App_Web_scxnt4bh" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="css/main.css" />
    <link rel="stylesheet" href="css/product.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfUserId" runat="server" />
    <div class="section" style="margin-top: 0px; background-image: url('images/pattern-light.png');">
        <div class="container">
            <!--index-container start-->
            <div class="index-container">
                <div class="am-g">
                    <div class="am-u-md-12">
                        <div class="product3-main">
                            <div class="am-g">
                                <a href="#ct1">
                                    <div class="am-u-md-3 am-u-sm-6 product3-main-box">
                                        <div class="product3-icon">
                                            <i class="am-icon-star-o"></i>
                                        </div>
                                        <div class="product3-content">
                                            <h3>冶炼厂</h3>
                                            <p>诚信保证金<asp:Label ID="Label1" runat="server" Text="2000元" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></p>
                                            <p>权限：可查看平台所有注册商家及个人的信息、平台咨询、自定义个性化服务</p>
                                            <hr class="split-line">
                                        </div>
                                    </div>
                                </a>
                                <a href="#ct1">
                                    <div class="am-u-md-3 am-u-sm-6 product3-main-box">
                                        <div class="product3-icon">
                                            <i class="am-icon-heart-o"></i>
                                        </div>
                                        <div class="product3-content">
                                            <h3>回收公司</h3>
                                            <p>诚信保证金<asp:Label ID="Label2" runat="server" Text="2000元" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></p>
                                            <p>权限：可查看平台所有注册商家及个人的信息、平台咨询、自定义个性化服务</p>
                                            <hr class="split-line">
                                        </div>
                                    </div>
                                </a>
                                <a href="#ct1">
                                    <div class="am-u-md-3 am-u-sm-6 product3-main-box">
                                        <div class="product3-icon">
                                            <i class="am-icon-send-o"></i>
                                        </div>
                                        <div class="product3-content">
                                            <h3>街道回收员</h3>
                                            <p>诚信保证金<asp:Label ID="Label3" runat="server" Text="2000元" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></p>
                                            <p>权限：可查看平台所有注册商家及个人的信息、平台咨询、自定义个性化服务</p>
                                            <hr class="split-line">
                                        </div>
                                    </div>
                                </a>
                                <a href="#ct1">
                                    <div class="am-u-md-3 am-u-sm-6 product3-main-box">
                                        <div class="product3-icon">
                                            <i class="am-icon-diamond"></i>
                                        </div>
                                        <div class="product3-content">
                                            <h3>产废单位或个人</h3>
                                            <p>诚信保证金<asp:Label ID="Label4" runat="server" Text="200元" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></p>
                                            <p>权限：可查看平台所有注册商家及个人的信息、平台咨询、自定义个性化服务</p>
                                            <hr class="split-line">
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <!--index-container end-->
            <div class="section" id="ct1">
                <div class="container">
                    <div class="section--header">
                        <h2 class="section--title">我们欢迎您！相信您也需要这个平台！</h2>
                        <p class="section--description">
                            我们，致力于建立一个正规、合法、有序的电瓶回收平台！
                        </p>
                    </div>
                    <br />
                    <br />
                    <hr />
                    <div class="section-container">
                        <div class="am-g">
                            <!--contact-left start-->
                            <div class="am-u-md-5">
                                <ul class="contact-left">
                                    <li class="contact-box-item">
                                        <div class="contact_item">
                                            <i class="contact_item--icon am-icon-phone"></i>
                                            <h3 class="contact_item--title">我们的联系方式</h3>
                                            <p class="contact_item--text">
                                                联系电话： <strong>0574-86694505</strong>,
											<br>
                                                周一 --- 周五, 8：30---16：30
                                            </p>
                                        </div>
                                    </li>
                                    <li class="contact-item">
                                        <div class="contact_item">
                                            <i class="contact_item--icon am-icon-credit-card-alt"></i>
                                            <h3 class="contact_item--title">公司账号</h3>
                                            <p class="contact_item--text">
                                                <asp:Label ID="Label5" runat="server" Text="公司名称：宁波镇海绿宝科技有限公司" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
                                                <br />
                                                开户行：宁波银行庄市支行
                                                <br />
                                                账号：4495 9849 9844 8378
                                               
                                            </p>
                                        </div>
                                    </li>
                                    <li class="contact-item">
                                        <div class="contact_item">
                                            <i class="contact_item--icon am-icon-weixin"></i>
                                            <h3 class="contact_item--title">微信用户扫一扫付款</h3>
                                            <p class="contact_item--text">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/wxPay.jpg" Width="200px" Height="230px" />
                                            </p>
                                        </div>
                                    </li>
                                    <%--                                     <li class="contact-item">
                                        <div class="contact_item">
                                            <i class="contact_item--icon fa fa-hacker-news"></i>
                                            <h3 class="contact_item--title">支付宝用户扫一扫付款</h3>
                                            <p class="contact_item--text">
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/lb2w.jpg" />
                                            </p>
                                        </div>
                                    </li>--%>
                                    <li class="contact-item">
                                        <div class="contact_item">
                                            <i class="contact_item--icon am-icon-map-marker"></i>
                                            <h3 class="contact_item--title">公司地址</h3>
                                            <p class="contact_item--text">
                                                宁波市镇海区庄市街道中官西路279号文创园
                                            </p>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <!--contact-left end-->

                            <!--contact-right start-->
                            <div class="am-u-md-7">
                                <div class="contact-form">
                                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                        <asp:View ID="View1" runat="server">
                                            <asp:Label ID="lbNoBody" runat="server" Text="Label" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                        </asp:View>
                                        <asp:View ID="View2" runat="server">
                                            <asp:Label ID="lbBody" runat="server" Text="Label" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                        </asp:View>
                                        <asp:View ID="View3" runat="server">
                                        </asp:View>
                                    </asp:MultiView>
                                    <br />
                                    <hr />
                                    <br />
                                    <h3 class="contact-form_title" style="font-size: 18px">如果您汇款成功，请提交一下信息，客服将在工作日时间48小时内与您核实</h3>

                                    <div class="am-g">
                                        <div class="am-u-md-12">
                                            汇款姓名：
                                                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="am-g">
                                        <div class="am-u-md-12">
                                            汇款账户：
                                                <asp:TextBox ID="tbAccount" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="am-g">
                                        <div class="am-u-md-12">
                                            <div class="am-form-group">
                                                汇款金额：
                                                     <asp:TextBox ID="tbAmount" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="am-g">
                                        <div class="am-u-md-12">
                                            <div class="am-form-group">
                                                您的留言：
                                                     <asp:TextBox ID="tbMessage" runat="server"></asp:TextBox>注：如微信支付，请备注好微信账号
                                            </div>
                                        </div>
                                    </div>

                                    <div class="am-g">
                                        <div class="am-u-md-12">
                                            <div class="am-form-group">
                                                <asp:Button ID="btSure" runat="server" Text="提交信息" OnClick="btSure_Click" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <!--contact-right end-->
                        </div>
                    </div>
                </div>
            </div>

        </div>


    </div>
</asp:Content>

