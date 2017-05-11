using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LB.SQLServerDAL;
using System.Configuration;
using Senparc.Weixin.MP.CommonAPIs;

namespace LB.Weixin
{
    /// <summary>
    /// AccessToken 管理类
    /// </summary>
    public class AccessTokenManage
    {
        static LB.SQLServerDAL.AccessTokenDA daTokenStatic = new AccessTokenDA();
        LB.SQLServerDAL.AccessTokenDA daToken = new SQLServerDAL.AccessTokenDA();

        /// <summary>
        /// 对象自动创建完毕，即自动初始化AppId以及AppSecret，同时加载有效的AccessToken
        /// </summary>
        public AccessTokenManage()
        {
            Initial();
            LoadAccessToken();
        }

        #region 属性

        protected string AppId { get; set; }
        protected string AppSecret { get; set; }
        public string AccessToken { get; set; }
        #endregion

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void Initial()
        {
            AppId = ConfigurationManager.AppSettings["AppID"] ?? "wx5987b3efa3881815";
            AppSecret = ConfigurationManager.AppSettings["AppSecret"] ?? "1c70e036847a6bd653bcd24fe3d0c8cb";
        }
        private void LoadAccessToken()
        {
            if (daToken.ExistAccessToken())
            {
                LB.SQLServerDAL.OAuthAccessToken token = daToken.GetLastAccessToken();
                if (token.OAuthAccessTokenStartTime < DateTime.Now.AddHours(-1))
                {
                    LB.SQLServerDAL.OAuthAccessToken accessToken = GetAccessToken_FromRemote();
                    AccessToken = accessToken.Access_token;
                }
                else
                {
                    AccessToken = token.Access_token;
                }
            }
            else
            {
                LB.SQLServerDAL.OAuthAccessToken accessToken = GetAccessToken_FromRemote();
                AccessToken = accessToken.Access_token;
            }
        }

        /// <summary>
        /// 从微信服务器更新 Access_Token，并立即存储到本地数据库
        /// </summary>
        /// <returns></returns>
        private LB.SQLServerDAL.OAuthAccessToken GetAccessToken_FromRemote()
        {
            Senparc.Weixin.MP.Entities.AccessTokenResult commonAccessToken = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(AppId, AppSecret);

            LB.SQLServerDAL.OAuthAccessToken localAccessToken = new OAuthAccessToken();
            localAccessToken.Access_token = commonAccessToken.access_token;
            localAccessToken.Expires_in = 7200;
            daToken.CreateOAuthAccessToken(localAccessToken);
            return localAccessToken;
        }

        /// <summary>
        /// 从微信服务器更新 Access_Token，并立即存储到本地数据库
        /// </summary>
        /// <returns></returns>
        private static LB.SQLServerDAL.OAuthAccessToken GetAccessToken_FromRemote(string appId, string appSecret)
        {
            Senparc.Weixin.MP.Entities.AccessTokenResult commonAccessToken = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(appId, appSecret);

            LB.SQLServerDAL.OAuthAccessToken localAccessToken = new OAuthAccessToken();
            localAccessToken.Access_token = commonAccessToken.access_token;
            localAccessToken.Expires_in = 7200;
            daTokenStatic.CreateOAuthAccessToken(localAccessToken);
            return localAccessToken;
        }

        public static string GetAccessToken(string appId, string appSecret)
        {
            if (daTokenStatic.ExistAccessToken())
            {
                LB.SQLServerDAL.OAuthAccessToken token = daTokenStatic.GetLastAccessToken();
                if (token.OAuthAccessTokenStartTime > DateTime.Now.AddHours(-1))
                {
                    return token.Access_token;
                }

            }

            LB.SQLServerDAL.OAuthAccessToken accessToken = GetAccessToken_FromRemote(appId, appSecret);
            return accessToken.Access_token;
        }




        /// <summary>
        /// 释放由本类占用的所有资源。
        /// </summary>
        public void Dispose()
        {
            daToken.Dispose();
        }

        /// <summary>
        /// 在数据库中新增AccessToken。
        /// </summary>
        /// <param name="accessToken">AccessToken。</param>
        /// <returns></returns>
        public LB.SQLServerDAL.OAuthAccessToken CreateOAuthAccessToken(SQLServerDAL.OAuthAccessToken accessToken)
        {
            return daToken.CreateOAuthAccessToken(accessToken);
        }

        /// <summary>
        /// 获取最新的AccessToken。
        /// </summary>
        /// <returns></returns>
        public OAuthAccessToken GetLastAccessToken_FromLocal()
        {
            return daToken.GetLastAccessToken();
        }

        /// <summary>
        /// 删除指定 wxId 的AccessToken
        /// </summary>
        /// <param name="wxId">AccessTokenId.</param>
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
            LB.SQLServerDAL.OAuthAccessToken token = GetAccessToken_FromRemote();
            this.AccessToken = token.Access_token;
        }

    }
}
