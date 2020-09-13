using AutoMapper;
using EchoLab.Api.Dtos;
using EchoLab.Domains.TopicAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLab.Api.Util.AutoMapper.CustomProfile
{
    public class TopicMapProfile : Profile
    {
        public TopicMapProfile()
        {
            CreateMap<Topic, TopicDto>();
        }
    }
}
