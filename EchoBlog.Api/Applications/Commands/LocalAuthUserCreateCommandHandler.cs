using AutoMapper;
using EchoBlog.Api.Dtos;
using EchoBlog.Domains.UserAggregate;
using EchoBlog.Infrastructures.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EchoBlog.Api.Applications.Commands
{
    public class LocalAuthUserCreateCommandHandler : IRequestHandler<LocalAuthUserCreateCommand, UserDto>
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

        public async Task<UserDto> Handle(LocalAuthUserCreateCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.AddAsync(new UserProfile());
            if (userProfile != null)
            {
                request.UserId = userProfile.Id;
                var localAuthUser = await _localAuthUserRepository.AddAsync(_mapper.Map<LocalAuthUserCreateCommand, LocalAuthUser>(request));
                userProfile.SetName(localAuthUser.UserName);  // 用户信息表中的用户名暂时使用用户的登录名
                await _localAuthUserRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                return _mapper.Map<LocalAuthUser, UserDto>(localAuthUser);
            }
            else
                throw new Exception("注册失败");
        }
    }
}
