using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Model.Auth
{
    /// <summary>
    /// 自定义授权策略类
    /// </summary>
    public class PermissionRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
    }
}
