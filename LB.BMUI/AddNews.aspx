<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.master" AutoEventWireup="true"
    CodeFile="AddNews.aspx.cs" Inherits="Admin_NewsManage" ValidateRequest="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/jquery.js" charset="gbk"></script>
    <script type="text/javascript" src="js/GlobalProvinces_main.js" charset="gbk"></script>
    <script type="text/javascript" src="js/GlobalProvinces_extend.js" charset="gbk"></script>
    <script type="text/javascript" src="js/initLocation.js" charset="gbk"></script>
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <br />
    <br />
    请选择发布资讯的类别：
    <asp:DropDownList ID="ddlNewsType" runat="server" ValidationGroup="1"
        AutoPostBack="True" OnSelectedIndexChanged="ddlNewsType_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="ddlNewsType"
        ErrorMessage="*”。" ToolTip="资讯类别不能为空”。" ValidationGroup="1">不能为空！</asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:TabContainer ID="TabContainer1" runat="server" Visible="false">
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="资讯类别">
            <ContentTemplate>

                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <asp:Button ID="btAddnews" runat="server" Text="新增资讯" OnClick="btPreview_Click" />(*预防苹果手机端资讯内容过长，备用按钮)
                        <br />
                        文章标题：
                        <asp:TextBox ID="tbTitle" runat="server" Width="500px"></asp:TextBox>
                        <br />
                        <br />
                        发布日期：
                        <asp:TextBox ID="tbNoteDate" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbNoteDate" BehaviorID="_content_CalendarExtender1"></asp:CalendarExtender>
                        <br />
                        <br />
                        正文：<FTB:FreeTextBox ID="FreeTextBox1" runat="server" Height="600px" Width="1000px" AllowHtmlMode="False"
                            AutoGenerateToolbarsFromString="True"
                            AutoHideToolbar="True" AutoParseStyles="True" BackColor="158, 190, 245" BaseUrl=""
                            BreakMode="Paragraph" ButtonDownImage="False" ButtonFileExtention="gif" ButtonFolder="Images"
                            ButtonHeight="20" ButtonImagesLocation="InternalResource" ButtonOverImage="False"
                            ButtonPath="" ButtonSet="Office2003" ButtonWidth="21" ClientSideTextChanged=""
                            ConvertHtmlSymbolsToHtmlCodes="False" DesignModeBodyTagCssClass="" DesignModeCss=""
                            DisableIEBackButton="False" DownLevelCols="50" DownlevelMessage="" DownlevelMode="TextArea"
                            DownlevelRows="10" EditorBorderColorDark="Gray" EditorBorderColorLight="Gray"
                            EnableHtmlMode="True" EnableSsl="False" EnableToolbars="True" Focus="False" FormatHtmlTagsToXhtml="True"
                            GutterBackColor="129, 169, 226" GutterBorderColorDark="Gray" GutterBorderColorLight="White"
                            HelperFilesParameters="" HelperFilesPath="" HtmlModeCss="" HtmlModeDefaultsToMonoSpaceFont="True"
                            ImageGalleryPath="~/images/" ImageGalleryUrl="ftb.imagegallery.aspx?rif={0}&amp;cif={0}"
                            InstallationErrorMessage="InlineMessage" JavaScriptLocation="InternalResource"
                            Language="en-US" PasteMode="Default" ReadOnly="False" RemoveScriptNameFromBookmarks="True"
                            RemoveServerNameFromUrls="True" RenderMode="NotSet" ScriptMode="External" ShowTagPath="False"
                            SslUrl="/." StartMode="DesignMode" StripAllScripting="False" SupportFolder="/aspnet_client/FreeTextBox/"
                            TabIndex="-1" TabMode="InsertSpaces" Text="" TextDirection="LeftToRight" ToolbarBackColor="Transparent"
                            ToolbarBackGroundImage="True" ToolbarImagesLocation="InternalResource" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertRule|Cut,Copy,Paste;Undo,Redo,Print">
                        </FTB:FreeTextBox>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        <asp:Button ID="btPreview" runat="server" Text="确定" OnClick="btPreview_Click" ValidationGroup="1" />
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        品名：<asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                        地区：
                        <select id="sheng" class="Material" name="province">
                        </select>
                        <script type="text/javascript">

                            $(function () { initLocation({ sheng_val: "---", shi_val: "成都", xian_val: "<?php echo $v['country']?>", xiang_val: "<?php echo $v['street']?>" }); })

                        </script>
                        报价：<asp:TextBox ID="tbPrice" runat="server"></asp:TextBox>
                        <asp:Button ID="btSure" runat="server" Text="确定" OnClick="btSure_Click" />
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>

</asp:Content>
