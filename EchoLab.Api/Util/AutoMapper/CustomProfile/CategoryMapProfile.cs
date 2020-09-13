using AutoMapper;
using EchoLab.Api.Dtos;
using EchoLab.Domains.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLab.Api.Util.AutoMapper.CustomProfile
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
