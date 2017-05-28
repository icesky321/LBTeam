<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Test1, App_Web_r1xdel2n" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function g_demo_fun(demo_number) {
            var g_demo = document.getElementById(demo_number);//绑定滚动标签  
            var cp_outtime = 500;//设置间隔多少时间刷新  
            var g_Number = g_demo.innerHTML;//复制标签值  
            var g_Number_min = g_Number - 53;
            console.log(g_Number_min);

            function Gundong() {

                if (g_Number_min < g_Number) {
                    g_Number_min = g_Number_min + 3;
                    g_demo.innerHTML = g_Number_min;
                }
                else if (g_Number_min >= g_Number) {
                    g_Number_min = g_Number_min - 16;
                    cp_outtime = 50;
                    console.log("==" + g_Number_min + "cp_outtime=" + cp_outtime);
                }
            }
            var MyMar = setInterval(Gundong, cp_outtime);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="demo1">
        1000  
    </div>
    <script type="text/javascript">
        g_demo_fun("demo1");
    </script>

    <div id="demo2">
        1880  
    </div>
    <script type="text/javascript">
        g_demo_fun("demo2");
    </script>


    <div id="demo3">
        880  
    </div>
    <script type="text/javascript">
        g_demo_fun("demo3");
    </script>
</asp:Content>

