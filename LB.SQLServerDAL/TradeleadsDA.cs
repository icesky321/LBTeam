using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
   public class TradeleadsDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.Tradeleads NewTradeleads(LB.SQLServerDAL.Tradeleads tradeleads)
        {
            if (tradeleads != null)
            {
                dbContext.Tradeleads.InsertOnSubmit(tradeleads);
                dbContext.SubmitChanges();

            }
            return tradeleads;
        }

        public void UpdateTradeleads(LB.SQLServerDAL.Tradeleads tradeleadsinfo)
        {
            dbContext.SubmitChanges();
        }

        public void DeleteTradeleads(int infoId)
        {
            var query = (from c in dbContext.Tradeleads
                         where c.InfoId == infoId
                         select c).FirstOrDefault();
            dbContext.Tradeleads.DeleteOnSubmit(query);
            dbContext.SubmitChanges();
        }

        public IQueryable<LB.SQLServerDAL.Tradeleads> GetTradeleads()
        {
            var query = from c in dbContext.Tradeleads
                        orderby c.ReleaseDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.Tradeleads>();
        }

        public IQueryable<LB.SQLServerDAL.Tradeleads> GetTradeleadsByUserId(int UserId)
        {
            var query = from c in dbContext.Tradeleads
                        where c.UserId == UserId
                        orderby c.ReleaseDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.Tradeleads>();
        }

        public IQueryable<LB.SQLServerDAL.Tradeleads> GetTradeleadsByTSId(int TSId)
        {
            var query = from c in dbContext.Tradeleads
                        where c.TSId == TSId
                        orderby c.ReleaseDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.Tradeleads>();
        }

        public IQueryable GetTradeleadsByTradeType(int TId)
        {
            var query = from c in dbContext.Tradeleads
                        where c.TId == TId
                        join u in dbContext.UserInfo on c.UserId equals u.UserId into leftGroup1
                        from u in leftGroup1.DefaultIfEmpty()
                        join t in dbContext.TSInfo on c.TSId equals t.TSId into leftGroup2
                        from t in leftGroup2.DefaultIfEmpty()
                        join n in dbContext.UnitInfo on c.UnitID equals n.UnitId into leftGroup3
                        from n in leftGroup3.DefaultIfEmpty()
                        join s in dbContext.TSType on c.TId equals s.TId into leftGroup4
                        from s in leftGroup4.DefaultIfEmpty()
                        orderby c.ReleaseDate descending
                        select new
                        {
                            c.Audit,
                            c.AuditDatetime,
                            c.City,
                            c.DetailInfo,
                            c.Hits,
                            c.InfoId,
                            c.PicPath,
                            c.Price,
                            c.Province,
                            c.Recommend,
                            c.ReleaseDate,
                            c.Street,
                            c.Title,
                            c.Town,
                            c.TId,
                            t.TSId,
                            t.TSName,
                            n.UnitId,
                            n.UnitName,
                            s.TSTypeName,
                            c.Volume,
                            c.UserId,
                            u.UserName,
                            u.MobilePhoneNum
                        };
            return query;
        }

        public LB.SQLServerDAL.Tradeleads GetTradeleadsByinfoId(int InfoId)
        {
            var query = from c in dbContext.Tradeleads
                        where c.InfoId == InfoId
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.Tradeleads>();
        }

        public IQueryable GetTradeleadsByAddressAndType(string province, string city, string country, string street,int TId)
        {
            var query = from c in dbContext.Tradeleads
                        where c.TId == TId
                        join u in dbContext.UserInfo on c.UserId equals u.UserId into leftGroup1
                        from u in leftGroup1.DefaultIfEmpty()
                        join t in dbContext.TSInfo on c.TSId equals t.TSId into leftGroup2
                        from t in leftGroup2.DefaultIfEmpty()
                        join n in dbContext.UnitInfo on c.UnitID equals n.UnitId into leftGroup3
                        from n in leftGroup3.DefaultIfEmpty()
                        join s in dbContext.TSType on c.TId equals s.TId into leftGroup4
                        from s in leftGroup4.DefaultIfEmpty()
                        orderby c.ReleaseDate descending
                        select new
                        {
                            c.Audit,
                            c.AuditDatetime,
                            c.City,
                            c.DetailInfo,
                            c.Hits,
                            c.InfoId,
                            c.PicPath,
                            c.Price,
                            c.Province,
                            c.Recommend,
                            c.ReleaseDate,
                            c.Street,
                            c.Title,
                            c.Town,
                            t.TSId,
                            t.TSName,
                            n.UnitId,
                            n.UnitName,
                            c.TId,
                            c.Volume,
                            c.UserId,
                            u.UserName,
                            s.TSTypeName,
                            u.MobilePhoneNum
                        };
            if (province != "---")
            {
                query = query.Where(p => p.Province.IndexOf(province) >= 0);
            }
            if (city != "--")
            {
                query = query.Where(p => p.City.IndexOf(city) >= 0);
            }
            if (country != "--")
            {
                query = query.Where(p => p.Town.IndexOf(country) >= 0);
            }
            if (street != "--")
            {
                query = query.Where(p => p.Street.IndexOf(street) >= 0);
            }
            return query;
        }
    }
}
