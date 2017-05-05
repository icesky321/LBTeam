using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class NewsInfoDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.NewsInfo NewNewsInfo(LB.SQLServerDAL.NewsInfo newsinfo)
        {
            if (newsinfo != null)
            {
                dbContext.NewsInfo.InsertOnSubmit(newsinfo);
                dbContext.SubmitChanges();

            }
            return newsinfo;
        }

        public IQueryable<LB.SQLServerDAL.NewsInfo> GetNewsInfo()
        {
            var query = from c in dbContext.NewsInfo
                        orderby c.Id descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.NewsInfo>();
        }

        public IQueryable<LB.SQLServerDAL.NewsInfo> GetNewsInfoByType(int TypeId)
        {
            var query = from c in dbContext.NewsInfo where c.NewsTypeId==TypeId
                        orderby c.Id descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.NewsInfo>();
        }

        public void DeleteNewsInfo(int id)
        {
            var query = (from c in dbContext.NewsInfo
                         where c.Id == id
                         select c).FirstOrDefault();
            dbContext.NewsInfo.DeleteOnSubmit(query);
            dbContext.SubmitChanges();
        }

        public LB.SQLServerDAL.NewsInfo GetNewsInfoById(int id)
        {
            var query = from c in dbContext.NewsInfo
                        where c.Id == id
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.NewsInfo>();
        }

        public void UpdateNewsInfo(LB.SQLServerDAL.NewsInfo newinfo)
        {
            dbContext.SubmitChanges();
        }

        public IQueryable<LB.SQLServerDAL.NewsInfo> GetNewsInfoByTypeTop13(int TypeId)
        {
            var query = from c in dbContext.NewsInfo
                        where c.NewsTypeId == TypeId
                        orderby c.Id descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.NewsInfo>().Take(13);
        }
    }
}
