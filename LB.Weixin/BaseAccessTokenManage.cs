using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LB.SQLServerDAL;
using System.Configuration;
using Senparc.Weixin.QY.CommonAPIs;

namespace LB.Weixin
{
    /// <summary>
    /// AccessToken 管理类
    /// </summary>
    public class BaseAccessTokenManage : IDisposable
    {
        static LB.SQLServerDAL.AccessTokenDA daTokenStatic = new AccessTokenDA();
        LB.SQLServerDAL.AccessTokenDA daToken = new SQLServerDAL.AccessTokenDA();

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
        protected string CorpID { get; set; }
        /// <summary>
        /// CorpSecret
        /// </summary>
        protected string CorpSecret { get; set; }
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
            CorpID = ConfigurationManager.AppSettings["CorpID"] ?? "wxabb13491cd384449";
            CorpSecret = ConfigurationManager.AppSettings["CorpSecret"] ?? "reX64E3nivXBU7J393U5u_QaTOe6L89He_DIhpuxVzVxsh3LpNEadlmJGDMlhJ0P";
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
            Senparc.Weixin.QY.Entities.AccessTokenResult commonAccessToken = Senparc.Weixin.QY.CommonAPIs.CommonApi.GetToken(CorpID, CorpSecret);

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
        private static LB.SQLServerDAL.OAuthAccessToken GetAccessToken_FromRemote(string corpId, string corpSecret)
        {
            Senparc.Weixin.QY.Entities.AccessTokenResult commonAccessToken = Senparc.Weixin.QY.CommonAPIs.CommonApi.GetToken(corpId, corpSecret);

            LB.SQLServerDAL.OAuthAccessToken localAccessToken = new OAuthAccessToken();
            localAccessToken.Access_token = commonAccessToken.access_token;
            localAccessToken.Expires_in = 7200;
            daTokenStatic.CreateOAuthAccessToken(localAccessToken);
            return localAccessToken;
        }

        /// <summary>
        /// 获取 AccessToken
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="corpSecret"></param>
        /// <returns></returns>
        public static string GetAccessToken(string corpId, string corpSecret)
        {
            if (daTokenStatic.ExistAccessToken())
            {
                LB.SQLServerDAL.OAuthAccessToken token = daTokenStatic.GetLastAccessToken();
                if (token.OAuthAccessTokenStartTime > DateTime.Now.AddHours(-1))
                {
                    return token.Access_token;
                }

            }

            LB.SQLServerDAL.OAuthAccessToken accessToken = GetAccessToken_FromRemote(corpId, corpSecret);
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
