using EchoBlog.Infrastructures.Core.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Dtos
{
    public class UserProfileDto : BaseDto<string>
    {
        public string Name { get; private set; }

        public string Avatar { get; private set; }

        public string Introduction { get; private set; }

        public string Roles { get; private set; }

        public string Email { get; private set; }

        public string Github { get; private set; }

        public string Website { get; private set; }
    }
}
