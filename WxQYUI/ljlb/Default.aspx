<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ljlb_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>了解绿宝</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page1" data-role="page">
            <div data-role="header">

                <div>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/ljlb/Images/apic13881.jpg" Width="100%" />
                </div>
            </div>
            <div data-role="content">

                <ul data-role="listview">
                    <li><a href="#page2" data-transition="slide">关于绿宝</a></li>
                    <li><a href="cjwt.aspx" data-transition="slide" rel="external">常见问题</a></li>
                    <li data-role="list-divider"></li>
                    <li>客服热线<br />
                        0574-86694505  (周一至周五 8:00-17:00)

                    </li>
                    <li>市场合作<br />李经理：13255748666

                    </li>
                    <li data-role="list-divider"></li>
                    <li><a href="#page3" data-transition="slide">联系我们</a></li>
                    <li><a href="#">加入我们</a></li>
                    <li><a href="#">意见反馈</a></li>
                    <li data-role="list-divider"></li>
                    <li><a href="http://www.lvbao111.com/">访问绿宝PC版网站</a></li>
                </ul>
            </div>
            <div data-role="footer">
                <div class="page__bd page__bd_spacing">
                    <br>
                    <br>
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:void(0);" class="weui-footer__link"></a>
                        </p>
                        <p class="weui-footer__text">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</p>
                    </div>
                </div>
            </div>
        </div>

        <div id="page2" data-role="page">
            <div data-role="header" data-add-back-btn="true" data-back-btn-text="返回">

                <h2>关于绿宝</h2>
            </div>
            <div data-role="main" class="ui-content">
                <title>绿宝三益公司简介</title>
                <p style="text-indent: 2em;">绿色环保，合规回收。绿宝三益电瓶回收平台是一家专注于废旧电瓶回收的垂直行业创新平台，凭借多年的电瓶回收行业经验，以及强大的的互联网优势，联合行业上下游资源，将电瓶产废源头单位（个人）、街道电瓶回收员、回收公司、冶炼厂等行业资源进行深度整合，促进专业领域资源共享，消除行业乱相，理顺行业秩序，引导行业顺应国家绿色、环保、节能的政策方向，让废旧电瓶交易合规化、合法化、阳光化。</p>
                <p style="text-indent: 2em;">未来，绿宝三益不仅定位于电瓶行业的回收交易平台，还将打造成互联网金融综合性交易平台，为行业内用户提供多元化的金融服务和产品。</p>
                <br />
                <p style="text-indent: 2em;">我们的愿景： <span style="color: yellowgreen">绿色回收，益国、益民、益环境</span> </p>
            </div>
            <div data-role="footer">
                <div class="page__bd page__bd_spacing">
                    <br>
                    <br>
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:void(0);" class="weui-footer__link"></a>
                        </p>
                        <p class="weui-footer__text">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</p>
                    </div>
                </div>
            </div>
        </div>

        <!-- 联系我们 -->
        <div data-role="page" id="page3">
            <div data-role="header" data-add-back-btn="true" data-back-btn-text="返回">
                <h2>联系我们</h2>
            </div>
            <div data-role="main" class="ui-content">
                <p>
                    <strong>公司名称：</strong> 绿宝科技有限公司<br />
                    <strong>公司地址：</strong>宁波市镇海区庄市街道中官西路279号文创园
                </p>
                <br />


                <div data-role="collapsible" data-collapsed="false">
                    <h2>客户服务</h2>
                    <p>
                        <strong>电话：</strong>0574-86694505 （周一至周五 8:00-17:00）<br />
                        <%--<strong>邮箱：</strong>kefu@lvbao111.com--%>
                    </p>
                </div>
                <br />
                <div data-role="collapsible" data-collapsed="false">
                    <h2>市场合作李经理</h2>
                    <p>
                        <strong>电话：</strong>132-5574-8666<br />
                        <%--<strong>邮箱：</strong>sale@lvbao111.com--%>
                    </p>
                </div>
                <br />
                <div data-role="collapsible" data-collapsed="false">
                    <h2>人事招聘方经理</h2>
                    <p>
                        <strong>电话：</strong>0574-86694505<br />
                        <%--<strong>邮箱：</strong>hr@lvbao111.com--%>
                    </p>
                </div>
            </div>
            <div data-role="footer">
                <div class="page__bd page__bd_spacing">
                    <br>
                    <br>
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:void(0);" class="weui-footer__link"></a>
                        </p>
                        <p class="weui-footer__text">Copyright &copy; 2016-2017 绿宝三益 lvbao111.com</p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
