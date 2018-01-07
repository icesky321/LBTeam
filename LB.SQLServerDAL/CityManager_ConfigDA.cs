using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class CityManager_ConfigDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }

            GC.SuppressFinalize(this);
        }

        ~CityManager_ConfigDA()
        {
            this.Dispose();
        }

        /// <summary>
        /// 设置城市经理人的用户配置
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.CityManager_Config SetConfig(LB.SQLServerDAL.CityManager_Config config)
        {
            LB.SQLServerDAL.CityManager_Config returnConfig = config;
            if (config != null)
            {
                if (ExistConfig(config.UserId))
                {
                    CityManager_Config cfg =  dbContext.CityManager_Config.Where(o => o.UserId == config.UserId).FirstOrDefault();

                    if (cfg.BillRemind != config.BillRemind)
                        cfg.BillRemind = config.BillRemind;

                    if (cfg.IsLocked != config.IsLocked)
                        cfg.IsLocked = config.IsLocked;

                    returnConfig = cfg;
                }
                else
                {
                    dbContext.CityManager_Config.InsertOnSubmit(config);
                }

                dbContext.SubmitChanges();

            }
            return config;
        }

        /// <summary>
        /// 是否存在用户配置
        /// </summary>
        /// <param name="userId">配置信息</param>
        /// <returns></returns>
        public bool ExistConfig(int userId)
        {
            bool exists = false;
            var query = from u in dbContext.CityManager_Config
                        where u.UserId == userId
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }

        /// <summary>
        /// 根据用户ID查询城市经理人信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.CityManager_Config GetCityManager_Config(int userId)
        {
            var query = from c in dbContext.CityManager_Config
                        where c.UserId == userId
                        select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 根据手机号查询城市经理人
        /// </summary>
        /// <param name="mobileNum"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.CityManager_Config GetCityManager_ConfigBymobileNum(string mobileNum)
        {
            var query = from c in dbContext.CityManager_Config
                        where c.MobilePhoneNum == mobileNum
                        select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 根据地区查询城市经理人
        /// </summary>
        /// <param name="RegionCode"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.CityManager_Config GetCityManager_ConfigByRegionCode(string RegionCode)
        {
            var query = from c in dbContext.CityManager_Config
                        where c.RegionCode.StartsWith(RegionCode)
                        select c;
            return query.FirstOrDefault();
        }
    }
}
