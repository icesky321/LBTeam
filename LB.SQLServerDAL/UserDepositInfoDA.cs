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

        public void DeleteUserDepositInfo(int userId)
        {
            var query = from s in dbContext.UserDepositInfo
                        where s.UserId == userId
                        select s;
            foreach (var para in query)
            {
                dbContext.UserDepositInfo.DeleteOnSubmit(para);
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

        public bool ExistUserId(int UserId)
        {
            bool exists = false;
            var query = from u in dbContext.UserDepositInfo
                        where u.UserId == UserId
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }
    }
}
