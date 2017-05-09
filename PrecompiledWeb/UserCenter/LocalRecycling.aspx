<%@ page title="" language="C#" masterpagefile="~/UserCenter/UserCenter.master" autoeventwireup="true" inherits="UserCenter_Supplier_LocalRecycling, App_Web_pcb3s3zr" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="section--header" style="text-align: center">
                <p class="section--description">
                    <h1>当地回收业务员</h1>
                </p>
            </div>
            <hr />
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <ul>
                        <li>1111
                        </li>
                    </ul>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <ul>
                        <li>dsfdsafasf
                        </li>
                    </ul>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>

