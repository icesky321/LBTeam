using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class UserTypeInfo
    {
        LB.SQLServerDAL.UserTypeInfoDA da = new SQLServerDAL.UserTypeInfoDA();

        /// <summary>
        /// 新增用户类别信息
        /// </summary>
        /// <param name="usertypeinfo"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.UserTypeInfo NewUserTypeInfo(LB.SQLServerDAL.UserTypeInfo usertypeinfo)
        {
            return da.NewUserTypeInfo(usertypeinfo);
        }

        /// <summary>
        /// 修改用户类别信息
        /// </summary>
        /// <param name="usertype"></param>
        public void UpdateUserTypeInfo(LB.SQLServerDAL.UserTypeInfo usertype)
        {
            da.UpdateUserTypeInfo(usertype);
        }

        /// <summary>
        /// 获取用户类别列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.UserTypeInfo> GetUserTypeInfo()
        {
            return da.GetUserTypeInfo();
        }

        /// <summary>
        /// 删除用户类别信息
        /// </summary>
        /// <param name="UserTypeId"></param>
        public void DeleteUserTypeInfo(int UserTypeId)
        {
            da.DeleteUserTypeInfo(UserTypeId);
        }

        /// <summary>
        /// 根据ID获取用户类别信息
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.UserTypeInfo GetUserTypeById(int UserTypeId)
        {
            return da.GetUserTypeById(UserTypeId);
        }
    }
}
