using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cobe.CnRegion.Entities;
using System.Threading;

public partial class SyncProvince : System.Web.UI.Page
{
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSync_Click(object sender, EventArgs e)
    {
        SyncSubRegion("0");
        bll_region.SubmitChanges();
    }


    protected void SyncSubRegion(string parentId)
    {
        UriBuilder urib = new UriBuilder(Cobe.CnRegion.Config.AliyunRegionAPIUrl);
        urib.Query = "parentId=" + parentId;
        string returnText = Cobe.CnRegion.HttpUtility.RequestUtility.HttpGet(urib.ToString(), null);

        if (returnText.Contains("远程服务器"))
        {
            tbSyncCity.Text += "ParentId:" + parentId + " | ";
        }
        else
        {
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            Cobe.CnRegion.Entities.JsonResult jsResult = js.Deserialize<JsonResult>(returnText);

            List<Cobe.CnRegion.Entities.Region> aliRegions = jsResult.Showapi_Res_Body.Data;

            foreach (Region aliRegion in aliRegions)
            {
                Cobe.CnRegion.SQLServerDAL.Region localRegion = Cobe.CnRegion.Utilities.EntityUtility.EntityUtility.Convert(aliRegion);
                bll_region.CreateRegion(localRegion);

            }

        }
    }

    protected void btnSyncCity_Click(object sender, EventArgs e)
    {
        var provinces = bll_region.GetProvinces();
        foreach (Cobe.CnRegion.SQLServerDAL.Region localRegion in provinces)
        {
            string provinceId = localRegion.Id;
            SyncSubRegion(provinceId);
        }
        bll_region.SubmitChanges();
    }


    protected void btnSyncCounty_Click(object sender, EventArgs e)
    {
        var cities = bll_region.GetRegions(2);
        foreach (Cobe.CnRegion.SQLServerDAL.Region localRegion in cities)
        {
            string cityId = localRegion.Id;
            SyncSubRegion(cityId);

        }
        bll_region.SubmitChanges();
    }

    protected void btnSyncStreet_Click(object sender, EventArgs e)
    {
        var counties = bll_region.GetRegions(3);
        foreach (Cobe.CnRegion.SQLServerDAL.Region localRegion in counties)
        {
            string cityId = localRegion.Id;
            SyncSubRegion(cityId);

        }
        bll_region.SubmitChanges();
    }
}