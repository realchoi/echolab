using EchoLab.Domains.ArticleAggregate;
using EchoLab.Infrastructures.Core;
using EchoLab.Infrastructures.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EchoLab.Infrastructures.Repositories
{
    public class ArticleRepository : Repository<Article, int, DomainContext>, IArticleRepository
    {
        public ArticleRepository(DomainContext dbContext) : base(dbContext)
        {
        }


        public Task<List<Article>> GetByAuthorIdAsync(string authorId)
        {
            return Task.FromResult(DbContext.Articles.Where(p => p.AuthorId.Equals(authorId)).ToList());
        }
    }
}
