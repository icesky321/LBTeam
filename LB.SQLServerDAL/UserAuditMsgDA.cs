﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class UserAuditMsgDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.UserAuditMsg NewUserAuditMsg(LB.SQLServerDAL.UserAuditMsg userauditmsg)
        {
            if (userauditmsg != null)
            {
                dbContext.UserAuditMsg.InsertOnSubmit(userauditmsg);
                dbContext.SubmitChanges();

            }
            return userauditmsg;
        }

        public IQueryable<LB.SQLServerDAL.UserAuditMsg> GetUserAuditMsg()
        {
            var query = from c in dbContext.UserAuditMsg
                        orderby c.MsgId descending
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.UserAuditMsg>();
        }

        public void UpdateUserAuditMsg(LB.SQLServerDAL.UserAuditMsg userauditmsg)
        {
            dbContext.SubmitChanges();
        }

        public LB.SQLServerDAL.UserAuditMsg GetUserAuditMsgByUserId(int UserId, bool Status)
        {
            var query = from c in dbContext.UserAuditMsg
                        where c.UserId == UserId && c.Status == Status
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.UserAuditMsg>();
        }

        public LB.SQLServerDAL.UserAuditMsg GetUserAuditMsgByMsgId(int MsgId)
        {
            var query = from c in dbContext.UserAuditMsg
                        where c.MsgId == MsgId
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.UserAuditMsg>();
        }

        public void DeleteUserAuditMsg(int msgId)
        {
            var query = from s in dbContext.UserAuditMsg
                        where s.MsgId == msgId
                        select s;
            foreach (var para in query)
            {
                dbContext.UserAuditMsg.DeleteOnSubmit(para);
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

        public IQueryable GetUserAuditMsgByStatus(bool Status)
        {
            var query = from c in dbContext.UserAuditMsg
                        join u in dbContext.UserInfo on c.UserId equals u.UserId
                        join t in dbContext.UserTypeInfo on u.UserTypeId equals t.UserTypeId
                        where c.Status == Status
                        select new
                        {
                            u.UserId,
                            u.UserName,
                            u.MobilePhoneNum,
                            u.Town,
                            u.Audit,
                            u.AuditDate,
                            c.Ammount,
                            c.AccountName,
                            c.Account,
                            c.Message,
                            c.CreateDate,
                            c.Status,
                            t.UserTypeName
                        };
            return query;
        }

    }
}
