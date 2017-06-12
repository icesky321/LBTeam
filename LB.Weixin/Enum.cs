using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.Weixin
{
    /// <summary>
    /// 绿宝平台中的部门，枚举值为部门ID。
    /// </summary>
    public enum 部门
    {
        平台员工 = 2,
        地域认证回收员 = 3,
        地域回收公司 = 4,
        冶炼厂 = 5
    }

    /// <summary>
    /// AgentId即为企业号应用ID，在使用AgentID的地方，可使用选定应用的枚举值。
    /// </summary>
    public enum 企业号应用
    {
        默认 = 5,
        绿宝提醒 = 5,
        行业资讯 = 6,
        开发测试 = 7
    }
}
