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

        public void DeleteUserNoticeInfo(int noticeId)
        {
            var query = from s in dbContext.UserNoticeInfo
                        where s.NoticeId == noticeId
                        select s;
            foreach (var para in query)
            {
                dbContext.UserNoticeInfo.DeleteOnSubmit(para);
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

        public void UpdateUserNoticeInfo(LB.SQLServerDAL.UserNoticeInfo UserNoticeInfo)
        {
            dbContext.SubmitChanges();
        }

        public IQueryable<LB.SQLServerDAL.UserNoticeInfo> GetUserNoticeInfoByAudit(bool Audit)
        {
            var query = from c in dbContext.UserNoticeInfo
                        orderby c.CreateDate descending
                        where c.Audit == Audit
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserNoticeInfo>();
        }

        public LB.SQLServerDAL.UserNoticeInfo GetUserNoticeInfoByNoticeId(int NoticeId)
        {
            var query = from c in dbContext.UserNoticeInfo
                        where c.NoticeId == NoticeId
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.UserNoticeInfo>();
        }

    }
}
