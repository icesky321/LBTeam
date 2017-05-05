<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Test, App_Web_iaubwtqu" theme="Default" %>


<%@ Register Src="UserControls/DDLAddress.ascx" TagName="DDLAddress" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <link href="css/lanrenzhijia.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/lanrenzhijia.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <%--这个Label1用来显示验证码--%>
        <label>验证码：</label><asp:Label ID="Label1" runat="server" Text="Label" Style="background: red; border: 1px solid yellow"></asp:Label>

        <%--这个button2用来更换新的验证码--%>
        <asp:Button ID="Button2" runat="server" Text="看不清" OnClick="Button2_Click" /><br />

        <%--这个TextBox用来让用户输入验证码--%>
        <asp:TextBox ID="TextBox1" runat="server" value="请输入验证码"></asp:TextBox>

        <%--提交验证码--%>
        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click"
            Style="height: 21px" />

        <%--这个Label用来提示验证码是否错误--%>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

        <asp:Timer ID="Timer1" runat="server" Enabled="true" Interval="500000" OnTick="Timer1_Tick">
        </asp:Timer>
        <br />
        <uc1:DDLAddress ID="DDLAddress1" runat="server" />
<%--        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>

                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
<%--            </ContentTemplate>
        </asp:UpdatePanel>--%>
        <select id="sheng1" class="Material" name="province">
</select>
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Material"></asp:DropDownList>
    </div>

  <div class="box">
    <h4>type:'none'</h4>
    <div id="myFocus1">
      <div class="loading"><span>请稍候...</span></div>
      <!--载入画面-->
      <ul class="btn">
        <!--标题-->
        <li>朋友</li>
        <li>兄弟</li>
        <li>亲人</li>
        <li>情人</li>
      </ul>
      <ul class="cont">
        <!--内容-->
        <li>
          <p>朋友朋友朋友</p>
        </li>
        <li>
          <p>兄弟兄弟兄弟</p>
        </li>
        <li>
          <p>亲人亲人亲人</p>
        </li>
        <li>
          <p>情人情人情人</p>
        </li>
      </ul>
    </div>
  </div>

</asp:Content>

