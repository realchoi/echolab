using EchoBlog.Domains.UserAggregate;
using EchoBlog.Infrastructures.Core;
using EchoBlog.Infrastructures.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EchoBlog.Infrastructures.Repositories
{
    public class UserProfileRepository : Repository<UserProfile, long, DomainContext>, IUserProfileRepository
    {
        public UserProfileRepository(DomainContext dbContext) : base(dbContext)
        {
        }
    }
}
