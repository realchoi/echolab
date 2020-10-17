using EchoLab.Api.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLab.Api.Applications.Queries.TopicQueries
{
    /// <summary>
    /// 单个话题查询
    /// </summary>
    public class TopicSingleQuery : IRequest<TopicDto>
    {
        public string Id { get; /*private*/ set; }

        public TopicSingleQuery() { }
        
        public TopicSingleQuery(string id)
        {
            Id = id;
        }
    }
}
