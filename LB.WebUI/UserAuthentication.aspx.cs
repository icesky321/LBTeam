using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAuthentication : System.Web.UI.Page
{
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["UserId"] != null)
            {
                string UserId = Request.QueryString["UserId"];
                hfUserId.Value = UserId;
            }
            else
            {
                //hfUserId.Value = "1";
                Response.Redirect("UserRegister.aspx");
            }
        }
    }

    protected void btUpLoad_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(hfUserId.Value));
        bool files = false;
        if (this.FUIDCard.HasFile)
        {
            //获取上传文件的后缀
            String fileExtensionFUI = System.IO.Path.GetExtension(this.FUIDCard.FileName).ToLower();
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
                    string filenameI = FUIDCard.PostedFile.FileName;
                    //string filenameC = FUChop.PostedFile.FileName;
                    string fileextI = System.IO.Path.GetExtension(filenameI);
                    //string fileextC = System.IO.Path.GetExtension(filenameC);
                    string newfilenameI = MUserInfo.MobilePhoneNum + fileextI;
                    //string newfilenameC = MUserInfo.MobilePhoneNum + fileextC;
                    string pathI = HttpContext.Current.Server.MapPath("~/IDCard/");
                    //string pathC = HttpContext.Current.Server.MapPath("~/Chop/");
                    string savefilenameI = pathI + newfilenameI;
                    //string savefilenameC = pathC + newfilenameC;
                    this.FUIDCard.SaveAs(savefilenameI);
                    //this.FUChop.SaveAs(savefilenameC);
                    this.Image1.ImageUrl = "~/IDCard/" + newfilenameI;
                    //this.Image2.ImageUrl = "~/Chop/" + newfilenameC;
                    this.Label1.Text = "文件上传成功,等待后台审核";
                    //this.Label1.Text += "<br/>";
                    //this.Label1.Text += "<li>" + "原文件路径：" + this.FileUpload1.PostedFile.FileName;
                    //this.Label1.Text += "<br/>";
                    //this.Label1.Text += "<li>" + "文件大小：" + this.FileUpload1.PostedFile.ContentLength + "字节";
                    //this.Label1.Text += "<br/>";
                    //this.Label1.Text += "<li>" + "文件类型：" + this.FileUpload1.PostedFile.ContentType;
                    MUserInfo.BankName = tbBankName.Text;
                    MUserInfo.Account = tbAccount.Text;
                    MUserInfo.IDCard = "~/IDCard/" + newfilenameI;
                    //MUserInfo.Chop = "~/Chop/" + newfilenameC;
                    bll_userinfo.UpdateUserInfo(MUserInfo);
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
    }
}