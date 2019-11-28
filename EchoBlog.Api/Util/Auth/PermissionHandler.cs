﻿using EchoBlog.Model.Auth;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Util.Auth
{
    /// <summary>
    /// 自定义授权策略处理类
    /// </summary>
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            // 如果传递进来的自定义参数 Role 的值为 Admin，则代表授权成功
            //if (requirement.Role.Equals("Admin"))
            //    context.Succeed(requirement);

            // 暂不写逻辑
            return Task.CompletedTask;
        }
    }
}
