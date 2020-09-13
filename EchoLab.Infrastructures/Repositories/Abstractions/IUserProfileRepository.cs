using EchoLab.Domains.UserAggregate;
using EchoLab.Infrastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoLab.Infrastructures.Repositories.Abstractions
{
    /// <summary>
    /// UserProfile 仓储接口
    /// </summary>
    public interface IUserProfileRepository : IRepository<UserProfile, long>
    {
        /// <summary>
        /// 根据认证信息获取用户信息
        /// </summary>
        /// <param name="authType">用户认证类型（值域：1-用户名密码登录用户；2-第三方登录用户）</param>
        /// <param name="authId">用户认证 ID</param>
        /// <returns></returns>
        Task<UserProfile> GetUserProfileByAuthId(int authType, long authId);
    }
}
