using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class UserDepositInfo
    {
        LB.SQLServerDAL.UserDepositInfoDA da = new SQLServerDAL.UserDepositInfoDA();

        public IQueryable<LB.SQLServerDAL.UserDepositInfo> GetUserDepositInfo()
        {
            return da.GetUserDepositInfo();
        }
        public LB.SQLServerDAL.UserDepositInfo NewUserDepositInfo(LB.SQLServerDAL.UserDepositInfo userdepositinfo)
        {
            return da.NewUserDepositInfo(userdepositinfo);
        }

        public LB.SQLServerDAL.UserDepositInfo GetUserDepositInfoByUserId(int UserId)
        {
            return da.GetUserDepositInfoByUserId(UserId);
        }

        public void UpdateUserDepositInfo(LB.SQLServerDAL.UserDepositInfo userdepositinfo)
        {
            da.UpdateUserDepositInfo(userdepositinfo);
        }

        public void DeleteUserDepositInfo(int UserId)
        {
            da.DeleteUserDepositInfo(UserId);
        }

        public bool ExistUserId(int UserId)
        {
            return da.ExistUserId(UserId);
        }
    }
}
