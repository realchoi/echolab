using AutoMapper;
using EchoBlog.Entity;
using EchoBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Util.AutoMapper
{
    /// <summary>
    /// AutoMapper 配置文件类
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// 构造方法，创建映射关系
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<ArticleEntity, ArticleModel>();
            CreateMap<ArticleModel, ArticleEntity>();
        }
    }
}
