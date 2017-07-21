<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestCascadingDDL.aspx.cs" Inherits="Test_TestCascadingDDL" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><ajaxToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="DropDownList1" />
        </div>
    </form>
</body>
</html>
