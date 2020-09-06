using AutoMapper;
using EchoBlog.Api.Dtos;
using EchoBlog.Domains.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Util.AutoMapper.CustomProfile
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
