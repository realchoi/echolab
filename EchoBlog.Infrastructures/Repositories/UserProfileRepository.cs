using EchoBlog.Domains.UserAggregate;
using EchoBlog.Infrastructures.Core;
using EchoBlog.Infrastructures.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
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
        DomainContext _dbContext;

        public UserProfileRepository(DomainContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }


        /// <summary>
        /// 根据认证信息获取用户信息
        /// </summary>
        /// <param name="authType">用户认证类型（值域：1-用户名密码登录用户；2-第三方登录用户）</param>
        /// <param name="authId">用户认证 ID</param>
        /// <returns></returns>
        public async Task<UserProfile> GetUserProfileByAuthId(int authType, long authId)
        {
            return await _dbContext.UserProfiles.Where(p => p.AuthType == authType && p.AuthId == authId).FirstOrDefaultAsync();
        }
    }
}
