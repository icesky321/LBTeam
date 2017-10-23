using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LB.SQLServerDAL;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.Entities.TemplateMessage;
using System.Threading.Tasks;

namespace LB.WeixinMP
{
    /// <summary>
    /// 微信模板消息发送队列管理
    /// </summary>
    public class TMQueue
    {
        TmQueueRecordDA da = new TmQueueRecordDA();

        TMSender sender = new TMSender();

        /// <summary>
        /// 微信队列已发送完毕事件。
        /// </summary>
        public event EventHandler SendCompleted;


        /// <summary>
        /// 释放由本类占用的所有资源。
        /// <para>因本类使用到异步线程技术，尽量别调用该方法</para>
        /// </summary>
        public void Dispose()
        {
            da.Dispose();
        }

        /// <summary>
        /// 更新 AccessToken
        /// </summary>
        public void RefreshAccessToken()
        {
            sender.RefreshAccessToken();
        }

        /// <summary>
        /// 获取已推入的信息的数目。
        /// </summary>
        /// <returns></returns>
        public int GetCount_InQueue()
        {
            return da.GetTMCount();
        }

        /// <summary>
        /// Check 队列中是否存在元素。
        /// </summary>
        /// <returns></returns>
        public bool HasTM()
        {
            return da.IsMessageAvailable();
        }

        /// <summary>
        /// 在数据库中新增微信模板信息。
        /// </summary>
        /// <param name="openId">接收微信信息人的OpenId。</param>
        /// <param name="data">模板消息数据包</param>
        /// <returns></returns>
        public bool PushInTM(string openId, TemplateMessageBase data)
        {
            bool result = false;
            LB.SQLServerDAL.TmQueueRecord message = new LB.SQLServerDAL.TmQueueRecord();

            message.OpenId = openId;

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = jss.Serialize(data);
            //XmlSerializer ser = new XmlSerializer(data.GetType());
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //ser.Serialize(ms, data);
            //string xmlString = Encoding.UTF8.GetString(ms.ToArray());

            message.TMData = json;
            message.TMDataType = data.GetType().ToString();
            LB.SQLServerDAL.TmQueueRecord newMessage = da.NewTmQueueRecord(message);
            if (newMessage != null)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 获取指定 wxId 的微信队列记录。
        /// </summary>
        /// <param name="wxId">微信消息ID</param>
        /// <returns></returns>
        public TmQueueRecord GetTMQueueRecord(System.Guid wxId)
        {
            return da.GetTmQueueRecord(wxId);
        }

        /// <summary>
        /// 随机取出一条从未发送失败的微信消息。
        /// </summary>
        /// <returns></returns>
        protected TmQueueRecord GetTMTopOne()
        {
            return da.GetTmQueueRecordTopOne();
        }

        /// <summary>
        /// 在队列中取出一条并发送。
        /// </summary>
        public void SendOneMessage()
        {
            //反序列化 
            TmQueueRecord message = GetTMTopOne();

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            var messageData = jss.Deserialize(message.TMData, Type.GetType(message.TMDataType));
            //XmlSerializer dser = new XmlSerializer(Type.GetType(message.TMDataType));

            //xmlString是你从数据库获取的字符串 
            //System.IO.Stream xmlStream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(message.TMData));
            //var messageData = dser.Deserialize(xmlStream);

            SendTemplateMessageResult result = sender.SendWx_ToOpenId(message.OpenId, messageData);
            if (result.errcode == Senparc.Weixin.ReturnCode.请求成功)
            {
                da.DeleteTmQueueRecord(message.WxId);
            }
            else
            {
                da.MarkSendFail(message);
            }
        }

        /// <summary>
        /// 启动发送微信消息
        /// </summary>
        public void StartSend()
        {
            Action sendQueueMessage = () =>
            {

                int count = 0;
                count = GetCount_InQueue();

                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        SendOneMessage();
                        System.Threading.Thread.Sleep(50);
                    }

                    if (SendCompleted != null)
                    {
                        SendCompleted(this, new EventArgs());
                    }
                }
                catch (Exception ee)
                {
                }
            };

            Task wxTask = new Task(sendQueueMessage);
            wxTask.Start();
        }
    }
}
