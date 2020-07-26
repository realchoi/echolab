using EchoBlog.Domains.UserAggregate;
using EchoBlog.Infrastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Infrastructures.Repositories
{
    public class LocalAuthUserRepository : Repository<LocalAuthUser, long, DomainContext>, ILocalAuthUserRepository
    {
        public LocalAuthUserRepository(DomainContext dbContext) : base(dbContext)
        {
        }
    }
}
