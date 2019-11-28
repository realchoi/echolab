using EchoBlog.Api.Util.Auth;
using EchoBlog.Model.Auth;
using EchoBlog.Util.AppConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoBlog.Api.Extension
{
    /// <summary>
    /// JWT 认证以及授权扩展类
    /// </summary>
    public static class JwtEx
    {
        /// <summary>
        /// 配置 Jwt
        /// </summary>
        /// <param name="services"></param>
        public static void AddJwtConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var privateKey = AppSetting.Get(new string[] { "JwtSetting", "PrivateKey" });
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));

            #region 添加 jwt 认证服务

            services
                .AddAuthentication("Bearer")
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        // 3+2
                        // 验证密钥
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = securityKey,
                        // 验证颁发者
                        ValidateIssuer = true,
                        ValidIssuer = "EchoBlog.Api",
                        // 验证订阅者
                        ValidateAudience = true,
                        ValidAudience = "EchoBlog.Ui",

                        // 需要过期时间
                        RequireExpirationTime = true,
                        // 验证生命周期（当设置 exp 和 nbf 时有效，同时启用 ClockSkew）
                        ValidateLifetime = true,
                        // 注意这是缓冲时间，总的有效时间 = 缓冲时间 + jwt 的过期时间；如果不设置，默认为 5 分钟
                        ClockSkew = TimeSpan.Zero
                    };
                });

            #endregion


            #region 添加授权策略

            services.AddAuthorization(o =>
            {
                #region 基于角色的授权策略

                // 授权策略：角色为 Admin 或者为 User 的用户都可以访问
                o.AddPolicy("AdminOrUser", p =>
                {
                    p.RequireRole("Admin", "User").Build();
                });

                // 授权策略：角色为 Admin 且为 User 的用户才可以访问
                o.AddPolicy("AdminAndUser", p =>
                {
                    p.RequireRole("Admin").RequireRole("User").Build();
                });

                #endregion


                #region 基于声明的授权策略

                o.AddPolicy("ClaimPolicy", p =>
                {
                    p.RequireClaim("Email", "admin@qq.com", "user@qq.com");
                });

                #endregion


                #region 基于自定义 Requirement 的授权策略

                o.AddPolicy("RequirementPolicy", p =>
                {
                    p.Requirements.Add(new PermissionRequirement() { Role = "Admin" });
                });

                services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

                #endregion
            });

            #endregion
        }
    }
}
