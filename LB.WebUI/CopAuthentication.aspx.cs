using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LB;

public partial class CopAuthentication : System.Web.UI.Page
{
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    LB.BLL.UserInfo bll_userinfo = new LB.BLL.UserInfo();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["CopId"] != null)
            {
                string CopId = Request.QueryString["CopId"];
                HFCopId.Value = CopId;
            }
            else
            {
                //HFCopId.Value = "1";
                Response.Redirect("CopRegister.aspx");
            }

        }
    }

    protected void btUpLoad_Click(object sender, EventArgs e)
    {
        MCopInfo = bll_copinfo.GetCopInfoeById(Convert.ToInt32(HFCopId.Value));
        MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(MCopInfo.UserId));
        bool files = false;
        if (this.FUBizlicense.HasFile && this.FUChop.HasFile && this.FUHWPermit.HasFile && this.FUIDCard.HasFile)
        {
            //获取上传文件的后缀
            String fileExtensionFUB = System.IO.Path.GetExtension(this.FUBizlicense.FileName).ToLower();
            String fileExtensionFUC = System.IO.Path.GetExtension(this.FUChop.FileName).ToLower();
            String fileExtensionFUH = System.IO.Path.GetExtension(this.FUHWPermit.FileName).ToLower();
            String fileExtensionFUI = System.IO.Path.GetExtension(this.FUIDCard.FileName).ToLower();
            String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
            //判断文件类型是否符合
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtensionFUB == restrictExtension[1] && fileExtensionFUC== restrictExtension[1] && fileExtensionFUH== restrictExtension[1] && fileExtensionFUI== restrictExtension[1])
                {
                    files = true;
                }
            }
            //调用SaveAs方法实现上传
            if (files == true)
            {
                try
                {

                    string filenameB = FUBizlicense.PostedFile.FileName;
                    string filenameC = FUChop.PostedFile.FileName;
                    string filenameH = FUHWPermit.PostedFile.FileName;
                    string filenameI = FUIDCard.PostedFile.FileName;
                    string fileextB = System.IO.Path.GetExtension(filenameB);
                    string fileextC = System.IO.Path.GetExtension(filenameC);
                    string fileextH = System.IO.Path.GetExtension(filenameH);
                    string fileextI = System.IO.Path.GetExtension(filenameI);
                    string newfilenameB = MCopInfo.CopName + fileextB;
                    string newfilenameC = MCopInfo.CopName + fileextC;
                    string newfilenameH = MCopInfo.CopName + fileextH;
                    string newfilenameI = MCopInfo.CopName + fileextI;
                    string pathB = HttpContext.Current.Server.MapPath("~/Bizlicense/");
                    string pathC = HttpContext.Current.Server.MapPath("~/Chop/");
                    string pathH = HttpContext.Current.Server.MapPath("~/HWPermit/");
                    string pathI = HttpContext.Current.Server.MapPath("~/IDCard/");
                    string savefilenameB = pathB + newfilenameB;
                    string savefilenameC = pathC + newfilenameC;
                    string savefilenameH = pathH + newfilenameH;
                    string savefilenameI = pathI + newfilenameI;
                    this.FUBizlicense.SaveAs(savefilenameB);
                    this.FUChop.SaveAs(savefilenameC);
                    this.FUHWPermit.SaveAs(savefilenameH);
                    this.FUIDCard.SaveAs(savefilenameI);
                    this.Image1.ImageUrl = "~/Bizlicense/" + newfilenameB;
                    this.Image2.ImageUrl = "~/Chop/" + newfilenameC;
                    this.Image3.ImageUrl = "~/HWPermit/" + newfilenameH;
                    this.Image4.ImageUrl = "~/IDCard/" + newfilenameI;
                    this.Label1.Text = "文件上传成功,等待后台审核";
                    //this.Label1.Text += "<br/>";
                    //this.Label1.Text += "<li>" + "原文件路径：" + this.FileUpload1.PostedFile.FileName;
                    //this.Label1.Text += "<br/>";
                    //this.Label1.Text += "<li>" + "文件大小：" + this.FileUpload1.PostedFile.ContentLength + "字节";
                    //this.Label1.Text += "<br/>";
                    //this.Label1.Text += "<li>" + "文件类型：" + this.FileUpload1.PostedFile.ContentType;
                    MUserInfo.BankName = tbBankName.Text;
                    MUserInfo.Account = tbAccount.Text;
                    MCopInfo.Bizlicense= "~/Bizlicense/" + newfilenameB;
                    MUserInfo.Chop= "~/Chop/" + newfilenameC;
                    MCopInfo.HWPermit = "~/HWPermit/" + newfilenameH;
                    MUserInfo.IDCard= "~/IDCard/" + newfilenameI;
                    bll_userinfo.UpdateUserInfo(MUserInfo);
                    bll_copinfo.UpdateCopInfo(MCopInfo);
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