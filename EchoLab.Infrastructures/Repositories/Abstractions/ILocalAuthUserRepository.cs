using EchoLab.Domains.UserAggregate;
using EchoLab.Infrastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoLab.Infrastructures.Repositories.Abstractions
{
    public interface ILocalAuthUserRepository : IRepository<LocalAuthUser, long>
    {
        /// <summary>
        /// 根据用户名和口令进行认证（异步）
        /// </summary>
        /// <param name="userName">登录用户名</param>
        /// <param name="password">登录口令</param>
        /// <returns></returns>
        Task<LocalAuthUser> AuthenticateAsync(string userName, string password);
    }
}
