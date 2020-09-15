using AutoMapper;
using EchoLab.Api.Dtos;
using EchoLab.Domains.NodeAggregate;

namespace EchoLab.Api.Util.AutoMapper.CustomProfile
{
    public class NodeMapProfile : Profile
    {
        public NodeMapProfile()
        {
            CreateMap<Node, NodeDto>();
            CreateMap<NodeDto, Node>();
        }
    }
}