<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateLeads.aspx.cs" Inherits="MP_CreateLeads" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />

    <%--    <script type="text/javascript">
        $(function () {
            $("#btnSubmit").click(function () {
                $.ajax({
                    //要用post方式 
                    type: "Post",
                    //方法所在页面和方法名 
                    url: "CreateLeads.aspx/SaveLeads",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //返回的数据用data.d获取内容 
                        alert(data.d);
                    },
                    error: function (err) {
                        alert(err);
                    }
                });

                //禁用按钮的提交 
                return false;
            });
        });
    </script>--%>
    <title>发布出售信息</title>
</head>
<!-- 本页面街道业务员调用，创建电瓶出卖信息。 -->
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div data-role="page" id="page1">
            <div data-role="header">
                <h2>绿宝--出售信息发布</h2>
            </div>
            <div data-role="main" class="ui-content">
                <div data-role="collapsible">
                    <h2>注册 登录 后方可发布出售信息（点击此信息）</h2>
                    <p>免费注册。 你还在为不知如何处理废旧电瓶而烦恼吗？立即注册为绿宝三益会员，您即可免费发布出售信息，会有合法回收人员上门为您服务，处理电瓶就那么轻松！！</p>
                </div>

                <fieldset data-role="controlgroup">
                    <legend>您要出售的电瓶品种</legend>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="ObjectDataSource1" DataTextField="TSName" DataValueField="TSId" RepeatLayout="UnorderedList">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTSInfo" TypeName="LB.BLL.TSInfo"></asp:ObjectDataSource>
                </fieldset>
                <div class="ui-field-contain">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <label for="fname">大约数量:</label></td>
                            <td>
                                <input type="text" name="fname" id="fname" runat="server" placeholder="大约数量 吨/组/个" /></td>
                        </tr>
                    </table>
                    <label for="info">附加信息：</label>
                    <input id="tbText" runat="server" textmode="MultiLine" rows="2"></input>


                </div>
                <div style="border-bottom: 1px solid #cccccc"></div>
                <div data-role="collapsible">
                    <h2>供废卖方信息</h2>
                    <p>卖方个人联系电话、地址等信息</p>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSubmit" runat="server" Text="发布" data-role="button" OnClick="btnSubmit_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>

                <%--<input type="button" value="发布" class="ui-btn" id="btnSubmit" />--%>
            </div>
            <div data-role="footer">
                <div class="page__bd page__bd_spacing">
                    <br>
                    <br>
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:void(0);" class="weui-footer__link"></a>
                        </p>
                        <p class="weui-footer__text">Copyright &copy; 2016-2017 宁波绿宝三益 lvbao111.com</p>
                    </div>
                </div>
            </div>

        </div>

    </form>
</body>
</html>
