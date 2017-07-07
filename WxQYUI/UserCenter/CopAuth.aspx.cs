using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_CopAuth : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo user = new LB.SQLServerDAL.UserInfo();
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        if (User.Identity.IsAuthenticated)
        {
            string userName = User.Identity.Name;
            user = bll_user.GetUserInfoByTelNum(userName);
            if (!bll_copinfo.ExistUseId(user.UserId))
            {
                ltlRealName.Text = "未设置公司名称";
            }
            else
            {
                MCopInfo = bll_copinfo.GetCopInfoeByUserId(user.UserId);
                ltlRealName.Text = MCopInfo.CopName;
                tbRealName.Text = MCopInfo.CopName;
                if (MCopInfo.BAuthentication == true)
                {
                    BAuthenticationLabel.Text = Aunth1.msg;
                    btBAuthentication.Visible = false;
                }
                else
                {
                    BAuthenticationLabel.Text = UnAunth1.msg;
                }
                if (MCopInfo.HWAuthentication == true)
                {
                    HWAuthenticationLable.Text = Aunth1.msg;
                    btHWAuthentication.Visible = false;
                }
                else
                {
                    HWAuthenticationLable.Text = UnAunth1.msg;
                }
            }


        }
    }

    protected void btBAuthentication_Click(object sender, EventArgs e)
    {
        MultiView2.SetActiveView(viewEditBizlicense);
    }

    protected void btBizlicenseAlter_Click(object sender, EventArgs e)
    {
        user = bll_user.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
        MCopInfo = bll_copinfo.GetCopInfoeByUserId(user.UserId);
        bool files = false;
        if (this.FileUpload1.HasFile)
        {
            //获取上传文件的后缀
            String fileExtensionFUB = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
            String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
            //判断文件类型是否符合
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtensionFUB == restrictExtension[1])
                {
                    files = true;
                }
            }
            //调用SaveAs方法实现上传
            if (files == true)
            {
                try
                {
                    string filenameB = FileUpload1.PostedFile.FileName;
                    string fileextB = System.IO.Path.GetExtension(filenameB);
                    string newfilenameB = MCopInfo.CopName + fileextB;
                    //string pathB = HttpContext.Current.Server.MapPath("~/Bizlicense/");
                    //string savefilenameB = pathB + newfilenameB;
                    this.FileUpload1.SaveAs("E://LvBao//WebUI//Bizlicense//" + newfilenameB);
                    this.Image1.ImageUrl = "E://LvBao//WebUI//Bizlicense//" + newfilenameB;
                    MCopInfo.Bizlicense = newfilenameB;
                    //bll_userinfo.UpdateUserInfo(MUserInfo);
                    bll_copinfo.UpdateCopInfo(MCopInfo);
                    this.lbmsg1.Text = "文件上传成功,等待后台审核";
                }
                catch
                {
                    this.lbmsg1.Text = "文件上传不成功";
                }
            }
            else
            {
                this.lbmsg1.Text = "只能够上传后缀为.gif、 .jpg、 .bmp、.png的文件夹";
            }
        }
        else
        {
            this.lbmsg1.Text = "上传文件不能为空";
        }
        MultiView2.SetActiveView(viewShowBizlicense);
    }

    protected void btHWAuthentication_Click(object sender, EventArgs e)
    {
        MultiView3.SetActiveView(viewEditHWPermit);
    }

    protected void btHWPermitAlter_Click(object sender, EventArgs e)
    {
        user = bll_user.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
        MCopInfo = bll_copinfo.GetCopInfoeByUserId(user.UserId);
        bool files = false;
        if (this.FileUpload2.HasFile)
        {
            //获取上传文件的后缀
            String fileExtensionFUH = System.IO.Path.GetExtension(this.FileUpload2.FileName).ToLower();
            String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
            //判断文件类型是否符合
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtensionFUH == restrictExtension[1])
                {
                    files = true;
                }
            }
            //调用SaveAs方法实现上传
            if (files == true)
            {
                try
                {
                    string filenameH = FileUpload2.PostedFile.FileName;
                    string fileextH = System.IO.Path.GetExtension(filenameH);
                    string newfilenameH = MCopInfo.CopName + fileextH;
                    //string pathB = HttpContext.Current.Server.MapPath("~/Bizlicense/");
                    //string savefilenameB = pathB + newfilenameB;
                    this.FileUpload2.SaveAs("E://LvBao//WebUI//HWPermit//" + newfilenameH);
                    this.Image1.ImageUrl = "E://LvBao//WebUI//HWPermit//" + newfilenameH;
                    MCopInfo.HWPermit = newfilenameH;
                    bll_copinfo.UpdateCopInfo(MCopInfo);
                    this.lbmsg2.Text = "文件上传成功,等待后台审核";
                }
                catch
                {
                    this.lbmsg2.Text = "文件上传不成功";
                }
            }
            else
            {
                this.lbmsg2.Text = "只能够上传后缀为.gif、 .jpg、 .bmp、.png的文件夹";
            }
        }
        else
        {
            this.lbmsg2.Text = "上传文件不能为空";
        }
        MultiView3.SetActiveView(viewShowHWPermit);
    }

    protected void btnEditRealName_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(viewEditRealName);
    }

    protected void btnSaveRealName_Click(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            user = bll_user.GetUserInfoByTelNum(User.Identity.Name);
            if (!bll_copinfo.ExistUseId(user.UserId))
            {
                MCopInfo.CopName = tbRealName.Text;
                MCopInfo.UserId = bll_user.GetUserInfoByTelNum(User.Identity.Name).UserId;
                MCopInfo.BAuthentication = false;
                MCopInfo.HWAuthentication = false;
                bll_copinfo.NewCopInfo(MCopInfo);

            }
            else
            {
                MCopInfo = bll_copinfo.GetCopInfoeByUserId(bll_user.GetUserInfoByTelNum(User.Identity.Name).UserId);
                MCopInfo.CopName = tbRealName.Text;
                bll_copinfo.UpdateCopInfo(MCopInfo);
            }

        }
        Init_Load();
        MultiView1.SetActiveView(viewRealName);
    }
}