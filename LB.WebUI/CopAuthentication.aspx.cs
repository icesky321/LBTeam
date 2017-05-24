﻿using System;
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
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["UserId"] != null)
            {
                string UserId = Request.QueryString["UserId"];
                HFUserId.Value = UserId;
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
        MCopInfo = bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(HFUserId.Value));
        MUserInfo = bll_userinfo.GetUserInfoByUserId(Convert.ToInt32(HFUserId.Value));
        bool files = false;
        if (this.FUIDCard.HasFile && this.FUBizlicense.HasFile && this.FUHWPermit.HasFile)
        {
            //获取上传文件的后缀
            String fileExtensionFUI = System.IO.Path.GetExtension(this.FUIDCard.FileName).ToLower();
            String fileExtensionFUB = System.IO.Path.GetExtension(this.FUBizlicense.FileName).ToLower();
            String fileExtensionFUH = System.IO.Path.GetExtension(this.FUHWPermit.FileName).ToLower();
            String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
            //判断文件类型是否符合
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtensionFUI == restrictExtension[1] && fileExtensionFUB == restrictExtension[1] && fileExtensionFUH== restrictExtension[1])
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
                    string filenameB = FUBizlicense.PostedFile.FileName;
                    string filenameH = FUHWPermit.PostedFile.FileName;
                    string fileextI = System.IO.Path.GetExtension(filenameI);
                    string fileextB = System.IO.Path.GetExtension(filenameB);
                    string fileextH = System.IO.Path.GetExtension(filenameH);
                    string newfilenameI = MUserInfo.MobilePhoneNum + fileextI;
                    string newfilenameB = MCopInfo.CopName + fileextB;
                    string newfilenameH = MCopInfo.CopName + fileextH;
                    string pathI = HttpContext.Current.Server.MapPath("~/IDCard/");
                    string pathB = HttpContext.Current.Server.MapPath("~/Bizlicense/");
                    string pathH = HttpContext.Current.Server.MapPath("~/HWPermit/");
                    string savefilenameI = pathI + newfilenameI;
                    string savefilenameB = pathB + newfilenameB;
                    string savefilenameH = pathH + newfilenameH;
                    this.FUIDCard.SaveAs(savefilenameI);
                    this.FUBizlicense.SaveAs(savefilenameB);
                    this.FUHWPermit.SaveAs(savefilenameH);
                    this.Image3.ImageUrl = "~/IDCard/" + newfilenameI;
                    this.Image1.ImageUrl = "~/Bizlicense/" + newfilenameB;
                    this.Image2.ImageUrl = "~/HWPermit/" + newfilenameH;
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
                    MCopInfo.HWPermit = "~/HWPermit/" + newfilenameH;
                    MUserInfo.IDCard = "~/IDCard/" + newfilenameI;
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
        Response.Redirect("WaitingForAudit.aspx");
    }
}