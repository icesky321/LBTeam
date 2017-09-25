using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class SellInfoDA
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

        ~SellInfoDA()
        {
            this.Dispose();
        }

        /// <summary>
        /// 帮帮忙供需数统计
        /// </summary>
        /// <returns></returns>
        public int GetSellInfoSum()
        {
            return dbContext.SellInfo.Count();
        }

        /// <summary>
        /// 获取客服待审核记录数
        /// </summary>
        /// <returns></returns>
        public int GetCount_KefuTohandle()
        {
            return dbContext.SellInfo.Where(o => o.Kefu_TohandleTag == true).Count();
        }

        /// <summary>
        /// 获取街道回收员待办回收信息
        /// </summary>
        /// <param name="jd_UserId">街道回收员UserId</param>
        /// <returns></returns>
        public int GetCount_JDTohandle(int jd_UserId)
        {
            return dbContext.SellInfo.Where(o => o.JD_UserId == jd_UserId && o.JD_TohandleTag == true).Count();
        }

        /// <summary>
        /// 创建出售信息。
        /// </summary>
        /// <param name="sellInfo"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.SellInfo CreateSellInfo(LB.SQLServerDAL.SellInfo sellInfo)
        {
            if (sellInfo != null)
            {
                sellInfo.InfoId = Guid.NewGuid();
                sellInfo.CreateDate = DateTime.Now;
                sellInfo.Kefu_TohandleTag = true;
                sellInfo.JD_TohandleTag = false;
                sellInfo.IsClosed = false;
                dbContext.SellInfo.InsertOnSubmit(sellInfo);
                dbContext.SubmitChanges();

            }
            return sellInfo;
        }

        /// <summary>
        /// 获取指定 infoId 的出售信息。
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.SellInfo GetSellInfo_ById(Guid infoId)
        {
            var query = from c in dbContext.SellInfo
                        where c.InfoId == infoId
                        select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 根据用户登录账户搜索用户自己发布的出售信息。
        /// </summary>
        /// <param name="userMobile">用户手机号</param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetSellInfo_ByUserMobile(string userMobile)
        {
            var query = from c in dbContext.SellInfo
                        where c.CF_UserMobile == userMobile
                        orderby c.CreateDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.SellInfo>();
        }

        /// <summary>
        /// 获取我的未关闭出售信息。
        /// </summary>
        /// <param name="userMobile">用户手机号</param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetMySellInfo_NotClosed(string userMobile)
        {
            var query = from c in dbContext.SellInfo
                        where c.CF_UserMobile == userMobile && c.IsClosed == false
                        orderby c.CreateDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.SellInfo>();
        }

        /// <summary>
        /// 获取派单街道业务员的要处理的出售信息
        /// </summary>
        /// <param name="JD_UserId"></param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetSellInfoBy_JD_NotClosed(int JD_UserId)
        {
            var query = from c in dbContext.SellInfo
                        where c.JD_UserId == JD_UserId && c.IsClosed == false
                        orderby c.CreateDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.SellInfo>();
        }

        /// <summary>
        /// 获取所有待街道业务员接单的收货信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetAllSellInfoBy_JD_NotClosed()
        {
            var query = from c in dbContext.SellInfo
                        where c.IsClosed == false
                        orderby c.CreateDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.SellInfo>();
        }

        /// <summary>
        /// 获取我的已关闭出售信息。
        /// </summary>
        /// <param name="userMobile">用户手机号</param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetMySellInfo_IsClosed(string userMobile)
        {
            var query = from c in dbContext.SellInfo
                        where c.CF_UserMobile == userMobile && c.IsClosed == true
                        orderby c.CreateDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.SellInfo>().Take(20);
        }

        /// <summary>
        /// 获取我的已关闭出售信息。
        /// </summary>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetSellInfo_IsClosed()
        {
            var query = from c in dbContext.SellInfo
                        where c.IsClosed == true
                        orderby c.CreateDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.SellInfo>().Take(20);
        }


        /// <summary>
        /// 根据客服处理标记搜索出售信息。
        /// </summary>
        /// <param name="kefuToHandleTag">客服处理标记。</param>
        /// <param name="count">获取记录数</param>
        /// <returns></returns>
        public IQueryable GetSellInfo_ByKefuTohandleTag(bool kefuToHandleTag, int count)
        {
            var query = from c in dbContext.SellInfo
                        where c.Kefu_TohandleTag == kefuToHandleTag
                        orderby c.CreateDate descending
                        select c;
            return query.Take(count).AsQueryable<LB.SQLServerDAL.SellInfo>();
        }

        /// <summary>
        /// 根据街道回收员处理标记搜索出售信息。
        /// </summary>
        /// <param name="jd_UserId">街道回收员用户Id</param>
        /// <param name="jdTohandleTag">街道回收员处理标记。</param>
        /// <returns></returns>
        public IQueryable GetSellInfo_ByJDTohandleTag(int jd_UserId, bool jdTohandleTag)
        {
            var query = from c in dbContext.SellInfo
                        where c.JD_UserId == jd_UserId && c.JD_TohandleTag == jdTohandleTag
                        orderby c.CreateDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.SellInfo>();
        }

        /// <summary>
        /// 根据产废单位卖货单的状态信息查询单据信息
        /// </summary>
        /// <param name="jd_UserId">街道回收员用户Id</param>
        /// <param name="StatusMsg">状态信息</param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetMySellInfo_ByStatusMsg(int jd_UserId, string StatusMsg)
        {
            var query = from c in dbContext.SellInfo
                        where c.JD_UserId == jd_UserId && c.StatusMsg == StatusMsg
                        orderby c.CreateDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.SellInfo>();
        }

        public void UpdateSellInfo(LB.SQLServerDAL.SellInfo sellInfoinfo)
        {
            dbContext.SubmitChanges();
        }

        /// <summary>
        /// 删除出售信息。
        /// </summary>
        /// <param name="infoId"></param>
        public void DeleteSellInfo(Guid infoId)
        {
            var query = from s in dbContext.SellInfo
                        where s.InfoId == infoId
                        select s;
            foreach (var para in query)
            {
                dbContext.SellInfo.DeleteOnSubmit(para);
            }

            try
            {
                dbContext.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
