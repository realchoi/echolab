using System.Collections.Generic;
using System.Threading.Tasks;
using EchoLab.Domains.NodeAggregate;
using EchoLab.Infrastructures.Core;
using EchoLab.Infrastructures.Repositories.Abstractions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EchoLab.Infrastructures.Repositories
{
    /// <summary>
    /// 节点分类数据仓储类
    /// </summary>
    public class NodeRepository : Repository<Node, long, DomainContext>, INodeRepository
    {
        readonly DomainContext _dbContext;

        public NodeRepository(DomainContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 查询节点列表
        /// </summary>
        /// <param name="categoryId">分类 ID</param>
        /// <returns></returns>
        public async Task<List<Node>> GetNodesAsync(long categoryId)
        {
            return await _dbContext.Nodes.Where(p => p.CategoryId == categoryId).ToListAsync();
        }
    }
}