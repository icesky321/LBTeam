using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class UserInfoDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.UserInfo NewUserInfo(LB.SQLServerDAL.UserInfo userinfo)
        {
            if (userinfo != null)
            {
                dbContext.UserInfo.InsertOnSubmit(userinfo);
                dbContext.SubmitChanges();

            }
            return userinfo;
        }

        public IQueryable<LB.SQLServerDAL.UserInfo> GetUserInfo()
        {
            var query = from c in dbContext.UserInfo
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserInfo>();
        }

        public LB.SQLServerDAL.UserInfo GetUserInfoByUserId(int UserId)
        {
            var query = from c in dbContext.UserInfo
                        where c.UserId == UserId
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.UserInfo>();
        }

        public LB.SQLServerDAL.UserInfo GetUserInfoByTelNum(string TelNum)
        {
            var query = from c in dbContext.UserInfo
                        where c.MobilePhoneNum == TelNum
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.UserInfo>();
        }

        public LB.SQLServerDAL.UserInfo GetUserInfoByAddress(int UserTypeId, string province, string city, string country, string street)
        {
            var query = from c in dbContext.UserInfo
                        where c.UserTypeId == UserTypeId
                        select c;
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
            return query.FirstOrDefault<LB.SQLServerDAL.UserInfo>();
        }


        public IQueryable<LB.SQLServerDAL.UserInfo> GetUserInfoByUserTypeId(int UserTypeId)
        {
            var query = from c in dbContext.UserInfo
                        where c.UserTypeId == UserTypeId
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserInfo>();
        }

        public void DeleteUserInfo(int UserId)
        {
            var query = (from c in dbContext.UserInfo
                         where c.UserId == UserId
                         select c).FirstOrDefault();
            dbContext.UserInfo.DeleteOnSubmit(query);
            dbContext.SubmitChanges();
        }

        public void UpdateUserInfo(LB.SQLServerDAL.UserInfo userinfo)
        {
            dbContext.SubmitChanges();
        }

        public bool ExistUser(string user)
        {
            bool exists = false;
            var query = from u in dbContext.Aspnet_Users
                        where u.UserName == user
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }

        public bool ExistTelNum(string telnum)
        {
            bool exists = false;
            var query = from u in dbContext.UserInfo
                        where u.MobilePhoneNum == telnum
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }

        public string GetPWD(string UserName)
        {
            var query = from u in dbContext.Aspnet_Users
                        where u.UserName == UserName
                        join m in dbContext.Aspnet_Membership on u.UserId equals m.UserId
                        select m;
            return query.AsEnumerable().Last().Password;
        }

        public IQueryable<LB.Model.UserInfoModel> GetUserInfosByAddress(string province, string city, string country, string street, int UserTypeId)
        {
            var query = from u in dbContext.UserInfo
                        join c in dbContext.CopInfo on u.UserId equals c.UserId into leftGroup1
                        from c in leftGroup1.DefaultIfEmpty()
                        where u.UserTypeId == UserTypeId
                        select new LB.Model.UserInfoModel()
                        {
                            Account = u.Account,
                            BankName = u.BankName,
                            BAuthentication = c.BAuthentication == null ? false : c.BAuthentication.Value,
                            Bizlicense = c.Bizlicense,
                            Chop = u.Chop,
                            ChopAuthentication = Convert.ToBoolean(u.ChopAuthentication),
                            City = u.City,
                            UserName = u.UserName,
                            CopDetail = c.CopDetail,
                            CopName = c.CopName,
                            CreateTime = Convert.ToDateTime(u.CreateTime),
                            HWAuthentication = c.HWAuthentication == null ? false : c.HWAuthentication.Value,
                            HWPermit = c.HWPermit,
                            IDAuthentication = u.IDAuthentication == null ? false : u.IDAuthentication.Value,
                            IDCard = u.IDCard,
                            Province = u.Province,
                            Street = u.Street,
                            MobilePhoneNum = u.MobilePhoneNum,
                            Town = u.Town,
                            Audit = u.Audit == null ? false : u.Audit.Value,
                            AuditDate = Convert.ToDateTime(u.AuditDate)
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
            return query.AsQueryable<LB.Model.UserInfoModel>();
        }
    }
}
