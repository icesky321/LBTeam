using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TradeleadsDetail : System.Web.UI.Page
{
    LB.BLL.Tradeleads bll_tradeleads = new LB.BLL.Tradeleads();
    LB.Model.TradeleadsModel MTradeleadsModel = new LB.Model.TradeleadsModel();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["infoId"] != null)
            {
                int infoId = Convert.ToInt32(Request.QueryString["infoId"]);
                MTradeleadsModel = bll_tradeleads.GetTradeleadsInfoModelByinfoId(infoId);
                if (Request.IsAuthenticated)
                {
                    if (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("InfoManage") || HttpContext.Current.User.IsInRole("UserManage"))
                    {
                        lbTitle.Text = MTradeleadsModel.Title;
                        lbDetail.Text = MTradeleadsModel.DetailInfo;
                        lbAddress.Text = MTradeleadsModel.Province + MTradeleadsModel.City + MTradeleadsModel.Town + MTradeleadsModel.Street;
                        lbMobileNum.Text = MTradeleadsModel.MobilePhoneNum;
                    }
                    else if (bll_usermanage.GetUserInfoByTelNum(HttpContext.Current.User.Identity.Name).Audit == true)
                    {
                        lbTitle.Text = MTradeleadsModel.Title;
                        lbDetail.Text = MTradeleadsModel.DetailInfo;
                        lbAddress.Text = MTradeleadsModel.Province + MTradeleadsModel.City + MTradeleadsModel.Town + MTradeleadsModel.Street;
                        lbMobileNum.Text = MTradeleadsModel.MobilePhoneNum;
                    }
                    else
                    {
                        Response.Redirect("~/UserCenter/Deposit.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/LoginM.aspx");
                }

                lbPrice.Text = MTradeleadsModel.Price;
                lbType.Text = MTradeleadsModel.TSName + "/" + MTradeleadsModel.UnitName;
                lbUserName.Text = MTradeleadsModel.UserName;
                lbVolume.Text = MTradeleadsModel.Volume;
                if (MTradeleadsModel.IDAuthentication == true)
                {
                    IDAuthenticationLabel.Text = Aunth1.msg;
                }
                else
                {
                    IDAuthenticationLabel.Text = UnAunth1.msg;
                }
                //IDAuthenticationLabel.Text = MTradeleadsModel.IDAuthentication.ToString();
                if (MTradeleadsModel.UserAudit == true)
                {
                    AuditLabel.Text = Aunth1.msg;
                }
                else
                {
                    AuditLabel.Text = UnAunth1.msg;
                }
                //AuditLabel.Text = MTradeleadsModel.UserAudit.ToStrin/*/*/*g();*/*/*/
                if (MTradeleadsModel.PicPath != "")
                { Image1.ImageUrl = MTradeleadsModel.PicPath; }
                else
                {
                    Image1.ImageUrl = "~/img/noimg.jpg";
                }

            }
        }
    }
}