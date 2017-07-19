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
        public QyJsonResult CreateMember(string qyUserId, string name, string mobile, 部门 dep, string accessToken = null)
        {
            accessToken = accessToken ?? AccessToken;
            List<int> listDeps = new List<int>();
            listDeps.Add((int)dep);
            int[] deps = listDeps.ToArray();
            return MailListApi.CreateMember(accessToken, qyUserId, name, deps, mobile: mobile);
        }

        /// <summary>
        /// 删除企业号账户
        /// </summary>
        /// <param name="qyUserId">企业号用户Id</param>
        /// <param name="accessToken">访问口令</param>
        /// <returns></returns>
        public QyJsonResult DeleteMember(string qyUserId, string accessToken = null)
        {
            accessToken = accessToken ?? AccessToken;
            return MailListApi.DeleteMember(accessToken, qyUserId);
        }
    }
}
