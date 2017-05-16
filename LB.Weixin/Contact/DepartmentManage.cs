using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.Weixin.Contact
{
    /// <summary>
    /// 微信企业号中部门管理类。
    /// </summary>
    public class DepartmentManage
    {
        AccessTokenManage atManage = new AccessTokenManage();

        /// <summary>
        /// 自构函数
        /// </summary>
        public DepartmentManage()
        {
            Init_Data();
        }

        /// <summary>
        /// 释放本类占用的资源。
        /// </summary>
        public void Dispose()
        {
            atManage.Dispose();
        }

        private void Init_Data()
        {
            if (atManage != null)
                AccessToken = atManage.AccessToken;
        }

        /// <summary>
        /// 微信基础AccessToken
        /// </summary>
        public string AccessToken
        {
            get; set;
        }
    }


}
