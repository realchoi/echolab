using EchoBlog.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoBlog.Service.Def
{
    /// <summary>
    /// 文章业务服务接口
    /// </summary>
    public interface IArticleService
    {
        Task<IEnumerable<ArticleModel>> GetAllArticles();
    }
}
