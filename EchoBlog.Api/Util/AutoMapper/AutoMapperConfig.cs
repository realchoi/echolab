using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Util.AutoMapper
{
    /// <summary>
    /// AutoMapper 配置帮助类
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// 获取 AutoMapper 配置
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration GetAutoMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
        }
    }
}
