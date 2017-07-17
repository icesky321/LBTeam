using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class StaffManage
    {
        LB.SQLServerDAL.StaffDA da = new SQLServerDAL.StaffDA();

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            da.Dispose();
        }

        #region 用户数统计
        /// <summary>
        /// 获取用户总数
        /// </summary>
        /// <returns></returns>
        public int GetStaffSum()
        {
            return da.GetStaffSum();
        }


        #endregion

        public LB.SQLServerDAL.Staff CreateStaff(LB.SQLServerDAL.Staff user)
        {
            return da.CreateStaff(user);
        }

        /// <summary>
        /// 获取所有平台员工
        /// </summary>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.Staff> GetStaff()
        {
            return da.GetStaff();
        }

        /// <summary>
        /// 根据StaffId获取员工对象
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.Staff GetStaffByStaffId(Guid staffId)
        {
            return da.GetStaffByStaffId(staffId);
        }

        /// <summary>
        /// 根据手机号获取员工对象
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.Staff GetStaffByMobile(string mobile)
        {
            return da.GetStaffByMobile(mobile);
        }


        public void DeleteStaff(Guid staffId)
        {
            da.DeleteStaff(staffId);
        }

        public void UpdateStaff(LB.SQLServerDAL.Staff user)
        {
            da.UpdateStaff(user);
        }

        public bool ExistUser(string user)
        {
            return da.ExistUser(user);
        }

        public bool ExistMobile(string mobileNum)
        {
            return da.ExistMobile(mobileNum);
        }

    }
}
