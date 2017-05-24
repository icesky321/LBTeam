using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DepositManage : System.Web.UI.Page
{
    LB.SQLServerDAL.UserInfo MUserInfo = new LB.SQLServerDAL.UserInfo();
    LB.BLL.UserManage bll_userinfo = new LB.BLL.UserManage();
    LB.SQLServerDAL.UserDepositInfo MUserDepositInfo = new LB.SQLServerDAL.UserDepositInfo();
    LB.BLL.UserDepositInfo bll_userdepositinfo = new LB.BLL.UserDepositInfo();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void UserBind(string TelNum)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(TelNum);
        UserNameLabel.Text = MUserInfo.UserName;
        MobilePhoneNumLabel.Text = MUserInfo.MobilePhoneNum;
        ProvinceLabel.Text = MUserInfo.Province;
        CityLabel.Text = MUserInfo.City;
        TownLabel.Text = MUserInfo.Town;
        StreetLabel.Text = MUserInfo.Street;
        IDAuthenticationLabel.Text = MUserInfo.IDAuthentication.ToString();
        if (MUserInfo.IDAuthentication == true)
        {
            IDAuthenticationLabel.Text = Aunth1.msg;
        }
        else
        {
            IDAuthenticationLabel.Text = UnAunth1.msg;
        }
        //AuditLabel.Text = MUserInfo.Audit.ToString();
        if (MUserInfo.Audit == true)
        {
            AuditLabel.Text = Aunth1.msg;
        }
        else
        {
            AuditLabel.Text = UnAunth1.msg;
        }
        BankNameLabel.Text = MUserInfo.BankName;
        AccountLabel.Text = MUserInfo.Account;
    }


    protected void btSearch_Click(object sender, EventArgs e)
    {
        UserBind(tbTelNum.Text);
    }

    protected void btInSure_Click(object sender, EventArgs e)
    {
        MUserInfo = bll_userinfo.GetUserInfoByTelNum(tbTelNum.Text);
        MUserDepositInfo.UserId = MUserInfo.UserId;
        MUserDepositInfo.Amount = Convert.ToDecimal(tbInDeposit.Text);
        MUserDepositInfo.InDate = Convert.ToDateTime(tbIndate.Text);
        MUserDepositInfo.OutDate = Convert.ToDateTime("1900-1-1");
        MUserDepositInfo.Operator = HttpContext.Current.User.Identity.Name;
        MUserDepositInfo.OperateDate = System.DateTime.Now;
        bll_userdepositinfo.NewUserDepositInfo(MUserDepositInfo);
        lbmsg.Text = "操作成功";
    }

    protected void btOutSure_Click(object sender, EventArgs e)
    {

        MUserInfo = bll_userinfo.GetUserInfoByTelNum(tbTelNum.Text);
        MUserDepositInfo = bll_userdepositinfo.GetUserDepositInfoByUserId(MUserInfo.UserId);
        MUserDepositInfo.UserId = MUserInfo.UserId;
        MUserDepositInfo.Amount = Convert.ToDecimal(MUserDepositInfo.Amount) - Convert.ToDecimal(tbOutDeposit.Text);
        MUserDepositInfo.OutDate = Convert.ToDateTime(tbOutDate.Text);
        MUserDepositInfo.Operator = HttpContext.Current.User.Identity.Name;
        MUserDepositInfo.OperateDate = System.DateTime.Now;
        if (MUserDepositInfo.Amount != Convert.ToDecimal(tbOutDeposit.Text))
        {
            lbmsg.Text = "金额好像不对哦";
        }
        else
        {
            bll_userdepositinfo.UpdateUserDepositInfo(MUserDepositInfo);
        }
    }
}