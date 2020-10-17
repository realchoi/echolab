using AutoMapper;
using EchoLab.Api.Dtos;
using EchoLab.Domains.CommentAggregate;
using EchoLab.Domains.NodeAggregate;
using EchoLab.Domains.TopicAggregate;
using EchoLab.Domains.UserAggregate;
using EchoLab.Infrastructures.Repositories.Abstractions;
using MediatR;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace EchoLab.Api.Applications.Queries.TopicQueries
{
    /// <summary>
    /// 根据分类查询单个话题集成事件处理类
    /// </summary>
    public class TopicSingleQueryHandler : IRequestHandler<TopicSingleQuery, TopicDto>
    {
        readonly ITopicRepository _topicRepository;
        readonly IUserProfileRepository _userProfileRepository;
        readonly INodeRepository _nodeRepository;
        readonly ICommentRepository _commentRepository;
        readonly IMapper _mapper;

        public TopicSingleQueryHandler(ITopicRepository topicRepository,
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

        public async Task<TopicDto> Handle(TopicSingleQuery request, CancellationToken cancellationToken)
        {
            if (!long.TryParse(request.Id, out var id))
                return null;

            var topic = await _topicRepository.GetAsync(id, cancellationToken);
            var topicDto = _mapper.Map<Topic, TopicDto>(topic);
            if (topicDto != null)
            {
                // 作者
                var author = await _userProfileRepository.GetAsync(topicDto.AuthorId, cancellationToken);
                topicDto.Author = _mapper.Map<UserProfile, UserProfileDto>(author);
                /*
                // 节点
                var node = await _nodeRepository.GetAsync(topicDto.NodeId, cancellationToken);
                topicDto.Node = _mapper.Map<Node, NodeDto>(node);
                // 评论
                Expression<Func<Comment, bool>> comentExpression = comment => comment.TopicId == long.Parse(topicDto.Id);
                var comments = await _commentRepository.GetListAsync(comentExpression);
                topicDto.CommentNumber = comments?.Count ?? 0;*/
            }
            return topicDto;
        }
    }
}
