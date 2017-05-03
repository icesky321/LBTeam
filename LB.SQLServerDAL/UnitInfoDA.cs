using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class UnitInfoDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public IQueryable<LB.SQLServerDAL.UnitInfo> GetUnitInfo()
        {
            var query = from c in dbContext.UnitInfo
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UnitInfo>();
        }
    }
}
