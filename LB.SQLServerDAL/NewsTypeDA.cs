using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class NewsTypeDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.NewsType NewNewsType(LB.SQLServerDAL.NewsType newtype)
        {
            if (newtype != null)
            {
                //newtype.NewsTypeId = System.Guid.NewGuid();
                dbContext.NewsType.InsertOnSubmit(newtype);
                dbContext.SubmitChanges();

            }
            return newtype;
        }

        public void UpdateNewsType(LB.SQLServerDAL.NewsType newtype)
        {
            dbContext.SubmitChanges();
        }

        public IQueryable<LB.SQLServerDAL.NewsType> GetNewsType()
        {
            var query = from c in dbContext.NewsType
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.NewsType>();
        }

        public void DeleteNewsTypeinfo(int NewsTypeId)
        {
            var query = (from c in dbContext.NewsType
                         where c.NewsTypeId == NewsTypeId
                         select c).FirstOrDefault();
            dbContext.NewsType.DeleteOnSubmit(query);
            dbContext.SubmitChanges();
        }

        public LB.SQLServerDAL.NewsType GetNewTypeById(int id)
        {
            var query = from c in dbContext.NewsType
                        where c.NewsTypeId == id
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.NewsType>();
        }

    }
}
