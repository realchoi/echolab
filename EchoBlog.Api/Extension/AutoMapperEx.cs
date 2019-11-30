using AutoMapper;
using EchoBlog.Api.Util.AutoMapper.CustomProfile;
using EchoBlog.Util.AppConfig;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EchoBlog.Api.Extension
{
    /// <summary>
    /// AutoMapper 扩展类
    /// </summary>
    public static class AutoMapperEx
    {
        /// <summary>
        /// 配置 AutoMapper
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // 利用反射，批量注入 Profile 类的自定义子类
            List<Type> profiles = new List<Type>();

            // 从 appsettings.config 文件读取配置，每个程序集之间使用英文逗号分隔
            var assemblies = AppSetting.Get("Assembly", "AutoMapper");

            foreach (var assembly in assemblies.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                // 获取所有继承 Profile 的子类
                var types = Assembly.Load(assembly).GetTypes()
                    .Where(t => t.BaseType != null && t.BaseType.Name.Equals("Profile"));

                if (types.Any())
                    profiles.AddRange(types);
            }
            if (profiles.Any())
                services.AddAutoMapper(profiles.ToArray());
        }
    }
}
