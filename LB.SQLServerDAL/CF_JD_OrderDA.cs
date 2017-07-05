using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class CF_JD_OrderDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.CF_JD_Order NewCF_JD_Order(LB.SQLServerDAL.CF_JD_Order order)
        {
            if (order != null)
            {
                order.CFId = System.Guid.NewGuid();
                dbContext.CF_JD_Order.InsertOnSubmit(order);
                dbContext.SubmitChanges();

            }
            return order;
        }

        public void UpdateCF_JD_Order(LB.SQLServerDAL.CF_JD_Order order)
        {
            dbContext.SubmitChanges();
        }

        public IQueryable<LB.SQLServerDAL.CF_JD_Order> GetCF_JD_Order_ByInUserId(int InUserId)
        {
            var query = from c in dbContext.CF_JD_Order
                        where c.InUserId == InUserId
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.CF_JD_Order>();
        }
    }
}
