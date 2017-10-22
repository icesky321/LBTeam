using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class TmQueueRecordDA
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

        ~TmQueueRecordDA()
        {
            this.Dispose();
        }
        /// <summary>
        /// 获取已推入的信息的数目。
        /// </summary>
        /// <returns></returns>
        public int GetTMCount()
        {
            var query = from m in dbContext.TmQueueRecord
                        select m;
            int count = query.Count();
            return count;
        }

        /// <summary>
        /// 在数据库中新增微信信息。
        /// </summary>
        /// <param name="tm">微信信息。</param>
        /// <returns></returns>
        public TmQueueRecord NewTmQueueRecord(SQLServerDAL.TmQueueRecord tm)
        {
            if (tm != null)
            {
                tm.WxId = System.Guid.NewGuid();
                tm.InQueueDate = DateTime.Now;
                tm.SendFailureCount = 0;
                dbContext.TmQueueRecord.InsertOnSubmit(tm);
                dbContext.SubmitChanges();
            }
            return tm;
        }

        /// <summary>
        /// 获取指定 wxId 的微信消息。
        /// </summary>
        /// <param name="wxId">微信消息ID</param>
        /// <returns></returns>
        public TmQueueRecord GetTmQueueRecord(System.Guid wxId)
        {
            var query = from message in dbContext.TmQueueRecord
                        where message.WxId == wxId
                        select message;
            var wxMessage = query.FirstOrDefault();
            return wxMessage;
        }

        /// <summary>
        /// 随机取出一条从未发送失败的微信消息。
        /// </summary>
        /// <returns></returns>
        public TmQueueRecord GetTmQueueRecordTopOne()
        {
            var query = from message in dbContext.TmQueueRecord
                        where message.SendFailureCount == 0
                        select message;
            var wxMessage = query.FirstOrDefault();
            return wxMessage;
        }

        /// <summary>
        /// 删除指定 wxId 的微信消息
        /// </summary>
        /// <param name="wxId">微信消息Id.</param>
        public void DeleteTmQueueRecord(System.Guid wxId)
        {
            var query = from para in dbContext.TmQueueRecord
                        where para.WxId == wxId
                        select para;
            foreach (var para in query)
            {
                dbContext.TmQueueRecord.DeleteOnSubmit(para);
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
        /// Check 队列中是否存在元素。
        /// </summary>
        /// <returns></returns>
        public bool IsMessageAvailable()
        {
            bool exist = false;
            var query = from m in dbContext.TmQueueRecord
                        select m;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }

        /// <summary>
        /// 在数据库中更新费用类型对象。
        /// </summary>
        /// <param name="costTypeId">费用类型Id</param>
        /// <param name="costTypeName">费用类型名称。</param>
        /// <param name="description">费用类型说明</param>
        public void MarkSendFail(TmQueueRecord message)
        {
            message.SendFailureCount++;
            dbContext.SubmitChanges();
        }
    }
}
