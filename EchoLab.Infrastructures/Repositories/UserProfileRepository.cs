using EchoLab.Domains.UserAggregate;
using EchoLab.Infrastructures.Core;
using EchoLab.Infrastructures.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EchoLab.Infrastructures.Repositories
{
    public class UserProfileRepository : Repository<UserProfile, long, DomainContext>, IUserProfileRepository
    {
        DomainContext _dbContext;

        public UserProfileRepository(DomainContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
