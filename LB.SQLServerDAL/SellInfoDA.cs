﻿using System;
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

        //public IQueryable<LB.SQLServerDAL.SellInfo> GetSellInfo()
        //{
        //    var query = from c in dbContext.SellInfo
        //                orderby c.ReleaseDate descending
        //                select c;
        //    return query.AsQueryable<LB.SQLServerDAL.SellInfo>();
        //}

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
        /// 根据客服处理标记搜索出售信息。
        /// </summary>
        /// <param name="kefuToHandleTag">客服处理标记。</param>
        /// <returns></returns>
        public IQueryable GetSellInfo_ByKefuTohandleTag(bool kefuToHandleTag)
        {
            var query = from c in dbContext.SellInfo
                        where c.Kefu_TohandleTag == kefuToHandleTag
                        orderby c.CreateDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.SellInfo>();
        }

        /// <summary>
        /// 根据客服处理标记搜索出售信息。
        /// </summary>
        /// <param name="kefuToHandleTag">客服处理标记。</param>
        /// <returns></returns>
        public IQueryable GetSellInfo_ByJDTohandleTag(bool jdTohandleTag)
        {
            var query = from c in dbContext.SellInfo
                        where c.JD_TohandleTag == jdTohandleTag
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
            var query = (from c in dbContext.SellInfo
                         where c.InfoId == infoId
                         select c).FirstOrDefault();
            dbContext.SellInfo.DeleteOnSubmit(query);
            dbContext.SubmitChanges();
        }

    }
}