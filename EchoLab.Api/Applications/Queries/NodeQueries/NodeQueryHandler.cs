using System.Collections.Generic;
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
            var nodeList = await _nodeRepository.GetNodesAsync(long.Parse(request.CategoryId));
            var nodeDtoList = _mapper.Map<List<Node>, List<NodeDto>>(nodeList);
            return nodeDtoList;
        }
    }
}