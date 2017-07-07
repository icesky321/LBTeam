using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_EditRealName : System.Web.UI.Page
{
    LB.BLL.UserManage bll_user = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);
        if (user == null)
            return;

        if (string.IsNullOrEmpty(user.RealName))
            ltlRealName.Text = "未实名";
        else
        {
            ltlRealName.Text = user.RealName;
            tbRealName.Text = user.RealName;
        }

        if (string.IsNullOrEmpty(user.UserName))
            ltlNiChen.Text = "未设置";
        else
        {
            ltlNiChen.Text = user.UserName;
            tbNiChen.Text = user.UserName;
        }

        if (string.IsNullOrEmpty(user.BankName))
            lbBankName.Text = "未设置";
        else
        {
            lbBankName.Text = user.BankName;
            tbBankInfo.Text = user.BankName;
        }
        if (string.IsNullOrEmpty(user.Account))
            lbAccount.Text = "未设置";
        else
        {
            lbAccount.Text = user.Account;
            tbAccount.Text = user.Account;
        }
        tbRealName.Text = user.RealName;
        if (user.IDAuthentication == true)
        {
            IDAuthenticationLabel.Text = Aunth1.msg;
            btAuthentication.Visible = false;
        }
        else
        {
            IDAuthenticationLabel.Text = UnAunth1.msg;
        }
        if (user.Audit == true)//当保证金交好审核通过后，全部的修改按钮都要隐藏，即不能修改
        {
            btnEditRealName.Visible = false;
            btAuthentication.Visible = false;
        }
    }

    protected void btnEditRealName_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(viewEditRealName);
    }

    protected void btnSaveRealName_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);
        if (user == null)
            return;


        string realName = tbRealName.Text;
        if (!string.IsNullOrEmpty(realName))
        {
            user.RealName = realName;
            bll_user.UpdateUserInfo(user);
        }

        Init_Load();

        MultiView1.SetActiveView(viewRealName);
    }

    protected void btnEditNiChen_Click(object sender, EventArgs e)
    {
        MultiView2.SetActiveView(viewEditNiChen);
    }

    protected void btnSaveNiChen_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);
        if (user == null)
            return;


        string nichen = tbNiChen.Text;
        if (!string.IsNullOrEmpty(nichen))
        {
            user.UserName = nichen;
            bll_user.UpdateUserInfo(user);
        }

        Init_Load();

        MultiView2.SetActiveView(viewShowNiChen);
    }

    protected void btUserAlter_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_user.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        bool files = false;
        if (this.FileUpload1.HasFile)
        {
            //获取上传文件的后缀
            String fileExtensionFUI = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
            String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
            //判断文件类型是否符合
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtensionFUI == restrictExtension[1])
                {
                    files = true;
                }
            }
            //调用SaveAs方法实现上传
            if (files == true)
            {
                try
                {
                    string filenameI = FileUpload1.PostedFile.FileName;
                    string fileextI = System.IO.Path.GetExtension(filenameI);
                    string newfilenameI = MUserInfo.MobilePhoneNum + fileextI;
                    //string pathI = HttpContext.Current.Server.MapPath(@"E:\LvBao\WebUI\IDCard\");
                    //string savefilenameI = pathI + newfilenameI;
                    this.FileUpload1.SaveAs("E://LvBao//WebUI//IDCard//" + newfilenameI);
                    
                    this.Image1.ImageUrl = "E://LvBao//WebUI//IDCard//" + newfilenameI;
                    this.Label1.Text = "文件上传成功,等待后台审核";
                    MUserInfo.IDCard = newfilenameI;
                    bll_user.UpdateUserInfo(MUserInfo);
                }
                catch
                {
                    this.Label1.Text = "文件上传不成功";
                }
            }
            else
            {
                this.Label1.Text = "只能够上传后缀为.gif、 .jpg、 .bmp、.png的文件夹";
            }
        }
        else
        {
            this.Label1.Text = "上传文件不能为空";
        }
        MultiView3.SetActiveView(viewShowAuthentication);
    }

    protected void btAuthentication_Click(object sender, EventArgs e)
    {
        MultiView3.SetActiveView(viewEditAuthentication);
    }

    protected void btnEditBankInfo_Click(object sender, EventArgs e)
    {
        MultiView4.SetActiveView(viewEditBankInfo);
    }

    protected void btSaveBankInfo_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_user.GetUserInfoByTelNum(userName);
        if (user == null)
            return;


        string bankname = tbBankInfo.Text;
        string account = tbAccount.Text;
        if (!string.IsNullOrEmpty(bankname)&& !string.IsNullOrEmpty(account))
        {
            user.BankName = bankname;
            user.Account = account;
            bll_user.UpdateUserInfo(user);
        }

        Init_Load();

        MultiView4.SetActiveView(viewShwoBankInfo);
    }
}