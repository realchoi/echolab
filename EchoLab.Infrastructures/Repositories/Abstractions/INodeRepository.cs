using EchoLab.Domains.NodeAggregate;
using EchoLab.Infrastructures.Core;

namespace EchoLab.Infrastructures.Repositories.Abstractions
{
    /// <summary>
    /// Node 仓储接口
    /// </summary>
    public interface INodeRepository : IRepository<Node, long>
    {
    }
}