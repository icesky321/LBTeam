using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{

    public class UserManage
    {
        LB.SQLServerDAL.UserInfoDA da = new SQLServerDAL.UserInfoDA();


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
        public int GetUserSum()
        {
            return da.GetUserSum();
        }

        /// <summary>
        /// 获取已认证并登记进微信企业号中的人员数。
        /// </summary>
        /// <returns></returns>
        public int GetIsQYUser_Sum()
        {
            return da.GetIsQYUser_Sum();
        }

        #endregion

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.UserInfo NewUserInfo(LB.SQLServerDAL.UserInfo userinfo)
        {
            return da.NewUserInfo(userinfo);
        }

        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.UserInfo> GetUserInfo()
        {
            return da.GetUserInfo();
        }
        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.UserInfo GetUserInfoByUserId(int UserId)
        {
            return da.GetUserInfoByUserId(UserId);
        }

        public LB.SQLServerDAL.UserInfo GetUserInfoByTelNum(string TelNum)
        {
            return da.GetUserInfoByTelNum(TelNum);
        }

        /// <summary>
        /// 根据用户类型获取用户信息
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.UserInfo> GetUserInfoByUserTypeId(int UserTypeId)
        {
            return da.GetUserInfoByUserTypeId(UserTypeId);
        }

        /// <summary>
        /// 根据ID删除用户信息
        /// </summary>
        /// <param name="UserId"></param>
        public void DeleteUserInfo(int UserId)
        {
            da.DeleteUserInfo(UserId);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userinfo"></param>
        public void UpdateUserInfo(LB.SQLServerDAL.UserInfo userinfo)
        {
            da.UpdateUserInfo(userinfo);
        }
        public bool ExistUser(string user)
        {
            return da.ExistUser(user);
        }

        public bool ExistTelNum(string telnum)
        {
            return da.ExistTelNum(telnum);
        }

        public string GetPWD(string UserName)
        {
            return da.GetPWD(UserName);
        }

        public LB.SQLServerDAL.UserInfo GetUserInfoByAddress(int UserTypeId, string province, string city, string country, string street)
        {
            return da.GetUserInfoByAddress(UserTypeId, province, city, country, street);
        }

        public IQueryable<LB.Model.UserInfoModel> GetUserInfosBySEO(string province, string city, string country, string street, string UserTypeId, string TelNum)
        {
            return da.GetUserInfosBySEO(province, city, country, street, UserTypeId, TelNum);
        }

        /// <summary>
        /// 获取新的QYUserId。
        /// </summary>
        /// <returns></returns>
        public string GenerateNewQYUserId()
        {
            int lastQYUserId = 0;
            lastQYUserId = SQLServerDAL.CodeDA.GetLastQYUserId();

            return (lastQYUserId + 1).ToString();
        }
    }
}
