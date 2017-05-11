using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities.Menu;
using Senparc.Weixin.MP.AdvancedAPIs;
using System.Configuration;

namespace LB.Weixin
{
    public class TemplateMessageSender
    {
        //LB.Weixin.WeixinUserManage weixinUserManage = new LB.Weixin.WeixinUserManage();
        LB.Weixin.AccessTokenManage tokenManage = new LB.Weixin.AccessTokenManage();


        public TemplateMessageSender()
        {
        }

        public void Dispose()
        {
            //weixinUserManage.Dispose();
        }

        public void RefreshAccessToken()
        {
            tokenManage.RefreshAccessToken();
        }

        /// <summary>
        /// 给指定工号的人员发送微信模版消息。
        /// </summary>
        /// <typeparam name="T">模版消息类</typeparam>
        /// <param name="jobNumber">工号</param>
        /// <param name="data">模板消息实例。</param>
        /// <param name="redirectUrl">点击接收到的微信模版消息后，转链接到的网址。</param>
        /// <returns></returns>
        //public SendTemplateMessageResult SendShortMsg<T>(string jobNumber, T data, string redirectUrl)
        //{
        //    SendTemplateMessageResult result = new SendTemplateMessageResult();
        //    string commonAccessToken = tokenManage.AccessToken;
        //    if (weixinUserManage.ExistWeixinUser(jobNumber))
        //    {
        //        LB.SQLServerDAL.WeixinUser wxUser = weixinUserManage.GetWeixinUserByJobNumber(jobNumber);
        //        TemplateMessageBaseData commonData = data as TemplateMessageBaseData;
        //        try
        //        {
        //            result = Template.SendTemplateMessage(commonAccessToken, wxUser.OpenId, commonData.TemplateId, commonData.TemplateColor, redirectUrl, data);
        //        }
        //        catch (Senparc.Weixin.MP.ErrorJsonResultException ee)
        //        {
        //            if (ee.JsonResult.errcode.ToString() == "验证失败")
        //            {
        //                tokenManage.RefreshAccessToken();
        //                commonAccessToken = tokenManage.AccessToken;
        //                result = Template.SendTemplateMessage(commonAccessToken, wxUser.OpenId, commonData.TemplateId, commonData.TemplateColor, redirectUrl, data);
        //            }
        //            else
        //            {
        //                LB.Weixin.TemplateMessageData_任务处理通知 msg = new LB.Weixin.TemplateMessageData_任务处理通知();
        //                msg.first = new LB.Weixin.TemplateMessageDataItem();
        //                msg.first.value = "【微信发送出错】";
        //                // 任务名称
        //                msg.keyword1 = new LB.Weixin.TemplateMessageDataItem();
        //                msg.keyword1.value = "微信发送报错";
        //                // 通知类型
        //                msg.keyword2 = new LB.Weixin.TemplateMessageDataItem();
        //                msg.keyword2.value = "微信接收人：" + jobNumber + "\n";
        //                msg.keyword2.color = "Red";
        //                msg.remark = new LB.Weixin.TemplateMessageDataItem();
        //                msg.remark.value = "errcode:" + ee.JsonResult.errcode + "\nerrmsg:" + ee.JsonResult.errmsg +
        //                    "\nOpenId:" + wxUser.OpenId
        //                        + "\nAccessToken:" + commonAccessToken;
        //                Template.SendTemplateMessage(commonAccessToken, "oiqr1jq0d3UkLGLtqYyRlrtnLXtg", commonData.TemplateId, commonData.TemplateColor, redirectUrl, data);
        //            }

        //        }
        //    }
        //    return result;
        //}

        /// <summary>
        /// 给已知OpenId微信用户发送微信模版消息。
        /// </summary>
        /// <param name="openId">微信用户OpenId</param>
        /// <param name="data">模板消息实例。</param>
        /// <param name="redirectUrl">点击接收到的微信模版消息后，转链接到的网址。</param>
        /// <returns></returns>
        public SendTemplateMessageResult SendWx_ToOpenId<T>(string openId, T data, string redirectUrl)
        {
            SendTemplateMessageResult result = new SendTemplateMessageResult();
            string commonAccessToken = tokenManage.AccessToken;

            TemplateMessageBaseData commonData = data as TemplateMessageBaseData;
            try
            {

                result = TemplateApi.SendTemplateMessage(commonAccessToken, openId, commonData.TemplateId, redirectUrl, data);
            }
            catch (Exception ee)
            {
                tokenManage.RefreshAccessToken();
                commonAccessToken = tokenManage.AccessToken;
                result = TemplateApi.SendTemplateMessage(commonAccessToken, openId, commonData.TemplateId, redirectUrl, data);
            }
            return result;
        }
    }
}
