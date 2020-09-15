using AutoMapper;
using EchoLab.Api.Dtos;
using EchoLab.Domains.CommentAggregate;

namespace EchoLab.Api.Util.AutoMapper.CustomProfile
{
    public class CommentMapProfile : Profile
    {
        public CommentMapProfile()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}