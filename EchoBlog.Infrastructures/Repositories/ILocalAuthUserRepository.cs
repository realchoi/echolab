using EchoBlog.Domains.UserAggregate;
using EchoBlog.Infrastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Infrastructures.Repositories
{
    public interface ILocalAuthUserRepository : IRepository<LocalAuthUser, long>
    {
    }
}
