using AutoMapper;
using EchoLab.Api.Dtos;
using EchoLab.Domains.TopicAggregate;
using EchoLab.Infrastructures.Repositories.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EchoLab.Domains.NodeAggregate;
using EchoLab.Domains.UserAggregate;

namespace EchoLab.Api.Applications.Queries.TopicQueries
{
    /// <summary>
    /// 根据分类查询话题集成事件处理类
    /// </summary>
    public class CategoryTopicQueryHandler : IRequestHandler<TopicQuery, IEnumerable<TopicDto>>
    {
        readonly ITopicRepository _topicRepository;
        readonly IUserProfileRepository _userProfileRepository;
        readonly INodeRepository _nodeRepository;
        readonly ICommentRepository _commentRepository;
        readonly IMapper _mapper;

        public CategoryTopicQueryHandler(ITopicRepository topicRepository,
            IUserProfileRepository userProfileRepository,
            INodeRepository nodeRepository,
            ICommentRepository commentRepository,
            IMapper mapper)
        {
            this._topicRepository = topicRepository;
            this._userProfileRepository = userProfileRepository;
            this._nodeRepository = nodeRepository;
            this._commentRepository = commentRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<TopicDto>> Handle(TopicQuery request, CancellationToken cancellationToken)
        {
            var topicList = await _topicRepository.GetListByCategoryIdAsync(long.Parse(request.CategoryId));
            var topicDtoList = _mapper.Map<List<Topic>, List<TopicDto>>(topicList);
            if (topicDtoList == null || !topicDtoList.Any()) return topicDtoList;
            // 获取每个话题的作者信息、节点信息、评论数量
            foreach (var topicDto in topicDtoList)
            {
                // 作者
                var author = await _userProfileRepository.GetAsync(topicDto.AuthorId, cancellationToken);
                topicDto.Author = _mapper.Map<UserProfile, UserProfileDto>(author);
                // 节点
                var node = await _nodeRepository.GetAsync(topicDto.NodeId, cancellationToken);
                topicDto.Node = _mapper.Map<Node, NodeDto>(node);
                // 评论
                var comments = await _commentRepository.GetListByTopicId(long.Parse(topicDto.Id));
                topicDto.CommentNumber = comments?.Count ?? 0;
            }

            return topicDtoList;
        }
    }
}