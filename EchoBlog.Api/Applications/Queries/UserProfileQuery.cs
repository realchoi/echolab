using EchoBlog.Api.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Applications.Queries
{
    public class UserProfileQuery : IRequest<UserProfileDto>
    {
        public string Id { get; /*private*/ set; }

        public string Name { get; /*private*/ set; }

        public UserProfileQuery() { }

        public UserProfileQuery(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
