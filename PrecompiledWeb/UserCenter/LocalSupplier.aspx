<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="UserCenter_LocalSupplier, App_Web_qwb0kbh1" theme="Default" %>

<%@ Register Src="~/UserControls/Aunth.ascx" TagName="Aunth" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/UnAunth.ascx" TagName="UnAunth" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/amazeui.js" type="text/javascript" charset="utf-8"></script>
    <link rel="stylesheet" href="../css/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>当地供应商</h1>
                </p>
            </div>
            <hr />
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <uc2:Aunth ID="Aunth1" runat="server" Visible="false" />
                    <uc3:UnAunth ID="UnAunth1" runat="server" Visible="false" />
                    <div class="section">
                        <div class="container">
                            <div class="index-container">
                                <div class="am-g">
                                    <div class="am-u-md-12">
                                        <asp:DataList ID="DLCopInfo" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                                            <ItemTemplate>
<%--                                                UserId:
                                                <asp:Label ID="UserIdLabel" runat="server" Text='<%# Eval("UserId") %>' />
                                                <br />
                                                UserTypeId:
                                                <asp:Label ID="UserTypeIdLabel" runat="server" Text='<%# Eval("UserTypeId") %>' />
                                                <br />--%>
                                                用户名:
                                                <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                                                <br />
                                                电话号码:
                                                <asp:Label ID="MobilePhoneNumLabel" runat="server" Text='<%# Eval("MobilePhoneNum") %>' />
                                                <br />
                                                地址：:
                                                  <asp:Label ID="ProvinceLabel" runat="server" Text='<%# Eval("Province") %>' />省<asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />市
                                            <asp:Label ID="TownLabel" runat="server" Text='<%# Eval("Town") %>' />区<asp:Label ID="StreetLabel" runat="server" Text='<%# Eval("Street") %>' />
                                               
                                                <br />
                                                身份证认证:
                                                 <asp:Label ID="IDAuthenticationLabel" runat="server" Text='<%# Convert.ToBoolean(Eval("IDAuthentication"))? Aunth1.msg : UnAunth1.msg %> ' />
                                                <br />
                                                Audit:
                                                <asp:Label ID="AuditLabel" runat="server" Text='<%# Eval("Audit") %>' />
                                                <br />
                                                商家名称:
                                                <asp:Label ID="CopNameLabel" runat="server" Text='<%# Eval("CopName") %>' />
                                                <br />
                                                商家信息:
                                                <asp:Label ID="CopDetailLabel" runat="server" Text='<%# Eval("CopDetail") %>' />
                                                <br />
                                                <br />
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <br />
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <ul>
                        <li>对不起，该地区暂空缺~
                        </li>
                    </ul>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>

