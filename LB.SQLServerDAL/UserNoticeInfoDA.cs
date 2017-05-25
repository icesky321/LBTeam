﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class UserNoticeInfoDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.UserNoticeInfo NewUserNoticeInfo(LB.SQLServerDAL.UserNoticeInfo usernoticeinfo)
        {
            if (usernoticeinfo != null)
            {
                dbContext.UserNoticeInfo.InsertOnSubmit(usernoticeinfo);
                dbContext.SubmitChanges();

            }
            return usernoticeinfo;
        }

        public void DeleteUserNoticeInfo(int NoticeId)
        {
            var query = (from c in dbContext.UserNoticeInfo
                         where c.NoticeId == NoticeId
                         select c).FirstOrDefault();
            dbContext.UserNoticeInfo.DeleteOnSubmit(query);
            dbContext.SubmitChanges();
        }

        public void UpdateUserNoticeInfo(LB.SQLServerDAL.UserNoticeInfo UserNoticeInfo)
        {
            dbContext.SubmitChanges();
        }

        public IQueryable<LB.SQLServerDAL.UserNoticeInfo> GetUserNoticeInfo()
        {
            var query = from c in dbContext.UserNoticeInfo
                        orderby c.CreateDate descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserNoticeInfo>();
        }
    }
}
