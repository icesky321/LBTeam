using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class ConfigManage
    {
        LB.SQLServerDAL.JD_ConfigDA daHsConfig = new SQLServerDAL.JD_ConfigDA();


        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            daHsConfig.Dispose();
        }


        /// <summary>
        /// 设置回收员的用户配置
        /// </summary>
        /// <param name="config">配置数据</param>
        /// <returns></returns>
        public LB.SQLServerDAL.JD_Config SetConfig(LB.SQLServerDAL.JD_Config config)
        {
            return daHsConfig.SetConfig(config);
        }

        /// <summary>
        /// 获取回收业务员的配置信息
        /// </summary>
        /// <param name="userId">回收业务员用户Id</param>
        /// <returns></returns>
        public LB.SQLServerDAL.JD_Config GetJD_Config(int userId)
        {
            return daHsConfig.GetJD_Config(userId);
        }

        /// <summary>
        /// 获取回收业务员的配置信息
        /// </summary>
        /// <param name="mobileNum">回收业务员手机号码</param>
        /// <returns></returns>
        public LB.SQLServerDAL.JD_Config GetJD_Config(string mobileNum)
        {
            return daHsConfig.GetJD_Config(mobileNum);
        }

        /// <summary>
        /// 是否存在用户配置
        /// </summary>
        /// <param name="userId">配置信息</param>
        /// <returns></returns>
        public bool ExistConfig(int userId)
        {
            return daHsConfig.ExistConfig(userId);
        }
    }
}
