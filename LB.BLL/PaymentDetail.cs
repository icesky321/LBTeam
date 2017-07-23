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

       /// <summary>
       /// 该用户已到款的金额
       /// </summary>
       /// <param name="UserId"></param>
       /// <returns></returns>
        public decimal GetAmountSumByUserId(int UserId)
        {
            return da.GetAmountSumByUserId(UserId);
        }
        public bool ExistUserId(int UserId)
        {
            return da.ExistUserId(UserId);
        }

        public bool ExistCFId(Guid CFId)
        {
            return da.ExistCFId(CFId);
        }

        /// <summary>
        /// 该用户在途资产
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public decimal GetWaitAmountSumByUserId(int UserId)
        {
            return da.GetWaitAmountSumByUserId(UserId);
        }

        /// <summary>
        /// 该用户已结清的金额
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public decimal GetOverAmountSumByUserId(int UserId)
        {
            return da.GetOverAmountSumByUserId(UserId);
        }

        public LB.SQLServerDAL.PaymentDetail GetPaymentDetailByPDId(Guid PDId)
        {
            return da.GetPaymentDetailByPDId(PDId);
        }

        public LB.SQLServerDAL.PaymentDetail GetPaymentDetailByCFId(Guid CFId)
        {
            return da.GetPaymentDetailByCFId(CFId);
        }

    }
}
