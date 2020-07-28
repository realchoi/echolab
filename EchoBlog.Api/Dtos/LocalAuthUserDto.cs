using EchoBlog.Infrastructures.Core.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Dtos
{
    public class LocalAuthUserDto : BaseDto<long>
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
