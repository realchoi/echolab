using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using AspectCore.Injector;
using AutoMapper;
using EchoBlog.Api.Attribute;
using EchoBlog.Api.Extension;
using EchoBlog.Api.Util.Auth;
using EchoBlog.Api.Util.AutoMapper;
using EchoBlog.Repository.DbConfig;
using EchoBlog.Repository.Def;
using EchoBlog.Repository.Impl;
using EchoBlog.Service.Def;
using EchoBlog.Service.Impl;
using EchoBlog.Util.AppConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace EchoBlog.Api
{
    public class Startup
    {
        /// <summary>
        /// Api 名称
        /// </summary>
        public string ApiName { get; set; } = "EchoBlog";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;

            // 初始化数据库连接字符串
            BaseDbConfig.ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region 注入用到的类

            services.AddSingleton(new AppSetting(Env.ContentRootPath));
            services.AddSingleton<IArticleRepository, ArticleRepository>();
            services.AddSingleton<IArticleService, ArticleService>();

            #endregion

            // 添加 Swagger 服务
            services.AddSwaggerConfiguration();
            // 添加授权策略
            services.AddJwtConfiguration();
            // 添加 AutoMapper
            services.AddAutoMapperConfiguration();

            services.AddControllers();

            // 注入属性拦截器
            services.ConfigureDynamicProxy(cfg =>
            {
                cfg.Interceptors.AddTyped<LogAttribute>(Predicates.ForService("*Service"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 启用 Swagger 中间件
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"{ApiName} v1");
                c.RoutePrefix = "";
            });

            app.UseRouting();

            // 先认证
            app.UseAuthentication();
            // 再授权
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
