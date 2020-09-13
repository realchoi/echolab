using EchoLab.Domains.UserAggregate;
using EchoLab.Infrastructures.Core;
using EchoLab.Infrastructures.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoLab.Infrastructures.Repositories
{
    public class LocalAuthUserRepository : Repository<LocalAuthUser, long, DomainContext>, ILocalAuthUserRepository
    {
        public LocalAuthUserRepository(DomainContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 根据用户名和口令进行认证
        /// </summary>
        /// <param name="userName">登录用户名</param>
        /// <param name="password">登录口令</param>
        /// <returns></returns>
        public async Task<LocalAuthUser> AuthenticateAsync(string userName, string password)
        {
            var localAuthUser = await DbContext.LocalAuthUsers
                .FirstOrDefaultAsync(p => p.UserName == userName && p.Password == password);
            return localAuthUser;
        }
    }
}
