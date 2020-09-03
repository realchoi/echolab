using AutoMapper;
using EchoBlog.Api.Dtos;
using EchoBlog.Domains.TopicAggregate;
using EchoBlog.Infrastructures.Repositories.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EchoBlog.Api.Applications.Queries.TopicQueries
{
    /// <summary>
    /// 话题查询集成事件处理类
    /// </summary>
    public class TopicQueryHandler : IRequestHandler<TopicQuery, IEnumerable<TopicDto>>
    {
        ITopicRepository _topicRepository;
        IMapper _mapper;

        public TopicQueryHandler(ITopicRepository topicRepository, IMapper mapper)
        {
            this._topicRepository = topicRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<TopicDto>> Handle(TopicQuery request, CancellationToken cancellationToken)
        {
            var topics = await _topicRepository.GetListByCategoryIdAsync(request.CategoryId);
            var topicsDto = _mapper.Map<IEnumerable<Topic>, IEnumerable<TopicDto>>(topics);
            return topicsDto;
        }
    }
}
