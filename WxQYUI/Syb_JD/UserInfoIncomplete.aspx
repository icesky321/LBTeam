<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfoIncomplete.aspx.cs" Inherits="Syb_JD_UserInfoIncomplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <title>信息不完善</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>客户资料不完整</h2>
            </div>
            <div data-role="main" class="ui-content">
                对不起，您注册的个人地址信息尚不完整，无法查阅相关内容，请先移步到个人中心完善您的注册地址。<br />
                <div style="text-align: center;">
                    <a href="../UserCenter/ShowAddress.aspx" data-role="button" data-inline="true" class="ui-btn-active">去完善个人信息</a>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
