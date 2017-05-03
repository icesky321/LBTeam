using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace LB.SQLServerDAL.DS
{
    public class ConnectionString
    {
        public static string ConnectionStringLB()
        {
            string conString = string.Empty;
            if (ConfigurationManager.ConnectionStrings["LB_SQL_ConnString"] != null)
            {
                conString = ConfigurationManager.ConnectionStrings["LB_SQL_ConnString"].ConnectionString;
            }
            else
            {
                throw new Exception("config 文件中找不到名称为 LB_SQL_ConnString 的数据库连接字符串");
            }
            return conString;
        }
    }
}
