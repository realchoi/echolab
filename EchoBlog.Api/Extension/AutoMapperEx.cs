using AutoMapper;
using EchoBlog.Api.Util.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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

            services.AddAutoMapper(typeof(AutoMapperProfile));
            //AutoMapperConfig.GetAutoMapperConfiguration();
        }
    }
}
