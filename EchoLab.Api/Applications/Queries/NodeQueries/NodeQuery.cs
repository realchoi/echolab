using System.Collections.Generic;
using EchoLab.Api.Dtos;
using MediatR;

namespace EchoLab.Api.Applications.Queries.NodeQueries
{
    /// <summary>
    /// 节点查询
    /// </summary>
    public class NodeQuery : IRequest<IEnumerable<NodeDto>>
    {
        /// <summary>
        /// 分类 ID
        /// </summary>
        public string CategoryId { get; /*private*/ set; }

        public NodeQuery()
        {
        }

        public NodeQuery(string categoryId)
        {
            CategoryId = categoryId;
        }
    }
}