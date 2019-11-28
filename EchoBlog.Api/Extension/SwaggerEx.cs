using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;

namespace EchoBlog.Api.Extension
{
    /// <summary>
    /// Swagger 扩展类
    /// </summary>
    public static class SwaggerEx
    {
        /// <summary>
        /// 配置 Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var apiName = "EchoBlog";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"{apiName} 接口文档（.net core 3.0 版本）",
                    Description = $"{apiName} Http Api V1",
                    Contact = new OpenApiContact { Name = "Eric Choi", Email = "meetcds@foxmail.com" },
                    License = new OpenApiLicense { Name = "Choi's Page", Url = new Uri("https://realchoi.com") }
                });
                c.OrderActionsBy(o => o.RelativePath);

                #region 读取 xml 信息

                // 配置注释的 xml 文件
                // var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "EchoBlog.Api.xml");
                c.IncludeXmlComments(xmlPath, true);

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
    }
}
