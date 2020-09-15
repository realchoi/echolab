using EchoLab.Domains.ArticleAggregate;
using EchoLab.Infrastructures.Core;
using EchoLab.Infrastructures.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// 测试使用 Expression 表达式当作条件
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<List<Article>> GetListAsync(Expression<Func<Article, bool>> expression)
        {
            return await DbContext.Articles.Where(expression).ToListAsync();
        }
    }
}