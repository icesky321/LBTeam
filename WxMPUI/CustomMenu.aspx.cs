using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities.Menu;
using System.Configuration;


public partial class CustomMenu : System.Web.UI.Page
{
    LB.WeixinMP.BaseAccessTokenManage bat = new LB.WeixinMP.BaseAccessTokenManage();
    string appId = string.Empty;
    string appSecret = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void CustomizeMenu()
    {
        if (ConfigurationManager.AppSettings["AppId"] != null)
        {
            appId = ConfigurationManager.AppSettings["AppId"];
            appSecret = ConfigurationManager.AppSettings["AppSecret"];
        }

        var accessToken = bat.AccessToken;


        ButtonGroup bg = new ButtonGroup();

        //单击
        //bg.button.Add(new SingleClickButton()
        //{
        //    name = "单击测试",
        //    key = "OneClick",
        //    type = Senparc.Weixin.MP.ButtonType.click.ToString(),//默认已经设为此类型，这里只作为演示
        //});
        var subButton1 = new SubButton()
        {
            name = "回收业务"
        };
        subButton1.sub_button.Add(new SingleViewButton()
        {
            url = "http://weixin.lvbao111.com/WeixinMP/TodayQuotation.aspx",
            name = "查询回收价格"
        });
        subButton1.sub_button.Add(new SingleViewButton()
        {
            url = "http://weixin.lvbao111.com/weixinQY/MP/CreateLeads.aspx",
            name = "我要卖货"
        });
        subButton1.sub_button.Add(new SingleViewButton()
        {
            url = "http://weixin.lvbao111.com/WeixinQY/MP/MySellInfos.aspx",
            name = "我的出售"
        });
        subButton1.sub_button.Add(new SingleViewButton()
        {
            url = "http://weixin.lvbao111.com/weixinQY/MP/TodayNews.aspx",
            name = "今日资讯"
        });
        //subButton1.sub_button.Add(new SingleViewButton()
        //{
        //    url = "http://weixin.lvbao111.com/weixinMP/TodayQuotation.aspx",
        //    name = "授权绑定"
        //});

        bg.button.Add(subButton1);



        // 二级菜单
        //var subButton = new SubButton()
        //{
        //    name = "二级菜单"
        //};
        //subButton.sub_button.Add(new SingleClickButton()
        //{
        //    key = "SubClickRoot_Text",
        //    name = "返回文本"
        //});
        //subButton.sub_button.Add(new SingleClickButton()
        //{
        //    key = "SubClickRoot_News",
        //    name = "返回图文"
        //});
        //subButton.sub_button.Add(new SingleClickButton()
        //{
        //    key = "SubClickRoot_Music",
        //    name = "返回音乐"
        //});
        //subButton.sub_button.Add(new SingleViewButton()
        //{
        //    url = "http://www.tiyigroup.com",
        //    name = "公司办公平台"
        //});
        //subButton.sub_button.Add(new SingleViewButton()
        //{
        //    url = "http://www.tiyigroup.com/weixin/Default.aspx",
        //    name = "公司微网站"
        //});
        //bg.button.Add(subButton);
        var subButton2 = new SubButton()
        {
            name = "我要加盟"
        };
        subButton2.sub_button.Add(new SingleViewButton()
        {
            url = "http://weixin.lvbao111.com/WeixinQY/Login/CF_QuickReg.aspx",
            name = "我是产废单位"
        });
        subButton2.sub_button.Add(new SingleViewButton()
        {
            url = "http://weixin.lvbao111.com/WeixinQY/Login/Register.aspx?UserTypeId=2",
            name = "我是回收公司"
        });
        subButton2.sub_button.Add(new SingleViewButton()
        {
            name = "我是冶炼厂",
            url = "http://weixin.lvbao111.com/WeixinQY/Login/Register.aspx?UserTypeId=3"
        });

        subButton2.sub_button.Add(new SingleViewButton()
        {
            name = "我是回收员",
            url = "http://weixin.lvbao111.com/WeixinQY/Login/Register.aspx?UserTypeId=5"
        });
        bg.button.Add(subButton2);


        //二级菜单
        var subButton3 = new SubButton()
        {
            name = "我"
        };

        subButton3.sub_button.Add(new SingleViewButton()
        {
            name = "个人中心",
            url = "http://weixin.lvbao111.com/WeixinQY/UserCenter/uc_cfdw.aspx"
        });
        subButton3.sub_button.Add(new SingleViewButton()
        {
            name = "我的消息",
            url = "http://weixin.lvbao111.com/WeixinQY/Login/Register.aspx"
        });
        subButton3.sub_button.Add(new SingleViewButton()
        {
            name = "联系我们",
            url = "http://weixin.lvbao111.com/WeixinQY/ljlb/Default.aspx#page3"
        });
        subButton3.sub_button.Add(new SingleViewButton()
        {
            name = "常见问题",
            url = "http://weixin.lvbao111.com/WeixinQY/ljlb/cjwt.aspx"
        });
        subButton3.sub_button.Add(new SingleViewButton()
        {
            name = "了解绿宝",
            url = "http://weixin.lvbao111.com/WeixinQY/ljlb/Default.aspx"
        });
        bg.button.Add(subButton3);

        var result = CommonApi.CreateMenu(accessToken, bg);
    }


    protected void btnCreateMenu_Click(object sender, EventArgs e)
    {
        CustomizeMenu();
        lbMsg.Text = "菜单创建成功";
    }
}