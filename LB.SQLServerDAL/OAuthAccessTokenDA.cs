using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class AccessTokenDA : IDisposable
    {
        LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());


        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }

            GC.SuppressFinalize(this);
        }

        ~AccessTokenDA()
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
            if (accessToken != null)
            {
                // 将最新获取到的AccessToken 存储到本地数据库中。
                accessToken.Openid = System.Guid.NewGuid().ToString();
                accessToken.OAuthAccessTokenStartTime = DateTime.Now;
                dbContext.OAuthAccessToken.InsertOnSubmit(accessToken);

                // 在本地数据库中删除一个月前的 AccessToken
                var query = from para in dbContext.OAuthAccessToken
                            where para.OAuthAccessTokenStartTime < DateTime.Now.AddDays(-30)
                            select para;
                foreach (var para in query)
                {
                    dbContext.OAuthAccessToken.DeleteOnSubmit(para);
                }
                try
                {
                    dbContext.SubmitChanges();
                }
                catch (Exception ee)
                {

                }

            }
            return accessToken;
        }

        /// <summary>
        /// 获取最新的AccessToken。
        /// </summary>
        /// <returns></returns>
        public OAuthAccessToken GetLastAccessToken()
        {
            var query = from message in dbContext.OAuthAccessToken
                        orderby message.OAuthAccessTokenStartTime descending
                        select message;
            var token = query.FirstOrDefault();
            return token;
        }

        /// <summary>
        /// 删除指定 wxId 的AccessToken
        /// </summary>
        /// <param name="wxId">AccessTokenId.</param>
        public void DeleteOldAccessToken()
        {
            var query = from para in dbContext.OAuthAccessToken
                        where para.OAuthAccessTokenStartTime < DateTime.Now.AddHours(-2)
                        select para;
            foreach (var para in query)
            {
                dbContext.OAuthAccessToken.DeleteOnSubmit(para);
            }
            try
            {
                dbContext.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Check 队列中是否存在accessToken。
        /// </summary>
        /// <returns></returns>
        public bool ExistAccessToken()
        {
            bool exist = false;
            var query = from m in dbContext.OAuthAccessToken
                        select m;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }

    }
}
