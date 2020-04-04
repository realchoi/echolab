using EchoBlog.Domains.ArticleAggregate;
using EchoBlog.Infrastructures.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EchoBlog.Infrastructures.Repositories
{
    public class ArticleRepository : Repository<Article, int, DomainContext>, IArticleRepository
    {
        public ArticleRepository(DomainContext dbContext) : base(dbContext)
        {
        }


        public Task<List<Article>> GetByAuthorId(string authorId)
        {
            return Task.FromResult(DbContext.Articles.Where(p => p.AuthorId.Equals(authorId)).ToList());
        }
    }
}
