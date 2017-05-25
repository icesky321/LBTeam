using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class UserNoticeInfo
    {
        LB.SQLServerDAL.UserNoticeInfoDA da = new SQLServerDAL.UserNoticeInfoDA();

        public LB.SQLServerDAL.UserNoticeInfo NewUserNoticeInfo(LB.SQLServerDAL.UserNoticeInfo usernoticeinfo)
        {
            return da.NewUserNoticeInfo(usernoticeinfo);
        }

        public void DeleteUserNoticeInfo(int NoticeId)
        {
            da.DeleteUserNoticeInfo(NoticeId);
        }

        public void UpdateUserNoticeInfo(LB.SQLServerDAL.UserNoticeInfo UserNoticeInfo)
        {
            da.UpdateUserNoticeInfo(UserNoticeInfo);
        }

        public IQueryable<LB.SQLServerDAL.UserNoticeInfo> GetUserNoticeInfo()
        {
            return da.GetUserNoticeInfo();
        }
    }
}
