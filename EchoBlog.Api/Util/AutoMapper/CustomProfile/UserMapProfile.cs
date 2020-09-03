using AutoMapper;
using EchoBlog.Api.Applications.Commands.UserCommands;
using EchoBlog.Api.Dtos;
using EchoBlog.Domains.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Util.AutoMapper.CustomProfile
{
    public class UserMapProfile : Profile
    {
        /// <summary>
        /// 构造方法，创建映射关系
        /// </summary>
        public UserMapProfile()
        {
            CreateMap<LocalAuthUserCreateCommand, LocalAuthUser>();
            CreateMap<LocalAuthUser, LocalAuthUserDto>();

            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfileDto, UserProfile>();
        }
    }
}
