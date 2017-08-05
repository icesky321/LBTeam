using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
   public  class CF_JD_OrderDetail
    {
        LB.SQLServerDAL.CF_JD_OrderDetailDA da = new SQLServerDAL.CF_JD_OrderDetailDA();

        public LB.SQLServerDAL.CF_JD_OrderDetail NewCF_JD_OrderDetail(LB.SQLServerDAL.CF_JD_OrderDetail orderdetail)
        {
            return da.NewCF_JD_OrderDetail(orderdetail);
        }

        public void UpdateCF_JD_OrderDetail(LB.SQLServerDAL.CF_JD_OrderDetail ordetail)
        {
            da.UpdateCF_JD_OrderDetail(ordetail);
        }

        public IQueryable<LB.SQLServerDAL.CF_JD_OrderDetail> GetCF_JD_OrderDetailByCFId(Guid CFId)
        {
            return da.GetCF_JD_OrderDetailByCFId(CFId);
        }

        public bool ExistCFId(Guid CFId)
        {
            return da.ExistCFId(CFId);
        }
    }
}
