using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class UserInfoDA : IDisposable
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }

            GC.SuppressFinalize(this);
        }

        ~UserInfoDA()
        {
            this.Dispose();
        }

        #region 用户数统计
        /// <summary>
        /// 获取用户总数
        /// </summary>
        /// <returns></returns>
        public int GetUserSum()
        {
            return dbContext.UserInfo.Count();
        }

        /// <summary>
        /// 获取已认证并登记进微信企业号中的人员数。
        /// </summary>
        /// <returns></returns>
        public int GetIsQYUser_Sum()
        {
            return dbContext.UserInfo.Where(o => o.IsQYUser == true).Count();
        }

        /// <summary>
        /// 获取指定地级市的回收公司个数
        /// </summary>
        /// <param name="city">地级市</param>
        /// <returns></returns>
        public int GetCount_HS_InCity(string cityRegionCode)
        {
            if (string.IsNullOrWhiteSpace(cityRegionCode) || cityRegionCode.Length < 4)
                return 0;

            string cityShortCode = cityRegionCode.Substring(0, 4);
            return dbContext.UserInfo.Where(c => c.UserTypeId == 2 && c.Audit == true && c.RegionCode.Length >= 4 && c.RegionCode.Substring(0, 4) == cityShortCode).Count();
        }

        /// <summary>
        /// 获取指定街道的产废单位个数
        /// </summary>
        /// <param name="streetRegionCode">街道区划代号</param>
        /// <returns></returns>
        public int GetCount_CF_InStreet(string streetRegionCode)
        {
            string shortRegionCode = streetRegionCode.Substring(0, 9);
            return dbContext.UserInfo.Where(c => c.UserTypeId == 1 && c.RegionCode.Substring(0, 9) == shortRegionCode).Count();
        }

        /// <summary>
        /// 获取指定区县下的回收业务员个数
        /// </summary>
        /// <param name="countyRegionCode">区县代号</param>
        /// <returns></returns>
        public int GetCount_CF_InCounty(string countyRegionCode)
        {
            string shortRegionCode = countyRegionCode.Substring(0, 6);
            return dbContext.UserInfo.Where(c => c.UserTypeId == 1 && c.RegionCode.Substring(0, 6) == shortRegionCode).Count();
        }

        #endregion

        public LB.SQLServerDAL.UserInfo NewUserInfo(LB.SQLServerDAL.UserInfo userinfo)
        {
            if (userinfo != null)
            {
                userinfo.CreateTime = System.DateTime.Now;
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

        /// <summary>
        /// 获取没有地域代号，但有地域信息的人员
        /// <para>仅供后台数据维护使用</para>
        /// </summary>
        /// <returns></returns>
        public LB.SQLServerDAL.UserInfo GetUser_NotRegionCode()
        {
            var query = from c in dbContext.UserInfo
                        where c.RegionCode == "" && c.Province != "-1"
                        orderby c.Province, c.City, c.Town, c.Street
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.UserInfo>();
        }

        public LB.SQLServerDAL.UserInfo GetUserInfoByAddress(int UserTypeId, string province, string city, string country, string street)
        {
            var query = from c in dbContext.UserInfo
                        where c.UserTypeId == UserTypeId
                        select c;
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
            return query.FirstOrDefault<LB.SQLServerDAL.UserInfo>();
        }

        /// <summary>
        /// 查询指定地级市下的回收公司
        /// </summary>
        /// <param name="cityRegionCode">地级市12位数代码</param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.UserInfo> GetUserInfo_HS_InCity(string cityRegionCode)
        {
            if (string.IsNullOrWhiteSpace(cityRegionCode) || cityRegionCode.Length < 4)
                return null;

            string cityShortCode = cityRegionCode.Substring(0, 4);
            var query = from c in dbContext.UserInfo
                        where c.UserTypeId == 2 && c.RegionCode.Length >= 4 && c.RegionCode.Substring(0, 4) == cityShortCode && c.Audit == true
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserInfo>();
        }

        /// <summary>
        /// 查询全国所有已经过企业认证的回收公司
        /// </summary>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.UserInfo> GetUserInfo_AllHS_CopCertified()
        {
            var query = from c in dbContext.UserInfo
                        where c.UserTypeId == 2 && c.CopCertified == true && c.Audit == true
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserInfo>();
        }

        /// <summary>
        /// 查询指定地级市下的街道回收员
        /// </summary>
        /// <param name="cityRegionCode">地级市12位数代码</param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.UserInfo> GetUserInfo_JD_InCity(string cityRegionCode)
        {
            string cityShortCode = cityRegionCode.Substring(0, 4);
            var query = from c in dbContext.UserInfo
                        where c.UserTypeId == 5 && !string.IsNullOrWhiteSpace(c.RegionCode) && c.RegionCode.Substring(0, 4) == cityShortCode
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserInfo>();
        }

        /// <summary>
        /// 查询指定街道的街道回收员
        /// </summary>
        /// <param name="streetRegionCode">街道12位数代码</param>
        /// <returns></returns>
        public LB.SQLServerDAL.UserInfo GetUserInfo_JD_InStreet(string streetRegionCode)
        {
            var query = from c in dbContext.UserInfo
                        where c.UserTypeId == 5 && c.RegionCode == streetRegionCode
                        select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 查询指定街道下的产废单位
        /// </summary>
        /// <param name="streetRegionCode">街道行政区划代号</param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.UserInfo> GetUserInfo_InStreet(string streetRegionCode)
        {
            string shortRegionCode = streetRegionCode.Substring(0, 9);
            var query = from c in dbContext.UserInfo
                        where c.UserTypeId == 1 && c.RegionCode.Substring(0, 9) == shortRegionCode
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserInfo>();
        }


        public IQueryable<LB.SQLServerDAL.UserInfo> GetUserInfoByUserTypeId(int UserTypeId)
        {
            var query = from c in dbContext.UserInfo
                        where c.UserTypeId == UserTypeId
                        orderby c.CreateTime descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserInfo>();
        }

        public void DeleteUserInfo(int UserId)
        {
            var query = from s in dbContext.UserInfo
                        where s.UserId == UserId
                        select s;
            foreach (var para in query)
            {
                dbContext.UserInfo.DeleteOnSubmit(para);
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

        /// <summary>
        /// 根据手机号码删除用户对象
        /// </summary>
        /// <param name="mobileNum">用户手机号码</param>
        public void DeleteUserInfo(string mobileNum)
        {
            var query = from s in dbContext.UserInfo
                        where s.MobilePhoneNum == mobileNum
                        select s;
            foreach (var para in query)
            {
                dbContext.UserInfo.DeleteOnSubmit(para);
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


        /// <summary>
        /// 根据人员类别查询企业号里的用户
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.UserInfo> GetUserInfosByQY(int UserTypeId)
        {
            var query = from u in dbContext.UserInfo
                        where u.IsQYUser == true && u.UserTypeId == UserTypeId
                        select u;
            return query.AsQueryable<LB.SQLServerDAL.UserInfo>();

        }

        public IQueryable<LB.Model.UserInfoModel> GetUserInfosBySEO(string province, string city, string country, string street, string UserTypeId, string TelNum)
        {
            var query = from u in dbContext.UserInfo
                        join c in dbContext.CopInfo on u.UserId equals c.UserId into leftGroup1
                        from c in leftGroup1.DefaultIfEmpty()
                        join a in dbContext.Aspnet_Users on u.MobilePhoneNum equals a.UserName into leftGroup2
                        from a in leftGroup2.DefaultIfEmpty()
                        join b in dbContext.Aspnet_Membership on a.UserId equals b.UserId into leftGroup3
                        from b in leftGroup3.DefaultIfEmpty()
                        orderby u.CreateTime descending
                        select new LB.Model.UserInfoModel()
                        {
                            UserId = u.UserId,
                            Account = u.Account,
                            BankName = u.BankName,
                            BAuthentication = c.BAuthentication == null ? false : c.BAuthentication.Value,
                            Bizlicense = c.Bizlicense,
                            City = u.City,
                            UserName = u.UserName,
                            CopDetail = c.CopDetail,
                            CopName = c.CopName,
                            RealName = u.RealName,
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
                            UserTypeId = Convert.ToInt32(u.UserTypeId),
                            AuditDate = u.AuditDate == null ? Convert.ToDateTime("1900-1-1") : u.AuditDate.Value
                            //IsApproved = Convert.ToBoolean(b.IsApproved)
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
            if (!string.IsNullOrEmpty(UserTypeId))
            {
                query = query.Where(p => p.UserTypeId == Convert.ToInt32(UserTypeId));
            }
            if (!string.IsNullOrEmpty(TelNum))
            {
                query = query.Where(p => p.MobilePhoneNum.Contains(TelNum));
            }
            return query.AsQueryable<LB.Model.UserInfoModel>();
        }
    }
}
