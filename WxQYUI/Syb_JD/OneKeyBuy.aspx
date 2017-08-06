<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OneKeyBuy.aspx.cs" Inherits="Syb_JD_OneKeyBuy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <title>一键收货</title>
</head>
<body ontouchstart>
    <form id="form1" runat="server" data-ajax="false">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>街道业务员一键收货</h2>
                <asp:HiddenField ID="hfUserMobile" runat="server" />
                <asp:HiddenField ID="hfHS_UserId" runat="server" />
                <asp:HiddenField ID="hfCF_UserId" runat="server" />
                <asp:HiddenField ID="hfJD_UserId" runat="server" />
                <asp:HiddenField ID="hfCityRegionCode" runat="server" />
                <asp:HiddenField ID="hfRegionCode" runat="server" />
            </div>
            <p>
                你所在的城市为：
                <asp:Literal ID="ltlCityWholeName" runat="server"></asp:Literal>
            </p>
            <div data-role="main" class="ui-content">
                <label for="fullname">街道回收员：</label>
                <asp:Label ID="lbjd" runat="server" Text=""></asp:Label>
                <asp:Label ID="tbjdywy" runat="server" Text=""></asp:Label>
                <hr />
                <label for="fullname">产废单位：</label>
                <asp:Label ID="lbCf" runat="server" Text=""></asp:Label>
                <asp:Label ID="tbcfdw" runat="server" Text=""></asp:Label><asp:Button ID="btChooseCF" runat="server" Text="选择产废单位..." OnClick="btChooseCF_Click" />

                <hr />
                <br />
                <asp:Label ID="lbMsg" runat="server" Text="" ForeColor="Red" Font-Size="Medium" Visible="false"></asp:Label>

            </div>
            <div data-role="main" class="ui-content" runat="server" id="ChooseCF" visible="false">
                选择县市：
            <asp:DropDownList ID="ddlCounty" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCounty_SelectedIndexChanged"></asp:DropDownList>

                镇或街道：
                 <asp:DropDownList ID="ddlStreet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStreet_SelectedIndexChanged"></asp:DropDownList>
                <div class="page__bd page__bd_spacing">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <ul>
                        <asp:Repeater ID="rptStreet" runat="server" OnItemCommand="rptStreet_ItemCommand">
                            <HeaderTemplate>
                                <ul data-role="listview" style="background-color: white;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <a href="#">
                                        <asp:HiddenField ID="hfUserId" runat="server" Value='<%# Eval("UserId") %>'></asp:HiddenField>
                                        <asp:Literal ID="ltlCF_RealName" runat="server" Text='<%# Eval("RealName")==null ?"未实名认证":Eval("RealName").ToString() %>'></asp:Literal>)<br />
                                        <span class="ui-li-count">
                                            <div class="page__category js_categoryInner">
                                                <div class="weui-cells page__category-content">
                                                    <a class="weui-cell">
                                                        <div class="weui-cell__bd">
                                                            <p>
                                                                联系电话： <span style="color: #0094ff; font-size: 1em; font-weight: 600;">
                                                                    <asp:Literal ID="ltlMobilePhone" runat="server" Text='<%# Eval("MobilePhoneNum") %>'></asp:Literal></span>
                                                            </p>
                                                        </div>
                                                        <div class="weui-cell__ft"></div>
                                                    </a>
                                                    <a class="weui-cell">
                                                        <div class="weui-cell__bd">
                                                            <p>
                                                                详细地址：<asp:Literal ID="ltlAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Literal>
                                                            </p>
                                                        </div>
                                                        <%--<div class="weui-cell__ft"></div>--%>
                                                    </a>
                                                </div>
                                            </div>
                                        </span>
                                        <div class="weui-cell__bd">

                                            <asp:Button ID="btSure" runat="server" Text="选择该产废单位" rel="external" CommandName="Confirm" CommandArgument='<%#Eval("UserId") %>' />

                                        </div>

                                    </a></li>

                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>
            <hr />
            <br />
            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red" Font-Size="Medium" Visible="false"></asp:Label>
            <div data-role="main" class="ui-content">
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
                    <ItemTemplate>
                        <div class="weui-cell weui-cell_vcode">
                            <div class="weui-cell__hd">
                                <label class="weui-label">
                                    <asp:HiddenField ID="hfTSId" runat="server" Value='<%# Eval("TSId") %>' />
                                    <asp:Literal ID="ltlTSName" runat="server" Text='<%# Eval("TSName") %>'></asp:Literal></label>
                            </div>
                            <div class="weui-cell__bd">
                                <asp:TextBox ID="tbNum" runat="server" class="weui-input" type="text"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tbNum" ValidChars="1234567890./- " Enabled="True" />
                            </div>
                            <div class="weui-cell__ft">
                                <label class="weui-label">
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("ChargeUnit") %>'></asp:Literal></label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LB.SQLServerDAL.LBDataContext" EntityTypeName="" OrderBy="OrderNum" TableName="TSInfo"></asp:LinqDataSource>
            </div>
            <div class="weui-cell weui-cell_vcode">
                <div class="weui-cell__hd">
                    <label class="weui-label">
                        总金额：
                    </label>
                </div>
                <div class="weui-cell__bd">
                    <asp:TextBox ID="tbAmount" runat="server" class="weui-input" type="text" placeholder="请输入付款金额" ValidationGroup="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入金额！" ValidationGroup="1" ControlToValidate="tbAmount" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="weui-cell__ft">
                    <label class="weui-label">
                        元
                    </label>
                </div>
            </div>
            <div class="ui-field-contain">
                <label for="fullname">备注：</label>
                <asp:TextBox ID="tbRemark" runat="server" Text="" placeholder="如有补充说明请在这里输入"></asp:TextBox>

            </div>
            <br />

            <asp:Button ID="btSure" runat="server" Text="提交" OnClick="btSure_Click" rel="external" ValidationGroup="1" data-ajax="false" />


        </div>
    </form>
</body>
</html>
