using AutoMapper;
using EchoBlog.Api.Dtos;
using EchoBlog.Domains.TopicAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Util.AutoMapper.CustomProfile
{
    public class TopicMapProfile : Profile
    {
        public TopicMapProfile()
        {
            CreateMap<Topic, TopicDto>();
        }
    }
}
