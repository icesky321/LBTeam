using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    /// <summary>
    /// 关于回收员业务配置信息的操作类
    /// </summary>
    public class JD_ConfigDA
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

        ~JD_ConfigDA()
        {
            this.Dispose();
        }

        /// <summary>
        /// 设置回收员的用户配置
        /// </summary>
        /// <param name="config">配置数据</param>
        /// <returns></returns>
        public LB.SQLServerDAL.JD_Config SetConfig(LB.SQLServerDAL.JD_Config config)
        {
            LB.SQLServerDAL.JD_Config returnConfig = config;
            if (config != null)
            {
                if (ExistConfig(config.UserId))
                {
                    JD_Config cfg = dbContext.JD_Config.Where(o => o.UserId == config.UserId).FirstOrDefault();

                    if (cfg.BookBillModeToggle != config.BookBillModeToggle)
                        cfg.BookBillModeToggle = config.BookBillModeToggle;

                    if (cfg.BookBillStatusRemind != config.BookBillStatusRemind)
                        cfg.BookBillStatusRemind = config.BookBillStatusRemind;

                    if (cfg.IsLocked != config.IsLocked)
                        cfg.IsLocked = config.IsLocked;

                    if (cfg.RegionCode != config.RegionCode)
                        cfg.RegionCode = config.RegionCode;

                    returnConfig = cfg;
                }
                else
                {
                    dbContext.JD_Config.InsertOnSubmit(config);
                }

                dbContext.SubmitChanges();

            }
            return config;
        }

        /// <summary>
        /// 获取回收业务员的配置信息
        /// </summary>
        /// <param name="userId">回收业务员用户Id</param>
        /// <returns></returns>
        public LB.SQLServerDAL.JD_Config GetJD_Config(int userId)
        {
            var query = from c in dbContext.JD_Config
                        where c.UserId == userId
                        select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 获取回收业务员的配置信息
        /// </summary>
        /// <param name="mobileNum">回收业务员手机号码</param>
        /// <returns></returns>
        public LB.SQLServerDAL.JD_Config GetJD_Config(string mobileNum)
        {
            var query = from c in dbContext.JD_Config
                        where c.MobilePhoneNum == mobileNum
                        select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 是否存在用户配置
        /// </summary>
        /// <param name="userId">配置信息</param>
        /// <returns></returns>
        public bool ExistConfig(int userId)
        {
            bool exists = false;
            var query = from u in dbContext.JD_Config
                        where u.UserId == userId
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }

        /// <summary>
        /// 根据业务员是否关闭接单来搜索业务员
        /// </summary>
        /// <param name="BillMode"></param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.JD_Config> GetJDByBillMode(bool BillMode,bool IsLocked)
        {
            var query = from c in dbContext.JD_Config
                        where c.BookBillModeToggle==BillMode && c.IsLocked==IsLocked
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.JD_Config>();
        }

        public IQueryable<LB.SQLServerDAL.JD_Config> GetJDByRegionCode(string RegionCode)
        {
            var query = from c in dbContext.JD_Config
                        where c.RegionCode.StartsWith(RegionCode)
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.JD_Config>();
        }
    }
}
