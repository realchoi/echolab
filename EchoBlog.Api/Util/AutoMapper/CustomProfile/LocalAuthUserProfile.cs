using AutoMapper;
using EchoBlog.Api.Applications.Commands;
using EchoBlog.Api.Dtos;
using EchoBlog.Domains.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Util.AutoMapper.CustomProfile
{
    public class LocalAuthUserProfile : Profile
    {
        /// <summary>
        /// 构造方法，创建映射关系
        /// </summary>
        public LocalAuthUserProfile()
        {
            CreateMap<LocalAuthUserCreateCommand, LocalAuthUser>();
            CreateMap<LocalAuthUser, UserDto>();
        }
    }
}
