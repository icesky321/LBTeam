using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class SellInfoManage
    {
        LB.SQLServerDAL.SellInfoDA da = new SQLServerDAL.SellInfoDA();

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            da.Dispose();
        }



        /// <summary>
        /// 帮帮忙供需数统计
        /// </summary>
        /// <returns></returns>
        public int GetSellInfoSum()
        {
            return da.GetSellInfoSum();
        }

        /// <summary>
        /// 创建出售信息。
        /// </summary>
        /// <param name="sellInfo"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.SellInfo CreateSellInfo(LB.SQLServerDAL.SellInfo sellInfo)
        {
            return da.CreateSellInfo(sellInfo);
        }

        /// <summary>
        /// 根据用户登录账户搜索用户自己发布的出售信息。
        /// </summary>
        /// <param name="userMobile">用户手机号</param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetSellInfo_ByUserMobile(string userMobile)
        {
            return da.GetSellInfo_ByUserMobile(userMobile);
        }

        /// <summary>
        /// 根据客服处理标记搜索出售信息。
        /// </summary>
        /// <param name="kefuToHandleTag">客服处理标记。</param>
        /// <returns></returns>
        public IQueryable GetSellInfo_ByKefuTohandleTag(bool kefuToHandleTag)
        {
            return da.GetSellInfo_ByKefuTohandleTag(kefuToHandleTag);
        }

        /// <summary>
        /// 根据客服处理标记搜索出售信息。
        /// </summary>
        /// <param name="kefuToHandleTag">客服处理标记。</param>
        /// <returns></returns>
        public IQueryable GetSellInfo_ByJDTohandleTag(bool jdTohandleTag)
        {
            return da.GetSellInfo_ByJDTohandleTag(jdTohandleTag);
        }




        public void UpdateSellInfo(LB.SQLServerDAL.SellInfo sellInfo)
        {
            da.UpdateSellInfo(sellInfo);
        }

        /// <summary>
        /// 删除出售信息。
        /// </summary>
        /// <param name="infoId"></param>
        public void DeleteSellInfo(Guid infoId)
        {
            da.DeleteSellInfo(infoId);
        }

    }
}
