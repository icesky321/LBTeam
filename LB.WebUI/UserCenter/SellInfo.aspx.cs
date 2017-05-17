using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class SellInfo : System.Web.UI.Page
{
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.Tradeleads MTradeleads = new LB.SQLServerDAL.Tradeleads();
    LB.BLL.Tradeleads bll_tradeleads = new LB.BLL.Tradeleads();
    LB.BLL.TSInfo bll_tsinfo = new LB.BLL.TSInfo();
    LB.BLL.UnitInfo bll_unitinfo = new LB.BLL.UnitInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillTSType();
            FillUnitType();
            if (Request.IsAuthenticated)
            {
                if (MUserInfo.UserTypeId == 0)
                {
                    Response.Redirect("UpdateRole.aspx?UserId=" + MUserInfo.UserId.ToString());
                }
                else
                {
                    string telNum = HttpContext.Current.User.Identity.Name;
                    hfUserTelNum.Value = telNum;
                    MUserInfo = bll_userinfo.GetUserInfoByTelNum(telNum);
                    lbTelNum.Text = telNum;
                    lbContact.Text = MUserInfo.UserName;
                    hfUserId.Value = MUserInfo.UserId.ToString();
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }

        }
    }
    void FillTSType()
    {
        IQueryable<LB.SQLServerDAL.TSInfo> tsinfos = bll_tsinfo.GetTSInfo();
        foreach (LB.SQLServerDAL.TSInfo TSInfo in tsinfos)
        {
            ddlTS.Items.Add(new ListItem(TSInfo.TSName, TSInfo.TSId.ToString()));
        }
        ddlTS.Items.Insert(0, "");
    }

    void FillUnitType()
    {
        IQueryable<LB.SQLServerDAL.UnitInfo> unitinfos = bll_unitinfo.GetUnitInfo();
        foreach (LB.SQLServerDAL.UnitInfo UnitInfo in unitinfos)
        {
            ddlUnit.Items.Add(new ListItem(UnitInfo.UnitName, UnitInfo.UnitId.ToString()));
        }
        ddlUnit.Items.Insert(0, "");
    }

    protected void btSell_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(hfUserTelNum.Value);
        bool files = false;
        if (this.FileUpload1.HasFile)
        {
            //获取上传文件的后缀
            String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
            String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
            //判断文件类型是否符合
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtension == restrictExtension[1])
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
                    string newfilenameI = System.DateTime.Now.ToString("yyyyMMddHHmmss") + MUserInfo.MobilePhoneNum + fileextI;
                    string pathI = HttpContext.Current.Server.MapPath("~/PicResource/");
                    string savefilenameI = pathI + newfilenameI;
                    this.FileUpload1.SaveAs(savefilenameI);
                    hfFilePath.Value = "~/PicResource/" + newfilenameI;
                   
                    MTradeleads.PicPath = hfFilePath.Value;

                }
                catch
                {
                    //this.Label1.Text = "文件上传不成功";
                }
            }
            else
            {
                //this.Label1.Text = "只能够上传后缀为.gif、 .jpg、 .bmp、.png的文件夹";
            }
        }
        MTradeleads.Title = tbTitle.Text;
        MTradeleads.Province = DDLAddress1.province;
        MTradeleads.City = DDLAddress1.city;
        MTradeleads.Town = DDLAddress1.country;
        MTradeleads.Street = DDLAddress1.street;
        MTradeleads.Volume = tbTotalNum.Text;
        MTradeleads.DetailInfo = tbDetail.Text;
        MTradeleads.Price = tbPrice.Text;
        MTradeleads.UserId = Convert.ToInt32(hfUserId.Value);
        MTradeleads.TSId = Convert.ToInt32(ddlTS.SelectedItem.Value);
        MTradeleads.UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
        MTradeleads.TId = 2;
        MTradeleads.Hits = 0;
        MTradeleads.ReleaseDate = System.DateTime.Now;
        MTradeleads.Audit = false;
        MTradeleads.AuditDatetime = Convert.ToDateTime("1900-1-1");
        bll_tradeleads.NewTradeleads(MTradeleads);
        Response.Redirect("../WaitingForAudit.aspx");
    }
}