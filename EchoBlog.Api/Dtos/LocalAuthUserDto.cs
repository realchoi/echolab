using EchoBlog.Infrastructures.Core.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Dtos
{
    public class LocalAuthUserDto : BaseDto<long>
    {
        public long UserId { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }
    }
}
