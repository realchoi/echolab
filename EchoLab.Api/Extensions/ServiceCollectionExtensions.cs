using AutoMapper;
using EchoLab.Api.Infrastructures.Auth;
using EchoLab.Domains.ArticleAggregate;
using EchoLab.Infrastructures;
using EchoLab.Infrastructures.Core.Authorization;
using EchoLab.Infrastructures.Core.Snowflake;
using EchoLab.Infrastructures.Repositories;
using EchoLab.Infrastructures.Repositories.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EchoLab.Api.Extensions
{
    /// <summary>
    /// ServiceCollection 扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加 Swagger 服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerService(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var apiName = "EchoLab";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = $"{apiName} 接口文档（.net core 3.1 版本）" });

                #region 读取 xml 信息
                // 配置注释的 xml 文件
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                #endregion

                #region 在 Swagger 中配置授权接口

                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT 授权：在下框中输入 Bearer {token}（注意 Bearer 后面有一个空格）",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                #endregion
            });
        }


        /// <summary>
        /// 添加 AutoMapper 服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddAutoMapperService(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // 利用反射，批量注入 Profile 类的自定义子类
            List<Type> profiles = new List<Type>();

            var assemblies = configuration.GetSection("Assembly")["AutoMapper"];

            foreach (var assembly in assemblies.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                // 获取所有继承 Profile 的子类
                var types = Assembly.Load(assembly).GetTypes()
                    .Where(t => t.BaseType != null && t.BaseType.FullName.Equals("AutoMapper.Profile"));

                if (types.Any())
                    profiles.AddRange(types);
            }
            if (profiles.Any())
                services.AddAutoMapper(profiles.ToArray());
        }


        /// <summary>
        /// 添加 Jwt 认证授权服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var privateKey = configuration.GetSection("JwtSetting")["PrivateKey"];
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
                        ValidIssuer = "EchoLab.Api",
                        // 验证订阅者
                        ValidateAudience = true,
                        ValidAudience = "EchoLab.Ui",

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

                // 授权策略：角色为 User 的用户都可以访问
                o.AddPolicy("AdminOrUser", p =>
                {
                    p.RequireRole("User").Build();
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


        /// <summary>
        /// 添加 MediatR 服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMediatRService(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DomainContextTransactionBehavior<,>));
            return services.AddMediatR(typeof(Article).Assembly, typeof(Program).Assembly);
        }


        /// <summary>
        /// 添加数据库连接配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IServiceCollection AddDomainContext(this IServiceCollection services, Action<DbContextOptionsBuilder> action)
        {
            return services.AddDbContext<DomainContext>(action);
        }


        /// <summary>
        /// 添加 Mysql 数据库连接配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddMySqlDomainContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDomainContext(builder =>
            {
                builder.UseMySql(connectionString);
            });
        }


        /// <summary>
        /// 添加业务服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomerService(this IServiceCollection services)
        {
            services.AddSingleton(new SnowflakeId(0, 0));
            services.AddScoped<JwtTokenGenerator>();
            services.AddScoped<JwtToken>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<ILocalAuthUserRepository, LocalAuthUserRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
