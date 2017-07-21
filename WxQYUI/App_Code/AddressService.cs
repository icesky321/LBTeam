using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using AjaxControlToolkit;
using System.Threading;
using System.Collections.Specialized;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
//[System.Web.Script.Services.ScriptService]
public class AddressService
{
    Cobe.CnRegion.RegionManage bll_region = new Cobe.CnRegion.RegionManage();
    // 要使用 HTTP GET，请添加 [WebGet] 特性。(默认 ResponseFormat 为 WebMessageFormat.Json)
    // 要创建返回 XML 的操作，
    //     请添加 [WebGet(ResponseFormat=WebMessageFormat.Xml)]，
    //     并在操作正文中包括以下行:
    //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
    [OperationContract]
    public CascadingDropDownNameValue[] GetProvince(string knownCategoryValues, string category)
    {
        Thread.Sleep(1000); // 等待1秒，模拟网络延迟

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

    [OperationContract]
    public CascadingDropDownNameValue[] GetCity(string knownCategoryValues, string category)
    {
        Thread.Sleep(1000);

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

    [OperationContract]
    public CascadingDropDownNameValue[] GetCounty(string knownCategoryValues, string category)
    {
        Thread.Sleep(1000);

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

    [OperationContract]
    public CascadingDropDownNameValue[] GetStreet(string knownCategoryValues, string category)
    {
        Thread.Sleep(1000);

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

    // 在此处添加更多操作并使用 [OperationContract] 标记它们
}
