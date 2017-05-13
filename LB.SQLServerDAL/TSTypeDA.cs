using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class TSTypeDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public IQueryable<LB.SQLServerDAL.TSType> GetTSType()
        {
            var query = from c in dbContext.TSType
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.TSType>();
        }
    }
}
