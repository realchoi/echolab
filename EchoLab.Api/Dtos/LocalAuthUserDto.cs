using EchoLab.Infrastructures.Core.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLab.Api.Dtos
{
    /// <summary>
    /// 用户名密码登录用户数据传输类
    /// 需要将 dto 的 id 统一设为 string 类型，原因是 long 类型传递到前端会丢失精度
    /// </summary>
    public class LocalAuthUserDto : BaseDto<string>
    {
        public int AuthType { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }
    }
}
