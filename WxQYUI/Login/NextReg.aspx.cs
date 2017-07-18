using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login_NextReg : System.Web.UI.Page
{
    LB.BLL.SMS bll_sms = new LB.BLL.SMS();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.BLL.UserTypeInfo bll_userType = new LB.BLL.UserTypeInfo();
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
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
        //user = bll_userinfo.GetUserInfoByTelNum("13738487153");
        user.RealName = tbRealName.Text;
        user.UserName = tbNiChen.Text;
        user.BankName = tbBankInfo.Text;
        user.Account = tbAccount.Text;
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
                    string newfilenameI = user.MobilePhoneNum + fileextI;
                    //string pathI = HttpContext.Current.Server.MapPath(@"E:\LvBao\WebUI\IDCard\");
                    //string savefilenameI = pathI + newfilenameI;
                    this.FileUpload1.SaveAs("E://LvBao//WebUI//IDCard//" + newfilenameI);

                    this.Image1.ImageUrl = "E://LvBao//WebUI//IDCard//" + newfilenameI;
                    user.IDCard = newfilenameI;
                    bll_userinfo.UpdateUserInfo(user);
                    Response.Redirect("NextReg.aspx#pageRegCompleted");
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
    }

}