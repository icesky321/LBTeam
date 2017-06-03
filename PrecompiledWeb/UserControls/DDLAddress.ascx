<%@ control language="C#" autoeventwireup="true" inherits="Admin_UserControls_DDLAddress, App_Web_wsugraiq" %>
<script type="text/javascript" src="../js/jquery.js" charset="gbk"></script>
<script type="text/javascript" src="../js/GlobalProvinces_main.js" charset="gbk"></script>
<script type="text/javascript" src="../js/GlobalProvinces_extend.js" charset="gbk"></script>
<script type="text/javascript" src="../js/initLocation.js" charset="gbk"></script>
<select id="sheng" class="Material" name="province">
</select>

省
            <select id="shi" class="Material" name="city">
            </select><asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>

市
            <select id="xian" class="Material" name="country">
            </select>
县
            <select id="xiang" class="Material" name="street">
            </select>
镇或街道
    <script type="text/javascript">

        $(function () { initLocation({ sheng_val: "", shi_val: "", xian_val: "<?php echo $v['country']?>", xiang_val: "<?php echo $v['street']?>" }); })

    </script>
