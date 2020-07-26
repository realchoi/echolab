using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EchoBlog.Api.Applications.Commands;
using EchoBlog.Api.Dtos;
using EchoBlog.Api.Infrastructures.Auth;
using EchoBlog.Core;
using EchoBlog.Infrastructures.Core.Authorization;
using EchoBlog.Infrastructures.Core.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EchoBlog.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly JwtToken _jwtToken;

        public UserController(IMediator mediator, JwtToken jwtToken)
        {
            _mediator = mediator;
            _jwtToken = jwtToken;
        }


        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<Result<string>> Register([FromBody] LocalAuthUserCreateCommand command)
        {
            LogUtil.Info("用户创建");
            var result = new Result<string>();
            try
            {
                var user = await _mediator.Send(command);
                // 如果注册成功，返回一个新的 jwt token
                if (user != null)
                {
                    var token = await _jwtToken.GetJwtToken();
                    result.Data = token;
                }
                else
                {
                    result.Code = -1;
                    result.Message = "注册失败";
                }
            }
            catch (Exception ex)
            {
                result.Code = -1;
                result.Message = $"程序发生异常：{ex.Message}";
            }
            return result;
        }
    }
}
