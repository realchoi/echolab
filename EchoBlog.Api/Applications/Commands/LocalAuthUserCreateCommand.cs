﻿using EchoBlog.Api.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Applications.Commands
{
    public class LocalAuthUserCreateCommand : IRequest<UserDto>
    {
        public LocalAuthUserCreateCommand() { }

        public LocalAuthUserCreateCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        /*public long Id { get; set }*/

        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}