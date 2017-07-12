<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditAddress.aspx.cs" Inherits="UserCenter_EditAddress" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <!-- 以下四句提供省市县功能 -->
    <script type="text/javascript" src="js/jquery.js" charset="gbk"></script>
    <script type="text/javascript" src="js/GlobalProvinces_main.js" charset="gbk"></script>
    <script type="text/javascript" src="js/GlobalProvinces_extend.js" charset="gbk"></script>
    <script type="text/javascript" src="js/initLocation.js" charset="gbk"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="pageMain" data-role="page">
            <div data-role="header">
                <h2>我的地址</h2>
            </div>
            <div data-role="main" class="ui-content">
                <div style="border: 1px dotted #999999; padding: 20px;" class="ui-corner-all">
                    <asp:Literal ID="ltlProvince" runat="server"></asp:Literal>-
                    <asp:Literal ID="ltlCity" runat="server"></asp:Literal>-
                    <asp:Literal ID="ltlXian" runat="server"></asp:Literal>-
                    <asp:Literal ID="ltlStreet" runat="server"></asp:Literal><br />
                    详细地址：<asp:Literal ID="ltlAddress" runat="server"></asp:Literal>
                </div>
                <div class="ui-grid-a">
                    <div class="ui-block-a">
                        <a href="#pageEdit" data-role="button">修改我的地址</a>
                    </div>
                    <div class="ui-block-b">
                        <a href="uc_cfdw.aspx" data-role="button" rel="external">回到个人中心</a>
                    </div>
                </div>



            </div>

        </div>

        <div id="pageEdit" data-role="page">
            <div data-role="header">
                <h2>修改联系地址</h2>
            </div>
            <div data-role="main" class="ui-content">
                选择省份：
                <asp:DropDownList ID="sheng" runat="server" class="Material" name="province" ClientIDMode="Static">
                </asp:DropDownList>
                选择地级市：
                <asp:DropDownList ID="shi" runat="server" name="city" ClientIDMode="Static"></asp:DropDownList>
                <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
                选择县市：
            <asp:DropDownList ID="xian" runat="server" name="country" ClientIDMode="Static"></asp:DropDownList>
                镇或街道：
                <asp:DropDownList ID="xiang" runat="server" name="street" ClientIDMode="Static"></asp:DropDownList>
                <script type="text/javascript">
                    $(function () { initLocation({ sheng_val: "浙江省", shi_val: "宁波", xian_val: "<?php echo $v['country']?>", xiang_val: "<?php echo $v['street']?>" }); })
                </script>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                    <ContentTemplate>
                        详细地址：
                <asp:TextBox ID="tbAddress" runat="server" ValidationGroup="edit"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="请填入详细地址" ControlToValidate="tbAddress" ValidationGroup="edit"></asp:RequiredFieldValidator>
                        <div class="ui-grid-a">
                            <div class="ui-block-a">
                                <asp:Button ID="btnEdit" runat="server" Text="保存信息" OnClick="btnEdit_Click" ValidationGroup="edit" />
                            </div>
                            <div class="ui-block-b">
                                <a href="EditAddress.aspx" data-role="button" rel="external">返回</a>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>

    </form>
</body>
</html>
