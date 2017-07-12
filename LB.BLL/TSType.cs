using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class TSType
    {
        LB.SQLServerDAL.TSTypeDA da = new SQLServerDAL.TSTypeDA();
        public IQueryable<LB.SQLServerDAL.TSType> GetTSType()
        {
            return da.GetTSType();
        }

       
    }
}
