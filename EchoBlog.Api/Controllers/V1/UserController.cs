using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EchoBlog.Api.Applications.Commands;
using EchoBlog.Api.Applications.Queries;
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
        public async Task<Result<LocalAuthUserDto>> Register([FromBody] LocalAuthUserCreateCommand command)
        {
            LogUtil.Info("用户创建");
            var result = new Result<LocalAuthUserDto>();
            try
            {
                var localAuthUserDto = await _mediator.Send(command);
                if (localAuthUserDto != null)
                {
                    result.Data = localAuthUserDto;
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


        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<Result<LocalAuthUserDto>> Login([FromBody] LocalAuthUserLoginCommand command)
        {
            LogUtil.Info("用户创建");
            var result = new Result<LocalAuthUserDto>();
            try
            {
                var localAuthUserDto = await _mediator.Send(command);
                // 如果登录成功，返回一个新的 jwt token
                if (localAuthUserDto != null)
                {
                    var token = await _jwtToken.GetJwtToken();
                    localAuthUserDto.Token = token;
                    localAuthUserDto.Password = ""; // 置空，防止传输过程中泄露到前台
                    result.Data = localAuthUserDto;
                }
                else
                {
                    result.Code = 404;
                    result.Message = "用户名或密码不正确";
                }
            }
            catch (Exception ex)
            {
                result.Code = -1;
                result.Message = $"程序发生异常：{ex.Message}";
            }
            return result;
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("getUserProfile")]
        public async Task<Result<UserProfileDto>> GetUserProfile([FromBody] UserProfileQuery query)
        {
            LogUtil.Info("用户创建");
            var result = new Result<UserProfileDto>();
            try
            {
                var userProfileDto = await _mediator.Send(query);
                // 返回用户信息
                if (userProfileDto != null)
                {
                    result.Data = userProfileDto;
                }
                else
                {
                    result.Code = 404;
                    result.Message = "未找到用户信息";
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
