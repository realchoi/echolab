using EchoLab.Domains.ArticleAggregate;
using EchoLab.Infrastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoLab.Infrastructures.Repositories.Abstractions
{
    public interface IArticleRepository : IRepository<Article, int>
    {
        Task<List<Article>> GetByAuthorIdAsync(string authorId);
    }
}
