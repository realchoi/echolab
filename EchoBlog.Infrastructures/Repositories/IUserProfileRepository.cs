using EchoBlog.Domains.UserAggregate;
using EchoBlog.Infrastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoBlog.Infrastructures.Repositories
{
    /// <summary>
    /// UserProfile 仓储接口
    /// </summary>
    public interface IUserProfileRepository : IRepository<UserProfile, long>
    {
        Task<List<UserProfile>> GetUserProfile(string userId);
    }
}
