using AutoMapper;
using EchoLab.Api.Dtos;
using EchoLab.Domains.TopicAggregate;
using EchoLab.Infrastructures.Repositories.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using EchoLab.Domains.NodeAggregate;
using EchoLab.Domains.UserAggregate;
using EchoLab.Domains.CommentAggregate;

namespace EchoLab.Api.Applications.Queries.TopicQueries
{
    /// <summary>
    /// 根据分类查询话题集合集成事件处理类
    /// </summary>
    public class TopicListQueryHandler : IRequestHandler<TopicListQuery, IEnumerable<TopicDto>>
    {
        readonly ITopicRepository _topicRepository;
        readonly IUserProfileRepository _userProfileRepository;
        readonly INodeRepository _nodeRepository;
        readonly ICommentRepository _commentRepository;
        readonly IMapper _mapper;

        public TopicListQueryHandler(ITopicRepository topicRepository,
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

        /// <summary>
        /// 根据不同条件查询话题集合数据
        /// </summary>
        /// <param name="request">查询条件，包括分类 id、节点 id、作者 id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TopicDto>> Handle(TopicListQuery request, CancellationToken cancellationToken)
        {
            // 分类查询条件是否可用
            var categoryIdExpression = long.TryParse(request.CategoryId, out var categoryId);
            // 节点查询条件是否可用
            var nodeIdExpression = long.TryParse(request.CategoryId, out var nodeId);
            // 作者查询条件是否可用
            var authorIdExpression = long.TryParse(request.CategoryId, out var authorId);
            // 拼接最后的查询条件
            Expression<Func<Topic, bool>> expression = topic =>
                (!categoryIdExpression || topic.CategoryId == categoryId) &&
                (!nodeIdExpression || topic.NodeId == nodeId) &&
                (!authorIdExpression || topic.AuthorId == authorId);

            var topicList = await _topicRepository.GetListAsync(expression, cancellationToken);
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
                //var comments = await _commentRepository.GetListByTopicId(long.Parse(topicDto.Id));
                Expression<Func<Comment, bool>> comentExpression = comment => comment.TopicId == long.Parse(topicDto.Id);
                var comments = await _commentRepository.GetListAsync(comentExpression);
                topicDto.CommentNumber = comments?.Count ?? 0;
            }

            return topicDtoList;
        }
    }
}