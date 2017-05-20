using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class UserDepositInfoDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public IQueryable<LB.SQLServerDAL.UserDepositInfo> GetUserDepositInfo()
        {
            var query = from c in dbContext.UserDepositInfo
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserDepositInfo>();
        }

        public LB.SQLServerDAL.UserDepositInfo NewUserDepositInfo(LB.SQLServerDAL.UserDepositInfo userdepositinfo)
        {
            if (userdepositinfo != null)
            {
                //newtype.NewsTypeId = System.Guid.NewGuid();
                dbContext.UserDepositInfo.InsertOnSubmit(userdepositinfo);
                dbContext.SubmitChanges();

            }
            return userdepositinfo;
        }

        public LB.SQLServerDAL.UserDepositInfo GetUserDepositInfoByUserId(int UserId)
        {
            var query = from c in dbContext.UserDepositInfo
                        where c.UserId == UserId
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.UserDepositInfo>();
        }

        public void UpdateUserDepositInfo(LB.SQLServerDAL.UserDepositInfo userdepositinfo)
        {
            dbContext.SubmitChanges();
        }
    }
}
