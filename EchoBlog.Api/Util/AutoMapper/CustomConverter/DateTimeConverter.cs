using AutoMapper;
using System;

namespace EchoBlog.Api.Util.AutoMapper.CustomConverter
{
    /// <summary>
    /// AutoMapper 自定义时间的映射规则：从 DateTime 转为对应的字符串
    /// </summary>
    public class DateTimeConverter : IValueConverter<DateTime, string>
    {
        public string Convert(DateTime sourceMember, ResolutionContext context)
        => sourceMember != null ? sourceMember.ToString("yyyy-MM-dd HH:mm:ss") : "暂无发布时间";
    }
}
