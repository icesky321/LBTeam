﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LB.SQLServerDAL
{
    public static class CodeDA
    {
        static LBDataContext dbContext = new LBDataContext(LB.SQLServerDAL.DS.ConnectionString.ConnectionStringLB());

        /// <summary>
        /// 获取用户的 QYUserId 最大编码。
        /// <para>若最大编码不存在或小于10000，则返回10000。</para>
        /// </summary>
        /// <returns></returns>
        public static int GetLastQYUserId()
        {
            int userId = 0;
            var query = from m in dbContext.UserInfo
                        orderby m.UserId descending
                        select m;
            var user = query.FirstOrDefault();
            if (user != null)
            {
                string lastCode = user.QYUserId;
                int.TryParse(lastCode, out userId);
                userId = userId < 10000 ? 10000 : userId;
            }
            else
            {
                userId = 10000;
            }

            return userId;
        }


    }
}