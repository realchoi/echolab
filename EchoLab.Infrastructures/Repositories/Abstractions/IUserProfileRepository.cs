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
    }
}
