using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class UnitInfo
    {
        LB.SQLServerDAL.UnitInfoDA da = new SQLServerDAL.UnitInfoDA();

        public IQueryable<LB.SQLServerDAL.UnitInfo> GetUnitInfo()
        {
            return da.GetUnitInfo();
        }
    }
}
