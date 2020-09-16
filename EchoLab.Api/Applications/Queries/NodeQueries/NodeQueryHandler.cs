using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EchoLab.Api.Dtos;
using EchoLab.Domains.NodeAggregate;
using EchoLab.Infrastructures.Repositories.Abstractions;
using MediatR;

namespace EchoLab.Api.Applications.Queries.NodeQueries
{
    public class CategoryNodeQueryHandler : IRequestHandler<NodeQuery, IEnumerable<NodeDto>>
    {
        readonly INodeRepository _nodeRepository;
        private readonly IMapper _mapper;

        public CategoryNodeQueryHandler(INodeRepository nodeRepository, IMapper mapper)
        {
            this._nodeRepository = nodeRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<NodeDto>> Handle(NodeQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Node, bool>> expression = node =>
                string.IsNullOrEmpty(request.CategoryId) || node.CategoryId == long.Parse(request.CategoryId);
            var nodeList = await _nodeRepository.GetListAsync(expression, cancellationToken);
            var nodeDtoList = _mapper.Map<List<Node>, List<NodeDto>>(nodeList);
            return nodeDtoList;
        }
    }
}