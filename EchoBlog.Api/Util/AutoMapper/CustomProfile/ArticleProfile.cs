using AutoMapper;
using EchoBlog.Api.Util.AutoMapper.CustomConverter;
using EchoBlog.Entity;
using EchoBlog.Model;

namespace EchoBlog.Api.Util.AutoMapper.CustomProfile
{
    /// <summary>
    /// 文章的 AutoMapper 配置文件类
    /// </summary>
    public class ArticleProfile : Profile
    {
        /// <summary>
        /// 构造方法，创建映射关系
        /// </summary>
        public ArticleProfile()
        {
            CreateMap<ArticleEntity, ArticleModel>()
                .ForMember(destination => destination.ReadTimes, source => source.MapFrom(s => s.ReadTimes + 1))
                .ForMember(destination => destination.CreateTime, source => source.MapFrom(s => s.CreateTime.ToString("yyyy-MM-dd")))
                .ForMember(destination => destination.UpdateTime, source => source.ConvertUsing(new DateTimeConverter()));
            CreateMap<ArticleModel, ArticleEntity>();
        }
    }
}
