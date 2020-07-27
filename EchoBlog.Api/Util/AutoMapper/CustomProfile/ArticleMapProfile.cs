using AutoMapper;
using EchoBlog.Api.Applications.Commands;
using EchoBlog.Api.Dtos;
using EchoBlog.Api.Util.AutoMapper.CustomConverter;
using EchoBlog.Domains.ArticleAggregate;
using System;

namespace EchoBlog.Api.Util.AutoMapper.CustomProfile
{
    /// <summary>
    /// 文章的 AutoMapper 配置文件类
    /// </summary>
    public class ArticleMapProfile : Profile
    {
        /// <summary>
        /// 构造方法，创建映射关系
        /// </summary>
        public ArticleMapProfile()
        {
            var zeroTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);

            /*CreateMap<Article, ArticleDto>()
                .ForMember(destination => destination.CreateTime, source => source.MapFrom(s => zeroTime.AddSeconds(s.CreateTime).ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(destination => destination.LastTime, source => source.ConvertUsing(new DateTimeConverter()));    // 还可以使用配置文件的方式
            CreateMap<ArticleDto, Article>()
                .ForMember(des => des.CreateTime, src => src.MapFrom(s => new DateTimeOffset(DateTime.Parse(s.CreateTime)).ToUnixTimeSeconds()))
                .ForMember(des => des.LastTime, src => src.MapFrom(s => new DateTimeOffset(DateTime.Parse(s.LastTime)).ToUnixTimeSeconds()));*/

            CreateMap<ArticleCreateCommand, Article>();
        }
    }
}
