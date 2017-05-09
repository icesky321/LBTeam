using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class CopInfo
    {
        LB.SQLServerDAL.CopInfoDA da = new SQLServerDAL.CopInfoDA();

        public LB.SQLServerDAL.CopInfo NewCopInfo(LB.SQLServerDAL.CopInfo copifo)
        {
            return da.NewCopInfo(copifo);
        }

        public LB.SQLServerDAL.CopInfo GetCopInfoeById(int id)
        {
            return da.GetCopInfoeById(id);
        }

        public LB.SQLServerDAL.CopInfo GetCopInfoeByUserId(int UserId)
        {
            return da.GetCopInfoeByUserId(UserId);
        }

        public void UpdateCopInfo(LB.SQLServerDAL.CopInfo CopInfo)
        {
            da.UpdateCopInfo(CopInfo);
        }

        public IQueryable GetCopInfo()
        {
            return da.GetCopInfo();
        }

        public IQueryable GetCopInfodByAddress(string province, string city, string country, string street, int UserTypeId)
        {
            return da.GetCopInfodByAddress(province, city, country, street, UserTypeId);
        }
    }
}
