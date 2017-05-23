using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class UserAuditMsg
    {
        LB.SQLServerDAL.UserAuditMsgDA da = new SQLServerDAL.UserAuditMsgDA();

        public LB.SQLServerDAL.UserAuditMsg NewUserAuditMsg(LB.SQLServerDAL.UserAuditMsg userauditmsg)
        {
            return da.NewUserAuditMsg(userauditmsg);
        }

        public IQueryable<LB.SQLServerDAL.UserAuditMsg> GetUserAuditMsg()
        {
            return da.GetUserAuditMsg();
        }

        public void UpdateUserAuditMsg(LB.SQLServerDAL.UserAuditMsg userauditmsg)
        {
            da.UpdateUserAuditMsg(userauditmsg);
        }

        public LB.SQLServerDAL.UserAuditMsg GetUserAuditMsgByUserId(int UserId)
        {
            return da.GetUserAuditMsgByUserId(UserId);
        }

        public LB.SQLServerDAL.UserAuditMsg GetUserAuditMsgByMsgId(int MsgId)
        {
            return da.GetUserAuditMsgByMsgId(MsgId);
        }
        public void DeleteUserAuditMsg(int MsgId)
        {
            da.DeleteUserAuditMsg(MsgId);
        }

        public IQueryable GetUserAuditMsgByStatus(bool Status)
        {
            return da.GetUserAuditMsgByStatus(Status);
        }
    }
}
