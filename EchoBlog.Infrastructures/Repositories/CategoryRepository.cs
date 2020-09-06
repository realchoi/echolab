using EchoBlog.Domains.CategoryAggregate;
using EchoBlog.Infrastructures.Core;
using EchoBlog.Infrastructures.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoBlog.Infrastructures.Repositories
{
    /// <summary>
    /// 话题分类数据仓储类
    /// </summary>
    public class CategoryRepository : Repository<Category, long, DomainContext>, ICategoryRepository
    {
        readonly DomainContext _dbContext;

        public CategoryRepository(DomainContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 查询话题分类列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GetListAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
