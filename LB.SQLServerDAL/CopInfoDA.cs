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
                            u.RealName,
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

        public IQueryable GetCopInfodByAddress(string province, string city, string country, string street,int UserTypeId)
        {
            var query = from c in dbContext.CopInfo
                        join u in dbContext.UserInfo on c.UserId equals u.UserId
                        where u.UserTypeId == UserTypeId
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
                            u.RealName,
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
            if (province != "---" && province != "-1")
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

        public IQueryable GetCopInfoByUserType(int UserTypeId)
        {
            var query = from c in dbContext.CopInfo
                        join u in dbContext.UserInfo on c.UserId equals u.UserId
                        where u.UserTypeId == UserTypeId orderby u.CreateTime descending
                        select new
                        {
                            u.Account,
                            u.BankName,
                            c.BAuthentication,
                            c.Bizlicense,
                            u.Chop,
                            u.ChopAuthentication,
                            u.City,
                            u.RealName,
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

        public bool ExistUseId(int UseId)
        {
            bool exists = false;
            var query = from u in dbContext.CopInfo
                        where u.UserId == UseId
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }

        public IQueryable<LB.SQLServerDAL.CopInfo> GetCopInfosByUserType(int UserType)
        {
            var query = from c in dbContext.CopInfo
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.CopInfo>();
        }

        public IQueryable GetCopInfoByUserType_RegionCode_TelNum(int UserTypeId,string RegionCode,string TelNum)
        {
            var query = from c in dbContext.CopInfo
                        join u in dbContext.UserInfo on c.UserId equals u.UserId
                        where u.UserTypeId == UserTypeId
                        orderby u.CreateTime descending
                        select new
                        {
                            u.Account,
                            u.BankName,
                            c.BAuthentication,
                            c.Bizlicense,
                            u.Chop,
                            u.ChopAuthentication,
                            u.City,
                            u.RealName,
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
                            u.AuditDate,
                            u.RegionCode
                        };
            if (!string.IsNullOrEmpty(RegionCode))
            {
                query = query.Where(p => p.RegionCode.StartsWith(RegionCode));
            }
            if (!string.IsNullOrEmpty(TelNum))
            {
                query = query.Where(p => p.MobilePhoneNum.IndexOf(TelNum) >= 0);
            }
            return query;
        }
    }
}
