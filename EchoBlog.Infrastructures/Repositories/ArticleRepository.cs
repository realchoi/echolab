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


        public async Task<List<Article>> GetByAuthorId(string authorId)
        {
            return await Task.Run(() =>
            {
                return DbContext.Articles.Where(p => p.AuthorId.Equals(authorId)).ToList();
            });
        }
    }
}
