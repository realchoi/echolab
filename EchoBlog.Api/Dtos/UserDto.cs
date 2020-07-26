using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Dtos
{
    /// <summary>
    /// 用户数据传输类
    /// </summary>
    public class UserDto
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
