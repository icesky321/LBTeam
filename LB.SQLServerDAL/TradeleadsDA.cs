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

        public IQueryable GetTradeleadsByTradeType(int TId,bool Audit)
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
                        where c.Audit == Audit
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
            return query.Take(13);
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
            if (province != "---" && province != "-1" && province != "-1")
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

        public IQueryable<LB.Model.TradeleadsModel> GetTradeleadsInfoByAudit(string Audit, string province, string city, string country, string street, string TId)
        {

            var query = from t in dbContext.Tradeleads
                        join u in dbContext.UserInfo on t.UserId equals u.UserId into leftGroup1
                        from u in leftGroup1.DefaultIfEmpty()
                        join a in dbContext.TSType on t.TId equals a.TId into leftGroup2
                        from a in leftGroup2.DefaultIfEmpty()
                        join b in dbContext.TSInfo on t.TSId equals b.TSId into leftGroup3
                        from b in leftGroup3.DefaultIfEmpty()
                        join c in dbContext.UnitInfo on t.UnitID equals c.UnitId into leftGroup4
                        from c in leftGroup4.DefaultIfEmpty()
                        orderby t.ReleaseDate descending
                        select new LB.Model.TradeleadsModel()
                        {
                            infoId = t.InfoId,
                            Title = t.Title,
                            Province = t.Province,
                            City = t.City,
                            Town = t.Town,
                            Street = t.Street,
                            Volume = t.Volume,
                            Price = t.Price,
                            DetailInfo = t.DetailInfo,
                            UserName = u.UserName,
                            UserId = Convert.ToInt32(t.UserId),
                            UnitName=c.UnitName,
                            TSId=b.TSId,
                            TSName=b.TSName,
                            ReleaseDate = Convert.ToDateTime(t.ReleaseDate),
                            Hits=Convert.ToInt32(t.Hits),
                            TId=Convert.ToInt32(t.TId),
                            TSTypeName=b.TSName,
                            PicPath=t.PicPath,
                            Audit=t.Audit==null?false : t.Audit.Value,
                            AuditDatetime=Convert.ToDateTime(t.AuditDatetime),
                            MobilePhoneNum=u.MobilePhoneNum,
                            UserTypeId=Convert.ToInt32(u.UserTypeId)
                        };
            if (!string.IsNullOrEmpty(Audit))
            {
                query = query.Where(p => p.Audit == Convert.ToBoolean(Audit));
            }
            if (province != "---" && province != "" && province != "-1")
            {
                query = query.Where(p => p.Province.IndexOf(province) >= 0);
            }
            if (city != "--" && city != "")
            {
                query = query.Where(p => p.City.IndexOf(city) >= 0);
            }
            if (country != "--" && country != "")
            {
                query = query.Where(p => p.Town.IndexOf(country) >= 0);
            }
            if (street != "--" && street != "")
            {
                query = query.Where(p => p.Street.IndexOf(street) >= 0);
            }
            if (!string.IsNullOrEmpty(TId))
            {
                query = query.Where(p => p.TId == Convert.ToInt32(TId));
            }
            return query.AsQueryable<LB.Model.TradeleadsModel>();
        }

        public IQueryable<LB.Model.TradeleadsModel> GetTradeleadsInfoByAll()
        {

            var query = from t in dbContext.Tradeleads
                        join u in dbContext.UserInfo on t.UserId equals u.UserId into leftGroup1
                        from u in leftGroup1.DefaultIfEmpty()
                        join a in dbContext.TSType on t.TId equals a.TId into leftGroup2
                        from a in leftGroup2.DefaultIfEmpty()
                        join b in dbContext.TSInfo on t.TSId equals b.TSId into leftGroup3
                        from b in leftGroup3.DefaultIfEmpty()
                        join c in dbContext.UnitInfo on t.UnitID equals c.UnitId into leftGroup4
                        from c in leftGroup4.DefaultIfEmpty()
                        orderby t.ReleaseDate descending
                        select new LB.Model.TradeleadsModel()
                        {
                            infoId = t.InfoId,
                            Title = t.Title,
                            Province = t.Province,
                            City = t.City,
                            Town = t.Town,
                            Street = t.Street,
                            Volume = t.Volume,
                            Price = t.Price,
                            DetailInfo = t.DetailInfo,
                            UserName = u.UserName,
                            UserId = u.UserId,
                            UnitName = c.UnitName,
                            TSId = b.TSId,
                            TSName = b.TSName,
                            ReleaseDate = Convert.ToDateTime(t.ReleaseDate),
                            Hits = Convert.ToInt32(t.Hits),
                            TId = Convert.ToInt32(t.TId),
                            TSTypeName = b.TSName,
                            PicPath = t.PicPath,
                            Audit = t.Audit == null ? false : t.Audit.Value,
                            AuditDatetime = Convert.ToDateTime(t.AuditDatetime),
                            MobilePhoneNum = u.MobilePhoneNum,
                            UserTypeId = Convert.ToInt32(u.UserTypeId)
                        };
            return query.AsQueryable<LB.Model.TradeleadsModel>();
        }

        public LB.Model.TradeleadsModel GetTradeleadsInfoModelByinfoId(int InfoId)
        {
            var query = from t in dbContext.Tradeleads
                        join u in dbContext.UserInfo on t.UserId equals u.UserId into leftGroup1
                        from u in leftGroup1.DefaultIfEmpty()
                        join a in dbContext.TSType on t.TId equals a.TId into leftGroup2
                        from a in leftGroup2.DefaultIfEmpty()
                        join b in dbContext.TSInfo on t.TSId equals b.TSId into leftGroup3
                        from b in leftGroup3.DefaultIfEmpty()
                        join c in dbContext.UnitInfo on t.UnitID equals c.UnitId into leftGroup4
                        from c in leftGroup4.DefaultIfEmpty()
                        where t.InfoId == InfoId
                        select new LB.Model.TradeleadsModel()
                        {
                            infoId = t.InfoId,
                            Title = t.Title,
                            Province = t.Province,
                            City = t.City,
                            Town = t.Town,
                            Street = t.Street,
                            Volume = t.Volume,
                            Price = t.Price,
                            DetailInfo = t.DetailInfo,
                            UserName = u.UserName,
                            UserId = Convert.ToInt32(t.UserId),
                            UnitName = c.UnitName,
                            TSId = b.TSId,
                            TSName = b.TSName,
                            ReleaseDate = Convert.ToDateTime(t.ReleaseDate),
                            Hits = Convert.ToInt32(t.Hits),
                            TId = Convert.ToInt32(t.TId),
                            TSTypeName = b.TSName,
                            PicPath = t.PicPath,
                            Audit = t.Audit == null ? false : t.Audit.Value,
                            AuditDatetime = Convert.ToDateTime(t.AuditDatetime),
                            MobilePhoneNum = u.MobilePhoneNum,
                            UserTypeId = Convert.ToInt32(u.UserTypeId),
                            IDAuthentication = u.IDAuthentication == null ? false : u.IDAuthentication.Value,
                            UserAudit = u.Audit == null ? false : u.Audit.Value
                        };
            return query.FirstOrDefault<LB.Model.TradeleadsModel>();
        }
    }
}
