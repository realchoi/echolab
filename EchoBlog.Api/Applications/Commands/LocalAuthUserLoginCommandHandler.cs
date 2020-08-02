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
    public class LocalAuthUserLoginCommandHandler : IRequestHandler<LocalAuthUserLoginCommand, LocalAuthUserDto>
    {
        readonly ILocalAuthUserRepository _localAuthUserRepository;
        readonly IMapper _mapper;

        public LocalAuthUserLoginCommandHandler(ILocalAuthUserRepository localAuthUserRepository, IMapper mapper)
        {
            _localAuthUserRepository = localAuthUserRepository;
            _mapper = mapper;
        }

        public async Task<LocalAuthUserDto> Handle(LocalAuthUserLoginCommand request, CancellationToken cancellationToken)
        {
            // 根据用户名和口令进行查找用户
            var localAuthUser = await _localAuthUserRepository.AuthenticateAsync(request.UserName, request.Password);
            return localAuthUser == null ? null : _mapper.Map<LocalAuthUser, LocalAuthUserDto>(localAuthUser);
        }
    }
}
