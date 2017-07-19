<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true" CodeFile="EditStaff.aspx.cs" Inherits="SystemAdmin_EditStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .infoBlock {
            margin: 20px 0 0 0;
            border-top: 1px solid #808080;
        }

        .title {
            font-size: 1.5em;
            padding: 10px 0 10px 0;
        }

        .data {
            color: blue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfStaffId" runat="server" />
    <asp:HiddenField ID="hfMobileNum" runat="server" />
    <asp:HiddenField ID="hfUserId" runat="server" />
    <div class="infoBlock">
        <div class="title">
            平台员工基本信息
        </div>
        <div style="line-height: 2em;">
            姓名：<asp:Label ID="lbRealName" runat="server" Text="" CssClass="data"></asp:Label><br />
            昵称：<asp:Label ID="lbUserName" runat="server" Text="" CssClass="data"></asp:Label><br />
            手机号码：<asp:Label ID="lbMobileNum" runat="server" Text="" CssClass="data"></asp:Label><br />

        </div>
    </div>

    <div class="infoBlock">
        <div class="title">
            修改行政区域
        </div>
        <div>
            <asp:HiddenField ID="hfRegionCode" runat="server" />
            当前所在行政区划：<asp:Label ID="lbRegionWholeName" runat="server" Text="" CssClass="data"></asp:Label><br />
            选择省份：
                <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
            选择地级市：
                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
            <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
            选择县市：
            <asp:DropDownList ID="ddlCounty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCounty_SelectedIndexChanged"></asp:DropDownList>
            镇或街道：
                 <asp:DropDownList ID="ddlStreet" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStreet_SelectedIndexChanged"></asp:DropDownList>
            <asp:Button ID="btnSaveRegionCode" runat="server" Text="保存行政区划" OnClick="btnSaveRegionCode_Click" BorderColor="#669999" />
            <br />
        </div>
    </div>

    <div class="infoBlock">
        <div class="title">变更行业身份</div>
        <div>
            当前行业身份：<asp:Label ID="lbHangyeIdentity" runat="server" Text="" CssClass="data"></asp:Label><br />
            <asp:DropDownList ID="ddlHangyeIdentity" runat="server"></asp:DropDownList>
            <asp:Button ID="btnSaveHangyeIdentity" runat="server" Text="保存行业身份" OnClick="btnSaveHangyeIdentity_Click" BorderColor="#669999" />
        </div>
    </div>

    <div class="infoBlock">
        <div class="title">设置用户角色</div>
        <div>
            <table>
                <tr>
                    <td style="width: 300px;">
                        <asp:HiddenField ID="userRoles" runat="server" />
                        <asp:CheckBoxList ID="cblRoles" runat="server"></asp:CheckBoxList></td>
                    <td style="vertical-align: top;">Admin:系统核心管理员，掌管全系统所有权限；<br />
                        CEMetalFactory:信用审核通过后的冶炼厂；<br />
                        CERecyclingCop:信用审核通过后的回收公司；<br />
                        CESupplier:信用审核通过后的产废单位或个人；<br />
                        CEUser:信用审核通过后的街道回收员；<br />
                        general:注册后未审核的普通用户；<br />
                        InfoManage:资讯管理审核员；<br />
                        UserManage:用户管理审核员；<br />
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnSetUserRoles" runat="server" Text="设置用户角色" OnClick="btnSetUserRoles_Click" BorderColor="#669999" />
        </div>
    </div>

    <div class="infoBlock">
        <div class="title">设置企业号账户</div>
        <div>
            <div style="padding: 20px 0 20px 0;">
                用户状态：企业号用户Id：<asp:Label ID="lbQYUserId" runat="server" Text=""></asp:Label>
                <asp:LinkButton ID="lbtnDeleteQYUser" runat="server" OnClick="lbtnDeleteQYUser_Click">解绑企业号账户，同时删除企业号账户</asp:LinkButton>
            </div>
            <table>
                <tr>
                    <td>企业号用户Id</td>
                    <td>
                        <asp:TextBox ID="tbQYUserId" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>姓名</td>
                    <td>
                        <asp:TextBox ID="tbRealName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>手机号码</td>
                    <td>
                        <asp:TextBox ID="tbMobileNum" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>行业身份</td>
                    <td>
                        <asp:DropDownList ID="ddlShengfen" runat="server">
                            <asp:ListItem Text="平台员工" Value="平台员工"></asp:ListItem>
                            <asp:ListItem Text="冶炼厂" Value="冶炼厂"></asp:ListItem>
                            <asp:ListItem Text="回收公司" Value="回收公司"></asp:ListItem>
                            <asp:ListItem Text="回收业务员" Value="回收业务员"></asp:ListItem>

                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding: 10px 0 10px 0;">
                        <asp:Button ID="btnCreateQYUser" runat="server" Text="创建企业号账户" OnClick="btnCreateQYUser_Click" BorderColor="#669999" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

