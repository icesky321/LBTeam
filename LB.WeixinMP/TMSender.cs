using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities.Menu;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.Entities.TemplateMessage;
using System.Configuration;

namespace LB.WeixinMP
{
    /// <summary>
    /// 模板微信发送器
    /// <para>Devor:Cobe</para>
    /// <para>DevTime: 2017-10-14</para>
    /// <para>Modify Date：2017-10-21</para>
    /// </summary>
    public class TMSender
    {
        BaseAccessTokenManage tokenManage;
        private string accessToken;

        /// <summary>
        /// 
        /// </summary>
        public TMSender()
        {
            tokenManage = new BaseAccessTokenManage();
            accessToken = tokenManage.AccessToken;
        }

        /// <summary>
        /// 初始化 AccessToken 
        /// </summary>
        /// <param name="baseAccessToken"></param>
        public TMSender(string baseAccessToken)
        {
            accessToken = baseAccessToken;
        }


        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// 刷新 AccessToken
        /// </summary>
        public void RefreshAccessToken()
        {
            tokenManage.RefreshAccessToken();
            accessToken = tokenManage.AccessToken;
        }

        /// <summary>
        /// 给指定工号的人员发送微信模版消息。
        /// </summary>
        /// <typeparam name="T">模版消息类</typeparam>
        /// <param name="jobNumber">工号</param>
        /// <param name="data">模板消息实例。</param>
        /// <param name="redirectUrl">点击接收到的微信模版消息后，转链接到的网址。</param>
        /// <returns></returns>
        public SendTemplateMessageResult SendShortMsg<T>(string jobNumber, T data, string redirectUrl)
        {
            SendTemplateMessageResult result = new SendTemplateMessageResult();
            //string commonAccessToken = tokenManage.AccessToken;
            //if (weixinUserManage.ExistWeixinUser(jobNumber))
            //{
            //    Tiyi.Weixin.SQLServerDAL.WeixinUser wxUser = weixinUserManage.GetWeixinUserByJobNumber(jobNumber);
            //    TMBaseData commonData = data as TMBaseData;
            //    try
            //    {
            //        result = Template.SendTemplateMessage(commonAccessToken, wxUser.OpenId, commonData.TemplateId, commonData.TemplateColor, redirectUrl, data);
            //    }
            //    catch (Senparc.Weixin.MP.ErrorJsonResultException ee)
            //    {
            //        if (ee.JsonResult.errcode.ToString() == "验证失败")
            //        {
            //            tokenManage.RefreshAccessToken();
            //            commonAccessToken = tokenManage.AccessToken;
            //            result = Template.SendTemplateMessage(commonAccessToken, wxUser.OpenId, commonData.TemplateId, commonData.TemplateColor, redirectUrl, data);
            //        }
            //        else
            //        {
            //            Tiyi.Weixin.TemplateMessageData_任务处理通知 msg = new Tiyi.Weixin.TemplateMessageData_任务处理通知();
            //            msg.first = new Tiyi.Weixin.TemplateMessageDataItem();
            //            msg.first.value = "【微信发送出错】";
            //            // 任务名称
            //            msg.keyword1 = new Tiyi.Weixin.TemplateMessageDataItem();
            //            msg.keyword1.value = "微信发送报错";
            //            // 通知类型
            //            msg.keyword2 = new Tiyi.Weixin.TemplateMessageDataItem();
            //            msg.keyword2.value = "微信接收人：" + jobNumber + "\n";
            //            msg.keyword2.color = "Red";
            //            msg.remark = new Tiyi.Weixin.TemplateMessageDataItem();
            //            msg.remark.value = "errcode:" + ee.JsonResult.errcode + "\nerrmsg:" + ee.JsonResult.errmsg +
            //                "\nOpenId:" + wxUser.OpenId
            //                    + "\nAccessToken:" + commonAccessToken;
            //            Template.SendTemplateMessage(commonAccessToken, "oiqr1jq0d3UkLGLtqYyRlrtnLXtg", commonData.TemplateId, commonData.TemplateColor, redirectUrl, data);
            //        }

            //    }
            //}
            return result;
        }

        /// <summary>
        /// 给已知OpenId微信用户发送微信模版消息。
        /// </summary>
        /// <param name="openId">微信用户OpenId</param>
        /// <param name="tmwxData">模板消息实例。</param>
        /// <returns></returns>
        public SendTemplateMessageResult SendWx_ToOpenId<T>(string openId, T tmwxData)
        {
            SendTemplateMessageResult result = new SendTemplateMessageResult();

            ITemplateMessageBase tmData = tmwxData as TemplateMessageBase;
            try
            {
                result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(accessToken, openId, tmData);
            }
            catch (Exception ee)
            {
                //tokenManage.RefreshAccessToken();
                //commonAccessToken = tokenManage.AccessToken;
                //result = Template.SendTemplateMessage(commonAccessToken, openId, commonData.TemplateId, commonData.TemplateColor, redirectUrl, tmwxData);
            }
            return result;
        }

        /// <summary>
        /// 给已知OpenId微信用户发送微信模版消息。
        /// </summary>
        /// <param name="accessToken">Base AccessToken</param>
        /// <param name="openId">微信用户OpenId</param>
        /// <param name="tmwxData">模板消息实例。</param>
        /// <returns></returns>
        public SendTemplateMessageResult SendWx_ToOpenId<T>(string accessToken, string openId, T tmwxData)
        {
            SendTemplateMessageResult result = new SendTemplateMessageResult();
            string commonAccessToken = tokenManage.AccessToken;

            TemplateMessageBase tmData = tmwxData as TemplateMessageBase;

            try
            {
                result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(accessToken, openId, tmData);
            }
            catch (Exception ee)
            {
                //tokenManage.RefreshAccessToken();
                //commonAccessToken = tokenManage.AccessToken;
                //result = Template.SendTemplateMessage(commonAccessToken, openId, commonData.TemplateId, commonData.TemplateColor, redirectUrl, tmwxData);
            }
            return result;
        }
    }
}
