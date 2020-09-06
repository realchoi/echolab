using EchoBlog.Api.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Applications.Queries.TopicQueries
{
    /// <summary>
    /// 话题查询
    /// </summary>
    public class TopicQuery : IRequest<IEnumerable<TopicDto>>
    {
        public long CategoryId { get; /*private*/ set; }

        public long NodeId { get; /*private*/ set; }

        public long AuthorId { get; /*private*/ set; }

        public TopicQuery() { }

        public TopicQuery(long categoryId, long nodeId, long authorId)
        {
            CategoryId = categoryId;
            NodeId = nodeId;
            AuthorId = authorId;
        }
    }
}
