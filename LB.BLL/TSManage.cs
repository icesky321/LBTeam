using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class TSManage
    {
        LB.SQLServerDAL.TSInfoDA da = new SQLServerDAL.TSInfoDA();

        public IQueryable<LB.SQLServerDAL.TSInfo> GetTSInfo()
        {
            return da.GetTSInfo();
        }

        /// <summary>
        /// 根据品种代码搜索电瓶
        /// </summary>
        /// <param name="tsCode">品种代码</param>
        /// <returns></returns>
        public LB.SQLServerDAL.TSInfo GetTS_ByCode(string tsCode)
        {
            return da.GetTS_ByCode(tsCode);
        }

    }
}
