<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaveAddress.aspx.cs" Inherits="UserCenter_SaveAddress" %>

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
        <div id="pageEdit" data-role="page">
            <div data-role="header">
                <h2>修改联系地址</h2>
            </div>
            <div data-role="main" class="ui-content">
                <asp:HiddenField ID="hfRegionCode" runat="server" />
                选择省份：
                <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                选择地级市：
                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
                <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
                选择县市：
            <asp:DropDownList ID="ddlCounty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCounty_SelectedIndexChanged"></asp:DropDownList>
                镇或街道：
                 <asp:DropDownList ID="ddlStreet" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStreet_SelectedIndexChanged"></asp:DropDownList><br />


                详细地址：
                <asp:TextBox ID="tbAddress" runat="server" ValidationGroup="edit"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="请填入详细地址" ControlToValidate="tbAddress" ValidationGroup="edit"></asp:RequiredFieldValidator>
                <div class="ui-grid-a">
                    <div class="ui-block-a">
                        <asp:Button ID="btnEdit" runat="server" Text="保存信息" OnClick="btnEdit_Click" ValidationGroup="edit" />
                    </div>
                    <div class="ui-block-b">
                        <a href="ShowAddress.aspx" data-role="button" rel="external">返回</a>
                    </div>
                </div>

            </div>

        </div>
    </form>
</body>
</html>
