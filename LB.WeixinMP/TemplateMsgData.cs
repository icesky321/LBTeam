using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.Entities.TemplateMessage;

namespace LB.WeixinMP
{
    /// <summary>
    /// 模版消息数据项
    /// </summary>
    [Serializable]
    public class TMDataItem : TemplateDataItem
    {
        /// <summary>
        /// 模版消息数据项自构函数
        /// </summary>
        public TMDataItem() :
            base(string.Empty)
        {
            this.color = "#199900";
            this.value = string.Empty;
        }

        /// <summary>
        /// 模版消息数据项自构函数
        /// </summary>
        /// <param name="value"></param>
        public TMDataItem(string value)
            : base(value)
        {
            this.color = "#199900";
        }
    }




    /// <summary>
    /// 报价提醒 模板消息数据类
    /// </summary>
    [Serializable]
    public class TMData_报价提醒 : TemplateMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public TMData_报价提醒(string url = "")
            : base("1VogdIVVnRBPratJYu94i6vehyKcoMA2P3FS1jbQolM", url, "报价提醒")
        {
            first = new TMDataItem();
            keyword1 = new TMDataItem();
            keyword2 = new TMDataItem();
            remark = new TMDataItem();
        }

        /// <summary>
        /// 导语。
        /// </summary>
        public TMDataItem first
        {
            get;
            set;
        }

        /// <summary>
        /// 交易编号
        /// </summary>
        public TMDataItem keyword1
        {
            get;
            set;
        }

        /// <summary>
        /// 报价日期
        /// </summary>
        public TMDataItem keyword2
        {
            get;
            set;
        }

        /// <summary>
        /// 备注信息
        /// </summary>
        public TMDataItem remark
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 收到报价通知 模板消息数据类
    /// </summary>
    [Serializable]
    public class TMData_收到报价通知 : TemplateMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public TMData_收到报价通知(string url = "")
            : base("39sdixWQDlmeiMlHIOoKk1cOGqjlX02cO7qOwc-Y51g", url, "收到报价通知")
        {
            first = new TMDataItem();
            keyword1 = new TMDataItem();
            keyword2 = new TMDataItem();
            keyword3 = new TMDataItem();
            keyword4 = new TMDataItem();
            remark = new TMDataItem();
        }

        /// <summary>
        /// 导语
        /// </summary>
        public TMDataItem first
        {
            get;
            set;
        }

        /// <summary>
        /// 发送时间
        /// </summary>
        public TMDataItem keyword1
        {
            get;
            set;
        }

        /// <summary>
        /// 报价方
        /// </summary>
        public TMDataItem keyword2
        {
            get;
            set;
        }

        /// <summary>
        /// 报价产品
        /// </summary>
        public TMDataItem keyword3
        {
            get;
            set;
        }

        /// <summary>
        /// 报价详情
        /// </summary>
        public TMDataItem keyword4 { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public TMDataItem remark
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 回收成功通知 模板消息数据类
    /// </summary>
    [Serializable]
    public class TMData_回收成功通知 : TemplateMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public TMData_回收成功通知(string url = "")
            : base("onWvSRApj1HDHb9a2FTfAWGDqz6c8ZXF52fhgIOKenQ", url, "回收成功通知")
        {
            first = new TMDataItem();
            keyword1 = new TMDataItem();
            keyword2 = new TMDataItem();
            keyword3 = new TMDataItem();
            keyword4 = new TMDataItem();
            remark = new TMDataItem();
        }

        /// <summary>
        /// 导语。
        /// </summary>
        public TMDataItem first
        {
            get;
            set;
        }

        /// <summary>
        /// 订单号
        /// </summary>
        public TMDataItem keyword1
        {
            get;
            set;
        }

        /// <summary>
        /// 回收商品
        /// </summary>
        public TMDataItem keyword2
        {
            get;
            set;
        }

        /// <summary>
        /// 回收金额
        /// </summary>
        public TMDataItem keyword3 { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public TMDataItem keyword4 { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public TMDataItem remark { get; set; }
    }

    /// <summary>
    /// 预约成功通知 模板消息数据类
    /// </summary>
    public class TMData_预约成功通知 : TemplateMessageBase
    {
        /// <summary>
        /// 预约成功通知
        /// </summary>
        public TMData_预约成功通知(string url = "")
            : base("QcOQxK6y99WJmVCqhZbDhyLM8lDzJZwpXUOqdduyPdY", url, "预约成功通知")
        {
            first = new TMDataItem();
            keyword1 = new TMDataItem();
            keyword2 = new TMDataItem();
            keyword3 = new TMDataItem();
            keyword4 = new TMDataItem();
            remark = new TMDataItem();
        }

        /// <summary>
        /// 导语。
        /// </summary>
        public TMDataItem first
        {
            get;
            set;
        }

        /// <summary>
        /// 预约时间
        /// </summary>
        public TMDataItem keyword1 { get; set; }

        /// <summary>
        /// 上门地点
        /// </summary>
        public TMDataItem keyword2 { get; set; }

        /// <summary>
        /// 回收人员
        /// </summary>
        public TMDataItem keyword3 { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public TMDataItem keyword4 { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public TMDataItem remark { get; set; }
    }

    /// <summary>
    /// 下单成功通知
    /// </summary>
    public class TMData_下单成功通知 : TemplateMessageBase
    {
        /// <summary>
        /// 下单成功通知
        /// </summary>
        public TMData_下单成功通知(string url = "")
            : base("C5UAiQDyYrqpQZjqgEWjDzj4h5PoNfUV287wWtYP7uU", url, "下单成功通知")
        {
            first = new TMDataItem();
            keyword1 = new TMDataItem();
            keyword2 = new TMDataItem();
            remark = new TMDataItem();
        }

        /// <summary>
        /// 导语。
        /// </summary>
        public TMDataItem first
        {
            get;
            set;
        }

        /// <summary>
        /// 服务内容
        /// </summary>
        public TMDataItem keyword1 { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public TMDataItem keyword2 { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public TMDataItem remark { get; set; }
    }

    /// <summary>
    /// 派单成功通知
    /// </summary>
    public class TMData_派单成功通知 : TemplateMessageBase
    {
        /// <summary>
        /// 派单成功通知
        /// </summary>
        public TMData_派单成功通知(string url = "")
             : base("Kv9n9B_Rn3aKu33tOOOZhkUAck5JuauQckiyGAE68uE", url, "派单成功通知")
        {
            first = new TMDataItem();
            keyword1 = new TMDataItem();
            keyword2 = new TMDataItem();
            keyword3 = new TMDataItem();
            keyword4 = new TMDataItem();
            remark = new TMDataItem();
        }

        /// <summary>
        /// 导语。
        /// </summary>
        public TMDataItem first
        {
            get;
            set;
        }

        /// <summary>
        /// 订单号
        /// </summary>
        public TMDataItem keyword1 { get; set; }

        /// <summary>
        /// 服务地址
        /// </summary>
        public TMDataItem keyword2 { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public TMDataItem keyword3 { get; set; }

        /// <summary>
        /// 工人信息
        /// </summary>
        public TMDataItem keyword4 { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public TMDataItem remark { get; set; }
    }
}
