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
        /// 获取客服待审核记录数
        /// </summary>
        /// <returns></returns>
        public int GetCount_KefuTohandle()
        {
            return da.GetCount_KefuTohandle();
        }

        /// <summary>
        /// 获取街道回收员待办回收信息
        /// </summary>
        /// <param name="jd_UserId">街道回收员UserId</param>
        /// <returns></returns>
        public int GetCount_JDTohandle(int jd_UserId)
        {
            return da.GetCount_JDTohandle(jd_UserId);
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
        /// 获取指定 infoId 的出售信息。
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.SellInfo GetSellInfo_ById(Guid infoId)
        {
            return da.GetSellInfo_ById(infoId);
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
        /// 获取我的未关闭出售信息。
        /// </summary>
        /// <param name="userMobile">用户手机号</param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetMySellInfo_NotClosed(string userMobile)
        {
            return da.GetMySellInfo_NotClosed(userMobile);
        }

        /// <summary>
        /// 获取派单街道业务员的要处理的出售信息
        /// </summary>
        /// <param name="JD_UserId"></param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetSellInfoBy_JD_NotClosed(int JD_UserId)
        {
            return da.GetSellInfoBy_JD_NotClosed(JD_UserId);
        }

        /// <summary>
        /// 获取所有待街道业务员接单的收货信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetAllSellInfoBy_JD_NotClosed()
        {
            return da.GetAllSellInfoBy_JD_NotClosed();
        }

        /// <summary>
        /// 根据产废单位卖货单的状态信息查询单据信息
        /// </summary>
        /// <param name="jd_UserId">街道回收员用户Id</param>
        /// <param name="StatusMsg">状态信息</param>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetMySellInfo_ByStatusMsg(int jd_UserId, string StatusMsg)
        {
            return da.GetMySellInfo_ByStatusMsg(jd_UserId, StatusMsg);
        }

        /// <summary>
        /// 获取我的已关闭出售信息。
        /// </summary>
        /// <param name="userMobile">用户手机号</param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.SellInfo> GetMySellInfo_IsClosed(string userMobile)
        {
            return da.GetMySellInfo_IsClosed(userMobile);
        }

        public IQueryable<LB.SQLServerDAL.SellInfo> GetSellInfo_IsClosed()
        {
            return da.GetSellInfo_IsClosed();
        }

        /// <summary>
        /// 根据客服处理标记搜索出售信息。
        /// </summary>
        /// <param name="kefuToHandleTag">客服处理标记。</param>
        /// <param name="count">获取记录数</param>
        /// <returns></returns>
        public IQueryable GetSellInfo_ByKefuTohandleTag(bool kefuToHandleTag, int count)
        {
            return da.GetSellInfo_ByKefuTohandleTag(kefuToHandleTag, count);
        }

        /// <summary>
        /// 根据街道回收员处理标记搜索出售信息。
        /// </summary>
        /// <param name="jd_UserId">街道回收员用户Id</param>
        /// <param name="jdTohandleTag">街道回收员处理标记。</param>
        /// <returns></returns>
        public IQueryable GetSellInfo_ByJDTohandleTag(int jd_UserId, bool jdTohandleTag)
        {
            return da.GetSellInfo_ByJDTohandleTag(jd_UserId, jdTohandleTag);
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
