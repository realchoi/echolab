using EchoBlog.Domains.TopicAggregate;
using EchoBlog.Infrastructures.Core;
using EchoBlog.Infrastructures.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoBlog.Infrastructures.Repositories
{
    public class TopicRepository : Repository<Topic, long, DomainContext>, ITopicRepository
    {
        readonly DomainContext _dbContext;

        public TopicRepository(DomainContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 根据分类 Id 查询话题列表
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<List<Topic>> GetListByCategoryIdAsync(long categoryId)
        {
            return await _dbContext.Topics.Where(p => p.CategoryId == categoryId).ToListAsync();
        }


        /// <summary>
        /// 根据节点 Id 查询话题列表
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public async Task<List<Topic>> GetListByNodeIdAsync(long nodeId)
        {
            return await _dbContext.Topics.Where(p => p.NodeId == nodeId).ToListAsync();
        }


        /// <summary>
        /// 根据作者 Id 查询话题列表
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public async Task<List<Topic>> GetListByAuthorIdAsync(long authorId)
        {
            return await _dbContext.Topics.Where(p => p.AuthorId == authorId).ToListAsync();
        }
    }
}
