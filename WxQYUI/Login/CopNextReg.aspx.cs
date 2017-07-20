using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_CopNextReg : System.Web.UI.Page
{
    LB.BLL.SMS bll_sms = new LB.BLL.SMS();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.BLL.UserTypeInfo bll_userType = new LB.BLL.UserTypeInfo();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["TelNum"] != null)
            {
                string TelNum = Request.QueryString["TelNum"];
                hfTelNum.Value = TelNum;
            }
        }
    }

    protected void btUserNext_Click(object sender, EventArgs e)
    {
        LB.SQLServerDAL.UserInfo user = new LB.SQLServerDAL.UserInfo();
        user = bll_userinfo.GetUserInfoByTelNum(hfTelNum.Value);
        user.PayeeName = tbBankRen.Text;
        //user = bll_userinfo.GetUserInfoByTelNum("13738487153");
        user.RealName = tbRealName.Text;
        MCopInfo.UserId = user.UserId;
        MCopInfo.CopName = tbCopName.Text;
        MCopInfo.BAuthentication = false;
        user.BankName = tbBankInfo.Text;
        user.Account = tbAccount.Text;
        bool Ifiles = false;
        bool Bfiles = false;
        bool Hfiles = false;
        if (this.FileUpload1.HasFile && this.FileUpload2.HasFile && this.FileUpload3.HasFile)
        {
            //获取上传文件的后缀
            String fileExtensionFUI = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
            String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
            //判断文件类型是否符合
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtensionFUI == restrictExtension[1])
                {
                    Ifiles = true;
                }
            }
            //获取上传文件的后缀
            String fileExtensionFUB = System.IO.Path.GetExtension(this.FileUpload2.FileName).ToLower();
            String[] restrictExtension1 = { ".gif", ".jpg", ".bmp", ".png" };
            //判断文件类型是否符合
            for (int i = 0; i < restrictExtension1.Length; i++)
            {
                if (fileExtensionFUB == restrictExtension1[1])
                {
                    Bfiles = true;
                }
            }

            //获取上传文件的后缀
            String fileExtensionFUH = System.IO.Path.GetExtension(this.FileUpload2.FileName).ToLower();
            String[] restrictExtension2 = { ".gif", ".jpg", ".bmp", ".png" };
            //判断文件类型是否符合
            for (int i = 0; i < restrictExtension2.Length; i++)
            {
                if (fileExtensionFUH == restrictExtension2[1])
                {
                    Hfiles = true;
                }
            }
            //调用SaveAs方法实现上传
            if (Ifiles == true && Bfiles == true && Hfiles == true)
            {
                try
                {
                    string filenameI = FileUpload1.PostedFile.FileName;
                    string fileextI = System.IO.Path.GetExtension(filenameI);
                    string newfilenameI = user.MobilePhoneNum + fileextI;
                    this.FileUpload1.SaveAs("E://LvBao//WebUI//IDCard//" + newfilenameI);
                    bll_userinfo.UpdateUserInfo(user);
                    string filenameB = FileUpload2.PostedFile.FileName;
                    string fileextB = System.IO.Path.GetExtension(filenameB);
                    string newfilenameB = MCopInfo.CopName + fileextB;
                    this.FileUpload2.SaveAs("E://LvBao//WebUI//Bizlicense//" + newfilenameB);

                    string filenameH = FileUpload3.PostedFile.FileName;
                    string fileextH = System.IO.Path.GetExtension(filenameH);
                    string newfilenameH = MCopInfo.CopName + fileextH;
                    this.FileUpload2.SaveAs("E://LvBao//WebUI//HWPermit//" + newfilenameH);
                    MCopInfo.Bizlicense = newfilenameB;
                    MCopInfo.HWPermit = newfilenameH;
                    bll_copinfo.NewCopInfo(MCopInfo);
                    Response.Redirect("CopNextReg.aspx#pageRegCompleted");
                }
                catch
                {
                    this.Label1.Text = "文件上传不成功";
                }
            }
            else
            {
                this.Label1.Text = "只能够上传后缀为.gif、 .jpg、 .bmp、.png的文件";
            }
        }
        else
        {
            this.Label1.Text = "上传文件不能为空";
        }

    }
}