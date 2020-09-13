using EchoLab.Api.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLab.Api.Applications.Queries.TopicQueries
{
    /// <summary>
    /// 话题查询
    /// </summary>
    public class TopicQuery : IRequest<IEnumerable<TopicDto>>
    {
        public string CategoryId { get; /*private*/ set; }

        public string NodeId { get; /*private*/ set; }

        public string AuthorId { get; /*private*/ set; }

        public TopicQuery() { }

        public TopicQuery(string categoryId, string nodeId, string authorId)
        {
            CategoryId = categoryId;
            NodeId = nodeId;
            AuthorId = authorId;
        }
    }
}
