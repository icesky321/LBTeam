using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Syb_HS_HSQuote2 : System.Web.UI.Page
{
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    LB.BLL.TSManage bll_ts = new LB.BLL.TSManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    #region 初始化加载
    private void Init_Load()
    {
        Load_TsInfo();
    }

    private void Load_TsInfo()
    {
        if (Request.QueryString["id"] != null)
        {
            string tsCode = string.Empty;
            tsCode = Request.QueryString["id"];

            LB.SQLServerDAL.TSInfo tsInfo = bll_ts.GetTS_ByCode(tsCode);

            if (tsInfo == null)
                return;

            ltlTSName.Text = tsInfo.TSName + " ，  按" + tsInfo.ChargeUnit + "计价";
        }
    }

    #endregion
}