using AutoMapper;
using System;

namespace EchoLab.Api.Util.AutoMapper.CustomConverter
{
    /// <summary>
    /// AutoMapper 自定义时间的映射规则：从 DateTime 转为对应的字符串
    /// </summary>
    public class DateTimeConverter : IValueConverter<long, string>
    {
        readonly DateTime _zeroTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);

        public string Convert(long sourceMember, ResolutionContext context)
            => _zeroTime.AddSeconds(sourceMember).ToString("yyyy-MM-dd HH:mm:ss");
    }
}
