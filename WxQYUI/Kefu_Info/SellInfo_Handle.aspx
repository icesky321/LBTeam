<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellInfo_Handle.aspx.cs" Inherits="Kefu_Info_SellInfo_Handle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://apps.bdimg.com/libs/jquerymobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <style>
        .dataCell {
            padding: 10px;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page1" data-role="page">
            <div data-role="header">
                <h2>出售信息审核</h2>
            </div>
            <div data-role="main" class="ui-content">
                <div style="border: 1px solid #808080; padding: 15px; border-radius: 5px;">
                    平台客服初审信息，若无负面信息，直接放行。
                </div>
                <div>
                    <asp:HiddenField ID="hfInfoId" runat="server" />
                    <asp:HiddenField ID="hfCF_UserId" runat="server" Value="" />
                    <asp:HiddenField ID="hfCF_QYUserId" runat="server" Value="" />
                    <asp:HiddenField ID="hfRegionCode" runat="server" />

                    <div data-role="collapsible" data-collapsed="false">
                        <h3>
                            <div style="float: left;">
                                <asp:Label ID="lbTitle" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="float: right;">
                                <asp:Label ID="lbCreateDate" runat="server" Text=""></asp:Label>
                            </div>
                        </h3>
                        <p>
                            出售信息：<b><asp:Literal ID="ltlDescription" runat="server" Text=""></asp:Literal></b><br />
                            数量：<b><asp:Literal ID="ltlQuantity" runat="server" Text=""></asp:Literal></b><br />
                            <br />
                            联系人：                               
                            <asp:Label ID="ltlRealName" runat="server" ForeColor="#6699ff"></asp:Label><br />

                            联系电话：                               
                            <asp:Label ID="ltlPhone" runat="server" ForeColor="#6699ff"></asp:Label><br />

                            行政区划：<asp:Label ID="lbRegionWholeName" runat="server" Text="" ForeColor="#6699ff" Font-Bold="true"></asp:Label><br />
                            详细地址：                               
                            <asp:Label ID="ltlAddress" runat="server" ForeColor="#6699ff"></asp:Label><br />
                        </p>
                    </div>
                    <div id="divMsg" runat="server" visible="false" style="margin: 20px 0 20px 0; border: 1px solid #808080; padding: 15px; border-radius: 5px; background-color: #ce2c2c; color: white;">
                        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
                    </div>
                    选择回收公司：
                                        <div class="ui-grid-a">
                                            <asp:DropDownList ID="ddlCop" runat="server">
                                                <asp:ListItem Value="0">...请选择回收公司...</asp:ListItem>
                                                <asp:ListItem Value="1155">杭州赐翔</asp:ListItem>
                                                <asp:ListItem Value="2442">绍兴云豪</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                    转发此信息至：

                    <div class="ui-grid-a">
                        <div class="ui-block-a">
                            <asp:RadioButton ID="rbtnAuto" runat="server" Text="指派回收业务员 →" Checked="true" GroupName="Next"/>
                        </div>
                        <div class="ui-block-b">
                            <asp:DropDownList ID="ddlJD" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="ui-grid-a">
                        <div class="ui-block-a">
                            <asp:RadioButton ID="rbtnHS" runat="server" Text="人工指派回收公司 →" GroupName="Next" Visible="false" />
                        </div>
                        <div class="ui-block-b">
                            <asp:DropDownList ID="ddlHS" runat="server" Visible="false"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="ui-grid-a">
                        <div class="ui-block-a">
                            <asp:RadioButton ID="rbtnJD" runat="server" Text="人工指派回收业务员 →" GroupName="Next" Visible="false"  />
                        </div>
                        <div class="ui-block-b">
                            <asp:DropDownList ID="ddlPingtaiYWY" runat="server"  Visible="false"></asp:DropDownList>
                        </div>
                    </div>

                    客服留言：<br />
                    <asp:TextBox ID="tbRemark" runat="server" Rows="2" TextMode="MultiLine" Width="100%" Style="margin-bottom: 10px;"></asp:TextBox>
                    <fieldset data-role="controlgroup" data-type="horizontal" data-inline="false">
                        <asp:Button ID="btnAccept" runat="server" Text="审核通过" data-icon="check" CssClass="ui-btn-active" CommandName="Accept" CommandArgument='<%# Eval("InfoId") %>' OnCommand="CommandButton_Click" rel="external"/>
                        <asp:Button ID="btnReject" runat="server" Text="作废，关闭信息" data-icon="delete" CommandName="Reject" CommandArgument='<%# Eval("InfoId") %>' OnCommand="CommandButton_Click" rel="external"/>
                    </fieldset>
                    <div style="padding: 20px 0 50px 0;">
                        处理结果：<asp:Literal ID="ltlResult" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>

        </div>

    </form>
</body>
</html>

