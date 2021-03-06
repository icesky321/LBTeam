﻿using System;
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

        public LB.SQLServerDAL.CF_JD_Order GetCF_JD_OrderById(Guid id)
        {
            var query = from c in dbContext.CF_JD_Order
                        where c.CFId == id
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.CF_JD_Order>();
        }

        public LB.SQLServerDAL.CF_JD_Order GetCF_JD_OrderByinfoId(Guid InfoId)
        {
            var query = from c in dbContext.CF_JD_Order
                        where c.InfoId == InfoId
                        select c;
            return query.FirstOrDefault<LB.SQLServerDAL.CF_JD_Order>();
        }

        public IQueryable<LB.SQLServerDAL.CF_JD_Order> GetCF_JD_Order_ByInUserId(int InUserId)
        {
            var query = from c in dbContext.CF_JD_Order
                        where c.InUserId == InUserId
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.CF_JD_Order>();
        }

        public IQueryable<LB.SQLServerDAL.CF_JD_Order> GetCF_JD_Order_ByAudit(bool Audit)
        {
            var query = from c in dbContext.CF_JD_Order
                        where c.Audit == Audit
                        select c;
            return query.AsQueryable<LB.SQLServerDAL.CF_JD_Order>();
        }

        public bool ExistInfoId(Guid InfoId)
        {
            bool exists = false;
            var query = from u in dbContext.CF_JD_Order
                        where u.InfoId == InfoId
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }

        public void DeleteCF_JD_OrderByCFId(Guid CFId)
        {
            var query = from s in dbContext.CF_JD_Order
                        where s.CFId == CFId
                        select s;
            foreach (var para in query)
            {
                dbContext.CF_JD_Order.DeleteOnSubmit(para);
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
    }
}
