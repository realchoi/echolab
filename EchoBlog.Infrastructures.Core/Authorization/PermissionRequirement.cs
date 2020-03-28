using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Infrastructures.Core.Authorization
{
    /// <summary>
    /// 授权策略类
    /// </summary>
    public class PermissionRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
    }
}
