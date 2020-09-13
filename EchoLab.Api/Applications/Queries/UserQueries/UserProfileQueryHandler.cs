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

namespace EchoLab.Api.Applications.Queries.UserQueries
{
    public class UserProfileQueryHandler : IRequestHandler<UserProfileQuery, UserProfileDto>
    {
        readonly IUserProfileRepository _userProfileRepository;
        readonly IMapper _mapper;

        public UserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
        {
            this._userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task<UserProfileDto> Handle(UserProfileQuery request, CancellationToken cancellationToken)
        {
            if (long.TryParse(request.AuthId, out var authId))
            {
                var userProfile = await _userProfileRepository.GetUserProfileByAuthId(request.AuthType.Value, authId);
                return _mapper.Map<UserProfile, UserProfileDto>(userProfile);
            }
            return null;
        }
    }
}
