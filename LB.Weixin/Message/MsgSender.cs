using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Senparc.Weixin.QY.Entities;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.QY.AdvancedAPIs.Mass;

namespace LB.Weixin.Message
{
    /// <summary>
    /// 微信企业号发送消息类
    /// </summary>
    public class MsgSender
    {
        /// <summary>
        /// 微信企业号发送消息类
        /// </summary>
        public MsgSender()
        {
            Init_Data();
        }

        /// <summary>
        /// 微信基础 AccessToken
        /// <para>该属性在类创建时会自动初始化信息，也可根据实际需要手动赋值。</para>
        /// </summary>
        public string AccessToken
        {
            get; set;
        }

        private void Init_Data()
        {
            string serviceUri = ConfigurationManager.AppSettings["AccessTokenServiceUri"] ?? "";
            if (string.IsNullOrEmpty(serviceUri))
            {
                using (BaseAccessTokenManage at = new BaseAccessTokenManage())
                {
                    AccessToken = at.AccessToken;
                }
            }
            else
            {
                AccessToken = Senparc.Weixin.HttpUtility.RequestUtility.HttpGet(serviceUri, null);
            }
        }

        /// <summary>
        /// 发送文章类型消息
        /// </summary>
        /// <param name="toUsers">接收用户QYUserID，若有多个以|改开。</param>
        /// <param name="article">文章对象数据</param>
        /// <param name="agentId">微信企业号中接收消息的应用ID</param>
        /// <returns></returns>
        public MassResult SendArticleToUsers(string toUsers, Article article, string agentId = "5")
        {
            if (article == null)
            {
                MassResult result = new MassResult();
                result.errmsg = "无发送内容";
                return result;
            }
            List<Senparc.Weixin.QY.Entities.Article> articles = new List<Senparc.Weixin.QY.Entities.Article>();
            articles.Add(article);

            return Senparc.Weixin.QY.AdvancedAPIs.MassApi.SendNews(this.AccessToken, toUsers, null, null, agentId, articles);
        }

        /// <summary>
        /// 发送文本类型消息
        /// </summary>
        /// <param name="toUsers">接收用户QYUserID，若有多个以|改开。</param>
        /// <param name="text">文本消息，换行加\n</param>
        /// <param name="agentId">微信企业号中接收消息的应用ID</param>
        /// <returns></returns>
        public MassResult SendTextToUsers(string toUsers, string text, string agentId = "5")
        {
            if (string.IsNullOrEmpty(text))
            {
                MassResult result = new MassResult();
                result.errmsg = "无发送内容";
                return result;
            }

            return Senparc.Weixin.QY.AdvancedAPIs.MassApi.SendText(this.AccessToken, toUsers, null, null, agentId, text);
        }

        /// <summary>
        /// 发送文本类型消息
        /// </summary>
        /// <param name="toTags">接收标签组ID，若有多个以|改开。</param>
        /// <param name="text">文本消息，换行加\n</param>
        /// <param name="agentId">微信企业号中接收消息的应用ID，默认发送到“消息通知”应用。</param>
        /// <returns></returns>
        public MassResult SendTextToTags(string toTags, string text, string agentId = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                MassResult result = new MassResult();
                result.errmsg = "无发送内容";
                return result;
            }
            string appId = agentId ?? "5";
            return Senparc.Weixin.QY.AdvancedAPIs.MassApi.SendText(this.AccessToken, null, null, toTags, appId, text);
        }


        /// <summary>
        /// 发送文本类型消息
        /// </summary>
        /// <param name="toUsers">接收用户QYUserID，若有多个以|改开。</param>
        /// <param name="fileId">文本消息，换行加\n</param>
        /// <param name="agentId">微信企业号中接收消息的应用ID</param>
        /// <returns></returns>
        public MassResult SendFileToUsers(string toUsers, string fileId, string agentId = "5")
        {
            if (string.IsNullOrEmpty(fileId))
            {
                MassResult result = new MassResult();
                result.errmsg = "无发送内容";
                return result;
            }

            return Senparc.Weixin.QY.AdvancedAPIs.MassApi.SendFile(this.AccessToken, toUsers, null, null, agentId, fileId);
        }
    }
}
