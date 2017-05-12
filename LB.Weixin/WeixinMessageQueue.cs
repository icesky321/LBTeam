using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LB.SQLServerDAL;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using System.Threading.Tasks;

namespace LB.Weixin
{
    public class WeixinMessageQueue
    {
        LB.SQLServerDAL.WeixinMessageDA da = new SQLServerDAL.WeixinMessageDA();
        TemplateMessageSender sender = new TemplateMessageSender();
        public event EventHandler SendCompleted;

        public WeixinMessageQueue()
        {

        }

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
        public int GetMessageCount_InQueue()
        {
            return da.GetCountOfMessage();
        }

        /// <summary>
        /// Check 队列中是否存在元素。
        /// </summary>
        /// <returns></returns>
        public bool IsMessageAvailable()
        {
            return da.IsMessageAvailable();
        }

        /// <summary>
        /// 在数据库中新增微信信息。
        /// </summary>
        /// <param name="weixinMessage">微信信息。</param>
        /// <returns></returns>
        public bool PushInWeixinMessage(string jobNumber, LB.Weixin.TemplateMessageBaseData data, string redirectUrl)
        {
            bool result = false;
            LB.SQLServerDAL.WeixinMessage message = new WeixinMessage();
            message.JobNumber = jobNumber;
            message.RedirectUrl = redirectUrl;
            System.IO.Stream stream = new System.IO.MemoryStream();

            XmlSerializer ser = new XmlSerializer(data.GetType());

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            ser.Serialize(ms, data);

            string xmlString = Encoding.UTF8.GetString(ms.ToArray());

            message.TemplateMessageData = xmlString;
            message.TemplateMessageDataType = data.GetType().ToString();
            LB.SQLServerDAL.WeixinMessage newMessage = da.NewWeixinMessage(message);
            if (message != null)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 获取指定 wxId 的微信消息。
        /// </summary>
        /// <param name="wxId">微信消息ID</param>
        /// <returns></returns>
        public WeixinMessage GetWeixinMessage(System.Guid wxId)
        {
            return da.GetWeixinMessage(wxId);
        }

        /// <summary>
        /// 随机取出一条从未发送失败的微信消息。
        /// </summary>
        /// <returns></returns>
        protected WeixinMessage GetWeixinMessageTopOne()
        {
            return da.GetWeixinMessageTopOne();
        }

        public void SendTopOneMessage()
        {
            //反序列化 
            WeixinMessage message = GetWeixinMessageTopOne();

            XmlSerializer dser = new XmlSerializer(Type.GetType(message.TemplateMessageDataType));

            //xmlString是你从数据库获取的字符串 

            System.IO.Stream xmlStream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(message.TemplateMessageData));

            var messageData = dser.Deserialize(xmlStream);


            SendTemplateMessageResult result = new SendTemplateMessageResult();
            //result = sender.SendShortMsg(message.JobNumber, messageData, message.RedirectUrl);
            //if (result.errcode == Senparc.Weixin.MP.ReturnCode.请求成功)
            //{
            //    da.DeleteWeixinMessage(message.WMId);
            //}
            //else
            //{
            //    da.MarkSendFail(message);
            //}
        }

        /// <summary>
        /// 启动发送微信消息
        /// </summary>
        public void StartSend()
        {
            Action sendQueueMessage = () =>
            {

                int count = 0;
                count = GetMessageCount_InQueue();

                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        SendTopOneMessage();
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
