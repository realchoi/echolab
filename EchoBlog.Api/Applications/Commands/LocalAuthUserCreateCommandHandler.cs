using AutoMapper;
using EchoBlog.Api.Dtos;
using EchoBlog.Domains.UserAggregate;
using EchoBlog.Infrastructures.Repositories.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EchoBlog.Api.Applications.Commands
{
    public class LocalAuthUserCreateCommandHandler : IRequestHandler<LocalAuthUserCreateCommand, LocalAuthUserDto>
    {
        readonly IUserProfileRepository _userProfileRepository;
        readonly ILocalAuthUserRepository _localAuthUserRepository;
        readonly IMapper _mapper;

        public LocalAuthUserCreateCommandHandler(IUserProfileRepository userProfileRepository, ILocalAuthUserRepository localAuthUserRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _localAuthUserRepository = localAuthUserRepository;
            _mapper = mapper;
        }

        public async Task<LocalAuthUserDto> Handle(LocalAuthUserCreateCommand request, CancellationToken cancellationToken)
        {
            // 注册时，创建一个用户信息数据，用来以后关联用户信息
            var userProfile = await _userProfileRepository.AddAsync(new UserProfile());
            request.UserId = userProfile.Id;
            var localAuthUser = await _localAuthUserRepository.AddAsync(_mapper.Map<LocalAuthUserCreateCommand, LocalAuthUser>(request));
            // 用户信息表中的用户名暂时使用用户的登录名，用户后续可自行更改
            userProfile.SetName(localAuthUser.UserName);
            await _localAuthUserRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return _mapper.Map<LocalAuthUser, LocalAuthUserDto>(localAuthUser);
        }
    }
}
