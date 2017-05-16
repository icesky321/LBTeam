using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.Entities;

namespace LB.Weixin.Contact
{
    /// <summary>
    /// 微信企业号中用户管理类。
    /// </summary>
    public class MemberManage
    {
        // TODO 发布前要删除
        //AccessTokenManage atManage = new AccessTokenManage();

        /// <summary>
        /// 
        /// </summary>
        public MemberManage()
        {
            //Init_Data();
        }

        /// <summary>
        /// 释放本类占用的资源。
        /// </summary>
        //public void Dispose()
        //{
        //    atManage.Dispose();
        //}

        //private void Init_Data()
        //{
        //    if (atManage != null)
        //        AccessToken = atManage.AccessToken;
        //}

        /// <summary>
        /// 微信基础AccessToken
        /// </summary>
        public string AccessToken
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qyUserId"></param>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="dep"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public QyJsonResult CreateMember(string qyUserId, string name, string mobile, 绿宝部门 dep, string accessToken = null)
        {
            accessToken = accessToken ?? AccessToken;
            int[] deps = new int[1] { (int)dep };
            return MailListApi.CreateMember(accessToken, qyUserId, name, deps, mobile: mobile);
        }
    }
}
