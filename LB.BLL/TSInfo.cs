using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class TSInfo
    {
        LB.SQLServerDAL.TSInfoDA da = new SQLServerDAL.TSInfoDA();

        public IQueryable<LB.SQLServerDAL.TSInfo> GetTSInfo()
        {
            return da.GetTSInfo();
        }
    }
}
