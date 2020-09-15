using System.Collections.Generic;
using System.Threading.Tasks;
using EchoLab.Domains.NodeAggregate;
using EchoLab.Infrastructures.Core;

namespace EchoLab.Infrastructures.Repositories.Abstractions
{
    /// <summary>
    /// Node 仓储接口
    /// </summary>
    public interface INodeRepository : IRepository<Node, long>
    {
        /// <summary>
        /// 根据分类 Id 查询节点列表
        /// </summary>
        /// <param name="categoryId">分类 ID</param>
        /// <returns></returns>
        Task<List<Node>> GetNodesAsync(long categoryId);
    }
}