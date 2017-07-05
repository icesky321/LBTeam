using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class CF_JD_OrderDetailDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.CF_JD_OrderDetail NewCF_JD_OrderDetail(LB.SQLServerDAL.CF_JD_OrderDetail orderdetail)
        {
            if (orderdetail != null)
            {
                orderdetail.ODId = System.Guid.NewGuid();
                dbContext.CF_JD_OrderDetail.InsertOnSubmit(orderdetail);
                dbContext.SubmitChanges();

            }
            return orderdetail;
        }


        public void UpdateCF_JD_OrderDetail(LB.SQLServerDAL.CF_JD_OrderDetail ordetail)
        {
            dbContext.SubmitChanges();
        }

        public IQueryable<LB.SQLServerDAL.CF_JD_OrderDetail> GetCF_JD_OrderDetailByCFId(Guid CFId)
        {
            var query = from c in dbContext.CF_JD_OrderDetail
                        where c.CFId == CFId
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.CF_JD_OrderDetail>();
        }
    }
}
