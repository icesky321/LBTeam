using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.Weixin
{
    /// <summary>
    /// 模版消息基础数据类
    /// </summary>
    [Serializable]
    public abstract class TemplateMessageBaseData
    {
        private string templateColor;

        public TemplateMessageBaseData()
        {
            templateColor = "#99FF99";
        }

        /// <summary>
        /// 模版消息Id。
        /// <para>例：TemplateId = "a5LOukCZtWivNMpeMw9Ghhhq4UPuUNPy83iW8Vm3yA0" </para>
        /// </summary>
        public abstract string TemplateId
        {
            get;
        }

        /// <summary>
        /// 获取或设置 模版消息颜色。
        /// <para>例：TemplateColor = "#99FF99"</para>
        /// </summary>
        public virtual string TemplateColor
        {
            get { return templateColor; }
            set { templateColor = value; }
        }
    }

    /// <summary>
    /// 模版消息数据项
    /// </summary>
    [Serializable]
    public class TemplateMessageDataItem : Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage.TemplateDataItem
    {
        public TemplateMessageDataItem() :
            base(string.Empty)
        {
            this.color = "#333366";
            this.value = string.Empty;
        }

        public TemplateMessageDataItem(string value)
            : base(value)
        {
            this.color = "#333366";
        }
    }




    /// <summary>
    /// 任务处理通知 模板消息数据类
    /// </summary>
    [Serializable]
    public class TemplateMessageData_任务处理通知 : TemplateMessageBaseData
    {
        /// <summary>
        /// 获取模版消息Id。
        /// <para>例：TemplateId = "a5LOukCZtWivNMpeMw9Ghhhq4UPuUNPy83iW8Vm3yA0" </para>
        /// </summary>
        public override string TemplateId
        {
            get { return "a5LOukCZtWivNMpeMw9Ghhhq4UPuUNPy83iW8Vm3yA0"; }
        }


        public TemplateMessageData_任务处理通知()
            : base()
        {
            first = new TemplateMessageDataItem();
            keyword1 = new TemplateMessageDataItem();
            keyword2 = new TemplateMessageDataItem();
            remark = new TemplateMessageDataItem();
        }

        /// <summary>
        /// 导语。
        /// </summary>
        public TemplateMessageDataItem first
        {
            get;
            set;
        }

        /// <summary>
        /// 任务名称
        /// </summary>
        public TemplateMessageDataItem keyword1
        {
            get;
            set;
        }

        /// <summary>
        /// 通知类型
        /// </summary>
        public TemplateMessageDataItem keyword2
        {
            get;
            set;
        }

        /// <summary>
        /// Remark。
        /// </summary>
        public TemplateMessageDataItem remark
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 审批待办通知 模板消息数据类
    /// </summary>
    [Serializable]
    public class TemplateMessageData_审批待办通知 : TemplateMessageBaseData
    {
        /// <summary>
        /// 获取模版消息Id。
        /// <para>例：TemplateId = "a5LOukCZtWivNMpeMw9Ghhhq4UPuUNPy83iW8Vm3yA0" </para>
        /// </summary>
        public override string TemplateId
        {
            get { return "DBIw89bM9nJQ6x_qLzNKHvS4kq4nkFVpa1h51wwjs1w"; }
        }

        public TemplateMessageData_审批待办通知()
        {
            first = new TemplateMessageDataItem();
            noticeType = new TemplateMessageDataItem();
            bizType = new TemplateMessageDataItem();
            message = new TemplateMessageDataItem();
            remark = new TemplateMessageDataItem();
        }

        /// <summary>
        /// 导语
        /// </summary>
        public TemplateMessageDataItem first
        {
            get;
            set;
        }

        /// <summary>
        /// 通知类型
        /// </summary>
        public TemplateMessageDataItem noticeType
        {
            get;
            set;
        }

        /// <summary>
        /// 业务类型
        /// </summary>
        public TemplateMessageDataItem bizType
        {
            get;
            set;
        }

        /// <summary>
        /// 通知内容。
        /// </summary>
        public TemplateMessageDataItem message
        {
            get;
            set;
        }

        /// <summary>
        /// Remark
        /// </summary>
        public TemplateMessageDataItem remark
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 公告通知提醒 模板消息数据类
    /// </summary>
    [Serializable]
    public class TemplateMessageData_公告通知提醒 : TemplateMessageBaseData
    {
        /// <summary>
        /// 获取模版消息Id。
        /// <para>例：TemplateId = "tpsR1KNDq_5lrGdCvLCwU_1RhWq5DNU2bnOOOsrV68c" </para>
        /// </summary>
        public override string TemplateId
        {
            get { return "tpsR1KNDq_5lrGdCvLCwU_1RhWq5DNU2bnOOOsrV68c"; }
        }

        public TemplateMessageData_公告通知提醒()
            : base()
        {
            first = new TemplateMessageDataItem();
            keyword1 = new TemplateMessageDataItem();
            keyword2 = new TemplateMessageDataItem();
            remark = new TemplateMessageDataItem();
        }

        /// <summary>
        /// 导语。
        /// </summary>
        public TemplateMessageDataItem first
        {
            get;
            set;
        }

        /// <summary>
        /// 公告类型
        /// </summary>
        public TemplateMessageDataItem keyword1
        {
            get;
            set;
        }

        /// <summary>
        /// 公告内容
        /// </summary>
        public TemplateMessageDataItem keyword2
        {
            get;
            set;
        }

        /// <summary>
        /// Remark。
        /// </summary>
        public TemplateMessageDataItem remark
        {
            get;
            set;
        }
    }
}
