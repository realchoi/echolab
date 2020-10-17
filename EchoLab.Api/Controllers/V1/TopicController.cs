using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoLab.Api.Applications.Queries.TopicQueries;
using EchoLab.Api.Dtos;
using EchoLab.Core;
using EchoLab.Infrastructures.Core.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EchoLab.Api.Controllers.V1
{
    /// <summary>
    /// 话题接口
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        readonly IMediator _mediator;

        public TopicController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        // 基于角色的授权：角色为 User 的用户才可以访问
        //[Authorize(Roles = "User")]
        [HttpGet("list")]
        public async Task<Result<IEnumerable<TopicDto>>> GetTopics([FromQuery] TopicListQuery query)
        {
            var result = new Result<IEnumerable<TopicDto>>();
            try
            {
                var topicDtoList = await _mediator.Send(query);
                result.Data = topicDtoList;
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = $"程序发生异常：{ex.Message}";
            }

            return result;
        }


        /// <summary>
        /// 根据 id 获取话题详情
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        //[Authorize(Roles = "LoginUser")]
        [HttpGet("single")]
        public async Task<Result<TopicDto>> GetTopicById([FromQuery] TopicSingleQuery query)
        {
            var result = new Result<TopicDto>();
            try
            {
                var topicDto = await _mediator.Send(query);
                result.Data = topicDto;
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