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
    /// 根据分类查询话题集成事件处理类
    /// </summary>
    public class CategoryTopicQueryHandler : IRequestHandler<TopicQuery, IEnumerable<TopicDto>>
    {
        readonly ITopicRepository _topicRepository;
        readonly IMapper _mapper;

        public CategoryTopicQueryHandler(ITopicRepository topicRepository, IMapper mapper)
        {
            this._topicRepository = topicRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<TopicDto>> Handle(TopicQuery request, CancellationToken cancellationToken)
        {
            var topicList = await _topicRepository.GetListByCategoryIdAsync(request.CategoryId);
            var topicDtoList = _mapper.Map<IEnumerable<Topic>, IEnumerable<TopicDto>>(topicList);
            return topicDtoList;
        }
    }
}
