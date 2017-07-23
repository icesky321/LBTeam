using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_MyWallet : System.Web.UI.Page
{
    LB.BLL.PaymentDetail bll_paymentdetail = new LB.BLL.PaymentDetail();
    LB.SQLServerDAL.PaymentDetail MPaymentDetail = new LB.SQLServerDAL.PaymentDetail();
    LB.BLL.UserManage bll_usermanage = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
                Init_Load();
                MUserInfo = bll_usermanage.GetUserInfoByTelNum(User.Identity.Name);
                if (bll_paymentdetail.ExistUserId(MUserInfo.UserId))
                {
                    lbTotalMoney.Text = bll_paymentdetail.GetAmountSumByUserId(MUserInfo.UserId).ToString();
                    lbWaitMoney.Text = System.Math.Abs(bll_paymentdetail.GetWaitAmountSumByUserId(MUserInfo.UserId)).ToString();
                }
                else
                {
                    lbTotalMoney.Text = "0";
                    lbWaitMoney.Text = "0";
                }
            }
        }
    }

    private void Init_Load()
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_usermanage.GetUserInfoByTelNum(userName);
        if (string.IsNullOrEmpty(user.BankName))
            lbBankName.Text = "未设置";
        else
        {
            lbPayeeName.Text = user.PayeeName;
            lbBankName.Text = user.BankName;
            tbBankInfo.Text = user.BankName;
            tbPayeeName.Text = user.PayeeName;
        }
        if (string.IsNullOrEmpty(user.Account))
            lbAccount.Text = "未设置";
        else
        {
            lbPayeeName.Text = user.PayeeName;
            lbAccount.Text = user.Account;
            tbAccount.Text = user.Account;
            tbPayeeName.Text = user.PayeeName;
        }
        if (string.IsNullOrEmpty(user.ZfbAccount))
            lbZFBName.Text = "未设置";
        else
        {
            lbZFBName.Text = user.ZfbName;
            lbZFBAccount.Text = user.ZfbAccount;
        }
        if (string.IsNullOrEmpty(user.WxAccount))
            lbWXName.Text = "未设置";
        else
        {
            lbWXName.Text = user.WxName;
            lbWXAccount.Text = user.WxAccount;
        }
    }

    protected void btSure_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_usermanage.GetUserInfoByTelNum(User.Identity.Name);
        if (bll_paymentdetail.GetAmountSumByUserId(MUserInfo.UserId) != 0)
        {
            MUserInfo = bll_usermanage.GetUserInfoByTelNum(User.Identity.Name);
            MPaymentDetail.Amount = Convert.ToDecimal("-" + lbTotalMoney.Text);
            MPaymentDetail.UserId = MUserInfo.UserId;
            MPaymentDetail.CreateDate = System.DateTime.Now;
            MPaymentDetail.PayStatus = "提款中";
            MPaymentDetail.AuditDate = Convert.ToDateTime("1900-01-01");
            bll_paymentdetail.newPaymentDetail(MPaymentDetail);

            SendWxArticle_ToCF("100", "产废单位提交提现请求", "请到管理后台-货款管理审核");
            Response.Redirect("MyWallet.aspx#pageRegCompleted", true);

        }
        else
        {
            Response.Redirect("MyWallet.aspx#errorPage", true);
        }
    }

    private void SendWxArticle_ToCF(string QYId, string title, string description)
    {
        //TODO: 发布前修改微信发布逻辑
        LB.Weixin.Message.MsgSender sendmsg = new LB.Weixin.Message.MsgSender();
        Senparc.Weixin.QY.Entities.Article article = new Senparc.Weixin.QY.Entities.Article();
        article.Title = title;
        article.Description = description;
        sendmsg.SendArticleToUsers(QYId, article, "5");
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
        LB.SQLServerDAL.UserInfo user = bll_usermanage.GetUserInfoByTelNum(userName);
        if (user == null)
            return;

        string payeename = tbPayeeName.Text;
        string bankname = tbBankInfo.Text;
        string account = tbAccount.Text;
        if (!string.IsNullOrEmpty(bankname) && !string.IsNullOrEmpty(account))
        {
            user.PayeeName = payeename;
            user.BankName = bankname;
            user.Account = account;
            bll_usermanage.UpdateUserInfo(user);
        }

        Init_Load();

        MultiView4.SetActiveView(viewShwoBankInfo);
    }

    protected void btnEditZFBInfo_Click(object sender, EventArgs e)
    {
        MultiView4.SetActiveView(viewEditZFBInfo);
    }

    protected void btSaveZFBInfo_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_usermanage.GetUserInfoByTelNum(userName);
        if (user == null)
            return;

        string zfbname = tbZFBName.Text;
        string zfbaccount = tbZFBAccount.Text;
        if (!string.IsNullOrEmpty(zfbname) && !string.IsNullOrEmpty(zfbaccount))
        {
            user.ZfbName = zfbname;
            user.ZfbAccount = zfbaccount;
            bll_usermanage.UpdateUserInfo(user);
        }

        Init_Load();

        MultiView4.SetActiveView(viewShowZFB);
    }

    protected void ddlTXType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTXType.SelectedValue == "0")
        {

            MultiView4.Visible = false;
        }
        else if (ddlTXType.SelectedValue == "1")
        {
            MultiView4.Visible = true;
            MultiView4.SetActiveView(viewShwoBankInfo);
        }
        else if (ddlTXType.SelectedValue == "2")
        {
            MultiView4.Visible = true;
            MultiView4.SetActiveView(viewShowZFB);
        }
        else if (ddlTXType.SelectedValue == "3")
        {
            MultiView4.Visible = true;
            MultiView4.SetActiveView(viewShowWX);
        }
    }

    protected void btnEditWXInfo_Click(object sender, EventArgs e)
    {
        MultiView4.SetActiveView(viewEditWXInfo);
    }

    protected void btSaveWXInfo_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
            return;

        string userName = User.Identity.Name;
        LB.SQLServerDAL.UserInfo user = bll_usermanage.GetUserInfoByTelNum(userName);
        if (user == null)
            return;

        string wxname = tbWXName.Text;
        string wxaccount = tbWXAccount.Text;
        if (!string.IsNullOrEmpty(wxname) && !string.IsNullOrEmpty(wxaccount))
        {
            user.WxName = wxname;
            user.WxAccount = wxaccount;
            bll_usermanage.UpdateUserInfo(user);
        }

        Init_Load();

        MultiView4.SetActiveView(viewShowWX);
    }
}