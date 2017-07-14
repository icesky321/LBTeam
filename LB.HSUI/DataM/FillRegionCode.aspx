<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FillRegionCode.aspx.cs" Inherits="DataM_FillRegionCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:Button ID="btnFetchOneUser" runat="server" Text="获取一位用户" OnClick="btnFetchOneUser_Click" /><br />
            用户Id：<asp:Literal ID="ltlUserId" runat="server"></asp:Literal><br />
            用户名：<asp:Literal ID="ltlUserName" runat="server"></asp:Literal><br />
            地域信息：<asp:Literal ID="ltlDiyu" runat="server"></asp:Literal><br />
            <br />
            ----------------------------------------------------------<br />

            <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="ddlCounty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCounty_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="ddlStreet" runat="server"></asp:DropDownList><br />
            <asp:Button ID="btnSaveProvince" runat="server" Text="保存省份" OnClick="btnSaveProvince_Click" />
            <asp:Button ID="btnSavecity" runat="server" Text="保存城市" OnClick="btnSavecity_Click" />
            <asp:Button ID="btnSaveCounty" runat="server" Text="保存县区" OnClick="btnSaveCounty_Click" />
            <asp:Button ID="btnSaveStreet" runat="server" Text="保存街道" OnClick="btnSaveStreet_Click" /><br />
            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>

        </div>
    </form>
</body>
</html>
