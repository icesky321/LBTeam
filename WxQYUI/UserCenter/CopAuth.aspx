<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CopAuth.aspx.cs" Inherits="UserCenter_CopAuth" %>

<%@ Register Src="~/UserControls/Aunth.ascx" TagName="Aunth" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/UnAunth.ascx" TagName="UnAunth" TagPrefix="uc3" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <link href="https://cdn.bootcss.com/weui/1.1.2/style/weui.css" rel="stylesheet" />
    <title>公司资质审核</title>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
        <uc2:Aunth ID="Aunth1" runat="server" Visible="false" />
        <uc3:UnAunth ID="UnAunth1" runat="server" Visible="false" />
        <div id="pageMain" data-role="page">
            <div data-role="header">
                <h2>公司资质资料修改审核</h2>
            </div>
            <div data-role="main" class="ui-content">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewRealName" runat="server">
                        <div style="border: 1px dotted #999999; padding: 20px;" class="ui-corner-all">
                            公司名称：<asp:Literal ID="ltlRealName" runat="server"></asp:Literal>

                        </div>
                        <asp:Button ID="btnEditRealName" runat="server" Text="修改" OnClick="btnEditRealName_Click" data-icon="edit" />
                    </asp:View>
                    <asp:View ID="viewEditRealName" runat="server">
                        公司名称：<asp:TextBox ID="tbRealName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSaveRealName" runat="server" Text="确定保存" OnClick="btnSaveRealName_Click" data-icon="check" />
                    </asp:View>
                </asp:MultiView>
                <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewShowBizlicense" runat="server">
                        <div style="border: 1px dotted #999999; padding: 20px;" class="ui-corner-all">
                            营业执照信息：<asp:Label ID="BAuthenticationLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("BAuthentication"))?  Aunth1.msg : UnAunth1.msg %> ' />

                        </div>
                        <asp:Button ID="btBAuthentication" runat="server" Text="修改" OnClick="btBAuthentication_Click" data-icon="edit" />
                        <asp:Label ID="lbmsg1" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </asp:View>
                    <asp:View ID="viewEditBizlicense" runat="server">
                        <table>
                            <tr>
                                <td>营业执照信息：<asp:Image ID="Image1" runat="server" Width="200px" Height="100px" /></td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btBizlicenseAlter" runat="server" Text="修改认证信息" OnClick="btBizlicenseAlter_Click" /></td>
                            </tr>
                        </table>

                    </asp:View>
                </asp:MultiView>
                <div style="border-bottom: 1px solid #999999; height: 2px; margin: 20px 0 20px 0;"></div>
                <asp:MultiView ID="MultiView3" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewShowHWPermit" runat="server">
                        <div style="border: 1px dotted #999999; padding: 20px;" class="ui-corner-all">
                            危化许可证信息：<asp:Label ID="HWAuthenticationLable" runat="server" Text='<%# Convert.ToBoolean(Eval("HWAuthentication"))?  Aunth1.msg : UnAunth1.msg %> ' />

                        </div>
                        <asp:Button ID="btHWAuthentication" runat="server" Text="修改" OnClick="btHWAuthentication_Click" data-icon="edit" />
                        <asp:Label ID="lbmsg2" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </asp:View>
                    <asp:View ID="viewEditHWPermit" runat="server">
                        <table>
                            <tr>
                                <td>危化许可证信息：<asp:Image ID="Image2" runat="server" Width="200px" Height="100px" /></td>
                                <td>
                                    <asp:FileUpload ID="FileUpload2" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btHWPermitAlter" runat="server" Text="修改认证信息" OnClick="btHWPermitAlter_Click" /></td>
                            </tr>
                        </table>

                    </asp:View>
                </asp:MultiView>
                <div style="height: 60px;"></div>
            </div>
<%--            <div data-role="main" class="ui-content" runat="server" id="Person" visible="false">
                <h2>对不起，您不是商家或公司，无需提交此类材料.</h2>
            </div>--%>
        </div>
    </form>
</body>
</html>
