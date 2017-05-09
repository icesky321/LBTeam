using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class NewsInfo
    {
        LB.SQLServerDAL.NewsInfoDA da = new SQLServerDAL.NewsInfoDA();

        /// <summary>
        /// 新增新闻资讯信息
        /// </summary>
        /// <param name="newsinfo"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.NewsInfo NewNewsInfo(LB.SQLServerDAL.NewsInfo newsinfo)
        {
            return da.NewNewsInfo(newsinfo);
        }

        /// <summary>
        /// 获取信息资讯列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.NewsInfo> GetNewsInfo()
        {
            return da.GetNewsInfo();
        }

        /// <summary>
        /// 根据资讯类型查询资讯信息
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.NewsInfo> GetNewsInfoByType(int TypeId)
        {
            return da.GetNewsInfoByType(TypeId);
        }

        /// <summary>
        /// 根据ID删除某条新闻资讯
        /// </summary>
        /// <param name="id"></param>
        public void DeleteNewsInfo(int id)
        {
            da.DeleteNewsInfo(id);
        }

        /// <summary>
        /// 根据id获取model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.NewsInfo GetNewsInfoById(int id)
        {
            return da.GetNewsInfoById(id);
        }

        /// <summary>
        /// 更新资讯信息
        /// </summary>
        /// <param name="newinfo"></param>
        public void UpdateNewsInfo(LB.SQLServerDAL.NewsInfo newinfo)
        {
            da.UpdateNewsInfo(newinfo);
        }

        public IQueryable<LB.SQLServerDAL.NewsInfo> GetNewsInfoByTypeTop13(int TypeId)
        {
            return da.GetNewsInfoByTypeTop13(TypeId);
        }
    }
}
