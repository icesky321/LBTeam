<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestLocalJD.aspx.cs" Inherits="Syb_HS_TestLocalJD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- 以下四句提供省市县功能 -->
    <script type="text/javascript" src="js/jquery.js" charset="gbk"></script>
    <script type="text/javascript" src="js/GlobalProvinces_main.js" charset="gbk"></script>
    <script type="text/javascript" src="js/GlobalProvinces_extend.js" charset="gbk"></script>
    <script type="text/javascript" src="js/initLocation.js" charset="gbk"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="main" class="ui-content">
            <asp:DropDownList ID="sheng" runat="server" class="Material" name="province" ClientIDMode="Static">
            </asp:DropDownList>
            <asp:DropDownList ID="shi" runat="server" name="city" ClientIDMode="Static"></asp:DropDownList>
            <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
            选择县市：
            <asp:DropDownList ID="xian" runat="server" name="country" ClientIDMode="Static"></asp:DropDownList>
            镇或街道：
                <asp:DropDownList ID="xiang" runat="server" name="street" ClientIDMode="Static"></asp:DropDownList>
            <script type="text/javascript">
                $(function () { initLocation({ sheng_val: "浙江", shi_val: "宁波", xian_val: "<?php echo $v['country']?>", xiang_val: "<?php echo $v['street']?>" }); })
            </script>

            详细地址：
                <asp:TextBox ID="tbAddress" runat="server" ValidationGroup="edit"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="请填入详细地址" ControlToValidate="tbAddress" ValidationGroup="edit"></asp:RequiredFieldValidator>
            <div class="ui-grid-a">
                <div class="ui-block-a">
                    <asp:Button ID="btnEdit" runat="server" Text="保存信息" ValidationGroup="edit" />
                </div>
                <div class="ui-block-b">
                    <a href="EditAddress.aspx" data-role="button" rel="external">返回</a>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
