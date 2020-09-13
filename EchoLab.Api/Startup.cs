using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using EchoLab.Api.Attribute;
using EchoLab.Api.Extensions;
using EchoLab.Infrastructures;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EchoLab.Api
{
    public class Startup
    {
        /// <summary>
        /// Api 名称
        /// </summary>
        public string ApiName { get; set; } = "EchoLab";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 添加数据库配置
            services.AddMySqlDomainContext(Configuration.GetConnectionString("Default"));
            // 添加 Swagger 服务
            services.AddSwaggerService();
            // 添加授权策略
            services.AddJwtService(Configuration);
            // 添加 AutoMapper
            services.AddAutoMapperService(Configuration);
            // 添加 MediatR
            services.AddMediatRService();
            // 添加业务类
            services.AddCustomerService();

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

            // 确保数据库创建
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DomainContext>();
                context.Database.EnsureCreated();
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
