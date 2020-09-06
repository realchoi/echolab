﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoBlog.Api.Applications.Queries.TopicQueries;
using EchoBlog.Api.Dtos;
using EchoBlog.Core;
using EchoBlog.Infrastructures.Core.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EchoBlog.Api.Controllers.V1
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
        [Authorize(Roles = "User")]
        [HttpPost("getListByCategoryId")]
        public async Task<Result<IEnumerable<TopicDto>>> GetListByCategoryId([FromBody] TopicQuery topicQuery)
        {
            LogUtil.Info("Get 方法执行");
            var result = new Result<IEnumerable<TopicDto>>();
            try
            {
                var topicDto = await _mediator.Send(topicQuery);
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