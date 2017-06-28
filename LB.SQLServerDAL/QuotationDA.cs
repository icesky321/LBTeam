using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class QuotationDA
    {

        LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

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

        ~QuotationDA()
        {
            this.Dispose();
        }


        /// <summary>
        /// 在数据库中更新已更改的内容。
        /// </summary>
        public void SubmitChanges()
        {
            dbContext.SubmitChanges();
        }

        /// <summary>
        /// 获取现有报价信息数量。
        /// </summary>
        /// <returns></returns>
        public int GetCountOfQuotation()
        {
            int count = 0;
            var query = from s in dbContext.Quotation
                        select s;
            count = query.Count();
            return count;
        }

        /// <summary>
        /// 在数据库中新增报价信息。
        /// </summary>
        /// <param name="quotation">报价信息对象。</param>
        /// <returns></returns>
        public Quotation NewQuotation(Quotation quotation)
        {
            if (quotation != null)
            {
                quotation.QuotId = Guid.NewGuid();
                quotation.OfferDate = DateTime.Now;
                dbContext.Quotation.InsertOnSubmit(quotation);
                dbContext.SubmitChanges();
            }
            return quotation;
        }


        /// <summary>
        /// 在数据库中新增报价信息。
        /// </summary>
        /// <param name="quotation">报价信息对象。</param>
        /// <returns></returns>
        public Quotation NewQuotation_NotSubmit(Quotation quotation)
        {
            if (quotation != null)
            {
                quotation.QuotId = Guid.NewGuid();
                quotation.OfferDate = DateTime.Now;
                dbContext.Quotation.InsertOnSubmit(quotation);
            }
            return quotation;
        }

        /// <summary>
        /// 获取今日报价信息对象。
        /// </summary>
        /// <returns></returns>
        public IQueryable<Quotation> GetQuotation(string city, DateTime today)
        {
            var query = from m in dbContext.Quotation
                        where m.City == city && m.OfferDate.Date == today.Date
                        orderby m.TSName
                        select m;
            return query.AsQueryable<Quotation>();
        }

        /// <summary>
        /// 获取某回收公司的最后一条报价。
        /// </summary>
        /// <param name="userId">回收公司Id</param>
        /// <param name="tsId">电瓶品种Id</param>
        /// <returns></returns>
        public Quotation GetLastQuotedPrice(int userId, int tsId)
        {
            var query = from m in dbContext.Quotation
                        where m.UserId == userId && m.TSId == tsId
                        orderby m.OfferDate descending
                        select m;

            return query.FirstOrDefault();
        }

        /// <summary>
        /// 根据报价信息编号获取报价信息对象。
        /// </summary>
        /// <param name="quotId">报价信息编号。</param>
        /// <returns></returns>
        public Quotation GetQuotation(Guid quotId)
        {
            var query = from m in dbContext.Quotation
                        where m.QuotId == quotId
                        select m;
            return query.FirstOrDefault<Quotation>();
        }


        /// <summary>
        /// 在数据库中更新报价信息对象。
        /// <para>参数对象必须为数据库查询对象。</para>
        /// </summary>
        /// <param name="newAccount">新的报价信息对象</param>
        public void UpdateQuotation(Quotation newAccount)
        {
            if (newAccount != null)
            {
                dbContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 删除指定 accId 的参数对。
        /// </summary>
        /// <param name="quotId">报价信息Id.</param>
        public void DeleteQuotation(Guid quotId)
        {
            var query = from s in dbContext.Quotation
                        where s.QuotId == quotId
                        select s;
            foreach (var para in query)
            {
                dbContext.Quotation.DeleteOnSubmit(para);
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

        /// <summary>
        /// 检测是否指定的电瓶品种当日已有报价。
        /// </summary>
        /// <param name="today">日期</param>
        /// <param name="tsId">电瓶品种Id</param>
        /// <returns></returns>
        public bool ExistQuotation(DateTime today, int tsId)
        {
            var query = from s in dbContext.Quotation
                        where s.TSId == tsId && s.OfferDate == today
                        select s;
            if (query.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
