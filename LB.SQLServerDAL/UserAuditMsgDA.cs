using System;
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

        public LB.SQLServerDAL.UserAuditMsg GetUserAuditMsgByUserId(int UserId)
        {
            var query = from c in dbContext.UserAuditMsg
                        where c.UserId == UserId
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

        public void DeleteUserAuditMsg(int MsgId)
        {
            var query = (from c in dbContext.UserAuditMsg
                         where c.MsgId == MsgId
                         select c).FirstOrDefault();
            dbContext.UserAuditMsg.DeleteOnSubmit(query);
            dbContext.SubmitChanges();
        }

        public IQueryable GetUserAuditMsgByStatus(bool Status)
        {
            var query = from c in dbContext.UserAuditMsg
                        join u in dbContext.UserInfo on c.UserId equals u.UserId
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
                            c.Status
                        };
            return query;
        }

    }
}
