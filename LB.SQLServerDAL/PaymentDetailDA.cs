using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class PaymentDetailDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.PaymentDetail newPaymentDetail(LB.SQLServerDAL.PaymentDetail paydetail)
        {
            if (paydetail != null)
            {
                paydetail.PDId = System.Guid.NewGuid();
                dbContext.PaymentDetail.InsertOnSubmit(paydetail);
                dbContext.SubmitChanges();

            }
            return paydetail;
        }

        public void UpdatePaymentDetail(LB.SQLServerDAL.PaymentDetail paydetail)
        {
            dbContext.SubmitChanges();
        }

        public decimal GetAmountSumByUserId(int UserId)
        {
            decimal total = Convert.ToDecimal(dbContext.PaymentDetail.Where(a => a.UserId == UserId).ToList().Sum(a => a.Amount));
            return total;
        }

        public decimal GetWaitAmountSumByUserId(int UserId)
        {
            decimal total = Convert.ToDecimal(dbContext.PaymentDetail.Where(a => a.UserId == UserId && a.PayStatus== "待审核").ToList().Sum(a => a.Amount));
            return total;
        }

        public bool ExistUserId(int UserId)
        {
            bool exists = false;
            var query = from u in dbContext.PaymentDetail
                        where u.UserId == UserId
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }

        public LB.SQLServerDAL.PaymentDetail GetPaymentDetailByPDId(Guid PDId)
        {
            var query = from c in dbContext.PaymentDetail
                        where c.PDId == PDId
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.PaymentDetail>();
        }
    }
}
