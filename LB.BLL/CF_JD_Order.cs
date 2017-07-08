﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class CF_JD_Order
    {
        LB.SQLServerDAL.CF_JD_OrderDA da = new SQLServerDAL.CF_JD_OrderDA();

        public LB.SQLServerDAL.CF_JD_Order NewCF_JD_Order(LB.SQLServerDAL.CF_JD_Order order)
        {
            return da.NewCF_JD_Order(order);
        }

        public void UpdateCF_JD_Order(LB.SQLServerDAL.CF_JD_Order order)
        {
            da.UpdateCF_JD_Order(order);
        }

        public IQueryable<LB.SQLServerDAL.CF_JD_Order> GetCF_JD_Order_ByInUserId(int InUserId)
        {
            return da.GetCF_JD_Order_ByInUserId(InUserId);
        }
    }
}