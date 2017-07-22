using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AjaxControlToolkit;
using System.Threading;
using System.Collections.Specialized;

/// <summary>
/// CNRegionService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
[System.Web.Script.Services.ScriptService]
public class CNRegionService : System.Web.Services.WebService
{
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    public CNRegionService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [System.Web.Script.Services.ScriptMethod]
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [System.Web.Script.Services.ScriptMethod]
    [WebMethod]
    public CascadingDropDownNameValue[] GetProvince(string knownCategoryValues, string category)
    {
        //Thread.Sleep(1000); // 等待1秒，模拟网络延迟

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        var provinces = bll_region.GetRegions("0");
        foreach (Cobe.CnRegion.SQLServerDAL.Region region in provinces)
        {
            string id = region.Id.ToString();
            string name = region.AreaName;
            values.Add(new CascadingDropDownNameValue(name, id));
        }
        return values.ToArray();
    }

    [System.Web.Script.Services.ScriptMethod]
    [WebMethod]
    public CascadingDropDownNameValue[] GetCity(string knownCategoryValues, string category)
    {
        //Thread.Sleep(1000);

        StringDictionary keyValue =
            CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        string provinceId = keyValue["Province"];

        var cities = bll_region.GetRegions(provinceId);
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        foreach (Cobe.CnRegion.SQLServerDAL.Region region in cities)
        {
            string id = region.Id.ToString();
            string name = region.AreaName;
            values.Add(new CascadingDropDownNameValue(name, id));
        }

        return values.ToArray();
    }

    [System.Web.Script.Services.ScriptMethod]
    [WebMethod]
    public CascadingDropDownNameValue[] GetCounty(string knownCategoryValues, string category)
    {
        //Thread.Sleep(1000);

        StringDictionary keyValue =
            CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        string cityId = keyValue["City"];

        var counties = bll_region.GetRegions(cityId);
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        foreach (Cobe.CnRegion.SQLServerDAL.Region region in counties)
        {
            string id = region.Id.ToString();
            string name = region.AreaName;
            values.Add(new CascadingDropDownNameValue(name, id));
        }

        return values.ToArray();
    }

    [System.Web.Script.Services.ScriptMethod]
    [WebMethod]
    public CascadingDropDownNameValue[] GetStreet(string knownCategoryValues, string category)
    {
        //Thread.Sleep(1000);

        StringDictionary keyValue =
            CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        string cityId = keyValue["County"];

        var streets = bll_region.GetRegions(cityId);
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        foreach (Cobe.CnRegion.SQLServerDAL.Region region in streets)
        {
            string id = region.Id.ToString();
            string name = region.AreaName;
            values.Add(new CascadingDropDownNameValue(name, id));
        }

        return values.ToArray();
    }
}
