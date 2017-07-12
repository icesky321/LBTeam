using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class TSInfoDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public IQueryable<LB.SQLServerDAL.TSInfo> GetTSInfo()
        {
            var query = from c in dbContext.TSInfo
                        orderby c.OrderNum
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.TSInfo>();
        }

        /// <summary>
        /// 根据品种代码搜索电瓶
        /// </summary>
        /// <param name="tsCode">品种代码</param>
        /// <returns></returns>
        public LB.SQLServerDAL.TSInfo GetTS_ByCode(string tsCode)
        {
            var query = from c in dbContext.TSInfo
                        where c.TsCode == tsCode
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.TSInfo>();
        }
    }
}
