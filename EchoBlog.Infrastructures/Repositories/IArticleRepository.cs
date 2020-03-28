using EchoBlog.Domains.ArticleAggregate;
using EchoBlog.Infrastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoBlog.Infrastructures.Repositories
{
    public interface IArticleRepository : IRepository<Article, int>
    {
        Task<List<Article>> GetByAuthorId(string authorId);
    }
}
