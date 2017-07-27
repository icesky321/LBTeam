using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LB.SQLServerDAL;

namespace LB.BLL
{
    public class QuotationManage
    {
        LB.SQLServerDAL.QuotationDA quotDA = new SQLServerDAL.QuotationDA();

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            quotDA.Dispose();
        }

        /// <summary>
        /// 在数据库中更新已更改的内容。
        /// </summary>
        public void SubmitChanges()
        {
            quotDA.SubmitChanges();
        }

        /// <summary>
        /// 获取现有报价信息数量。
        /// </summary>
        /// <returns></returns>
        public int GetCountOfQuotation()
        {
            return quotDA.GetCountOfQuotation();
        }

        /// <summary>
        /// 在数据库中新增报价信息。
        /// </summary>
        /// <param name="quotation">报价信息对象。</param>
        /// <returns></returns>
        public Quotation NewQuotation(Quotation quotation)
        {
            return quotDA.NewQuotation(quotation);
        }

        /// <summary>
        /// 在数据库中新增报价信息。
        /// <para>本方法暂不提交数据库，需另行SubmitChanges，方可真正写入数据库。</para>
        /// </summary>
        /// <param name="quotation">报价信息对象。</param>
        /// <returns></returns>
        public Quotation NewQuotation_NotSubmit(Quotation quotation)
        {
            return quotDA.NewQuotation_NotSubmit(quotation);
        }

        /// <summary>
        /// 获取今日报价信息对象。
        /// </summary>
        /// <returns></returns>
        public IQueryable<Quotation> GetQuotation(string city, DateTime today)
        {
            return quotDA.GetQuotation(city, today);
        }

        /// <summary>
        /// 获取某回收公司的最后一条报价。
        /// </summary>
        /// <param name="userId">回收公司Id</param>
        /// <param name="tsId">电瓶品种Id</param>
        /// <returns></returns>
        public LB.SQLServerDAL.Quotation GetLastQuotation(int userId, int tsId)
        {
            return quotDA.GetLastQuotedPrice(userId, tsId);
        }

        /// <summary>
        /// 获取最新的回收报价信息。
        /// </summary>
        /// <param name="userId">回收公司Id</param>
        /// <param name="tsCode">电瓶代码</param>
        /// <param name="regionCode">行政区域代码</param>
        /// <returns></returns>
        public Quotation GetLastQuotedPrice(int userId, string tsCode, string regionCode)
        {
            return quotDA.GetLastQuotedPrice(userId, tsCode, regionCode);
        }

        /// <summary>
        /// 获取当日最新的回收报价信息。
        /// </summary>
        /// <param name="userId">回收公司Id</param>
        /// <param name="tsCode">电瓶代码</param>
        /// <param name="regionCode">行政区域代码</param>
        /// <returns></returns>
        public Quotation GetTodayLastQuotedPrice(int userId, string tsCode, string regionCode)
        {
            return quotDA.GetTodayLastQuotedPrice(userId, tsCode, regionCode);
        }

        /// <summary>
        /// 获取最新的回收报价信息。
        /// </summary>
        /// <param name="tsCode">电瓶代码</param>
        /// <param name="regionCode">行政区域代码</param>
        /// <returns></returns>
        public Quotation GetLastQuotedPrice(string tsCode, string regionCode)
        {
            return quotDA.GetLastQuotedPrice(tsCode, regionCode);
        }

        /// <summary>
        /// 根据报价信息编号获取报价信息对象。
        /// </summary>
        /// <param name="quotId">报价信息编号。</param>
        /// <returns></returns>
        public Quotation GetQuotation(Guid quotId)
        {
            return quotDA.GetQuotation(quotId);
        }


        /// <summary>
        /// 在数据库中更新报价信息对象。
        /// <para>参数对象必须为数据库查询对象。</para>
        /// </summary>
        /// <param name="newAccount">新的报价信息对象</param>
        public void UpdateQuotation(Quotation newAccount)
        {
            quotDA.UpdateQuotation(newAccount);
        }

        /// <summary>
        /// 删除指定 accId 的参数对。
        /// </summary>
        /// <param name="quotId">报价信息Id.</param>
        public void DeleteQuotation(Guid quotId)
        {
            quotDA.DeleteQuotation(quotId);
        }

        /// <summary>
        /// 检测是否指定的电瓶品种当日已有重复的报价。
        /// </summary>
        /// <param name="today">日期</param>
        /// <param name="tsCode">电瓶品种代号</param>
        /// <param name="userId">用户Id</param>
        /// <param name="price">价格</param>
        /// <returns></returns>
        public bool ExistQuotation(DateTime today, string tsCode, int userId, decimal price)
        {
            return quotDA.ExistQuotation(today, tsCode, userId, price);
        }
    }
}
