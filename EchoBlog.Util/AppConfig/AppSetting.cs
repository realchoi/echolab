using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Util.AppConfig
{
    /// <summary>
    /// appsettings.json 操作类
    /// </summary>
    public class AppSetting
    {
        /// <summary>
        /// 配置对象
        /// </summary>
        private static IConfiguration configuration;

        /// <summary>
        /// 构造方法，初始化配置对象
        /// </summary>
        /// <param name="rootPath">配置文件所在的根目录</param>
        public AppSetting(string rootPath)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(rootPath)
                .Add(new JsonConfigurationSource()
                {
                    Path = "appsettings.json",
                    Optional = false,
                    ReloadOnChange = true
                }).Build();
        }

        /// <summary>
        /// 获取配置项的值
        /// </summary>
        /// <param name="sections">配置项的 key</param>
        /// <returns></returns>
        public static string Get(params string[] sections)
        {
            if (sections.Length > 0)
            {
                return configuration[string.Join(":", sections)];
            }
            return "";
        }
    }
}
