using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LB.SQLServerDAL;
using System.Text.RegularExpressions;

namespace LB.BLL
{
    /// <summary>
    /// 编码规则类
    /// <para>微信企业号中用户 QYUserId 管理。</para>
    /// </summary>
    public static class CodeRule
    {
        /// <summary>
        /// 获取新的QYUserId。
        /// </summary>
        /// <returns></returns>
        public static string GenerateNewQYUserId()
        {
            int lastQYUserId = 0;
            lastQYUserId = CodeDA.GetLastQYUserId();


            return (lastQYUserId + 1).ToString();
        }

    }
}

