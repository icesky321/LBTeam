<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cjwt.aspx.cs" Inherits="ljlb_cjwt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <style type="text/css">
        .question {
            color: darkorange;
            padding: 20px 0 0 0;
        }

        .answer {
            color: darkgrey;
            font-size: 0.9em;
            text-indent: 2em;
        }
    </style>
    <title>常见问题</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page1" data-role="page">
            <div data-role="header">
                <a href="Default.aspx" data-icon="home" rel="external">&nbsp;</a>
                <h1>常见问题分类</h1>
            </div>
            <div data-role="main" class="ui-content">
                <ul data-role="listview">
                    <li><a href="#page2" data-transition="slide">行业身份说明</a></li>
                    <li><a href="#page3" data-transition="slide">产废单位（个人）常见问题</a></li>
                    <li><a href="#page4" data-transition="slide">街道电瓶回收员常见问题</a></li>
                    <li><a href="#page5" data-transition="slide">回收公司常见问题</a></li>
                    <li><a href="#page6" data-transition="slide">冶炼厂常见问题</a></li>
                    <li><a href="#page7" data-transition="slide">注册和登录</a></li>
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

        <!-- 行业身份说明 -->
        <div id="page2" data-role="page">
            <div data-role="header" data-add-back-btn="true" data-back-btn-text="返回">
                <h2>行业主体说明</h2>
            </div>
            <div data-role="main" class="ui-content">
                <p class="question">1、什么是供废单位（个人）</p>
                <p class="answer">铅蓄电池（电瓶）的消费主体主要包括个人消费者和集团消费者，个人消费者主要是汽车、电动车等电池用户，这些电瓶一般被汽车4S店、汽车修理店、电动车修理店等回收。集团用户主要是通讯、电力、运输等UPS和牵引型电池用户。</p>
                <p class="question">2、什么是街道电瓶回收员</p>
                <p class="answer">街道电瓶回收员经由平台认证，接受平台及合法回收公司的双重管理，在产废单位和回收公司之间起到电瓶转移的桥梁作用。经认证的街道电瓶回收员负责指定街道的电瓶回收业务，并最终将电瓶转移到合法回收公司。</p>
                <p class="question">3、什么是地域回收公司</p>
                <p class="answer">地域回收公司是经省市级工商部门认证，具备废旧电瓶回收资质但不具有废旧电瓶处理的企业，接收街道回收员回收上来的电瓶，并最终转移至电瓶冶炼厂。</p>
                <p class="question">4、什么是电瓶冶炼厂</p>
                <p class="answer">具有废旧电瓶处理、回炉冶炼资质的再生铅厂，废旧铅蓄电池的经回收链后的最终归属地，将在这里重新冶炼成铅块。</p>
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

        <!-- 产废单位（个人）常见问题 -->
        <div id="page3" data-role="page">
            <div data-role="header" data-add-back-btn="true" data-back-btn-text="返回">
                <h2>产废单位（个人）常见问题</h2>
            </div>
            <div data-role="main" class="ui-content">
                <p class="question">1、你们平台回收电瓶吗？</p>

                <p class="answer">平台不直接回收电瓶。绿宝三益电瓶交易平台是第三方平台，促进买卖双方信息联系，帮助解决废旧电瓶回收处理过程中出现的各种乱相。</p>
                <p class="question">2、我的废电瓶要卖，但不知道卖给谁才是合法的，你们平台能提供帮助吗？</p>
                <p class="answer">绿宝三益平台正是为此而生，平台整合行业各方资源，使电瓶回收过程在合法、合规的框架内运作，保证各方利益。</p>
                <p class="question">3、	我跟电瓶行业没啥关系，有废电瓶要处理，但不知道卖给谁。</p>
                <p class="answer">无论您是行业内、还是行业外人员，都可在我们平台上发布出售信息，平台会第一时间指派合法回收人员为您上门服务。</p>
                <p class="question">4、	我发现市场上电瓶回收价格很乱，时刻担心我是不是卖亏了。</p>
                <p class="answer">请加入绿宝三益平台，平台统一了市场地域回收价格，保障您的利益。</p>
                <p class="question">5、	加入你们平台需要收费吗？</p>
                <p class="answer">加入平台不收费，你可以免费发布出售信息，平台将助你合法无忧完成废旧电瓶处理的全过程。</p>
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

        <!-- 街道电瓶回收员常见问题 -->
        <div id="page4" data-role="page">
            <div data-role="header" data-add-back-btn="true" data-back-btn-text="返回">
                <h2>街道电瓶回收员常见问题</h2>
            </div>
            <div data-role="main" class="ui-content">
                <p class="question">1、	我初入电瓶回收行业，产废单位都不知道我的存在，怎样发展我的业务？</p>
                <p class="answer">绿宝三益平台提供全面的行业资源信息，只要您认证成为平台街道回收员，整个街道都是您的地盘，您将直接接管本街道所有电瓶回收业务。</p>
                <p class="question">2、	我成为平台街道回收员，没人跟我竞争业务吗？</p>
                <p class="answer">平台认证的街道回收员具有唯一性、独占性，具有本街道专属合法回收权限，本街道所有电瓶回收出售需求，将会直接推送到您手机。</p>
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

        <!-- 回收公司常见问题 -->
        <div id="page5" data-role="page">
            <div data-role="header" data-add-back-btn="true" data-back-btn-text="返回">
                <h2>回收公司常见问题</h2>
            </div>
            <div data-role="main" class="ui-content">
                Html 内容
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

        <!-- 冶炼厂常见问题 -->
        <div id="page6" data-role="page">
            <div data-role="header" data-add-back-btn="true" data-back-btn-text="返回">
                <h2>冶炼厂常见问题</h2>
            </div>
            <div data-role="main" class="ui-content">
                Html 内容
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

        <!-- 注册和登录 -->
        <div id="page7" data-role="page">
            <div data-role="header" data-add-back-btn="true" data-back-btn-text="返回">
                <h2>注册和登录</h2>
            </div>
            <div data-role="main" class="ui-content">
                Html 内容
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
