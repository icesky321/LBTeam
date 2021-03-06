﻿using System;
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

        public bool ExistCFId(Guid CFId)
        {
            bool exists = false;
            var query = from u in dbContext.CF_JD_OrderDetail
                        where u.CFId == CFId
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }


        public void DeleteCF_JD_OrderDetailByCFId(Guid CFId)
        {
            var query = from s in dbContext.CF_JD_OrderDetail
                        where s.CFId == CFId
                        select s;
            foreach (var para in query)
            {
                dbContext.CF_JD_OrderDetail.DeleteOnSubmit(para);
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
