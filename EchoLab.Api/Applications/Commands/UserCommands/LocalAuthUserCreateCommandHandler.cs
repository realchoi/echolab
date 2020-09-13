using AutoMapper;
using EchoLab.Api.Dtos;
using EchoLab.Domains.UserAggregate;
using EchoLab.Infrastructures.Repositories.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EchoLab.Api.Applications.Commands.UserCommands
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
            var localAuthUser = await _localAuthUserRepository.AddAsync(_mapper.Map<LocalAuthUserCreateCommand, LocalAuthUser>(request));
            // 注册时，创建一个用户信息数据，用来关联用户信息
            // 用户信息表中的用户名暂时使用用户的登录名，用户后续可自行更改
            var userProfile = new UserProfile(localAuthUser.Id, 1, localAuthUser.UserName);
            await _userProfileRepository.AddAsync(userProfile);
            await _localAuthUserRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return _mapper.Map<LocalAuthUser, LocalAuthUserDto>(localAuthUser);
        }
    }
}
