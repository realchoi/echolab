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

namespace EchoBlog.Api.Applications.Queries.UserQueries
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
            if (long.TryParse(request.Id, out var id))
            {
                var userProfile = await _userProfileRepository.GetAsync(id);
                return _mapper.Map<UserProfile, UserProfileDto>(userProfile);
            }
            return null;
        }
    }
}
