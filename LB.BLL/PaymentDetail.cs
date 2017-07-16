using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class PaymentDetail
    {
        LB.SQLServerDAL.PaymentDetailDA da = new SQLServerDAL.PaymentDetailDA();
        public LB.SQLServerDAL.PaymentDetail newPaymentDetail(LB.SQLServerDAL.PaymentDetail paydetail)
        {
            return da.newPaymentDetail(paydetail);

        }

        public void UpdatePaymentDetail(LB.SQLServerDAL.PaymentDetail paydetail)
        {
            da.UpdatePaymentDetail(paydetail);
        }

        public decimal GetAmountSumByUserId(int UserId)
        {
            return da.GetAmountSumByUserId(UserId);
        }
        public bool ExistUserId(int UserId)
        {
            return da.ExistUserId(UserId);
        }

        public decimal GetWaitAmountSumByUserId(int UserId)
        {
            return da.GetWaitAmountSumByUserId(UserId);
        }

        public LB.SQLServerDAL.PaymentDetail GetPaymentDetailByPDId(Guid PDId)
        {
            return da.GetPaymentDetailByPDId(PDId);
        }

    }
}
