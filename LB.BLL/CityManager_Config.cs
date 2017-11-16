using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class CityManager_Config
    {
        LB.SQLServerDAL.CityManager_ConfigDA daHsConfig = new SQLServerDAL.CityManager_ConfigDA();

        public LB.SQLServerDAL.CityManager_Config SetConfig(LB.SQLServerDAL.CityManager_Config config)
        {
            return daHsConfig.SetConfig(config);
        }

        public bool ExistConfig(int userId)
        {
            return daHsConfig.ExistConfig(userId);
        }

        public LB.SQLServerDAL.CityManager_Config GetCityManager_Config(int userId)
        {
            return daHsConfig.GetCityManager_Config(userId);
        }
        public LB.SQLServerDAL.CityManager_Config GetCityManager_ConfigBymobileNum(string mobileNum)
        {
            return daHsConfig.GetCityManager_ConfigBymobileNum(mobileNum);
        }

        public LB.SQLServerDAL.CityManager_Config GetCityManager_ConfigByRegionCode(string RegionCode)
        {
            return daHsConfig.GetCityManager_ConfigByRegionCode(RegionCode);
        }
    }
}
