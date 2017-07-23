using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class UserTypeInfoDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.UserTypeInfo NewUserTypeInfo(LB.SQLServerDAL.UserTypeInfo usertypeinfo)
        {
            if (usertypeinfo != null)
            {
                //newtype.NewsTypeId = System.Guid.NewGuid();
                dbContext.UserTypeInfo.InsertOnSubmit(usertypeinfo);
                dbContext.SubmitChanges();

            }
            return usertypeinfo;
        }

        public void UpdateUserTypeInfo(LB.SQLServerDAL.UserTypeInfo usertype)
        {
            dbContext.SubmitChanges();
        }

        public IQueryable<LB.SQLServerDAL.UserTypeInfo> GetUserTypeInfo()
        {
            var query = from c in dbContext.UserTypeInfo
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserTypeInfo>();
        }

        public void DeleteUserTypeInfo(int userTypeId)
        {
            var query = from s in dbContext.UserTypeInfo
                        where s.UserTypeId == userTypeId
                        select s;
            foreach (var para in query)
            {
                dbContext.UserTypeInfo.DeleteOnSubmit(para);
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

        public LB.SQLServerDAL.UserTypeInfo GetUserTypeById(int UserTypeId)
        {
            var query = from c in dbContext.UserTypeInfo
                        where c.UserTypeId == UserTypeId
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.UserTypeInfo>();
        }
    }
}
