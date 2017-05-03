using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class NewsType
    {
        LB.SQLServerDAL.NewsTypeDA da = new SQLServerDAL.NewsTypeDA();

        /// <summary>
        /// 新增资讯类别信息
        /// </summary>
        /// <param name="newtype"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.NewsType NewNewsType(LB.SQLServerDAL.NewsType newtype)
        {
            return da.NewNewsType(newtype);
        }

        /// <summary>
        /// 获取资讯类别信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<LB.SQLServerDAL.NewsType> GetNewsType()
        {
            return da.GetNewsType();
        }

        /// <summary>
        /// 根据NewsTypeId删除资讯类别
        /// </summary>
        /// <param name="NewsTypeId"></param>
        public void DeleteNewsTypeinfo(int NewsTypeId)
        {
            da.DeleteNewsTypeinfo(NewsTypeId);
        }

        /// <summary>
        /// 修改资讯类别信息
        /// </summary>
        /// <param name="newtype"></param>
        public void UpdateNewsType(LB.SQLServerDAL.NewsType newtype)
        {
            da.UpdateNewsType(newtype);
        }

        /// <summary>
        /// 根据ID获取资讯类别信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LB.SQLServerDAL.NewsType GetNewTypeById(int id)
        {
            return da.GetNewTypeById(id);
        }
    }
}
