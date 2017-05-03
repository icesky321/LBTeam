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
    }
}
