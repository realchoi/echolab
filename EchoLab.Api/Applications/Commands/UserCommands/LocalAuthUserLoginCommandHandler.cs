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
    public class LocalAuthUserLoginCommandHandler : IRequestHandler<LocalAuthUserLoginCommand, LocalAuthUserDto>
    {
        readonly ILocalAuthUserRepository _localAuthUserRepository;
        readonly IMapper _mapper;

        public LocalAuthUserLoginCommandHandler(ILocalAuthUserRepository localAuthUserRepository, IMapper mapper)
        {
            _localAuthUserRepository = localAuthUserRepository;
            _mapper = mapper;
        }

        public async Task<LocalAuthUserDto> Handle(LocalAuthUserLoginCommand request,
            CancellationToken cancellationToken)
        {
            // 根据用户名和口令进行查找用户
            var localAuthUser = await _localAuthUserRepository.AuthenticateAsync(request.UserName, request.Password);
            var localAuthUserDto = _mapper.Map<LocalAuthUser, LocalAuthUserDto>(localAuthUser);
            if (localAuthUser != null)
                localAuthUserDto.AuthType = 1;
            return localAuthUserDto;
        }
    }
}