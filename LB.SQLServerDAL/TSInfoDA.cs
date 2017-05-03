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
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.TSInfo>();
        }
    }
}
