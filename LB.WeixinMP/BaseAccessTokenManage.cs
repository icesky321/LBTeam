using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LB.SQLServerDAL;
using System.Configuration;
using Senparc.Weixin.MP.CommonAPIs;

namespace LB.WeixinMP
{
    /// <summary>
    /// 关于微信服务号基础 AccessToken 的管理类
    /// </summary>
    public class BaseAccessTokenManage : IDisposable
    {
        static LB.SQLServerDAL.BaseAccessTokenMPDA daTokenStatic = new BaseAccessTokenMPDA();
        LB.SQLServerDAL.BaseAccessTokenMPDA daToken = new SQLServerDAL.BaseAccessTokenMPDA();

        /// <summary>
        /// 对象自动创建完毕，即自动初始化AppId以及AppSecret，同时加载有效的AccessToken
        /// </summary>
        public BaseAccessTokenManage()
        {
            Initial();
            LoadAccessToken();
        }

        #region 属性

        /// <summary>
        /// CorpID
        /// </summary>
        protected string AppId { get; set; }
        /// <summary>
        /// CorpSecret
        /// </summary>
        protected string AppSecret { get; set; }
        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { get; set; }
        #endregion

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void Initial()
        {
            AppId = ConfigurationManager.AppSettings["AppId"] ?? "wx05eb2305685408a7";  // 绿宝服务号AppId
            AppSecret = ConfigurationManager.AppSettings["AppSecret"] ?? "b1100370fae06d358ab0ba6263bfa6ac";    // 绿宝服务号AppSecret
        }
        private void LoadAccessToken()
        {
            if (daToken.ExistAccessToken())
            {
                LB.SQLServerDAL.BaseAccessTokenMP token = daToken.GetLastAccessToken();
                if (token.AccessTokenStartTime < DateTime.Now.AddHours(-1))
                {
                    LB.SQLServerDAL.BaseAccessTokenMP accessToken = GetAccessToken_FromRemote();
                    AccessToken = accessToken.Access_token;
                }
                else
                {
                    AccessToken = token.Access_token;
                }
            }
            else
            {
                LB.SQLServerDAL.BaseAccessTokenMP accessToken = GetAccessToken_FromRemote();
                AccessToken = accessToken.Access_token;
            }
        }

        /// <summary>
        /// 从微信服务器获取最新 Access_Token，并立即存储到本地数据库。
        /// </summary>
        /// <returns></returns>
        private LB.SQLServerDAL.BaseAccessTokenMP GetAccessToken_FromRemote()
        {
            Senparc.Weixin.MP.Entities.AccessTokenResult commonAccessToken = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(AppId, AppSecret);

            LB.SQLServerDAL.BaseAccessTokenMP localAccessToken = new BaseAccessTokenMP();
            localAccessToken.AppId = AppId;
            localAccessToken.Access_token = commonAccessToken.access_token;
            localAccessToken.Expires_in = 7200;
            daToken.CreateBaseAccessTokenMP(localAccessToken);
            return localAccessToken;
        }

        /// <summary>
        /// 从微信服务器更新 Access_Token，并立即存储到本地数据库
        /// </summary>
        /// <returns></returns>
        private static LB.SQLServerDAL.BaseAccessTokenMP GetAccessToken_FromRemote(string appId, string appSecret)
        {
            Senparc.Weixin.MP.Entities.AccessTokenResult commonAccessToken = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(appId, appSecret);

            LB.SQLServerDAL.BaseAccessTokenMP localAccessToken = new BaseAccessTokenMP();
            localAccessToken.AppId = appId;
            localAccessToken.Access_token = commonAccessToken.access_token;
            localAccessToken.Expires_in = 7200;
            daTokenStatic.CreateBaseAccessTokenMP(localAccessToken);
            return localAccessToken;
        }

        /// <summary>
        /// 获取 AccessToken
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static string GetAccessToken(string appId, string appSecret)
        {
            if (daTokenStatic.ExistAccessToken())
            {
                LB.SQLServerDAL.BaseAccessTokenMP token = daTokenStatic.GetLastAccessToken();
                if (token.AccessTokenStartTime > DateTime.Now.AddHours(-1))
                {
                    return token.Access_token;
                }

            }

            LB.SQLServerDAL.BaseAccessTokenMP accessToken = GetAccessToken_FromRemote(appId, appSecret);
            return accessToken.Access_token;
        }




        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            if (daToken != null)
            {
                daToken.Dispose();
                daToken = null;
            }

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~BaseAccessTokenManage()
        {
            this.Dispose();
        }

        /// <summary>
        /// 在数据库中新增AccessToken。
        /// </summary>
        /// <param name="accessToken">AccessToken。</param>
        /// <returns></returns>
        public LB.SQLServerDAL.BaseAccessTokenMP CreateOAuthAccessToken(SQLServerDAL.BaseAccessTokenMP accessToken)
        {
            return daToken.CreateBaseAccessTokenMP(accessToken);
        }

        /// <summary>
        /// 获取最新的AccessToken。
        /// </summary>
        /// <returns></returns>
        public BaseAccessTokenMP GetLastAccessToken_FromLocal()
        {
            return daToken.GetLastAccessToken();
        }

        /// <summary>
        /// 删除指定 wxId 的AccessToken
        /// </summary>
        public void DeleteOldAccessToken()
        {
            daToken.DeleteOldAccessToken();
        }

        /// <summary>
        /// Check 队列中是否存在accessToken。
        /// </summary>
        /// <returns></returns>
        public bool ExistAccessToken()
        {
            return daToken.ExistAccessToken();
        }


        /// <summary>
        /// 无论是否快过期，都强制刷新微信服务器上的Access_Token
        /// </summary>
        public void RefreshAccessToken()
        {
            LB.SQLServerDAL.BaseAccessTokenMP token = GetAccessToken_FromRemote();
            this.AccessToken = token.Access_token;
        }

    }
}
