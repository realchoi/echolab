using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Repository.DbConfig
{
    /// <summary>
    /// 数据库连接配置类
    /// </summary>
    public class BaseDbConfig
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnectionString { get; set; }
    }
}
