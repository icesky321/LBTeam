using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class StaffDA : IDisposable
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

        ~StaffDA()
        {
            this.Dispose();
        }

        #region 用户数统计
        /// <summary>
        /// 获取用户总数
        /// </summary>
        /// <returns></returns>
        public int GetStaffSum()
        {
            return dbContext.Staff.Count();
        }


        #endregion

        public LB.SQLServerDAL.Staff CreateStaff(LB.SQLServerDAL.Staff user)
        {
            if (user != null)
            {
                user.StaffId = Guid.NewGuid();
                user.CreateTime = System.DateTime.Now;
                dbContext.Staff.InsertOnSubmit(user);
                dbContext.SubmitChanges();

            }
            return user;
        }

        /// <summary>
        /// 获取所有平台员工
        /// </summary>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.Staff> GetStaff()
        {
            var query = from c in dbContext.Staff
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.Staff>();
        }

        /// <summary>
        /// 根据StaffId获取员工对象
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.Staff GetStaffByStaffId(Guid staffId)
        {
            var query = from c in dbContext.Staff
                        where c.StaffId == staffId
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.Staff>();
        }

        /// <summary>
        /// 根据手机号获取员工对象
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.Staff GetStaffByMobile(string mobile)
        {
            var query = from c in dbContext.Staff
                        where c.MobileNum == mobile
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.Staff>();
        }


        public void DeleteStaff(Guid staffId)
        {
            var query = (from c in dbContext.Staff
                         where c.StaffId == staffId
                         select c).FirstOrDefault();
            dbContext.Staff.DeleteOnSubmit(query);
            dbContext.SubmitChanges();
        }

        public void UpdateStaff(LB.SQLServerDAL.Staff user)
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

        public bool ExistMobile(string mobileNum)
        {
            bool exists = false;
            var query = from u in dbContext.Staff
                        where u.MobileNum == mobileNum
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }


    }
}
