using Dapper;
using EchoBlog.Entity;
using EchoBlog.Repository.DbConfig;
using EchoBlog.Repository.Def;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EchoBlog.Repository.Impl
{
    /// <summary>
    /// 文章数据服务类
    /// </summary>
    public class ArticleRepository : IArticleRepository, IDisposable
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        private readonly MySqlConnection Conn;

        public ArticleRepository()
        {
            Conn = new MySqlConnection(BaseDbConfig.ConnectionString);
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.OpenAsync();
            }
        }

        public async Task<IEnumerable<ArticleEntity>> GetAllArticles()
        {
            var sql = "select * from article";
            var articles = await Conn.QueryAsync<ArticleEntity>(sql);
            return articles;
        }

        public void Dispose()
        {
            if (Conn != null && Conn.State != ConnectionState.Closed)
                Conn.Close();
        }
    }
}
