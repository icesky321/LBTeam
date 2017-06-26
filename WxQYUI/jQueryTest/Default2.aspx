<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="jQueryTest_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="page1" data-role="page">
                <div data-role="header">
                    <h1>关于我们</h1>
                </div>
                <div data-role="content">
                    <p>jQuery Mobile 页面的正文部分</p>
                    <p><a href="#page2" data-transition="slide">第2页</a></p>
                </div>
                <div data-role="footer">
                    <h1>页脚</h1>
                </div>
            </div>
            <div id="page2" data-role="page">
                <div data-role="header">
                    <h1>第二个页面标题</h1>
                </div>
                <div data-role="content">
                    <p>jQuery Mobile 页面的正文部分</p>
                    <p><a href="#page1" data-transition="flip">返回第1页</a></p>
                </div>
                <div data-role="footer">
                    <h1>页脚</h1>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
