using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class CopInfoDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.CopInfo NewCopInfo(LB.SQLServerDAL.CopInfo copifo)
        {
            if (copifo != null)
            {
                dbContext.CopInfo.InsertOnSubmit(copifo);
                dbContext.SubmitChanges();

            }
            return copifo;
        }



        public LB.SQLServerDAL.CopInfo GetCopInfoeById(int id)
        {
            var query = from c in dbContext.CopInfo
                        where c.CopId == id
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.CopInfo>();
        }

        public LB.SQLServerDAL.CopInfo GetCopInfoeByUserId(int UserId)
        {
            var query = from c in dbContext.CopInfo
                        where c.UserId == UserId
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.CopInfo>();
        }

        public void UpdateCopInfo(LB.SQLServerDAL.CopInfo CopInfo)
        {
            dbContext.SubmitChanges();
        }

        public IQueryable GetCopInfo()
        {
            var query = from c in dbContext.CopInfo
                        join u in dbContext.UserInfo on c.UserId equals u.UserId
                        select new
                        {
                            u.Account,
                            u.BankName,
                            c.BAuthentication,
                            c.Bizlicense,
                            u.Chop,
                            u.ChopAuthentication,
                            u.City,
                            u.UserName,
                            c.CopDetail,
                            c.CopId,
                            c.CopName,
                            u.CreateTime,
                            c.HWAuthentication,
                            c.HWPermit,
                            u.IDAuthentication,
                            u.IDCard,
                            u.Province,
                            u.Street,
                            u.MobilePhoneNum,
                            u.Town,
                            u.Audit,
                            u.AuditDate
                        };
            return query;
        }

        public IQueryable GetCopInfodByAddress(string province, string city, string country, string street)
        {
            var query = from c in dbContext.CopInfo
                        join u in dbContext.UserInfo on c.UserId equals  u.UserId
                        select new
                        {
                            u.Account,
                            u.BankName,
                            c.BAuthentication,
                            c.Bizlicense,
                            u.Chop,
                            u.ChopAuthentication,
                            u.City,
                            u.UserName,
                            c.CopDetail,
                            c.CopId,
                            c.CopName,
                            u.CreateTime,
                            c.HWAuthentication,
                            c.HWPermit,
                            u.IDAuthentication,
                            u.IDCard,
                            u.Province,
                            u.Street,
                            u.MobilePhoneNum,
                            u.Town,
                            u.Audit,
                            u.AuditDate
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
