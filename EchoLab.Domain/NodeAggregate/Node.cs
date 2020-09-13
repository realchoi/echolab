using EchoLab.Domain.Abstractions;

namespace EchoLab.Domains.NodeAggregate
{
    /// <summary>
    /// 节点实体类，该实体类为聚合根
    /// </summary>
    public class Node : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; private set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }
    }
}