using EchoLab.Api.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLab.Api.Applications.Queries.UserQueries
{
    public class UserProfileQuery : IRequest<UserProfileDto>
    {
        public int? AuthType { get; /*private*/ set; }

        public string AuthId { get; /*private*/ set; }

        public UserProfileQuery() { }

        public UserProfileQuery(int? authType, string authId)
        {
            AuthType = authType;
            AuthId = authId;
        }
    }
}
