using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiyi.SMsg
{
    /// <summary>
    /// 工贸公司模板短信配置信息
    /// </summary>
    public static class WxAPIConfig
    {
        /// <summary>
        /// 请求超时设置（以毫秒为单位），默认为10秒。
        /// 说明：此处常量专为提供给方法的参数的默认值，不是方法内所有请求的默认超时时间。
        /// </summary>
        public const int TIME_OUT = 10000;

        /// <summary>
        /// 
        /// </summary>
        public const string SEND_MSG_API_URL = "http://aep.api.cmccopen.cn/sms/sendTemplateSms/v1";

        /// <summary>
        /// 模板短信接口 AppId
        /// </summary>
        public const string APP_ID = "wx05eb2305685408a7";

        /// <summary>
        /// 模板短信接口 App密钥
        /// </summary>
        public const string APP_SECRECT = "7a7ba58cad92f628";

        /// <summary>
        /// 模板短信平台发送号码
        /// </summary>
        public const string MSG_FROM = "106575261107771";
    }
}
