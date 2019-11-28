using EchoBlog.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoBlog.Repository.Def
{
    /// <summary>
    /// 文章数据服务接口
    /// </summary>
    public interface IArticleRepository
    {
        Task<IEnumerable<ArticleEntity>> GetAllArticles();
    }
}
