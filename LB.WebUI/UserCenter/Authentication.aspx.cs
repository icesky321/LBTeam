﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_Authentication : System.Web.UI.Page
{
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.CopInfo bll_copinfo = new LB.BLL.CopInfo();
    LB.SQLServerDAL.CopInfo MCopInfo = new LB.SQLServerDAL.CopInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { UserBind(); }

    }

    void UserBind()
    {
        if (Request.IsAuthenticated)
        {
            MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
            MCopInfo = bll_copinfo.GetCopInfoeByUserId(MUserInfo.UserId);
            if (bll_copinfo.ExistUseId(MUserInfo.UserId))
            {
                MultiView1.ActiveViewIndex = 1;
                MCopInfo = bll_copinfo.GetCopInfoeByUserId(MUserInfo.UserId);
                Image2.ImageUrl = "../IDCard/"+ MUserInfo.IDCard;
                Image3.ImageUrl = "../Bizlicense/" + MCopInfo.Bizlicense;
                Image4.ImageUrl = "../HWPermit/" + MCopInfo.HWPermit;
                if (MCopInfo.BAuthentication == false || MCopInfo.HWAuthentication == false)
                {
                    btCopAlter.Visible = true;
                    FUIDCard.Visible = true;
                    FUBizlicense.Visible = true;
                    FUHWPermit.Visible = true;
                }
                else
                {
                    btCopAlter.Visible = false;
                    FUIDCard.Visible = false;
                    FUBizlicense.Visible = false;
                    FUHWPermit.Visible = false;
                }
            }
            else
            {
                MultiView1.ActiveViewIndex = 0;
                Image1.ImageUrl = "../IDCard/" + MUserInfo.IDCard;
                if (MUserInfo.IDAuthentication == false)
                {
                    btUserAlter.Visible = true;
                    FileUpload1.Visible = true;
                }
                else
                {

                    btUserAlter.Visible = false;
                    FileUpload1.Visible = false;
                }
            }

        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }

    protected void btUserAlter_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
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
                    string pathI = HttpContext.Current.Server.MapPath("~/IDCard/");
                    string savefilenameI = pathI + newfilenameI;
                    this.FileUpload1.SaveAs(savefilenameI);
                    this.Image1.ImageUrl = "~/IDCard/" + newfilenameI;
                    this.Label1.Text = "文件上传成功,等待后台审核";
                    MUserInfo.IDCard = newfilenameI;
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
        else
        {
            this.Label1.Text = "上传文件不能为空";
        }
        UserBind();
    }

    protected void btCopAlter_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name);
        MCopInfo = bll_copinfo.GetCopInfoeByUserId(Convert.ToInt32(MUserInfo.UserId));
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
                    string fileextI = System.IO.Path.GetExtension(filenameI);
                    string newfilenameI = MUserInfo.MobilePhoneNum + fileextI;
                    string pathI = HttpContext.Current.Server.MapPath("~/IDCard/");
                    string savefilenameI = pathI + newfilenameI;
                    this.FUIDCard.SaveAs(savefilenameI);
                    this.Image3.ImageUrl = "~/IDCard/" + newfilenameI;
                    this.Label1.Text = "文件上传成功,等待后台审核";
                    MUserInfo.IDCard = newfilenameI;
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
        else if (this.FUBizlicense.HasFile)
        {
            //获取上传文件的后缀
            String fileExtensionFUB = System.IO.Path.GetExtension(this.FUBizlicense.FileName).ToLower();
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
                    string filenameB = FUBizlicense.PostedFile.FileName;
                    string fileextB = System.IO.Path.GetExtension(filenameB);
                    string newfilenameB = MCopInfo.CopName + fileextB;
                    string pathB = HttpContext.Current.Server.MapPath("~/Bizlicense/");
                    string savefilenameB = pathB + newfilenameB;
                    this.FUBizlicense.SaveAs(savefilenameB);
                    this.Image1.ImageUrl = "~/Bizlicense/" + newfilenameB;
                    MCopInfo.Bizlicense = newfilenameB;
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
        else if (this.FUHWPermit.HasFile)
        {
            //获取上传文件的后缀
            String fileExtensionFUH = System.IO.Path.GetExtension(this.FUHWPermit.FileName).ToLower();
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
                    string filenameH = FUHWPermit.PostedFile.FileName;
                    string fileextH = System.IO.Path.GetExtension(filenameH);
                    string newfilenameH = MCopInfo.CopName + fileextH;
                    string pathH = HttpContext.Current.Server.MapPath("~/HWPermit/");
                    string savefilenameH = pathH + newfilenameH;
                    this.FUHWPermit.SaveAs(savefilenameH);
                    this.Image2.ImageUrl = "~/HWPermit/" + newfilenameH;
                    MCopInfo.HWPermit = newfilenameH;

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
            this.Label1.Text = "文件上传不能为空";
        }
        bll_userinfo.UpdateUserInfo(MUserInfo);
        bll_copinfo.UpdateCopInfo(MCopInfo);
        UserBind();
    }


}