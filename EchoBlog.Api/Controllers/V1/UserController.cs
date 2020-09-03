using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EchoBlog.Api.Applications.Commands.UserCommands;
using EchoBlog.Api.Applications.Queries.UserQueries;
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
    /// <summary>
    /// 用户接口
    /// </summary>
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
            var result = new Result<LocalAuthUserDto>();
            try
            {
                var localAuthUserDto = await _mediator.Send(command);
                result.Data = localAuthUserDto;
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = $"程序发生异常：{ex.Message}";
            }
            return result;
        }


        /// <summary>
        /// 用户登录
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
                result.Code = 500;
                result.Message = $"程序发生异常：{ex.Message}";
            }
            return result;
        }


        /// <summary>
        /// 获取用户资料
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
                result.Data = userProfileDto;
                /*if (userProfileDto != null)
                {
                    result.Data = userProfileDto;
                }
                else
                {
                    result.Code = 404;
                    result.Message = "未找到用户信息";
                }*/
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = $"程序发生异常：{ex.Message}";
            }
            return result;
        }
    }
}
